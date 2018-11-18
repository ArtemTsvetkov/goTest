using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces.Manipulators
{
    interface SubjectManipulatorI
    {
        Subject load(string name);
        void create(Subject subject);
        void update(Subject subject);
    }
}
