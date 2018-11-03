using goTest.CommonComponents.DataConverters.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters.Realization.Workers
{
    class FromDataSetToString : DataConverter<DataSet, string>
    {
        public string convert(DataSet data)
        {
            try
            {
                DataSet ds = data;
                DataTable table = ds.Tables[0];
                return table.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                throw new СonversionError();
            }
        }
    }
}
