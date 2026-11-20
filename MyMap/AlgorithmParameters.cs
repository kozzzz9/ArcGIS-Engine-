using System;

namespace MyMap
{
    /// <summary>
    /// 聚类算法参数基类：携带算法名，供各算法校验参数类型。
    /// </summary>
    public abstract class AlgorithmParameters
    {
        /// <summary>参数所属的算法名称。</summary>
        public string AlgorithmName { get; set; }
    }
}
