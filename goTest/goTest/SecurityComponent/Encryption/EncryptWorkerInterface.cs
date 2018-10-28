using goTest.SecurityComponent.Encryption.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Encryption
{
    interface EncryptWorkerInterface
    {
        void setConfig(EncryptConfig config);
        //Зашифровать
        string encrypt(string message);
        //Расшифровать
        string decrypt(string message);
    }
}