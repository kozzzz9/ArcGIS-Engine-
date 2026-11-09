using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Facade
{
    class FileWriter
    {
        public void write(String encryptString, String fileNameTarget)
        {
            Console.WriteLine("保存密文，写入文件。");
            FileStream fs = null;
            try
            {
                fs = new FileStream(fileNameTarget, FileMode.Create);
                byte[] buffer = Encoding.Default.GetBytes(encryptString);
                fs.Write(buffer, 0, buffer.Length);
                fs.Flush();
                fs.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.Write("文件不存在！");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Console.Write("文件操作错误！");
            }
        }
    }
}
