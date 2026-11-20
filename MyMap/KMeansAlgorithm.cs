using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MyMap
{
    /// <summary>
    /// K-Means 聚类算法：洗牌法随机选初始中心，Lloyd 迭代（分配 + 均值更新），
    /// 空簇用离其所属中心最远的点重新初始化，收敛或达到最大迭代次数后结束。
    /// </summary>
    public class KMeansAlgorithm : IClusterAlgorithm
    {
        private readonly Random _rand = new Random();
        private readonly Stopwatch _sw = new Stopwatch();

        /// <summary>算法名称。</summary>
        public string Name
        {
            get { return "K-Means聚类"; }
        }

        /// <summary>
        /// 执行 K-Means 聚类：按参数 Runs 独立运行多次 Lloyd 迭代，保留 SSE 最小的一次，
        /// 消除随机初始化带来的结果波动。
        /// </summary>
        /// <param name="points">输入点集。</param>
        /// <param name="parameters">KMeansParameters 参数。</param>
        /// <returns>聚类结果。</returns>
        public ClusterResult Run(List<ClusterPoint> points, AlgorithmParameters parameters)
        {
            KMeansParameters para = parameters as KMeansParameters;
            if (para == null)
                throw new ArgumentException("K-Means 算法需要 KMeansParameters 类型的参数。");
            if (points == null || points.Count == 0)
                throw new ArgumentException("输入点集为空。");

            _sw.Reset();
            _sw.Start();

            int n = points.Count;
            int k = Math.Max(1, Math.Min(para.K, n));
            int runs = Math.Max(1, para.Runs);

            // 多次运行取最优：保留簇内误差平方和（SSE）最小的一次划分
            int[] bestLabels = null;
            double bestSse = double.MaxValue;
            for (int run = 0; run < runs; run++)
            {
                double sse;
                int[] labels = RunLloyd(points, k, para.MaxIterations, out sse);
                if (sse < bestSse)
                {
                    bestSse = sse;
                    bestLabels = labels;
                }
            }

            // 回写结果
            for (int i = 0; i < n; i++) points[i].ClusterId = bestLabels[i];

            _sw.Stop();
            return ClusterResult.Build(Name,
                string.Format("K={0}, 最大迭代次数={1}, 运行{2}次取最优", k, para.MaxIterations, runs),
                points, _sw.ElapsedMilliseconds);
        }

        /// <summary>
        /// 单次 Lloyd 迭代：洗牌法随机选初始中心，分配 + 均值更新直至收敛，
        /// 结束后输出该划分的 SSE。
        /// </summary>
        /// <param name="points">输入点集。</param>
        /// <param name="k">簇数量。</param>
        /// <param name="maxIterations">最大迭代次数。</param>
        /// <param name="sse">输出：簇内误差平方和。</param>
        /// <returns>每个点的簇编号。</returns>
        private int[] RunLloyd(List<ClusterPoint> points, int k, int maxIterations, out double sse)
        {
            int n = points.Count;

            // 1. 初始化：随机抽取 k 个不同样本点作为初始中心（洗牌法）
            int[] seedIdx = new int[n];
            for (int i = 0; i < n; i++) seedIdx[i] = i;
            for (int i = n - 1; i > 0; i--)
            {
                int j = _rand.Next(i + 1);
                int tmp = seedIdx[i]; seedIdx[i] = seedIdx[j]; seedIdx[j] = tmp;
            }

            double[][] centers = new double[k][];
            for (int c = 0; c < k; c++)
                centers[c] = new double[] { points[seedIdx[c]].X, points[seedIdx[c]].Y };

            // 2. Lloyd 迭代
            int[] labels = new int[n];
            for (int iter = 0; iter < maxIterations; iter++)
            {
                bool changed = false;

                // 2.1 分配：每个点归入最近中心
                for (int i = 0; i < n; i++)
                {
                    int best = 0;
                    double bestD = double.MaxValue;
                    for (int c = 0; c < k; c++)
                    {
                        double dx = points[i].X - centers[c][0];
                        double dy = points[i].Y - centers[c][1];
                        double d = dx * dx + dy * dy;
                        if (d < bestD) { bestD = d; best = c; }
                    }
                    if (labels[i] != best) { labels[i] = best; changed = true; }
                }

                // 2.2 更新：簇中心 = 簇内坐标均值；空簇用离其所属中心最远的点重新初始化
                double[] sx = new double[k];
                double[] sy = new double[k];
                int[] cnt = new int[k];
                for (int i = 0; i < n; i++)
                {
                    sx[labels[i]] += points[i].X;
                    sy[labels[i]] += points[i].Y;
                    cnt[labels[i]]++;
                }
                for (int c = 0; c < k; c++)
                {
                    if (cnt[c] == 0)
                    {
                        int farIdx = -1;
                        double farD = -1.0;
                        for (int i = 0; i < n; i++)
                        {
                            double dx = points[i].X - centers[labels[i]][0];
                            double dy = points[i].Y - centers[labels[i]][1];
                            double d = dx * dx + dy * dy;
                            if (d > farD) { farD = d; farIdx = i; }
                        }
                        centers[c][0] = points[farIdx].X;
                        centers[c][1] = points[farIdx].Y;
                    }
                    else
                    {
                        centers[c][0] = sx[c] / cnt[c];
                        centers[c][1] = sy[c] / cnt[c];
                    }
                }

            if (!changed) break; // 已收敛
            }

            // 3. 计算该划分的簇内误差平方和（SSE）
            sse = 0.0;
            double[] sumX = new double[k];
            double[] sumY = new double[k];
            int[] clusterSize = new int[k];
            for (int i = 0; i < n; i++)
            {
                sumX[labels[i]] += points[i].X;
                sumY[labels[i]] += points[i].Y;
                clusterSize[labels[i]]++;
            }
            for (int i = 0; i < n; i++)
            {
                int c = labels[i];
                if (clusterSize[c] == 0) continue;
                double dx = points[i].X - sumX[c] / clusterSize[c];
                double dy = points[i].Y - sumY[c] / clusterSize[c];
                sse += dx * dx + dy * dy;
            }

            return labels;
        }
    }
}
