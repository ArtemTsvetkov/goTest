using goTest.CommonComponents.ExceptionHandler.Realization;
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

        public GoTestController(GoTestModel model)
        {
            this.model = model;
        }

        public void createSubject(string name)
        {
            model.createSubject(name);
        }

        public void createTest(string name, int subjectId, int questionsNumber, 
            int requeredUnswersNumber)
        {
            model.createTest(name, subjectId, questionsNumber, requeredUnswersNumber);
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
            model.loadAllTestContent(testId);
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

        public void loadAllSubjects()
        {
            int[] ids = model.getAllSubjectIds();
            List<Subject> subjects = new List<Subject>();
            for (int i=0; i<ids.Length; i++)
            {
                subjects.Add(model.getSubject(ids[i]));
            }
            model.setConfig(subjects);
            model.loadStore();
        }
    }
}
