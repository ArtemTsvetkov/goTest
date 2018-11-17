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
        void updateSubject(string oldName, string newName);
        void addUnswer(string content, bool isRightAnswer);
        void deleteQuestion();
        void addQueston(string shortContent, QuestionType questionsType);      
        void deleteUnswer();
        void setQuestionSelection(string questionsContent, List<Unswer> unswers, 
            QuestionType questionsType);
        void setUnswerSelection(string content, bool IsRight);
        void getFullQuestionContent();
        void getFullTestContent(int testsId);
        void updateSelected(Question newVersion);
        void updateSelected(Unswer newVersion);
    }
}
