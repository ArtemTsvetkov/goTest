using goTest.Testing.Interfaces;
using goTest.Testing.Objects;
using goTest.Testing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization
{
    class GoTestController : GoTestControllerI
    {
        //ДОБАВИТЬ БЛОКИ TRY CATCH
        private GoTestModel model;

        public GoTestController()
        {
            model = new GoTestModel();
        }

        public void addQueston(string shortContent, QuestionType questionsType)
        {
            model.addQuestion(shortContent, questionsType);
        }

        public void addUnswer(string content, bool isRightAnswer)
        {
            model.addUnswer(content, isRightAnswer);
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

        public void setUnswerSelection(string content, bool IsRight)
        {
            Unswer unswer = new Unswer();
            unswer.Content = content;
            unswer.IsRight = IsRight;

            model.setUnswerSelection(unswer);
        }

        public void setQuestionSelection(string questionsContent, 
            List<Unswer> unswers, QuestionType questionsType)
        {
            Question question = new Question();
            question.QuestionsContent = questionsContent;
            question.QuestionsType = questionsType;
            question.Unswers = unswers;

            model.setQuestionSelection(question);
        }

        public void updateSubject(string oldName, string newName)
        {
            model.updateSubject(oldName, newName);
        }

        public void getFullTestContent(int testsId)
        {
            model.setConfig(testsId);
            model.loadStore();
        }

        public void updateSelected(Question newVersion)
        {
            model.updateSelected(newVersion);
        }

        public void updateSelected(Unswer newVersion)
        {
            model.updateSelected(newVersion);
        }
    }
}
