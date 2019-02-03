using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization.Workers
{
    static class QueryFixer
    {
        public static string fix(string query)
        {
            query = query.Replace("'", "''");
            return query;
        }
    }
}
