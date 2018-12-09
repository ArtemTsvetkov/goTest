using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.DataConverters;
using goTest.CommonComponents.DataConverters.Exceptions;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.CommonComponents.ExceptionHandler.View.Information.PopupWindow;
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
    class GoTestModel : BasicModel<List<Subject>, List<Subject>>, GoTestModelI 
    {
        private List<Subject> store;
        private TestObjectsSearcher searcher;
        private GoTestQueryConfiguratorI queryConfigurator;
        private TestManipulatorI testManipulator;
        private SubjectManipulatorI subjectManipulator;

        public GoTestModel()
        {
            queryConfigurator = new GoTestQueryConfigurator();
            UnswerManipalator unswerManipalator = new UnswerManipalator(queryConfigurator);
            testManipulator = new TestManipulator(unswerManipalator, queryConfigurator, 
                new QuestionManipulator(unswerManipalator, queryConfigurator));
            subjectManipulator = new SubjectManipulator(queryConfigurator, testManipulator);
            store = new List<Subject>();
            searcher = new TestObjectsSearcher();
        }

        public void createSubject(string name)
        {
            Subject subject = new Subject();
            subject.Name = name;
            try
            {
                subjectManipulator.load(subject.Name, true, false);
                throw new ObjectAlreadyCreated();  
            }
            catch (ObjectAlreadyCreated ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
            catch (СonversionError ex)
            {
                try
                {
                    subjectManipulator.create(subject);
                    showInformationMessage("Дисциплина успешно добавлена");
                }
                catch(Exception e)
                {
                    ExceptionHandler.getInstance().processing(e);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        private void showInformationMessage(string message)
        {
            InformationPopupWindow view = new InformationPopupWindow();
            InformationPopupWindowConfig config = new InformationPopupWindowConfig(message);
            view.setConfig(config);
            view.show();
        }

        public void createTest(string name, int subjectId, int questionsNumber, 
            int requeredUnswersNumber)
        {
            try
            {
                try
                {
                    int[] id = DataSetConverter.fromDsToBuf.toIntBuf.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getObjectIdsInDevelopStatus()));
                    if(id.Length>0)
                    {
                        string ids = "";
                        for (int i=0; i<id.Length; i++)
                        {
                            ids += id[i] + ";";
                        }
                        throw new NotApprowedObjectsFound("Нельзя создать тест, пока существуют "+
                            "объекты без статуса Approve:"+ids);
                    }
                }
                catch(СonversionError er)
                {
                }

                Subject subject = new Subject();
                Test currentTest = new Test();
                currentTest.Name = name;
                currentTest.RequeredUnswersNumber = requeredUnswersNumber;
                currentTest.QuestionsNumber = questionsNumber;

                subject.Id = subjectId;
                subject.Tests.Add(currentTest);

                List<Subject> newConfig = new List<Subject>();
                newConfig.Add(subject);

                setConfig(newConfig);
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public void deleteQuestion(int id)
        {
            IntHierarchy hi = searcher.getQuestionPosition(store, id);
            if(!hi.getLastListType().Equals(new Question().GetType()))
            {
                throw new GoTestObjectNotFound();
            }
            else
            {
                store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                    Questions.RemoveAt(hi.getChild().getChild().value);
                notifyObservers();
            }
        }

        public void deleteUnswer(int unswerId)
        {
            IntHierarchy hi = searcher.getQuestionPosition(store, unswerId);
            if (!hi.getLastListType().Equals(new Unswer().GetType()))
            {
                throw new GoTestObjectNotFound();
            }
            else
            {
                store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                    Questions.ElementAt(hi.getChild().getChild().value).Unswers.
                    RemoveAt(hi.getChild().getChild().getChild().value);
                notifyObservers();
            }  
        }

        public override List<Subject> getResult()
        {
            return store;
        }

        public override void loadStore()
        {
            try
            {
                store = copy(config);
                notifyObservers();
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public override void setConfig(List<Subject> configData)
        {
            config = copy(configData);
        }

        private List<Subject> copy(List<Subject> obj)
        {
            List<Subject> copy = new List<Subject>();
            for (int i = 0; i < obj.Count; i++)
            {
                copy.Add(obj.ElementAt(i).copy());
            }

            return copy;
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

        public void update(int id, Question newVersion)
        {
            IntHierarchy hi = searcher.getQuestionPosition(store, id);
            if (!hi.getLastListType().Equals(new Question().GetType()))
            {
                throw new GoTestObjectNotFound();
            }
            else
            {
                store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                    Questions.RemoveAt(hi.getChild().getChild().value);
                store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                    Questions.Insert(hi.getChild().getChild().value, newVersion);
                notifyObservers();
            }
        }

        public void update(int id, Unswer newVersion)
        {
            IntHierarchy hi = searcher.getQuestionPosition(store, id);
            if (!hi.getLastListType().Equals(new Unswer().GetType()))
            {
                throw new GoTestObjectNotFound();
            }
            else
            {
                int rightUnswersCount = 1;
                Question question = store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                    Questions.ElementAt(hi.getChild().getChild().value);
                for (int i = 0; i < question.Unswers.Count; i++)
                {
                    if (question.Unswers.ElementAt(i).IsRight)
                    {
                        rightUnswersCount++;
                    }
                }
                if (rightUnswersCount > 1)
                {
                    question.QuestionsType = QuestionTypes.multiplyAnswer;
                }
                else
                {
                    question.QuestionsType = QuestionTypes.singleAnswer;
                }
                store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                    Questions.ElementAt(hi.getChild().getChild().value).Unswers.
                    RemoveAt(hi.getChild().getChild().getChild().value);
                store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                    Questions.ElementAt(hi.getChild().getChild().value).Unswers.
                    Insert(hi.getChild().getChild().getChild().value, newVersion);


                notifyObservers();
            }
        }

        public void update(int id, Test test)
        {
            try
            {
                IntHierarchy hi = searcher.getTestPosition(store, id);
                if (!hi.getLastListType().Equals(new Test().GetType()))
                {
                    throw new GoTestObjectNotFound();
                }
                else
                {
                    store.ElementAt(hi.value).Tests.RemoveAt(hi.getChild().value);
                    store.ElementAt(hi.value).Tests.Insert(hi.getChild().value, test);
                } 
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        public int[] getAllSubjectIds()
        {
            return DataSetConverter.fromDsToBuf.toIntBuf.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getAllSubjectIds()));
        }

        public Subject getSubject(int id)
        {
            string name = DataSetConverter.fromDsToSingle.toString.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getObjectName(id)));

            return subjectManipulator.load(name, true, true);
        }

        public void loadAllTestContent(int testId)
        {
            Subject newSubject = new Subject();
            newSubject.Id = DataSetConverter.fromDsToSingle.toInt.
                    convert(SqlLiteSimpleExecute.execute(queryConfigurator.loadSubjectId(testId)));
            Test loadTest = testManipulator.load(testId, true, false);

            bool testAlreadyPreLoad = false;
            int subjectPosition = -1;
            for(int i=0; i<store.Count; i++)
            {
                if(store.ElementAt(i).Id == newSubject.Id)
                {
                    testAlreadyPreLoad = true;
                    subjectPosition = i;
                    break;
                }
            }

            if (!testAlreadyPreLoad)
            {
                List<Subject> newConfig = new List<Subject>();
                newSubject.Tests.Add(loadTest);
                newSubject.Name = DataSetConverter.fromDsToSingle.toString.
                    convert(SqlLiteSimpleExecute.execute(queryConfigurator.
                    loadSubjectName(newSubject.Id)));
                newConfig.Add(newSubject);
                setConfig(newConfig);
            }
            else
            {
                for(int i=0; i<config.ElementAt(subjectPosition).Tests.Count; i++)
                {
                    if(config.ElementAt(subjectPosition).Tests.ElementAt(i).Id == testId)
                    {
                        config.ElementAt(subjectPosition).Tests.RemoveAt(i);
                        config.ElementAt(subjectPosition).Tests.Insert(i, loadTest);
                        setConfig(config);
                        break;
                    }
                }
            }

            loadStore();
        }
    }
}