using System;
using System.Windows.Forms;

namespace MyMap
{
    /// <summary>
    /// K-Means 聚类参数对话框：设置簇数量 K 与最大迭代次数。
    /// </summary>
    public partial class KMeansParamsDialog : Form
    {
        #region 公共属性

        /// <summary>组装完成的 K-Means 参数。</summary>
        public KMeansParameters Parameters { get; private set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 创建 K-Means 参数对话框。
        /// </summary>
        public KMeansParamsDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region 事件处理

        /// <summary>
        /// 确定：组装参数并关闭对话框。
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            KMeansParameters para = new KMeansParameters();
            para.AlgorithmName = ClusteringAlgorithmFactory.KMeans;
            para.K = (int)numK.Value;
            para.MaxIterations = (int)numIterations.Value;
            para.Runs = (int)numRuns.Value;
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
