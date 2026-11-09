using System;

namespace Facade
{
    /// <summary>
    /// 外观类：对“读取源文件——加密——保存加密文件”三个子系统提供统一入口
    /// </summary>
    class EncryptFacade
    {
        private FileReader reader = new FileReader();
        private CipherMachine cipher = new CipherMachine();
        private FileWriter writer = new FileWriter();

        /// <summary>
        /// 加密文件：依次调用读文件、加密、写文件三个子系统方法
        /// </summary>
        public void encryptFile(String fileNameSource, String fileNameTarget)
        {
            String plainText = reader.read(fileNameSource);
            String encryptText = cipher.encrypt(plainText);
            writer.write(encryptText, fileNameTarget);
        }
    }
}
