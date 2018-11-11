using goTest.Testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization
{
    class GoTestController : GoTestControllerI
    {
        private GoTestModel model;

        public GoTestController()
        {
            model = new GoTestModel();
        }

        public void addEmptyQuestonArea()
        {
            model.addQueston("");
        }

        public void addEmptyUnswerArea()
        {
            model.addUnswer("", false);
        }

        public void createSubject(string name)
        {
            model.createSubject(name);
        }

        public void createTest(string name, string subject, int questionsNumber, int requeredUnswersNumber)
        {
            model.createTest(name, subject, questionsNumber, requeredUnswersNumber);
        }

        public void deleteQuestion()
        {
            model.deleteQuestion();
        }

        public void deleteUnswer()
        {
            model.deleteUnswer();
        }

        public void getFullQuestionContent()
        {
            model.getQuestionsFullContent();
        }

        public void setAnswerSelection(int position)
        {
            model.setAnswerSelection(position);
        }

        public void setQuestionSelection(int position)
        {
            model.setQuestionSelection(position);
        }

        public void updateSubject(string oldName, string newName)
        {
            model.updateSubject(oldName, newName);
        }
    }
}
