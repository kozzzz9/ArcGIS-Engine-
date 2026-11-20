using System;
using System.Collections.Generic;

namespace MyMap
{
    /// <summary>
    /// 聚类算法工厂（注册表式简单工厂）：
    /// 内部维护"算法名 → 创建委托"注册表，新增算法只需注册一行，
    /// 调用方按名称创建 IClusterAlgorithm 实例，不依赖具体类型。
    /// </summary>
    public static class ClusteringAlgorithmFactory
    {
        /// <summary>K-Means 聚类的注册名。</summary>
        public const string KMeans = "K-Means聚类";

        /// <summary>DBSCAN 聚类的注册名。</summary>
        public const string DBSCAN = "DBSCAN聚类";

        /// <summary>层次聚类的注册名。</summary>
        public const string Hierarchical = "层次聚类";

        /// <summary>算法注册表：算法名 → 创建委托。</summary>
        private static readonly Dictionary<string, Func<IClusterAlgorithm>> _registry =
            new Dictionary<string, Func<IClusterAlgorithm>>(StringComparer.Ordinal);

        static ClusteringAlgorithmFactory()
        {
            // 内置算法注册；后续新算法在此追加一行即可被菜单与工厂识别
            _registry[KMeans] = delegate { return new KMeansAlgorithm(); };
            _registry[DBSCAN] = delegate { return new DBSCANAlgorithm(); };
            _registry[Hierarchical] = delegate { return new HierarchicalClusterAlgorithm(); };
        }

        /// <summary>
        /// 获取全部已注册的算法名（供界面枚举展示）。
        /// </summary>
        public static List<string> GetAlgorithmNames()
        {
            return new List<string>(_registry.Keys);
        }

        /// <summary>
        /// 按算法名创建聚类算法实例。
        /// </summary>
        /// <param name="algorithmName">算法注册名。</param>
        /// <returns>算法实例。</returns>
        public static IClusterAlgorithm Create(string algorithmName)
        {
            Func<IClusterAlgorithm> creator;
            if (algorithmName == null || !_registry.TryGetValue(algorithmName, out creator))
            {
                throw new ArgumentException("未注册的聚类算法：" + algorithmName);
            }
            return creator();
        }
    }
}
