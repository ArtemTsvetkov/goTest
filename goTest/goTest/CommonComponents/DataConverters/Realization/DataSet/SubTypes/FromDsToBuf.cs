using goTest.CommonComponents.DataConverters.Realization.Workers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters.Realization
{
    class FromDsToBuf
    {
        public DataConverter<DataSet, string[]> toStringBuf = 
            new FromDsToStringBufConverter();
        public DataConverter<DataSet, int[]> toIntBuf =
            new FromDsToIntBufConverter();
    }
}
