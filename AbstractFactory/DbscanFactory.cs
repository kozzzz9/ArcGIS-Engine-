using System;

namespace AbstractFactory
{
    /// <summary>
    /// DBSCAN 聚类算法工厂（手册步骤6：实现 createParams）
    /// </summary>
    class DbscanFactory : IFactory
    {
        public IClustering createClustering()
        {
            return new DbscanClustering();
        }

        public IParams createParams()
        {
            return new DbscanParams();
        }
    }
}
