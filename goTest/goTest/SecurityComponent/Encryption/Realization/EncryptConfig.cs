using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Encryption.Realization
{
    class EncryptConfig
    {
        private string key;

        public EncryptConfig(string key)
        {
            this.key = key;
        }

        public string getKey()
        {
            return key;
        }

        public EncryptConfig copy()
        {
            EncryptConfig copy = new EncryptConfig(key);

            return copy;
        }
    }
}
