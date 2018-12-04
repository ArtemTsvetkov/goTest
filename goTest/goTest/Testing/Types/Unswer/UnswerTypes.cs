using goTest.Testing.Types.Unswer.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Types.Unswer.Interfaces
{
    static class UnswerTypes
    {
        public static UnswerType unswer = new Unswer.Realization.Unswer();
        public static UnswerType rightUnswer = new RightUnswer();
    }
}
