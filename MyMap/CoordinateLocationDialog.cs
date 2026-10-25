using System;
using System.Windows.Forms;

namespace MyMap
{
    /// <summary>
    /// 坐标定位对话框。
    /// 输入当前地图坐标系下的 X、Y 坐标，确定后由主窗体定位到该位置并做标记。
    /// </summary>
    public partial class CoordinateLocationDialog : Form
    {
        #region 公共属性

        /// <summary>用户输入的 X 坐标。</summary>
        public double LocationX { get { return (double)numX.Value; } }

        /// <summary>用户输入的 Y 坐标。</summary>
        public double LocationY { get { return (double)numY.Value; } }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建坐标定位对话框。
        /// </summary>
        public CoordinateLocationDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 定位：关闭对话框并返回坐标。
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
