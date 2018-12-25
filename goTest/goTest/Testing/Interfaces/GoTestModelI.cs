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
        void createSubjectInBD(string name);
        /*void createTest(string name, int subjectId, int questionsNumber,
            int requeredUnswersNumber);*/
        void addEmptyQuestion();
        void addEmptyUnswer(int questionId);
        void updateTestInBD();
        void updateSubject(int id, string newName);
        void deleteQuestion(int id);
        void deleteUnswer(int unswerId);
        void update(int id, Question newVersion);
        void update(int id, Unswer newVersion);
        void update(int id, Test test);
        int[] getAllSubjectIds();
        Subject getSubjectFromBD(int id);
        void loadAllTestContentFromBD(int testId);
        void loadTestForTesting(int testId);
        Question getNextQuestion();
        void userUnswered(int id);
        void showTestResults();
    }
}
