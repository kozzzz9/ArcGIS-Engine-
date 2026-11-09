using System;
using System.IO;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            // 以程序所在目录（bin\Debug\net9.0）为基准定位数据文件，
            // 使 Visual Studio 启动与命令行 dotnet run 的运行结果保持一致
            String src = Path.Combine(AppContext.BaseDirectory, "plainText.json");
            String dst = Path.Combine(AppContext.BaseDirectory, "encryptText.json");

            // 通过求模加密外观类完成“读取——加密——保存”，客户端无需接触子系统
            EncryptFacade facade = new EncryptFacade();
            facade.encryptFile(src, dst);

            // 通过凯撒加密外观类完成同一流程，加密算法不同而客户端调用方式一致
            NewEncryptFacade newFacade = new NewEncryptFacade();
            newFacade.encryptFile(src, Path.Combine(AppContext.BaseDirectory, "encryptText_new.json"));

            if (!Console.IsInputRedirected) Console.ReadKey();
        }
    }
}
