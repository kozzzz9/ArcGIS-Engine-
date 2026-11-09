using System;

namespace AbstractFactory
{
    /// <summary>
    /// K-Means 聚类算法工厂（手册步骤6：实现 createParams）
    /// </summary>
    class KmeansFactory : IFactory
    {
        public IClustering createClustering()
        {
            return new KmeansClustering();
        }

        public IParams createParams()
        {
            return new KmeansParams();
        }
    }
}
