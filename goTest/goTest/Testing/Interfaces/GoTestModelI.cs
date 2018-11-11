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
        void addQueston(string shortContent);
        void deleteQuestion();
        void addUnswer(string content, bool isRightAnswer);
        void deleteUnswer();
        void getQuestionsFullContent();
        void setQuestionSelection(int position);
        void setAnswerSelection(int position);
    }
}
