using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace MyMap
{
    /// <summary>
    /// 聚类结果停靠窗（DockPanelSuite）：以表格展示各簇的点数、占比与质心，
    /// 行颜色与地图上该簇的渲染颜色一致，可拖拽停靠、浮动、自动隐藏；
    /// 双击簇行触发 ClusterSelected 事件，由主窗体在地图上闪亮该簇要素。
    /// </summary>
    public partial class ClusterResultDockWindow : DockContent
    {
        /// <summary>聚类结果。</summary>
        private readonly ClusterResult _result;

        /// <summary>双击某簇行时触发，参数为簇编号（负值表示噪声）。</summary>
        public event Action<int> ClusterSelected;

        /// <summary>
        /// 创建聚类结果停靠窗。
        /// </summary>
        /// <param name="result">聚类结果。</param>
        public ClusterResultDockWindow(ClusterResult result)
        {
            InitializeComponent();
            _result = result;
            dgvClusters.CellDoubleClick += dgvClusters_CellDoubleClick;
            BindResult();
        }

        /// <summary>
        /// 双击行：解析簇编号并触发闪亮事件。
        /// </summary>
        private void dgvClusters_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || ClusterSelected == null)
            {
                return;
            }

            string text = Convert.ToString(dgvClusters.Rows[e.RowIndex].Cells[0].Value);
            int clusterId;
            if (text == "噪声")
            {
                clusterId = -1;
            }
            else if (!int.TryParse(text.Replace("簇 ", string.Empty), out clusterId))
            {
                return;
            }

            ClusterSelected(clusterId);
        }

        /// <summary>
        /// 把聚类结果绑定到摘要标签与簇统计表。
        /// </summary>
        private void BindResult()
        {
            Text = _result.AlgorithmName + " - 聚类结果";

            double sse = ClusterQuality.CalculateSse(_result.Points);
            double silhouette = ClusterQuality.CalculateSilhouette(_result.Points);

            lblSummary.Text = string.Format(
                "算法：{0}    参数：{1}\r\n总点数：{2}    簇数：{3}    噪声点：{4}    耗时：{5} ms\r\nSSE：{6}    轮廓系数：{7}\r\n（双击簇行可在地图上闪亮该簇）",
                _result.AlgorithmName,
                _result.ParameterInfo,
                _result.Points.Count,
                _result.ClusterCount,
                _result.NoiseCount,
                _result.ElapsedMilliseconds,
                double.IsNaN(sse) ? "无法计算" : sse.ToString("F4"),
                double.IsNaN(silhouette) ? "无法计算" : silhouette.ToString("F4"));

            DataTable table = new DataTable();
            table.Columns.Add("簇编号", typeof(string));
            table.Columns.Add("点数", typeof(int));
            table.Columns.Add("占比(%)", typeof(double));
            table.Columns.Add("质心X", typeof(double));
            table.Columns.Add("质心Y", typeof(double));

            Dictionary<int, List<ClusterPoint>> groups = new Dictionary<int, List<ClusterPoint>>();
            foreach (ClusterPoint point in _result.Points)
            {
                List<ClusterPoint> bucket;
                if (!groups.TryGetValue(point.ClusterId, out bucket))
                {
                    bucket = new List<ClusterPoint>();
                    groups[point.ClusterId] = bucket;
                }
                bucket.Add(point);
            }

            foreach (int clusterId in groups.Keys.OrderBy(id => id))
            {
                List<ClusterPoint> bucket = groups[clusterId];
                double ratio = bucket.Count * 100.0 / _result.Points.Count;
                double centerX = bucket.Average(p => p.X);
                double centerY = bucket.Average(p => p.Y);

                DataRow row = table.NewRow();
                row["簇编号"] = clusterId < 0 ? "噪声" : "簇 " + clusterId;
                row["点数"] = bucket.Count;
                row["占比(%)"] = Math.Round(ratio, 2);
                row["质心X"] = Math.Round(centerX, 4);
                row["质心Y"] = Math.Round(centerY, 4);
                table.Rows.Add(row);
            }

            dgvClusters.DataSource = table;

            // 行颜色与地图渲染一致：噪声灰色，其余按簇编号取调色板颜色
            foreach (DataGridViewRow row in dgvClusters.Rows)
            {
                bool isNoise = (string)row.Cells[0].Value == "噪声";
                Color color = isNoise ? Color.Gray
                    : ClusterColorPalette.GetColor(clusterIdsFromRow(row));
                row.DefaultCellStyle.BackColor = color;
                row.Cells[0].Style.ForeColor = isNoise ? Color.White : Color.Black;
            }
        }

        /// <summary>
        /// 从行文本"簇 12"解析簇编号。
        /// </summary>
        private static int clusterIdsFromRow(DataGridViewRow row)
        {
            string text = (string)row.Cells[0].Value;
            int id;
            if (int.TryParse(text.Replace("簇 ", string.Empty), out id))
            {
                return id;
            }
            return -1;
        }
    }
}
