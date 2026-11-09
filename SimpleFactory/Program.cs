using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // 客户端通过简单工厂类创建聚类算法实例，无需直接 new 具体算法类
            IClustering kmeans = ClusteringFactory.createClustering("kmeans");
            Console.WriteLine(kmeans.calculate());

            IClustering dbscan = ClusteringFactory.createClustering("dbscan");
            Console.WriteLine(dbscan.calculate());

            IClustering hierarchical = ClusteringFactory.createClustering("hierarchical");
            Console.WriteLine(hierarchical.calculate());

            if (!Console.IsInputRedirected) Console.ReadKey();
        }
    }
}
