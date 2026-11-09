using System;

namespace AbstractFactory
{
    /// <summary>
    /// K-Means 聚类算法（手册步骤5：calculate 接收注入的参数）
    /// </summary>
    class KmeansClustering : IClustering
    {
        public string calculate(IParams p)
        {
            return p.paramsToString() + ":" + "执行KmeansClustering的calculate()方法";
        }
    }
}
