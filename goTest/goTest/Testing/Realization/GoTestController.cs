using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.Testing.Interfaces;
using goTest.Testing.Objects;
using goTest.Testing.Realization.Workers.Configs;
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

        public void createSubject(string name)
        {
            model.createSubject(name);
        }

        public void createTest(string name, string subject, int questionsNumber, 
            int requeredUnswersNumber)
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

        public void setUnswerSelection(int id)
        {
            model.setUnswerSelection(id);
        }

        public void setQuestionSelection(int id)
        {
            model.setQuestionSelection(id);
        }

        public void updateSubject(int id, string newName)
        {
            model.updateSubject(id, newName);
        }

        public void getFullTestContent(int testId)
        {
            Config config = new GetTestContentConfig();
            model.setConfig(config);
            model.loadStore();
        }

        public void updateSelected(Question newVersion)
        {
            try
            {
                model.updateSelected(newVersion);
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void updateSelected(Unswer newVersion)
        {
            try
            {
                model.updateSelected(newVersion);
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }
    }
}
