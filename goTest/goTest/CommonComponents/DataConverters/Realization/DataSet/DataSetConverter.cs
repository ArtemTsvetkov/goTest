using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters.Realization
{
    static class DataSetConverter
    {
        public static FromDsToSingle fromDsToSingle = new FromDsToSingle();
        public static FromDsToBuf fromDsToBuf = new FromDsToBuf();
    }
}
