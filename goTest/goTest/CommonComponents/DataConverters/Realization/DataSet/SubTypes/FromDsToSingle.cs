using goTest.CommonComponents.DataConverters.Realization.Workers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters.Realization
{
    class FromDsToSingle
    {
        public DataConverter<DataSet, int> toInt = new FromDataSetToIntDataConverter();
        public DataConverter<DataSet, string> toString = new FromDataSetToString();
    }
}
