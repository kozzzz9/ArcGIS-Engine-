using System;

namespace MyMap
{
    /// <summary>
    /// DBSCAN 聚类参数：邻域半径 Eps（地图单位）与核心点最小点数 MinPts。
    /// </summary>
    public class DBSCANParameters : AlgorithmParameters
    {
        /// <summary>邻域半径 Eps（地图单位）。</summary>
        public double Eps { get; set; }

        /// <summary>核心点邻域内要求的最少样本数 MinPts。</summary>
        public int MinPts { get; set; }
    }
}
