using System;
using System.Collections.Generic;

namespace MyMap
{
    /// <summary>
    /// 聚类算法接口：所有聚类算法（K-Means、DBSCAN 及后续扩展）统一实现此接口，
    /// 调用方只依赖接口，通过工厂创建具体算法实例。
    /// </summary>
    public interface IClusterAlgorithm
    {
        /// <summary>算法名称。</summary>
        string Name { get; }

        /// <summary>
        /// 对点集执行聚类，并把簇编号回写到每个点的 ClusterId。
        /// </summary>
        /// <param name="points">输入点集。</param>
        /// <param name="parameters">算法参数（具体类型由算法约定）。</param>
        /// <returns>聚类结果。</returns>
        ClusterResult Run(List<ClusterPoint> points, AlgorithmParameters parameters);
    }
}
