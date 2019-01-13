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
        private GoTestModel model;

        public GoTestController(GoTestModel model)
        {
            this.model = model;
        }

        public void createSubject(string name)
        {
            model.createSubjectInBD(name);
        }

        public void deleteQuestion(int questionId)
        {
            model.deleteQuestion(questionId);
        }

        public void deleteUnswer(int unswerId)
        {
            model.deleteUnswer(unswerId);
        }

        public void updateSubject(int id, string newName)
        {
            model.updateSubject(id, newName);
        }

        public void getFullTestContent(int testId)
        {
            try
            {
                int[] ids = model.getAllSubjectIds();
                List<Subject> subjects = new List<Subject>();
                for (int i = 0; i < ids.Length; i++)
                {
                    subjects.Add(model.getSubjectFromBD(ids[i]));
                }
                model.setConfig(subjects);
                model.loadAllTestContentFromBD(testId);
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void update(int questionId, Question newVersion)
        {
            try
            {
                model.update(questionId, newVersion);
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void update(int unswerId, Unswer newVersion)
        {
            try
            {
                model.update(unswerId, newVersion);
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void update(int testId, Test newVersion)
        {
            try
            {
                model.update(testId, newVersion);
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
                subjects.Add(model.getSubjectFromBD(ids[i]));
            }
            model.setConfig(subjects);
            model.loadStore();
        }

        public void updateTestInBD()
        {
            model.updateTestInBD();
        }

        public void addEmptyQuestion()
        {
            model.addEmptyQuestion();
        }

        public void addEmptyUnswer(int questionId)
        {
            model.addEmptyUnswer(questionId);
        }

        public void loadTestForTesting(int testId)
        {
            try
            {
                int[] ids = model.getAllSubjectIds();
                List<Subject> subjects = new List<Subject>();
                for (int i = 0; i < ids.Length; i++)
                {
                    subjects.Add(model.getSubjectFromBD(ids[i]));
                }
                model.setConfig(subjects);
                model.loadTestForTesting(testId);
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void userUnswered(int[] id)
        {
            model.userUnswered(id);
        }

        public void showTestResults()
        {
            model.showTestResults();
        }

        public void setSubjectForSelectedTest(int subjectId)
        {
            model.setSubjectForSelectedTest(subjectId);
        }

        public void addEmptyTest()
        {
            model.addEmptyTest();
        }
    }
}
