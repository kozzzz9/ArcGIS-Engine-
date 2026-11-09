using System;

namespace Factory
{
    /// <summary>
    /// K-Means 聚类算法工厂
    /// </summary>
    class KmeansFactory : IFactory
    {
        public IClustering createClustering()
        {
            return new KmeansClustering();
        }
    }
}
