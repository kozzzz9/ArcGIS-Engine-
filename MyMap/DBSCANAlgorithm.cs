using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyMap
{
    /// <summary>
    /// DBSCAN 聚类算法：基于密度发现任意形状的簇并识别噪声点。
    /// 预计算每个点的 Eps 邻域（O(n²) 教学实现，点数较大时可改用空间索引），
    /// 从核心点出发按密度可达扩展簇。
    /// </summary>
    public class DBSCANAlgorithm : IClusterAlgorithm
    {
        private readonly Stopwatch _sw = new Stopwatch();

        /// <summary>算法名称。</summary>
        public string Name
        {
            get { return "DBSCAN聚类"; }
        }

        /// <summary>
        /// 执行 DBSCAN 聚类。
        /// </summary>
        /// <param name="points">输入点集。</param>
        /// <param name="parameters">DBSCANParameters 参数。</param>
        /// <returns>聚类结果。</returns>
        public ClusterResult Run(List<ClusterPoint> points, AlgorithmParameters parameters)
        {
            DBSCANParameters para = parameters as DBSCANParameters;
            if (para == null)
                throw new ArgumentException("DBSCAN 算法需要 DBSCANParameters 类型的参数。");
            if (points == null || points.Count == 0)
                throw new ArgumentException("输入点集为空。");
            if (para.Eps <= 0)
                throw new ArgumentException("邻域半径 Eps 必须大于 0。");
            if (para.MinPts < 1)
                throw new ArgumentException("最小点数 MinPts 必须大于等于 1。");

            _sw.Reset();
            _sw.Start();

            int n = points.Count;
            const int UNVISITED = -2;
            const int NOISE = -1;
            int[] labels = new int[n];
            for (int i = 0; i < n; i++) labels[i] = UNVISITED;
            double eps2 = para.Eps * para.Eps;

            // 1. 预计算每个点的 Eps 邻域（教学实现采用 O(n^2)，点数较大时可改用空间索引）
            List<int>[] neighbors = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                List<int> nb = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    double dx = points[i].X - points[j].X;
                    double dy = points[i].Y - points[j].Y;
                    if (dx * dx + dy * dy <= eps2) nb.Add(j);
                }
                neighbors[i] = nb;
            }

            // 2. DBSCAN 主流程
            int clusterId = 0;
            for (int i = 0; i < n; i++)
            {
                if (labels[i] != UNVISITED) continue;

                // 非核心点，暂时标记为噪声
                if (neighbors[i].Count < para.MinPts)
                {
                    labels[i] = NOISE;
                    continue;
                }

                // 以点 i 为核心点，扩展新簇
                labels[i] = clusterId;
                Queue<int> seeds = new Queue<int>(neighbors[i]);
                while (seeds.Count > 0)
                {
                    int j = seeds.Dequeue();
                    if (labels[j] == NOISE) labels[j] = clusterId; // 噪声点是簇的边界点
                    if (labels[j] != UNVISITED) continue;
                    labels[j] = clusterId;

                    // j 也是核心点时，其邻域继续扩展（密度可达）
                    if (neighbors[j].Count >= para.MinPts)
                    {
                        foreach (int m in neighbors[j])
                        {
                            if (labels[m] == UNVISITED || labels[m] == NOISE)
                                seeds.Enqueue(m);
                        }
                    }
                }
                clusterId++;
            }

            // 3. 回写结果
            for (int i = 0; i < n; i++) points[i].ClusterId = labels[i];

            _sw.Stop();
            return ClusterResult.Build(Name,
                string.Format("Eps={0}, MinPts={1}", para.Eps, para.MinPts),
                points, _sw.ElapsedMilliseconds);
        }
    }
}
