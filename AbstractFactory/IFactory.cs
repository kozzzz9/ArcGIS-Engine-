namespace AbstractFactory
{
    /// <summary>
    /// 抽象工厂接口（手册步骤3：增加 createParams 方法）
    /// </summary>
    interface IFactory
    {
        /// <summary>
        /// 工厂方法：创建聚类算法实例
        /// </summary>
        IClustering createClustering();

        /// <summary>
        /// 工厂方法：创建与算法配套的参数实例
        /// </summary>
        IParams createParams();
    }
}
