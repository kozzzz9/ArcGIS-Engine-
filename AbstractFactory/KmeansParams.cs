using System;

namespace AbstractFactory
{
    /// <summary>
    /// K-Means 算法参数类（手册步骤2）
    /// </summary>
    class KmeansParams : IParams
    {
        public string paramsToString()
        {
            return "注入Kmeans算法参数";
        }
    }
}
