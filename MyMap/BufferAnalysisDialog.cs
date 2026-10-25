using System;
using System.Windows.Forms;

namespace MyMap
{
    /// <summary>
    /// 缓冲区分析参数对话框。
    /// 输入缓冲距离（单位为当前地图单位），确定后由主窗体
    /// 对当前选中的要素生成缓冲区并以图形方式显示。
    /// </summary>
    public partial class BufferAnalysisDialog : Form
    {
        #region 公共属性

        /// <summary>用户输入的缓冲距离。</summary>
        public double BufferDistance { get { return (double)numDistance.Value; } }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建缓冲区分析参数对话框。
        /// </summary>
        public BufferAnalysisDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 确定：关闭对话框并返回缓冲距离。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (numDistance.Value <= 0)
            {
                MessageBox.Show("缓冲距离必须大于 0！");
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
