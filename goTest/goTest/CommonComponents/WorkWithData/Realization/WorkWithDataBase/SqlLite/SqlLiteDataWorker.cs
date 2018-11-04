using goTest.CommonComponents.Exceptions;
using goTest.CommonComponents.WorkWithData.Exceptions.DataBasesExceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite
{
    class SqlLiteDataWorker : DataWorker<SqlLiteStateFields, DataSet>
    {
        private SqlLiteStateFields config;
        private DataSet resultStorage;

        public void execute()
        {
            resultStorage = runQuery(config.getQuery());
        }

        public bool connect()
        {
            if (config != null)
            {
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + config.getDbPath() +
                    "; Version=3;");
                try
                {
                    conn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                throw new NoConfigurationSpecified();
            }
        }

        public void setConfig(SqlLiteStateFields config)
        {
            this.config = config;
        }

        private DataSet runQuery(string query)
        {
            if(config != null)
            {
                SQLiteConnection conn = new SQLiteConnection(@"Data Source=" + config.getDbPath() +
                    "; Version=3;");
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    throw new NoDataBaseConnection("There is no database connection");
                }
                SQLiteDataAdapter adapt = new SQLiteDataAdapter(query, conn);
                DataSet ds = new DataSet();
                try
                {
                    adapt.Fill(ds);

                    return ds;
                }
                catch(Exception ex)
                {
                    //Table is not exist
                    if (ex.Message.Contains("SQL logic error\r\nno such table"))
                    {
                        throw ex;
                    }
                    //incorrect query
                    else
                    {
                        throw new DatabaseQueryError("Database query error");
                    }
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                }
            }
            else
            {
                throw new NoConfigurationSpecified();
            }
        }

        public DataSet getResult()
        {
            return resultStorage;
        }
    }
}
