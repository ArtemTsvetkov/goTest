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
        Test load(int testId, bool loadAllQuestions, bool loadOnlyTestNames);
        void create(Test test, int subjectId);
        void update(Test test, int subjectId);
    }
}
