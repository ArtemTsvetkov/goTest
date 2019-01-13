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
        private static EncryptWorker encryptWorker;
        private EncryptConfig config;
        private GeneralConverter converter = new GeneralConverter();

        private EncryptWorker()
        {

        }

        public static EncryptWorker getInstance()
        {
            if (encryptWorker == null)
            {
                encryptWorker = new EncryptWorker();
            }

            return encryptWorker;
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

        private byte[] encryptAes(byte[] data, byte[] key, byte[] initVector)
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

        private byte[] decryptAes(byte[] data, byte[] key, byte[] initVector)
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
    }
}
/*
EncryptConfig conf = new EncryptConfig(new byte[]{0x7c,0x26,0xf0,0xc6,0x77,
    0xaa,0xba,0x6a,0x66,0x7b,0x56,0x0f,0x98,0x43,0xba,0x2d,0xbb,0x06,0x0a,0xef,
    0xad,0x32,0x88,0xb0,0x5d,0xfb,0xfe,0x98,0xa7,0xa7,0xa5,0x1a});
EncryptWorker a = new EncryptWorker();
a.setConfig(conf);
string original = "Hellow, world!";
string originalInEncript = a.encrypt(original);
string originalInDecript = a.decrypt(originalInEncript);

string originalRus = "Привет, мир!";
string originalInEncriptRus = a.encrypt(originalRus);
string originalInDecriptRus = a.decrypt(originalInEncriptRus);
int test = 0;
 */
