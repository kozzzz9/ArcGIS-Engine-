using System;

namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            // 客户端面向 IFactory 编程：更换工厂即更换算法，无需修改客户端逻辑
            IFactory factory = new KmeansFactory();
            IClustering clustering = factory.createClustering();
            Console.WriteLine(clustering.calculate());

            factory = new DbscanFactory();
            clustering = factory.createClustering();
            Console.WriteLine(clustering.calculate());

            factory = new HierarchyFactory();
            clustering = factory.createClustering();
            Console.WriteLine(clustering.calculate());

            if (!Console.IsInputRedirected) Console.ReadKey();
        }
    }
}
