using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace MyMap
{
    /// <summary>
    /// 查询字段选择对话框（实习十四）。
    /// 列出图层中可用于查询的属性字段，确定后由主窗体按该字段执行空间查询。
    /// </summary>
    public partial class FieldSelectDialog : Form
    {
        #region 私有字段

        /// <summary>待查询的矢量图层。</summary>
        private readonly IFeatureLayer _featureLayer;

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建查询字段选择对话框。
        /// </summary>
        /// <param name="featureLayer">待查询的矢量图层。</param>
        public FieldSelectDialog(IFeatureLayer featureLayer)
        {
            _featureLayer = featureLayer;
            InitializeComponent();
            LoadFields();
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 返回用户选择的查询字段名（手册要求的命名）。
        /// </summary>
        public string selectFieldName()
        {
            return cboField.SelectedIndex >= 0 ? cboField.SelectedItem.ToString() : null;
        }

        #endregion

        #region 数据加载

        /// <summary>
        /// 将图层中可用于查询的属性字段填充到下拉框（跳过几何与 OID 字段）。
        /// </summary>
        private void LoadFields()
        {
            cboField.Items.Clear();
            if (_featureLayer == null || _featureLayer.FeatureClass == null)
            {
                return;
            }

            IFields fields = _featureLayer.FeatureClass.Fields;
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

        #endregion

        #region 事件处理

        /// <summary>
        /// 确定：关闭对话框并返回所选字段。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboField.SelectedIndex < 0)
            {
                MessageBox.Show("该图层没有可用于查询的属性字段！");
                return;
            }

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
