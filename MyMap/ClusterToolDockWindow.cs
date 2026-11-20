using System;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMap
{
    /// <summary>
    /// 聚类分析停靠面板（DockPanelSuite）：下拉框选择算法 → 参数区联动 → 执行聚类 →
    /// 带时间戳的滚动日志输出，可拖拽停靠、浮动、自动隐藏。
    /// </summary>
    public partial class ClusterToolDockWindow : DockContent
    {
        /// <summary>点击"执行聚类"时触发：参数为算法注册名与组装好的参数对象。</summary>
        public event Action<string, AlgorithmParameters> ExecuteRequested;

        /// <summary>
        /// 创建聚类分析停靠面板。
        /// </summary>
        public ClusterToolDockWindow()
        {
            InitializeComponent();
            cboAlgorithm.SelectedIndexChanged += cboAlgorithm_SelectedIndexChanged;
            cboAlgorithm.Items.AddRange(
                ClusteringAlgorithmFactory.GetAlgorithmNames().Cast<object>().ToArray());
            if (cboAlgorithm.Items.Count > 0)
            {
                cboAlgorithm.SelectedIndex = 0;
            }
            AppendLog("系统就绪：请在图层树选中点图层，选择算法并执行聚类。");
        }

        /// <summary>
        /// 追加一条带时间戳的日志。
        /// </summary>
        /// <param name="message">日志内容。</param>
        public void AppendLog(string message)
        {
            txtLog.AppendText("[" + DateTime.Now.ToString("HH:mm:ss") + "] "
                + message + Environment.NewLine);
        }

        /// <summary>
        /// 按当前选中的算法切换可见的参数分组框。
        /// </summary>
        private void cboAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateParamPanels();
        }

        /// <summary>
        /// 执行聚类：组装当前算法的参数并触发 ExecuteRequested 事件。
        /// </summary>
        private void btnExecute_Click(object sender, EventArgs e)
        {
            string name = Convert.ToString(cboAlgorithm.SelectedItem);
            AlgorithmParameters para;

            if (name == ClusteringAlgorithmFactory.KMeans)
            {
                KMeansParameters p = new KMeansParameters();
                p.AlgorithmName = name;
                p.K = (int)numK.Value;
                p.MaxIterations = (int)numIterations.Value;
                p.Runs = (int)numRuns.Value;
                para = p;
            }
            else if (name == ClusteringAlgorithmFactory.DBSCAN)
            {
                DBSCANParameters p = new DBSCANParameters();
                p.AlgorithmName = name;
                p.Eps = (double)numEps.Value;
                p.MinPts = (int)numMinPts.Value;
                para = p;
            }
            else if (name == ClusteringAlgorithmFactory.Hierarchical)
            {
                HierarchicalParameters p = new HierarchicalParameters();
                p.AlgorithmName = name;
                p.ClusterCount = (int)numTargetClusters.Value;
                para = p;
            }
            else
            {
                AppendLog("未支持的聚类算法：" + name);
                return;
            }

            if (ExecuteRequested != null)
            {
                ExecuteRequested(name, para);
            }
        }

        /// <summary>
        /// 只显示当前算法对应的参数分组框。
        /// </summary>
        private void UpdateParamPanels()
        {
            string name = Convert.ToString(cboAlgorithm.SelectedItem);
            gbKMeans.Visible = name == ClusteringAlgorithmFactory.KMeans;
            gbDBSCAN.Visible = name == ClusteringAlgorithmFactory.DBSCAN;
            gbHierarchical.Visible = name == ClusteringAlgorithmFactory.Hierarchical;
        }
    }
}
