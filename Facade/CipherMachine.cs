using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class CipherMachine
    {
        public String encrypt(String plainText)
        {
            Console.Write("数据加密，将明文转换为密文：");
            String encryptString = "";
            char[] chars = plainText.ToCharArray();
            foreach(char c in chars)
            {
                String tmp = (c % 7).ToString();
                encryptString += tmp;
            }
            Console.WriteLine(encryptString);

            return encryptString;
        }
    }
}
