using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace MyMap
{
    /// <summary>
    /// 要素属性表窗体：以表格形式展示指定矢量图层的全部属性。
    /// 支持编辑模式修改属性值、删除选中要素、定位选中要素与导出 CSV。
    /// </summary>
    public partial class FeatureAttributeTable : Form
    {
        /// <summary>待展示属性的矢量图层。</summary>
        private readonly IFeatureLayer _featureLayer;

        /// <summary>主窗体的活动视图，用于定位要素；可为 null。</summary>
        private readonly IActiveView _activeView;

        /// <summary>各行对应的要素 OID（与表格行顺序一致）。</summary>
        private readonly List<int> _oids = new List<int>();

        /// <summary>要素发生变化（修改属性或删除）时触发，由主窗体刷新地图。</summary>
        public event EventHandler FeaturesChanged;

        /// <summary>
        /// 创建要素属性表窗体。
        /// </summary>
        /// <param name="featureLayer">待展示属性的矢量图层。</param>
        /// <param name="activeView">主窗体的活动视图，用于定位要素；可为 null。</param>
        public FeatureAttributeTable(IFeatureLayer featureLayer, IActiveView activeView)
        {
            _featureLayer = featureLayer;
            _activeView = activeView;
            InitializeComponent();
        }

        /// <summary>
        /// 窗体加载时读取图层字段与要素，填充属性表格。
        /// </summary>
        private void FeatureAttributeTable_Load(object sender, EventArgs e)
        {
            if (_featureLayer == null)
            {
                return;
            }

            // 窗体标题带图层名，便于区分多个属性表
            Text = "属性表 - " + _featureLayer.Name;
            LoadTable();
        }

        /// <summary>
        /// 读取图层字段与要素填充表格，OID 列在首列。
        /// </summary>
        private void LoadTable()
        {
            if (_featureLayer == null || _featureLayer.FeatureClass == null)
            {
                return;
            }

            IFeatureClass featureClass = _featureLayer.FeatureClass;
            IFields fields = featureClass.Fields;

            DataTable table = new DataTable();
            table.Columns.Add("OID", typeof(string));
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                DataColumn column = new DataColumn(field.Name);
                column.DataType = typeof(string);
                table.Columns.Add(column);
            }

            _oids.Clear();
            IFeatureCursor featureCursor = featureClass.Search(null, false);
            IFeature feature = featureCursor.NextFeature();
            while (feature != null)
            {
                DataRow row = table.NewRow();
                row[0] = feature.OID.ToString();
                _oids.Add(feature.OID);
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if (field.Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        // 几何字段不在表格中展示
                        row[i + 1] = string.Empty;
                    }
                    else
                    {
                        // 空值统一转换为空字符串，避免直接调用 ToString 抛出异常
                        row[i + 1] = UniqueValueRenderHelper.FormatValue(feature.get_Value(i));
                    }
                }
                table.Rows.Add(row);
                feature = featureCursor.NextFeature();
            }

            dataGridView.DataSource = table;
            dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            // OID 列与几何列永远只读
            dataGridView.Columns[0].ReadOnly = true;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                if (fields.get_Field(i).Type == esriFieldType.esriFieldTypeGeometry)
                {
                    dataGridView.Columns[i + 1].ReadOnly = true;
                }
            }

            // 编辑模式还原为表格当前状态
            dataGridView.ReadOnly = !chkEditMode.Checked;
        }

        /// <summary>
        /// 获取指定行对应的要素 OID；行号无效时返回 -1。
        /// </summary>
        private int GetOidByRowIndex(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= _oids.Count)
            {
                return -1;
            }
            return _oids[rowIndex];
        }

        /// <summary>
        /// 编辑模式切换：控制表格是否可编辑。
        /// </summary>
        private void chkEditMode_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView.ReadOnly = !chkEditMode.Checked;
        }

        /// <summary>
        /// 单元格编辑结束：把修改写回要素并保存。
        /// </summary>
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!chkEditMode.Checked || e.RowIndex < 0 || e.ColumnIndex <= 0)
            {
                return;
            }

            IFeatureClass featureClass = _featureLayer.FeatureClass;
            string fieldName = dataGridView.Columns[e.ColumnIndex].Name;
            int fieldIndex = featureClass.Fields.FindField(fieldName);
            if (fieldIndex < 0)
            {
                return;
            }

            IField field = featureClass.Fields.get_Field(fieldIndex);
            if (field.Type == esriFieldType.esriFieldTypeGeometry ||
                field.Type == esriFieldType.esriFieldTypeOID)
            {
                return;
            }

            object cellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            object converted;
            if (!TryConvertValue(field, cellValue, out converted))
            {
                MessageBox.Show(
                    string.Format("“{0}”不是有效的 {1} 值，表格已还原。", fieldName, GetFieldTypeName(field.Type)),
                    "编辑失败",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                LoadTable();
                return;
            }

            try
            {
                IFeature feature = featureClass.GetFeature(GetOidByRowIndex(e.RowIndex));
                feature.set_Value(fieldIndex, converted);
                feature.Store();
                OnFeaturesChanged();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存修改失败：" + ex.Message);
                LoadTable();
            }
        }

        /// <summary>
        /// 按字段类型把界面文本转换为要素属性值；转换失败返回 false。
        /// </summary>
        private static bool TryConvertValue(IField field, object cellValue, out object result)
        {
            string text = cellValue == null ? string.Empty : cellValue.ToString().Trim();
            try
            {
                switch (field.Type)
                {
                    case esriFieldType.esriFieldTypeString:
                        result = text;
                        return true;
                    case esriFieldType.esriFieldTypeInteger:
                    case esriFieldType.esriFieldTypeSmallInteger:
                        if (text.Length == 0)
                        {
                            result = DBNull.Value;
                            return true;
                        }
                        result = int.Parse(text, CultureInfo.InvariantCulture);
                        return true;
                    case esriFieldType.esriFieldTypeSingle:
                        if (text.Length == 0)
                        {
                            result = DBNull.Value;
                            return true;
                        }
                        result = float.Parse(text, CultureInfo.InvariantCulture);
                        return true;
                    case esriFieldType.esriFieldTypeDouble:
                        if (text.Length == 0)
                        {
                            result = DBNull.Value;
                            return true;
                        }
                        result = double.Parse(text, CultureInfo.InvariantCulture);
                        return true;
                    case esriFieldType.esriFieldTypeDate:
                        if (text.Length == 0)
                        {
                            result = DBNull.Value;
                            return true;
                        }
                        result = DateTime.Parse(text, CultureInfo.InvariantCulture);
                        return true;
                    default:
                        result = null;
                        return false;
                }
            }
            catch
            {
                result = null;
                return false;
            }
        }

        /// <summary>
        /// 获取字段类型的中文名称，用于错误提示。
        /// </summary>
        private static string GetFieldTypeName(esriFieldType fieldType)
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeString: return "文本";
                case esriFieldType.esriFieldTypeInteger:
                case esriFieldType.esriFieldTypeSmallInteger: return "整数";
                case esriFieldType.esriFieldTypeSingle:
                case esriFieldType.esriFieldTypeDouble: return "数值";
                case esriFieldType.esriFieldTypeDate: return "日期";
                default: return "该类型";
            }
        }

        /// <summary>
        /// 定位选中要素：把主地图缩放到选中行要素的范围。
        /// </summary>
        private void btnZoomToFeature_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先点击行首选择一行！");
                return;
            }

            if (_activeView == null)
            {
                return;
            }

            int oid = GetOidByRowIndex(dataGridView.SelectedRows[0].Index);
            IFeature feature = _featureLayer.FeatureClass.GetFeature(oid);
            IGeometry geometry = feature.Shape;
            if (geometry == null || geometry.Envelope == null || geometry.Envelope.IsEmpty)
            {
                MessageBox.Show("该要素的范围为空，无法定位！");
                return;
            }

            IEnvelope extent = geometry.Envelope;
            extent.Expand(1.5, 1.5, true);
            _activeView.Extent = extent;
            _activeView.Refresh();
        }

        /// <summary>
        /// 导出 CSV：把当前属性表保存为 CSV 文件。
        /// </summary>
        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "导出属性表";
                dialog.Filter = "CSV 文件(*.csv)|*.csv";
                dialog.OverwritePrompt = true;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                StringBuilder builder = new StringBuilder();

                // 表头
                List<string> cells = new List<string>();
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    cells.Add(EscapeCsv(column.HeaderText));
                }
                builder.AppendLine(string.Join(",", cells.ToArray()));

                // 数据行
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    cells.Clear();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cells.Add(EscapeCsv(cell.Value == null ? string.Empty : cell.Value.ToString()));
                    }
                    builder.AppendLine(string.Join(",", cells.ToArray()));
                }

                try
                {
                    // UTF-8 带 BOM，保证 Excel 打开不乱码
                    File.WriteAllText(dialog.FileName, builder.ToString(), Encoding.UTF8);
                    MessageBox.Show("属性表导出成功：" + dialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("属性表导出失败：" + ex.Message);
                }
            }
        }

        /// <summary>
        /// 转义 CSV 单元格内容（含逗号或引号时用引号包裹）。
        /// </summary>
        private static string EscapeCsv(string value)
        {
            return "\"" + value.Replace("\"", "\"\"") + "\"";
        }

        /// <summary>
        /// 删除选中要素：从图层中删除选中行对应的要素并刷新表格。
        /// </summary>
        private void btnDeleteFeature_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先点击行首选择要删除的行！");
                return;
            }

            List<int> deleteOids = new List<int>();
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                int oid = GetOidByRowIndex(row.Index);
                if (oid >= 0)
                {
                    deleteOids.Add(oid);
                }
            }

            DialogResult dialogResult = MessageBox.Show(
                string.Format("确定要删除选中的 {0} 个要素吗？删除后不可恢复！", deleteOids.Count),
                "确认删除",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (dialogResult != DialogResult.Yes)
            {
                return;
            }

            try
            {
                IFeatureClass featureClass = _featureLayer.FeatureClass;
                foreach (int oid in deleteOids)
                {
                    IFeature feature = featureClass.GetFeature(oid);
                    feature.Delete();
                }
                OnFeaturesChanged();
                LoadTable();
                MessageBox.Show(string.Format("已删除 {0} 个要素。", deleteOids.Count));
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除要素失败：" + ex.Message);
                LoadTable();
            }
        }

        /// <summary>
        /// 触发要素变化事件，由主窗体刷新地图显示。
        /// </summary>
        private void OnFeaturesChanged()
        {
            if (FeaturesChanged != null)
            {
                FeaturesChanged(this, EventArgs.Empty);
            }
        }
    }
}
