using goTest.Testing.Objects;
using goTest.Testing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces
{
    interface GoTestModelI
    {
        void createSubject(string name);
        void createTest(string name, string subject, int questionsNumber,
            int requeredUnswersNumber);
        void updateSubject(int id, string newName);
        void deleteQuestion();
        void deleteUnswer();
        void getQuestionsFullContent();
        void setQuestionSelection(int id);
        void setUnswerSelection(int id);
        void updateSelected(Question newVersion);
        void updateSelected(Unswer newVersion);
        void updateTest(Test test);
    }
}
