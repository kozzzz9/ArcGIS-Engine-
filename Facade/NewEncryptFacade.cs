using System;

namespace Facade
{
    /// <summary>
    /// 外观类：复用文件读/写子系统，加密算法采用凯撒密码。
    /// 客户端更换外观类即可更换整套加密流程，无需接触子系统。
    /// </summary>
    class NewEncryptFacade
    {
        private FileReader reader = new FileReader();
        private CaesarMachine caesar = new CaesarMachine();
        private FileWriter writer = new FileWriter();

        public void encryptFile(String fileNameSource, String fileNameTarget)
        {
            String plainText = reader.read(fileNameSource);
            String encryptText = caesar.encrypt(plainText);
            writer.write(encryptText, fileNameTarget);
        }
    }
}
