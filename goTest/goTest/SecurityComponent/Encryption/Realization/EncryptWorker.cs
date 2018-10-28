using goTest.CommonComponents.DataConverters.Realization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Encryption.Realization
{
    class EncryptWorker : EncryptWorkerInterface
    {
        private EncryptConfig config;
        private GeneralConverter converter = new GeneralConverter();
        //вектор инициализации
        private static byte[] IV = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
        //ключ шифрования
        private static byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09,
            0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10 };

        public string decrypt(string message)
        {
            return converter.fromBytesBufToString(Decrypt(converter.
                fromStringToBytesBuf(message), key, IV));
        }

        public string encrypt(string message)
        {
            return converter.fromBytesBufToString(
                Encrypt(converter.fromStringToBytesBuf(message), key, IV));
        }

        private static byte[] Encrypt(byte[] ENC, byte[] AES_KEY, byte[] AES_IV)
        {
            using (Rijndael AES = Rijndael.Create())
            {
                AES.KeySize = 128;
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.None;

                MemoryStream MS = new MemoryStream();
                CryptoStream CS = new CryptoStream(MS, AES.CreateEncryptor(AES_KEY, AES_IV), CryptoStreamMode.Write);

                CS.Write(ENC, 0, ENC.Length);
                CS.Close();

                return MS.ToArray();
            }
        }
        private static byte[] Decrypt(byte[] DEC, byte[] AES_KEY, byte[] AES_IV)
        {
            using (Rijndael AES = Rijndael.Create())
            {
                AES.KeySize = 128;
                AES.BlockSize = 128;
                AES.Padding = PaddingMode.None;

                MemoryStream MS = new MemoryStream();
                CryptoStream CS = new CryptoStream(MS, AES.CreateDecryptor(AES_KEY, AES_IV), CryptoStreamMode.Write);

                CS.Write(DEC, 0, DEC.Length);
                CS.Close();

                return MS.ToArray();
            }
        }

        public void setConfig(EncryptConfig config)
        {
            this.config = config.copy();
        }
    }
}
