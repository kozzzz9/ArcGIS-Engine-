using System;

namespace Facade
{
    /// <summary>
    /// 加密子系统：凯撒密码（字母位移3位，其余字符原样保留）
    /// </summary>
    class CaesarMachine
    {
        public String encrypt(String plainText)
        {
            Console.Write("凯撒加密（位移3位），将明文转换为密文：");
            String encryptString = "";
            char[] chars = plainText.ToCharArray();
            foreach (char c in chars)
            {
                if (c >= 'a' && c <= 'z')
                    encryptString += (char)('a' + (c - 'a' + 3) % 26);
                else if (c >= 'A' && c <= 'Z')
                    encryptString += (char)('A' + (c - 'A' + 3) % 26);
                else
                    encryptString += c;
            }
            Console.WriteLine(encryptString);

            return encryptString;
        }
    }
}
