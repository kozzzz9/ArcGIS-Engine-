using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using esriGeometryType = ESRI.ArcGIS.Geometry.esriGeometryType;

namespace MyMap
{
    /// <summary>
    /// 唯一值渲染设置对话框。
    /// 负责选择唯一值字段、选择色带类型与颜色数量，并生成每个唯一值对应的符号。
    /// </summary>
    public partial class UniqueValueRenderDialog : Form
    {
        #region 私有字段

        private readonly IFeatureClass _featureClass;
        private readonly esriGeometryType _geometryType;
        private readonly ISymbol _symbolTemplate;

        /// <summary>当前字段的全部唯一值。</summary>
        private List<string> _values = new List<string>();

        /// <summary>唯一值与符号的对应关系。</summary>
        private Dictionary<string, ISymbol> _valueSymbols = new Dictionary<string, ISymbol>();

        /// <summary>当前色带生成的颜色。</summary>
        private List<IColor> _colors = new List<IColor>();

        #endregion

        #region 公共属性

        /// <summary>用户选择的唯一值字段名。</summary>
        public string SelectedField { get; private set; }

        /// <summary>所选字段是否为字符串类型。</summary>
        public bool SelectedFieldIsString { get; private set; }

        /// <summary>唯一值与符号的对应关系。</summary>
        public IDictionary<string, ISymbol> ValueSymbols { get { return _valueSymbols; } }

        /// <summary>未被唯一值覆盖要素使用的默认符号。</summary>
        public ISymbol DefaultSymbol { get; private set; }

        /// <summary>是否使用默认符号渲染其它值。</summary>
        public bool UseDefaultSymbol { get; private set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建唯一值渲染设置对话框。
        /// </summary>
        /// <param name="featureClass">图层对应的要素类，用于读取字段与唯一值。</param>
        /// <param name="geometryType">图层几何类型，用于生成默认符号模板。</param>
        /// <param name="symbolTemplate">符号模板；为 null 时按几何类型自动创建。</param>
        public UniqueValueRenderDialog(IFeatureClass featureClass, esriGeometryType geometryType, ISymbol symbolTemplate)
        {
            _featureClass = featureClass;
            _geometryType = geometryType;
            _symbolTemplate = symbolTemplate ?? UniqueValueRenderHelper.CreateDefaultTemplate(geometryType);

            InitializeComponent();
            LoadFields();
            RefreshAll();
        }

        #endregion

        #region 字段与唯一值

        /// <summary>
        /// 将要素类中可用于唯一值渲染的字段填充到下拉框。
        /// </summary>
        private void LoadFields()
        {
            cboField.Items.Clear();
            if (_featureClass == null)
            {
                return;
            }

            IFields fields = _featureClass.Fields;
            if (fields == null)
            {
                return;
            }

            for (int i = 0; i < fields.FieldCount; i++)
            {
                IField field = fields.get_Field(i);
                if (field == null)
                {
                    continue;
                }

                // 跳过几何字段与 OID 字段
                if (field.Type == esriFieldType.esriFieldTypeGeometry ||
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
        /// 读取当前字段的所有唯一值。
        /// </summary>
        private void LoadUniqueValues()
        {
            _values = new List<string>();
            lstValues.Items.Clear();

            if (_featureClass == null || cboField.SelectedItem == null)
            {
                return;
            }

            string fieldName = cboField.SelectedItem.ToString();
            int fieldIndex = _featureClass.Fields.FindField(fieldName);
            if (fieldIndex < 0)
            {
                return;
            }

            HashSet<string> distinct = new HashSet<string>(StringComparer.Ordinal);
            IQueryFilter filter = new QueryFilter();
            filter.SubFields = fieldName;
            filter.WhereClause = string.Empty;

            IFeatureCursor cursor = _featureClass.Search(filter, false);
            try
            {
                IFeature feature = cursor.NextFeature();
                while (feature != null)
                {
                    object value = feature.get_Value(fieldIndex);
                    string text = UniqueValueRenderHelper.FormatValue(value);
                    if (text.Length > 0)
                    {
                        distinct.Add(text);
                    }
                    feature = cursor.NextFeature();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取唯一值失败：" + ex.Message);
            }
            finally
            {
                UniqueValueRenderHelper.ReleaseComObject(cursor);
            }

            List<string> sorted = new List<string>(distinct);
            sorted.Sort(StringComparer.Ordinal);
            _values = sorted;

            foreach (string value in _values)
            {
                lstValues.Items.Add(value);
            }

            // 唯一值数量变化后同步颜色数量
            ApplyAutoColorCount();
        }

        /// <summary>
        /// 当勾选“颜色数量与唯一值数量一致”时，把颜色数量同步为唯一值数量。
        /// </summary>
        private void ApplyAutoColorCount()
        {
            if (chkAutoColorCount == null || numColorCount == null)
            {
                return;
            }

            numColorCount.Enabled = !chkAutoColorCount.Checked;

            if (!chkAutoColorCount.Checked || _values.Count == 0)
            {
                return;
            }

            int count = _values.Count;
            if (count < (int)numColorCount.Minimum)
            {
                count = (int)numColorCount.Minimum;
            }
            if (count > (int)numColorCount.Maximum)
            {
                count = (int)numColorCount.Maximum;
            }

            if ((int)numColorCount.Value != count)
            {
                numColorCount.Value = count;
            }
        }

        #endregion

        #region 色带与符号

        /// <summary>
        /// 依据当前设置重新生成色带颜色并刷新预览与符号。
        /// </summary>
        private void RefreshAll()
        {
            _colors = UniqueValueRenderHelper.CreateColors(cboRamp.SelectedIndex, (int)numColorCount.Value);
            picRamp.Invalidate();
            RebuildSymbols();
        }

        /// <summary>
        /// 按色带颜色为每个唯一值重新生成符号。
        /// </summary>
        private void RebuildSymbols()
        {
            _valueSymbols = new Dictionary<string, ISymbol>(StringComparer.Ordinal);

            if (_values.Count == 0 || _colors.Count == 0)
            {
                return;
            }

            for (int i = 0; i < _values.Count; i++)
            {
                IColor color = _colors[i % _colors.Count];
                ISymbol symbol = UniqueValueRenderHelper.CreateSymbol(_symbolTemplate, _geometryType, color);
                _valueSymbols[_values[i]] = symbol;
            }
        }

        /// <summary>
        /// 绘制色带预览。
        /// </summary>
        private void picRamp_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (_colors.Count == 0)
            {
                return;
            }

            int width = picRamp.Width;
            int height = picRamp.Height;
            float step = (float)width / _colors.Count;

            for (int i = 0; i < _colors.Count; i++)
            {
                Color color = UniqueValueRenderHelper.ToWinColor(_colors[i]);
                using (SolidBrush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, i * step, 0, step + 1, height);
                }
            }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 唯一值字段变化时重新读取唯一值。
        /// </summary>
        private void cboField_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUniqueValues();
        }

        /// <summary>
        /// 色带类型或颜色数量变化时重新生成色带与符号。
        /// </summary>
        private void colorSettingChanged(object sender, EventArgs e)
        {
            RefreshAll();
        }

        /// <summary>
        /// 勾选状态变化时同步颜色数量。
        /// </summary>
        private void chkAutoColorCount_CheckedChanged(object sender, EventArgs e)
        {
            ApplyAutoColorCount();
        }

        /// <summary>
        /// 确定：收集用户选择的结果并关闭对话框。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cboField.SelectedItem == null)
            {
                MessageBox.Show("请选择唯一值字段！");
                return;
            }

            if (_values.Count == 0)
            {
                MessageBox.Show("该字段没有可用的唯一值！");
                return;
            }

            SelectedField = cboField.SelectedItem.ToString();
            SelectedFieldIsString = IsStringField(SelectedField);
            UseDefaultSymbol = chkUseDefault.Checked;

            // 默认符号使用中性灰色，与色带颜色区分开
            DefaultSymbol = UniqueValueRenderHelper.CreateSymbol(
                _symbolTemplate, _geometryType, UniqueValueRenderHelper.CreateColor(200, 200, 200));

            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// 判断指定字段是否为字符串类型。
        /// </summary>
        private bool IsStringField(string fieldName)
        {
            if (_featureClass == null || string.IsNullOrEmpty(fieldName))
            {
                return true;
            }

            int fieldIndex = _featureClass.Fields.FindField(fieldName);
            if (fieldIndex < 0)
            {
                return true;
            }

            IField field = _featureClass.Fields.get_Field(fieldIndex);
            if (field == null)
            {
                return true;
            }

            return field.Type == esriFieldType.esriFieldTypeString;
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
