using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // 手册步骤7：同一个工厂成对创建算法与其配套参数，实现参数注入
            IFactory factory = new KmeansFactory();
            IClustering clustring = factory.createClustering();
            IParams p = factory.createParams();
            Console.WriteLine(clustring.calculate(p));

            if (!Console.IsInputRedirected) Console.ReadKey();
        }
    }
}
