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
        //bool loadAllQuestions - if true, then load all questions to update, else
        //load some questions to going test
        Subject load(string name, bool loadOnlySubjectAndTestNamesWithoutChilds, bool loadAllQuestions);
        void create(Subject subject);
        void update(Subject subject);
    }
}
