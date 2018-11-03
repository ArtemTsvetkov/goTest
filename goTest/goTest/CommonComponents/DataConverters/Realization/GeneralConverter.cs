using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters.Realization
{
    class GeneralConverter
    {
        public byte[] fromStringToBytesBufUtf8(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        public string fromBytesBufToStringUtf8(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public string fromByteBufToString(byte[] bytes)
        {
            string result = "";
            char[] chars = new char[bytes.Count()];
            for (int i = 0; i < chars.Count(); i++)
            {
                chars[i] = (char)bytes[i];
            }
            for (int i=0; i<chars.Count();i++)
            {
                result += chars[i];
            }

            return result;
        }

        public byte[] fromStringToBytesBuf(string str)
        {
            char[] chars = new char[str.Length];
            for (int i = 0; i < chars.Count(); i++)
            {
                chars[i] = str[i];
            }
            byte[] result = new byte[chars.Count()];
            for (int i = 0; i < chars.Count(); i++)
            {
                result[i] = (byte)chars[i];
            }

            return result;
        }
    }
}
