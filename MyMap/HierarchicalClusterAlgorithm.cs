using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyMap
{
    /// <summary>
    /// 凝聚式层次聚类（AGNES，单连接/最近邻距离）：
    /// 初始每个点自成一簇，每轮合并距离最近的两个簇（单连接 = 两簇间最小点对距离），
    /// 直至剩余簇数等于目标簇数。距离矩阵随合并滚动更新，复杂度 O(n³)、内存 O(n²)。
    /// </summary>
    public class HierarchicalClusterAlgorithm : IClusterAlgorithm
    {
        private readonly Stopwatch _sw = new Stopwatch();

        /// <summary>算法名称。</summary>
        public string Name
        {
            get { return "层次聚类"; }
        }

        /// <summary>
        /// 执行层次聚类。
        /// </summary>
        /// <param name="points">输入点集。</param>
        /// <param name="parameters">HierarchicalParameters 参数。</param>
        /// <returns>聚类结果。</returns>
        public ClusterResult Run(List<ClusterPoint> points, AlgorithmParameters parameters)
        {
            HierarchicalParameters para = parameters as HierarchicalParameters;
            if (para == null)
                throw new ArgumentException("层次聚类算法需要 HierarchicalParameters 类型的参数。");
            if (points == null || points.Count == 0)
                throw new ArgumentException("输入点集为空。");
            int n = points.Count;
            if (n > 3000)
                throw new ArgumentException(
                    "层次聚类内存 O(n²)、时间 O(n³)，要求点数不超过 3000，当前点数：" + n);

            _sw.Reset();
            _sw.Start();

            int target = Math.Max(1, Math.Min(para.ClusterCount, n));

            // 1. 初始每个点自成一簇，预计算点对距离并作为簇间距离（单连接）
            List<int>[] members = new List<int>[n];
            double[][] dist = new double[n][];
            for (int i = 0; i < n; i++)
            {
                members[i] = new List<int>();
                members[i].Add(i);
                dist[i] = new double[n];
            }
            for (int i = 0; i < n; i++)
            {
                dist[i][i] = 0.0;
                for (int j = i + 1; j < n; j++)
                {
                    double dx = points[i].X - points[j].X;
                    double dy = points[i].Y - points[j].Y;
                    double d = Math.Sqrt(dx * dx + dy * dy);
                    dist[i][j] = d;
                    dist[j][i] = d;
                }
            }

            // 2. 凝聚合并：每轮找单连接距离最近的两簇合并，
            //    合并后新簇到其它簇的距离 = 两原簇距离的较小值
            int alive = n;
            while (alive > target)
            {
                int bestA = -1;
                int bestB = -1;
                double bestD = double.MaxValue;
                for (int i = 0; i < n; i++)
                {
                    if (members[i] == null) continue;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (members[j] == null) continue;
                        if (dist[i][j] < bestD)
                        {
                            bestD = dist[i][j];
                            bestA = i;
                            bestB = j;
                        }
                    }
                }

                if (bestA < 0) break;

                members[bestA].AddRange(members[bestB]);
                members[bestB] = null;
                alive--;

                for (int k = 0; k < n; k++)
                {
                    if (members[k] == null || k == bestA) continue;
                    double merged = Math.Min(dist[bestA][k], dist[bestB][k]);
                    dist[bestA][k] = merged;
                    dist[k][bestA] = merged;
                }
                dist[bestB] = null;
            }

            // 3. 回写结果：剩余簇按首个成员的顺序重新编号 0..target-1
            int[] labels = new int[n];
            int clusterId = 0;
            for (int i = 0; i < n; i++)
            {
                if (members[i] == null) continue;
                foreach (int idx in members[i])
                {
                    labels[idx] = clusterId;
                }
                clusterId++;
            }
            for (int i = 0; i < n; i++) points[i].ClusterId = labels[i];

            _sw.Stop();
            return ClusterResult.Build(Name,
                string.Format("目标簇数={0}", target),
                points, _sw.ElapsedMilliseconds);
        }
    }
}
