using System;
using System.Windows.Forms;

namespace MyMap
{
    /// <summary>
    /// 图层透明度设置对话框。
    /// 输入 0-100 的透明度值（0 不透明，100 全透明），确定后由主窗体应用到栅格图层。
    /// </summary>
    public partial class TransparencyDialog : Form
    {
        #region 公共属性

        /// <summary>用户输入的透明度（0-100）。</summary>
        public int Transparency { get; private set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建图层透明度设置对话框。
        /// </summary>
        /// <param name="currentTransparency">图层当前透明度，用于初始化默认值。</param>
        public TransparencyDialog(int currentTransparency)
        {
            InitializeComponent();

            if (currentTransparency >= 0 && currentTransparency <= 100)
            {
                numTransparency.Value = currentTransparency;
            }
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 确定：记录透明度并关闭对话框。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            Transparency = (int)numTransparency.Value;
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
