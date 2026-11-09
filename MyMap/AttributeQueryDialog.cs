using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace MyMap
{
    /// <summary>
    /// 属性查询设置对话框。
    /// 选择待查询的矢量图层与字段，字段值列表支持双击快速构建查询条件，
    /// 也可直接输入标准 SQL 表达式（如 NAME = '北京'），确定后由主窗体按条件选择要素。
    /// </summary>
    public partial class AttributeQueryDialog : Form
    {
        #region 私有字段

        /// <summary>地图中全部可查询的矢量图层。</summary>
        private readonly List<IFeatureLayer> _featureLayers;

        #endregion

        #region 公共属性

        /// <summary>用户选择的待查询图层。</summary>
        public IFeatureLayer SelectedLayer { get; private set; }

        /// <summary>用户输入的 SQL 查询条件。</summary>
        public string WhereClause { get; private set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建属性查询设置对话框。
        /// </summary>
        /// <param name="featureLayers">地图中全部可查询的矢量图层。</param>
        public AttributeQueryDialog(List<IFeatureLayer> featureLayers)
        {
            _featureLayers = featureLayers;

            InitializeComponent();
            LoadLayers();
        }

        #endregion

        #region 数据加载

        /// <summary>
        /// 将可查询的矢量图层填充到图层下拉框。
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
        /// 将当前图层的全部属性字段填充到字段下拉框。
        /// </summary>
        private void LoadFields()
        {
            cboField.Items.Clear();
            lstValues.Items.Clear();

            IFeatureLayer featureLayer = CurrentLayer();
            if (featureLayer == null || featureLayer.FeatureClass == null)
            {
                return;
            }

            IFields fields = featureLayer.FeatureClass.Fields;
            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field == null || field.Type == esriFieldType.esriFieldTypeGeometry ||
                    field.Type == esriFieldType.esriFieldTypeOID)
                {
                    continue;
                }

                cboField.Items.Add(field.Name);
            }

            if (cboField.Items.Count > 0)
            {
                cboField.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 读取当前字段的全部唯一值填充到值列表。
        /// </summary>
        private void LoadFieldValues()
        {
            lstValues.Items.Clear();

            IFeatureLayer featureLayer = CurrentLayer();
            if (featureLayer == null || featureLayer.FeatureClass == null || cboField.SelectedIndex < 0)
            {
                return;
            }

            string fieldName = cboField.SelectedItem.ToString();
            int fieldIndex = featureLayer.FeatureClass.Fields.FindField(fieldName);
            if (fieldIndex < 0)
            {
                return;
            }

            HashSet<string> distinct = new HashSet<string>();
            IQueryFilter queryFilter = new QueryFilter();
            queryFilter.SubFields = fieldName;
            IFeatureCursor cursor = featureLayer.FeatureClass.Search(queryFilter, false);
            try
            {
                IFeature feature = cursor.NextFeature();
                while (feature != null)
                {
                    string text = UniqueValueRenderHelper.FormatValue(feature.get_Value(fieldIndex));
                    if (text.Length > 0)
                    {
                        distinct.Add(text);
                    }
                    feature = cursor.NextFeature();
                }
            }
            finally
            {
                UniqueValueRenderHelper.ReleaseComObject(cursor);
            }

            List<string> values = new List<string>(distinct);
            values.Sort(StringComparer.Ordinal);
            foreach (string value in values)
            {
                lstValues.Items.Add(value);
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
        /// 字段切换时刷新唯一值列表。
        /// </summary>
        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFieldValues();
        }

        /// <summary>
        /// 双击字段值：按字段类型生成等值条件填入查询框。
        /// </summary>
        private void lstValues_DoubleClick(object sender, EventArgs e)
        {
            if (cboField.SelectedIndex < 0 || lstValues.SelectedItem == null)
            {
                return;
            }

            IFeatureLayer featureLayer = CurrentLayer();
            if (featureLayer == null || featureLayer.FeatureClass == null)
            {
                return;
            }

            string fieldName = cboField.SelectedItem.ToString();
            string value = lstValues.SelectedItem.ToString();

            // 文本字段值需要引号，数值字段直接拼接
            int fieldIndex = featureLayer.FeatureClass.Fields.FindField(fieldName);
            bool isTextField = fieldIndex >= 0 &&
                featureLayer.FeatureClass.Fields.get_Field(fieldIndex).Type == esriFieldType.esriFieldTypeString;

            txtWhere.Text = isTextField
                ? string.Format("{0} = '{1}'", fieldName, value)
                : string.Format("{0} = {1}", fieldName, value);
        }

        /// <summary>
        /// 查询：校验输入并关闭对话框，由主窗体执行选择。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboLayer.SelectedIndex < 0)
            {
                MessageBox.Show("请选择查询图层！");
                return;
            }

            if (string.IsNullOrEmpty(txtWhere.Text.Trim()))
            {
                MessageBox.Show("请输入查询条件！");
                return;
            }

            int selectedIndex = cboLayer.SelectedIndex;
            if (_featureLayers != null && selectedIndex < _featureLayers.Count)
            {
                SelectedLayer = _featureLayers[selectedIndex];
            }

            if (SelectedLayer == null)
            {
                MessageBox.Show("未获取到查询图层！");
                return;
            }

            WhereClause = txtWhere.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 取消：直接关闭对话框。
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion
    }
}
