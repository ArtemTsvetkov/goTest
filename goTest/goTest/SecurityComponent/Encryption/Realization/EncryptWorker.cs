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

        byte[] encryptAes(byte[] data, byte[] key, byte[] initVector)
        {
            using (var aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = initVector;
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var encryptedStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(encryptedStream, 
                        encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(data, 0, data.Length);
                    }
                    return encryptedStream.ToArray();
                }
            }
        }

        byte[] decryptAes(byte[] data, byte[] key, byte[] initVector)
        {
            using (var aes = new AesManaged())
            {
                aes.Key = key;
                aes.IV = initVector;
                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                using (var dataStream = new MemoryStream(data))
                {
                    using (var cryptoStream = new CryptoStream(dataStream, decryptor, 
                        CryptoStreamMode.Read))
                    {
                        using (var decryptedStream = new MemoryStream())
                        {
                            cryptoStream.CopyTo(decryptedStream);
                            return decryptedStream.ToArray();
                        }
                    }
                }
            }
        }

        public void setConfig(EncryptConfig config)
        {
            this.config = config.copy();
        }

        public string encrypt(string message)
        {
            using (Rijndael myRijndael = Rijndael.Create())
            {
                myRijndael.Key = config.getKey();
                myRijndael.IV = config.getIV();
                byte[] encrypted = encryptAes(converter.fromStringToBytesBufUtf8(message), 
                    myRijndael.Key, myRijndael.IV);
                return converter.fromByteBufToString(encrypted);
            }
        }

        public string decrypt(string message)
        {
            using (Rijndael myRijndael = Rijndael.Create())
            {
                myRijndael.Key = config.getKey();
                myRijndael.IV = config.getIV();
                return converter.fromBytesBufToStringUtf8(decryptAes(
                    converter.fromStringToBytesBuf(message), myRijndael.Key, myRijndael.IV));
            }
        }
    }
}
