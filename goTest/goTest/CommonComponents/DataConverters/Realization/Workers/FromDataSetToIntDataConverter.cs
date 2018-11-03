using goTest.CommonComponents.DataConverters.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.DataConverters.Realization.Workers
{
    class FromDataSetToIntDataConverter : DataConverter<DataSet, int>
    {
        public int convert(DataSet data)
        {
            try
            {
                DataSet ds = data;
                DataTable table = ds.Tables[0];
                return convertFromItemToInt(table.Rows[0][0]);
            }
            catch(Exception ex)
            {
                throw new СonversionError();
            }
        }

        private int convertFromItemToInt(object item)
        {
            return int.Parse(item.ToString());
        }
    }
}
