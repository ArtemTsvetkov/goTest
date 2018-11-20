using goTest.Testing.Objects;
using goTest.Testing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces
{
    interface GoTestControllerI
    {
        void createSubject(string name);
        void createTest(string name, string subject, int questionsNumber, 
            int requeredUnswersNumber);
        void updateSubject(int id, string newName);
        void deleteQuestion();   
        void deleteUnswer();
        void setQuestionSelection(int id);
        void setUnswerSelection(int id);
        void getFullQuestionContent();
        void getFullTestContent(int testId);
        void updateSelected(Question newVersion);
        void updateSelected(Unswer newVersion);
    }
}
