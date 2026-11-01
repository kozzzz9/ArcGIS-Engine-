using System;
using System.Windows.Forms;

namespace MyMap
{
    /// <summary>
    /// 文字标注输入对话框。
    /// 输入标注文字与字号，确定后由主窗体在单击位置添加红色文字注记。
    /// </summary>
    public partial class TextAnnotationDialog : Form
    {
        #region 公共属性

        /// <summary>用户输入的标注文字。</summary>
        public string AnnotationText { get; private set; }

        /// <summary>用户选择的文字大小。</summary>
        public double AnnotationSize { get { return (double)numSize.Value; } }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建文字标注输入对话框。
        /// </summary>
        public TextAnnotationDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 确定：校验文字并关闭对话框。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            string text = txtText.Text.Trim();
            if (text.Length == 0)
            {
                MessageBox.Show("请输入标注文字！");
                return;
            }

            AnnotationText = text;
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
