using goTest.CommonComponents.InitialyzerComponent.ReadConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite
{
    class SqlLiteStateFields
    {
        private string dbPath;
        private string query;

        public SqlLiteStateFields(string query)
        {
            dbPath = ConfigReader.getInstance().getDbPath();
            this.query = query;
        }

        public string getDbPath()
        {
            return dbPath;
        }

        public string getQuery()
        {
            return query;
        }
    }
}
