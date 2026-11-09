using System;

namespace AbstractFactory
{
    /// <summary>
    /// 层次聚类算法（手册步骤5：calculate 接收注入的参数）
    /// </summary>
    class HierarchicalClustering : IClustering
    {
        public string calculate(IParams p)
        {
            return p.paramsToString() + ":" + "执行HierarchicalClustering的calculate()方法";
        }
    }
}
