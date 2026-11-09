using System;

namespace SimpleFactory
{
    /// <summary>
    /// DBSCAN 密度聚类算法
    /// </summary>
    class DbscanClustering : IClustering
    {
        public string calculate()
        {
            return "执行DbscanClustering的calculate()方法";
        }
    }
}
