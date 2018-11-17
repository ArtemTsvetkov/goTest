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
        void addEmptyQuestonArea();
        void deleteQuestion();
        void addEmptyUnswerArea();
        void deleteUnswer();
        void setQuestionSelection(string questionsContent, List<Unswer> unswers, 
            QuestionType questionsType);
        void setUnswerSelectio(string content, bool IsRight);
        void getFullQuestionContent();
        void getFullTestContent(int testsId);
    }
}
