using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces.Manipulators
{
    interface UnswerManipalatorI
    {
        Unswer load(int id);
        void create(Unswer unswer, int questionId);
        void update(Unswer unswer);
    }
}
