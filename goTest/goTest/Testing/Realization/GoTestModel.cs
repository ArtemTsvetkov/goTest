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
    class GoTestModel : BasicModel<List<Subject>, Config>, GoTestModelI 
    {
        private List<Subject> store;
        private List<Subject> result;
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
            store = new List<Subject>();
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
                Subject subject = new Subject();
                Test currentTest = new Test();
                currentTest.Name = name;
                currentTest.RequeredUnswersNumber = requeredUnswersNumber;
                currentTest.QuestionsNumber = questionsNumber;

                subject.Id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getSubjectId(subjectName)));
                subject.Tests.Add(currentTest);


                testManipulator.create(subject);
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void deleteQuestion()
        {
            int pos = searcher.getQuestionPosition(store.ElementAt(0).Tests.ElementAt(0).
                Questions, selectedQuestion.Id);
            
            selectedQuestion = null;
            store.ElementAt(0).Tests.ElementAt(0).Questions.RemoveAt(pos);
        }

        public void deleteUnswer()
        {
            int[] arg = searcher.getUnswerPosition(store.ElementAt(0).Tests.ElementAt(0).
                Questions, selectedQuestion.Id, selectedUnswer.Id);

            selectedUnswer = null;
            store.ElementAt(0).Tests.ElementAt(0).Questions.ElementAt(arg[0]).Unswers.
                RemoveAt(arg[1]);
        }

        public void getQuestionsFullContent()
        {
            result = new List<Subject>();
            Subject subject = new Subject();
            Test test = new Test();
            test.Questions.Add(selectedQuestion);
            subject.Tests.Add(test);
            result.Add(subject);

            notifyObservers();
        }

        public override List<Subject> getResult()
        {
            return result;
        }

        public override void loadStore()
        {
            try
            {
                store = config.loadStore();
                notifyObservers();
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void setUnswerSelection(int id)
        {
            if (selectedUnswer != null)
            {
                selectedUnswer = null;
            }
            int[] arg = searcher.getUnswerPosition(store.ElementAt(0).Tests.ElementAt(0).
                Questions, selectedQuestion.Id, id);

            selectedUnswer = store.ElementAt(0).Tests.ElementAt(0).Questions.ElementAt(arg[0]).
                Unswers.ElementAt(arg[1]);
        }

        public override void setConfig(Config configData)
        {
            config = configData;
        }

        public void setQuestionSelection(int id)
        {
            if (selectedQuestion != null)
            {
                selectedQuestion = null;
            }
            int pos = searcher.getQuestionPosition(store.ElementAt(0).Tests.ElementAt(0).
                Questions, id);
            selectedQuestion = store.ElementAt(0).Tests.ElementAt(0).Questions.ElementAt(pos);
        }

        public void updateSubject(int id, string newName)
        {
            try
            {
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
                int pos = searcher.getQuestionPosition(store.ElementAt(0).Tests.ElementAt(0)
                    .Questions, selectedQuestion.Id);

                store.ElementAt(0).Tests.ElementAt(0).Questions.RemoveAt(pos);
                store.ElementAt(0).Tests.ElementAt(0).Questions.Insert(pos, newVersion);
            }
            else
            {
                store.ElementAt(0).Tests.ElementAt(0).Questions.Add(newVersion);
                selectedQuestion = store.ElementAt(0).Tests.ElementAt(0).Questions.Last();
            }
        }

        public void updateSelected(Unswer newVersion)
        {
            if (selectedUnswer != null)
            {
                int[] pos = searcher.getUnswerPosition(store.ElementAt(0).Tests.ElementAt(0)
                    .Questions, selectedQuestion.Id, selectedUnswer.Id);

                store.ElementAt(0).Tests.ElementAt(0).Questions.ElementAt(pos[0]).Unswers.
                    RemoveAt(pos[1]);
                store.ElementAt(0).Tests.ElementAt(0).Questions.ElementAt(pos[0]).Unswers.
                    Insert(pos[1], newVersion);
            }
            else
            {
                int pos = searcher.getQuestionPosition(store.ElementAt(0).Tests.ElementAt(0).
                    Questions, selectedQuestion.Id);

                store.ElementAt(0).Tests.ElementAt(0).Questions.ElementAt(pos).
                    Unswers.Add(newVersion);
                selectedUnswer = store.ElementAt(0).Tests.ElementAt(0).Questions.
                    ElementAt(pos).Unswers.Last();
            }
        }

        public void updateTest(Test test)
        {
            try
            {
                testManipulator.update(store.ElementAt(0));
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }
    }
}