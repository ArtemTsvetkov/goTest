using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters
{
    interface DataConverter<TBasicData, TFinishData>
    {
        TFinishData convert(TBasicData data);
    }
}
