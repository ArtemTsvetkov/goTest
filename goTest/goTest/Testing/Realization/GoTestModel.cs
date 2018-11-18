using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.DataConverters;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Exceptions;
using goTest.Testing.Interfaces;
using goTest.Testing.Interfaces.Manipulators;
using goTest.Testing.Objects;
using goTest.Testing.Realization.Workers;
using goTest.Testing.Realization.Workers.Manipulators;
using goTest.Testing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization
{
    class GoTestModel : BasicModel<Test, string[]>, GoTestModelI 
    {
        private Test currentTest;
        private Test result;
        private Question selectedQuestion;
        private Unswer selectedUnswer;
        private TestObjectsSearcher searcher;
        private GoTestQueryConfiguratorI queryConfigurator;
        private TestManipulatorI testManipulator;
        private SubjectManipulatorI subjectManipulator;

        public GoTestModel()
        {
            queryConfigurator = new GoTestQueryConfigurator();
            subjectManipulator = new SubjectManipulator(queryConfigurator);
            UnswerManipalator unswerManipalator = new UnswerManipalator(queryConfigurator);
            testManipulator = new TestManipulator(unswerManipalator,
                subjectManipulator, queryConfigurator, 
                new QuestionManipulator(unswerManipalator, queryConfigurator));
            currentTest = new Test();
            searcher = new TestObjectsSearcher();
        }

        public void createSubject(string name)
        {
            try
            {
                Subject subject = new Subject();
                subject.Name = name;
                subjectManipulator.create(subject);
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void createTest(string name, string subjectName, int questionsNumber, 
            int requeredUnswersNumber)
        {
            try
            {
                currentTest = new Test();
                currentTest.Name = name;
                currentTest.RequeredUnswersNumber = requeredUnswersNumber;
                currentTest.QuestionsNumber = questionsNumber;

                Subject subject = new Subject();
                subject.Id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getSubjectId(subjectName)));
                currentTest.Subject = subject;


                testManipulator.create(currentTest);
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void deleteQuestion()
        {
            int pos = searcher.getQuestionPosition(currentTest.Questions, selectedQuestion);
            
            selectedQuestion = null;
            currentTest.Questions.RemoveAt(pos);
        }

        public void deleteUnswer()
        {
            int[] arg = searcher.getUnswerPosition(currentTest.Questions, selectedQuestion,
                selectedUnswer);

            selectedUnswer = null;
            currentTest.Questions.ElementAt(arg[0]).Unswers.RemoveAt(arg[1]);
        }

        public void getQuestionsFullContent()
        {
            result = new Test();
            result.Questions.Add(selectedQuestion);

            notifyObservers();
        }

        public override Test getResult()
        {
            return result;
        }

        public override void loadStore()
        {
            try
            {
                currentTest = testManipulator.load(config[0], config[1]);
                notifyObservers();
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void setUnswerSelection(Unswer unswer)
        {
            if (selectedUnswer != null)
            {
                selectedUnswer = null;
            }
            int[] arg = searcher.getUnswerPosition(currentTest.Questions, selectedQuestion,
                selectedUnswer);

            selectedUnswer = currentTest.Questions.ElementAt(arg[0]).
                Unswers.ElementAt(arg[1]);
        }

        public override void setConfig(string[] configData)
        {
            config = configData;
        }

        public void setQuestionSelection(Question question)
        {
            if (selectedQuestion != null)
            {
                selectedQuestion = null;
            }
            int pos = searcher.getQuestionPosition(currentTest.Questions, selectedQuestion);
            selectedQuestion = currentTest.Questions.ElementAt(pos);
        }

        public void updateSubject(string oldName, string newName)
        {
            try
            {
                int id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getSubjectId(oldName)));
                Subject sub = new Subject();
                sub.Id = id;
                sub.Name = newName;
                subjectManipulator.update(sub);
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void updateSelected(Question newVersion)
        {
            if (selectedQuestion != null)
            {
                int pos = searcher.getQuestionPosition(currentTest.Questions, selectedQuestion);

                currentTest.Questions.RemoveAt(pos);
                currentTest.Questions.Insert(pos, newVersion);
            }
            else
            {
                currentTest.Questions.Add(newVersion);
                selectedQuestion = currentTest.Questions.Last();
            }
        }

        public void updateSelected(Unswer newVersion)
        {
            if (selectedUnswer != null)
            {
                int[] pos = searcher.getUnswerPosition(currentTest.Questions, selectedQuestion,
                selectedUnswer);

                currentTest.Questions.ElementAt(pos[0]).Unswers.RemoveAt(pos[1]);
                currentTest.Questions.ElementAt(pos[0]).Unswers.Insert(pos[1], newVersion);
            }
            else
            {
                int pos = searcher.getQuestionPosition(currentTest.Questions, selectedQuestion);

                currentTest.Questions.ElementAt(pos).Unswers.Add(newVersion);
                selectedUnswer = currentTest.Questions.ElementAt(pos).Unswers.Last();
            }
        }

        public void updateTest(Test test)
        {
            try
            {
                testManipulator.update(currentTest);
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }
    }
}