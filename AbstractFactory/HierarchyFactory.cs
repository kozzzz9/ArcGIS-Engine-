using System;

namespace AbstractFactory
{
    /// <summary>
    /// 层次聚类算法工厂（命名与手册 UML 一致，手册步骤6：实现 createParams）
    /// </summary>
    class HierarchyFactory : IFactory
    {
        public IClustering createClustering()
        {
            return new HierarchicalClustering();
        }

        public IParams createParams()
        {
            return new HierarchicalParams();
        }
    }
}
