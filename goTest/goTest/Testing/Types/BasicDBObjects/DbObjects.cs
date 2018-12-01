using goTest.Testing.Types.BasicDBObjects.Interfaces;
using goTest.Testing.Types.BasicDBObjects.Realization.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Types.BasicDBObjects
{
    static class DbObjects
    {
        public static DbObject mainSchema = new MainSchema();
        public static DbObject inApproveStatus = new InApproveStatus();
    }
}
