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
        void updateSubject(string oldName, string newName);
        void addQuestion(string shortContent, QuestionType questionsType);
        void deleteQuestion();
        void addUnswer(string content, bool isRightAnswer);
        void deleteUnswer();
        void getQuestionsFullContent();
        void setQuestionSelection(Question question);
        void setUnswerSelection(Unswer unswer);
        void updateSelected(Question newVersion);
        void updateSelected(Unswer newVersion);
    }
}
