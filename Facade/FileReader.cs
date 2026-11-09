using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Facade
{
    class FileReader
    {
        public String read(String fileNameSource)
        {
            Console.Write("读取文件，获取明文：");
            FileStream fs = null;
            StringBuilder builder = new StringBuilder();

            try
            {
                fs = new FileStream(fileNameSource, FileMode.Open);
                int data;
                while((data = fs.ReadByte()) != -1)
                {
                    builder = builder.Append((char)data);
                }
                fs.Close();
                Console.WriteLine(builder.ToString());

            }catch(FileNotFoundException e)
            {
                Console.Write("文件不存在！");
            }catch(IOException e)
            {
                Console.WriteLine(e.Message);
                Console.Write("文件操作错误！");
            }

            return builder.ToString();
        }
    }
}
