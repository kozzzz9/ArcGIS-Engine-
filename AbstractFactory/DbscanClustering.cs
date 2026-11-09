using System;

namespace AbstractFactory
{
    /// <summary>
    /// DBSCAN 密度聚类算法（手册步骤5示例：calculate 接收注入的参数）
    /// </summary>
    class DbscanClustering : IClustering
    {
        public string calculate(IParams p)
        {
            return p.paramsToString() + ":" + "执行DbscanClustering的calculate()方法";
        }
    }
}
