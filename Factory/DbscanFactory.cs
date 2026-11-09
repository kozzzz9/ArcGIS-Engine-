using System;

namespace Factory
{
    /// <summary>
    /// DBSCAN 聚类算法工厂
    /// </summary>
    class DbscanFactory : IFactory
    {
        public IClustering createClustering()
        {
            return new DbscanClustering();
        }
    }
}
