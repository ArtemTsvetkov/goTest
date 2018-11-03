using goTest.CommonComponents.DataConverters.Realization;
using goTest.SecurityComponent.Encryption.Realization.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Encryption.Realization
{
    class EncryptConfig
    {
        //ключ
        private byte[] key;
        //вектор инициализации
        //supports lengths of 128, 192, or 256 bits
        private byte[] iv = {0x31,0x14,0xaf,0xf7,0x8b,0x4a,0x1c,0x3e,0x0f,
            0xa6,0xa8,0xde,0xb0,0x5f,0x10,0x4c};

        public EncryptConfig(byte[] key)
        {
            if (key.Length == 16 | key.Length == 24 | key.Length == 32)
            {
                this.key = key;
            }
            else
            {
                throw new NotSupportKeysLength();
            }
        }

        public byte[] getKey()
        {
            return key;
        }

        public byte[] getIV()
        {
            return iv;
        }

        public EncryptConfig copy()
        {
            EncryptConfig copy = new EncryptConfig(key);

            return copy;
        }
    }
}
