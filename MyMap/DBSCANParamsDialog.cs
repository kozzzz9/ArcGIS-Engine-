using System;
using System.Windows.Forms;

namespace MyMap
{
    /// <summary>
    /// DBSCAN 聚类参数对话框：设置邻域半径 Eps（地图单位）与核心点最小点数 MinPts。
    /// </summary>
    public partial class DBSCANParamsDialog : Form
    {
        #region 公共属性

        /// <summary>组装完成的 DBSCAN 参数。</summary>
        public DBSCANParameters Parameters { get; private set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建 DBSCAN 参数对话框。
        /// </summary>
        public DBSCANParamsDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 确定：校验参数并组装关闭对话框。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DBSCANParameters para = new DBSCANParameters();
            para.AlgorithmName = ClusteringAlgorithmFactory.DBSCAN;
            para.Eps = (double)numEps.Value;
            para.MinPts = (int)numMinPts.Value;
            Parameters = para;

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
