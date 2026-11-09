namespace AbstractFactory
{
    /// <summary>
    /// 抽象聚类算法接口（手册步骤4：calculate 方法增加 IParams 参数）
    /// </summary>
    interface IClustering
    {
        /// <summary>
        /// 执行聚类计算
        /// </summary>
        string calculate(IParams p);
    }
}
