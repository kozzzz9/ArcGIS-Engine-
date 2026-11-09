using System;

namespace Factory
{
    /// <summary>
    /// 层次聚类算法工厂（命名与手册 UML 一致）
    /// </summary>
    class HierarchyFactory : IFactory
    {
        public IClustering createClustering()
        {
            return new HierarchicalClustering();
        }
    }
}
