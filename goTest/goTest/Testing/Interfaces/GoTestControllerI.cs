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
        void createTest(string name, int subjectId, int questionsNumber, 
            int requeredUnswersNumber);
        void updateSubject(int id, string newName);
        void deleteQuestion(int id);   
        void deleteUnswer(int id);
        void getFullTestContent(int testId);
        void loadAllSubjects();
        void update(int questionId, Question newVersion);
        void update(int unswerId, Unswer newVersion);
        void update(int testId, Test newVersion);
    }
}
