using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces
{
    interface TestManipulatorI
    {
        Test load(string subject, string testName);
        void create(Test test);
        void update(Test test);
    }
}
