using System;

namespace MyMap
{
    /// <summary>
    /// K-Means 聚类参数：簇数量 K、最大迭代次数与运行次数（多次运行取 SSE 最小结果）。
    /// </summary>
    public class KMeansParameters : AlgorithmParameters
    {
        /// <summary>簇数量 K。</summary>
        public int K { get; set; }

        /// <summary>最大迭代次数。</summary>
        public int MaxIterations { get; set; }

        /// <summary>运行次数（消除随机初始化影响，默认 10，取 SSE 最小的一次）。</summary>
        public int Runs { get; set; }

        /// <summary>
        /// 构造参数对象，运行次数默认 10。
        /// </summary>
        public KMeansParameters()
        {
            Runs = 10;
        }
    }
}
