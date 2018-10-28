using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters.Realization
{
    class GeneralConverter
    {
        public byte[] fromStringToBytesBuf(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        public string fromBytesBufToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
