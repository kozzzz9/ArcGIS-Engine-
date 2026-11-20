using System;

namespace MyMap
{
    /// <summary>
    /// 聚类输入点：地图要素的坐标与要素 OID，ClusterId 为聚类算法回写的簇编号（-1 表示噪声点）。
    /// </summary>
    public class ClusterPoint
    {
        /// <summary>对应地图要素的 OID。</summary>
        public int Oid { get; set; }

        /// <summary>X 坐标。</summary>
        public double X { get; set; }

        /// <summary>Y 坐标。</summary>
        public double Y { get; set; }

        /// <summary>聚类编号，由算法回写；-1 表示噪声点。</summary>
        public int ClusterId { get; set; }
    }
}
