using goTest.Testing.Types.BasicDBObjects.Interfaces;
using goTest.Testing.Types.Unswer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Types.Unswer.Realization
{
    class Unswer : UnswerType, DbObject
    {
        public string getName()
        {
            return getType();
        }

        public string getType()
        {
            return "Unswer";
        }
    }
}
