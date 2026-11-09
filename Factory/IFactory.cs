namespace Factory
{
    /// <summary>
    /// 抽象工厂接口：声明工厂方法
    /// </summary>
    interface IFactory
    {
        /// <summary>
        /// 工厂方法：创建聚类算法实例
        /// </summary>
        IClustering createClustering();
    }
}
