using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.SecurityComponent.Configs;
using goTest.SecurityComponent.Exceptions;
using goTest.SecurityComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Realization
{
    class SqlLiteDbChecker : DataBaseChecker<SqlLiteCheckerConfig>
    {
        SecurityQueryConfigurator executer;

        public SqlLiteDbChecker(SecurityQueryConfigurator executer)
        {
            this.executer = executer;
        }

        public bool check(SqlLiteCheckerConfig config)
        {
            string[] dbTables = DataSetConverter.fromDsToBuf.toStringBuf.convert(
                SqlLiteSimpleExecute.execute(executer.checkDbTables()));
            //Create checking tables
            List<string[]> checkingTables = new List<string[]>();
            for(int i=0; i<7; i++)
            {
                checkingTables.Add(new string[2]);
                checkingTables.ElementAt(i)[1] = "no";
            }
            checkingTables.ElementAt(0)[0] = "Users";
            checkingTables.ElementAt(1)[0] = "Disciplines";
            checkingTables.ElementAt(2)[0] = "Tests";
            checkingTables.ElementAt(3)[0] = "Questions";
            checkingTables.ElementAt(4)[0] = "Parameters_types";
            checkingTables.ElementAt(5)[0] = "Parameters";
            checkingTables.ElementAt(6)[0] = "Unswers";
            //Check tables
            if (checkingTables.Count > dbTables.Count())
            {
                throw new NotEnoughTablesExeption();
            }
            else
            {
                for (int i = 0; i < dbTables.Count(); i++)
                {
                    for (int n = 0; n < checkingTables.Count(); n++)
                    {
                        if (dbTables[i].Equals(checkingTables.ElementAt(n)[0]))
                        {
                            checkingTables.ElementAt(i)[1] = "yes";
                        }
                    }
                }

                for (int i = 0; i < checkingTables.Count(); i++)
                {
                    if(checkingTables.ElementAt(i)[1].Equals("no"))
                    {
                        throw new NotEnoughTablesExeption();
                    }
                }

                //Check admin
                int count = DataSetConverter.fromDsToSingle.toInt.convert(
                    SqlLiteSimpleExecute.execute(executer.checkExistAdmin()));
                if(count==0)
                {
                    throw new AdminIsNotExist();
                }

                return true;
            }
        }
    }
}
