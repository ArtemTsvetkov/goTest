using goTest.CommonComponents.DataConverters.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters.Realization.Workers
{
    class FromDsToIntBufConverter : DataConverter<DataSet, int[]>
    {
        public int[] convert(DataSet ds)
        {
            try
            {
                int[] newData = new int[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    newData[i] = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                }
                return newData;
            }
            catch (Exception ex)
            {
                throw new СonversionError();
            }
        }
    }
}
