using System;

namespace SimpleFactory
{
    /// <summary>
    /// 简单工厂类：根据传入的算法类型创建对应的聚类算法实例
    /// </summary>
    class ClusteringFactory
    {
        /// <summary>
        /// 静态工厂方法
        /// </summary>
        /// <param name="type">聚类算法类型：kmeans / dbscan / hierarchical</param>
        public static IClustering createClustering(string type)
        {
            IClustering clustering = null;
            switch (type)
            {
                case "kmeans":
                    clustering = new KmeansClustering();
                    Console.WriteLine("创建KmeansClustering实例");
                    break;
                case "dbscan":
                    clustering = new DbscanClustering();
                    Console.WriteLine("创建DbscanClustering实例");
                    break;
                case "hierarchical":
                    clustering = new HierarchicalClustering();
                    Console.WriteLine("创建HierarchicalClustering实例");
                    break;
                default:
                    Console.WriteLine("不支持的算法类型：" + type);
                    break;
            }
            return clustering;
        }
    }
}
