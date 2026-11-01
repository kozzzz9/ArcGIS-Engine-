using System;
using System.Windows.Forms;

namespace MyMap
{
    /// <summary>
    /// 显示比例设置对话框。
    /// 输入比例尺分母（如 500 表示 1:500），确定后由主窗体缩放到该比例。
    /// </summary>
    public partial class ScaleDialog : Form
    {
        #region 公共属性

        /// <summary>用户输入的比例尺分母。</summary>
        public double ScaleValue { get { return (double)numScale.Value; } }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建显示比例设置对话框。
        /// </summary>
        /// <param name="currentScale">当前地图比例尺分母，用于初始化默认值。</param>
        public ScaleDialog(double currentScale)
        {
            InitializeComponent();

            if (currentScale >= (double)numScale.Minimum && currentScale <= (double)numScale.Maximum)
            {
                numScale.Value = (decimal)currentScale;
            }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 确定：记录比例尺并关闭对话框。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
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
