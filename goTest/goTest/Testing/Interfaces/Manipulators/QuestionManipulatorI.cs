using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces.Manipulators
{
    interface QuestionManipulatorI
    {
        Question load(int id);
        void create(Question question, int testId);
        void update(Question question);
    }
}
