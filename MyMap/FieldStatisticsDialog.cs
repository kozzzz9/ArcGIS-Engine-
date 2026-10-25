using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;

namespace MyMap
{
    /// <summary>
    /// 字段统计对话框。
    /// 选择图层与数值字段，统计要素的数量、总和、平均值、
    /// 最大值、最小值与标准差，可仅统计当前选中的要素。
    /// </summary>
    public partial class FieldStatisticsDialog : Form
    {
        #region 私有字段

        /// <summary>地图中全部可统计的矢量图层。</summary>
        private readonly List<IFeatureLayer> _featureLayers;

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建字段统计对话框。
        /// </summary>
        /// <param name="featureLayers">地图中全部可统计的矢量图层。</param>
        public FieldStatisticsDialog(List<IFeatureLayer> featureLayers)
        {
            _featureLayers = featureLayers;

            InitializeComponent();
            LoadLayers();
        }

        #endregion

        #region 数据加载

        /// <summary>
        /// 将可统计的矢量图层填充到图层下拉框。
        /// </summary>
        private void LoadLayers()
        {
            cboLayer.Items.Clear();
            if (_featureLayers == null)
            {
                return;
            }

            foreach (IFeatureLayer featureLayer in _featureLayers)
            {
                if (featureLayer != null)
                {
                    cboLayer.Items.Add(featureLayer.Name);
                }
            }

            if (cboLayer.Items.Count > 0)
            {
                cboLayer.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 获取当前选择的图层。
        /// </summary>
        private IFeatureLayer CurrentLayer()
        {
            if (_featureLayers == null || cboLayer.SelectedIndex < 0)
            {
                return null;
            }

            if (cboLayer.SelectedIndex >= _featureLayers.Count)
            {
                return null;
            }

            return _featureLayers[cboLayer.SelectedIndex];
        }

        /// <summary>
        /// 将当前图层的数值字段填充到字段下拉框。
        /// </summary>
        private void LoadFields()
        {
            cboField.Items.Clear();

            IFeatureLayer featureLayer = CurrentLayer();
            if (featureLayer == null || featureLayer.FeatureClass == null)
            {
                return;
            }

            IFields fields = featureLayer.FeatureClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field == null)
                {
                    continue;
                }

                // 仅保留数值类型字段
                if (field.Type == esriFieldType.esriFieldTypeInteger ||
                    field.Type == esriFieldType.esriFieldTypeSmallInteger ||
                    field.Type == esriFieldType.esriFieldTypeSingle ||
                    field.Type == esriFieldType.esriFieldTypeDouble)
                {
                    cboField.Items.Add(field.Name);
                }
            }

            if (cboField.Items.Count > 0)
            {
                cboField.SelectedIndex = 0;
            }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 图层切换时刷新字段列表。
        /// </summary>
        private void cboLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFields();
        }

        /// <summary>
        /// 统计：按当前选择计算字段统计值并显示。
        /// </summary>
        private void btnStatistic_Click(object sender, EventArgs e)
        {
            IFeatureLayer featureLayer = CurrentLayer();
            if (featureLayer == null)
            {
                MessageBox.Show("请选择统计图层！");
                return;
            }

            if (cboField.SelectedIndex < 0)
            {
                MessageBox.Show("该图层没有可统计的数值字段！");
                return;
            }

            string fieldName = cboField.SelectedItem.ToString();

            try
            {
                ICursor cursor;
                bool onlySelected = chkOnlySelected.Checked;

                // 仅统计选中要素时走选择集游标，否则按字段过滤全表
                IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
                ISelectionSet selectionSet = featureSelection != null ? featureSelection.SelectionSet : null;
                if (onlySelected && selectionSet != null && selectionSet.Count > 0)
                {
                    selectionSet.Search(null, true, out cursor);
                }
                else
                {
                    IQueryFilter queryFilter = new QueryFilter();
                    queryFilter.SubFields = fieldName;
                    cursor = featureLayer.FeatureClass.Search(queryFilter, true) as ICursor;
                }

                IDataStatistics dataStatistics = new DataStatistics();
                dataStatistics.Cursor = cursor;
                dataStatistics.Field = fieldName;
                IStatisticsResults results = dataStatistics.Statistics;
                UniqueValueRenderHelper.ReleaseComObject(cursor);

                if (results == null || results.Count == 0)
                {
                    txtResult.Text = "没有可统计的数据。";
                    return;
                }

                txtResult.Text = string.Format(
                    "要素数量：{0}\r\n字段总和：{1:F4}\r\n平均值：{2:F4}\r\n最大值：{3:F4}\r\n最小值：{4:F4}\r\n标准差：{5:F4}",
                    results.Count, results.Sum, results.Mean, results.Maximum, results.Minimum, results.StandardDeviation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("统计失败：" + ex.Message);
            }
        }

        /// <summary>
        /// 关闭：直接关闭对话框。
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
