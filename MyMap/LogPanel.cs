using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMap
{
    /// <summary>
    /// 消息日志停靠面板（ArcGIS Pro 的 History/通知视图）：
    /// 以带时间戳的滚动列表记录全站关键操作（加载数据、渲染、查询、导出等），
    /// 由主窗体的 Log 方法统一写入。
    /// </summary>
    public partial class LogPanel : DockContent
    {
        /// <summary>
        /// 创建消息日志面板。
        /// </summary>
        public LogPanel()
        {
            InitializeComponent();
            AppendLog("系统就绪。");
        }

        /// <summary>
        /// 追加一条带时间戳的日志并滚动到底部。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public void AppendLog(string message)
        {
            txtLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] "
                + message + Environment.NewLine);
        }

        /// <summary>
        /// 清空日志。
        /// </summary>
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }
    }
}
