using System;

namespace MyMap
{
    /// <summary>
    /// 层次聚类参数：目标簇数量（凝聚合并直至剩余指定簇数）。
    /// </summary>
    public class HierarchicalParameters : AlgorithmParameters
    {
        /// <summary>目标簇数量。</summary>
        public int ClusterCount { get; set; }
    }
}
