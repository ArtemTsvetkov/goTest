using goTest.Testing.Types.BasicDBObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Types.BasicDBObjects.Realization
{
    class SubjectType : DbObject
    {
        public string getName()
        {
            return "Subject";
        }
    }
}
