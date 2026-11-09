using System;

namespace AbstractFactory
{
    /// <summary>
    /// DBSCAN 算法参数类（手册步骤2）
    /// </summary>
    class DbscanParams : IParams
    {
        public string paramsToString()
        {
            return "注入Dbscan算法参数";
        }
    }
}
