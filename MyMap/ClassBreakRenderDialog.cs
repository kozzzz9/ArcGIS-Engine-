using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Geodatabase;

namespace MyMap
{
    /// <summary>
    /// 分级渲染设置对话框。
    /// 选择数值字段、分级方法（等间距/自然间断点/分位数）、分级数量与色带类型，
    /// 确定后由主窗体按分级结果生成分级渲染器。
    /// </summary>
    public partial class ClassBreakRenderDialog : Form
    {
        #region 私有字段

        /// <summary>待渲染图层对应的要素类。</summary>
        private readonly IFeatureClass _featureClass;

        #endregion

        #region 公共属性

        /// <summary>用户选择的分级字段名。</summary>
        public string SelectedField { get; private set; }

        /// <summary>分级方法索引：0 等间距、1 自然间断点、2 分位数。</summary>
        public int MethodIndex { get { return cboMethod.SelectedIndex; } }

        /// <summary>分级数量。</summary>
        public int ClassCount { get { return (int)numClassCount.Value; } }

        /// <summary>色带类型索引：0 随机色带、1 渐变色带、2 单色渐变。</summary>
        public int RampIndex { get { return cboRamp.SelectedIndex; } }

        /// <summary>是否排除空值与 0 值。</summary>
        public bool ExcludeZero { get { return chkExcludeZero.Checked; } }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建分级渲染设置对话框。
        /// </summary>
        /// <param name="featureClass">待渲染图层对应的要素类，用于读取数值字段。</param>
        public ClassBreakRenderDialog(IFeatureClass featureClass)
        {
            _featureClass = featureClass;

            InitializeComponent();
            LoadFields();
        }

        #endregion

        #region 数据加载

        /// <summary>
        /// 将要素类中的数值字段填充到下拉框。
        /// </summary>
        private void LoadFields()
        {
            cboField.Items.Clear();
            if (_featureClass == null)
            {
                return;
            }

            IFields fields = _featureClass.Fields;
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

        #region 确定与取消

        /// <summary>
        /// 确定：校验输入并关闭对话框。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboField.SelectedIndex < 0)
            {
                MessageBox.Show("该图层没有可用于分级的数值字段！");
                return;
            }

            SelectedField = cboField.SelectedItem.ToString();
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
