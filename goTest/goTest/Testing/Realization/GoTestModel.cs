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
        private int currentQuestionIndex;
        private int currentNewObjectIndex = -1;
        private TestObjectsSearcher searcher;
        private GoTestTeacher teacher;
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

        public void updateTestInBD()
        {
            for(int i=0; i<store.Count; i++)
            {
                for (int m = 0; m < store.ElementAt(i).Tests.Count; m++)
                {
                    if(store.ElementAt(i).Tests.ElementAt(m).IsSelected)
                    {
                        try
                        {
                            testManipulator.update(store.ElementAt(i).Tests.ElementAt(m),
                                store.ElementAt(i).Id);
                        }
                        catch (ObjectIsNotExistYet ex)
                        {
                            testManipulator.create(store.ElementAt(i).Tests.ElementAt(m),
                                store.ElementAt(i).Id);
                        }
                        return;
                    }
                }
            }
        }

        public void createSubjectInBD(string name)
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
                    showInformationMessage("Предмет успешно добавлен.");
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
            int questionIndex = -1;
            IntHierarchy hi = searcher.getQuestionPosition(store, id);
            if (!hi.getLastListType().Equals(new Question().GetType()))
            {
                throw new GoTestObjectNotFound();
            }
            else
            {
                questionIndex = hi.getChild().getChild().value;
            }
            newVersion.Id = store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                    Questions.ElementAt(questionIndex).Id;
            store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                    Questions.RemoveAt(questionIndex);
            store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                Questions.Insert(questionIndex, newVersion);
            notifyObservers();
        }

        public void update(int id, Unswer newVersion)
        {
            IntHierarchy hi = searcher.getQuestionPosition(store, id);
            int questionIndex = -1;
            int unswerIndex = -1;
            if (!hi.getLastListType().Equals(new Unswer().GetType()))
            {
                throw new GoTestObjectNotFound();
            }
            else
            {
                questionIndex = hi.getChild().getChild().value;
                unswerIndex = hi.getChild().getChild().getChild().value;
            }

            int rightUnswersCount = 1;
            Question question = store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                Questions.ElementAt(questionIndex);
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
            newVersion.Id = store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                Questions.ElementAt(questionIndex).Unswers.ElementAt(unswerIndex).Id;
            store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                Questions.ElementAt(questionIndex).Unswers.
                RemoveAt(unswerIndex);
            store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).
                Questions.ElementAt(questionIndex).Unswers.
                Insert(unswerIndex, newVersion);


            notifyObservers();
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
                    test.Id = store.ElementAt(hi.value).Tests.ElementAt(hi.getChild().value).Id;
                    store.ElementAt(hi.value).Tests.RemoveAt(hi.getChild().value);
                    store.ElementAt(hi.value).Tests.Insert(hi.getChild().value, test);
                    notifyObservers();
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

        public Subject getSubjectFromBD(int id)
        {
            string name = DataSetConverter.fromDsToSingle.toString.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getObjectName(id)));

            return subjectManipulator.load(name, true, true);
        }

        public void loadAllTestContentFromBD(int testId)
        {
            Subject newSubject = new Subject();
            newSubject.Id = DataSetConverter.fromDsToSingle.toInt.
                    convert(SqlLiteSimpleExecute.execute(queryConfigurator.loadSubjectId(testId)));
            Test loadTest = testManipulator.load(testId, true, false);
            loadTest.IsSelected = true;

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

        public void addEmptyQuestion()
        {
            Test test = getCurrentTest();
            Question newQuestion = new Question();
            newQuestion.Id = currentNewObjectIndex;
            currentNewObjectIndex--;
            test.Questions.Add(newQuestion);
            notifyObservers();
        }

        public void addEmptyUnswer(int questionId)
        {
            Test test = getCurrentTest();
            for(int i=0; i<test.Questions.Count; i++)
            {
                if(test.Questions.ElementAt(i).Id == questionId)
                {
                    Unswer newUnswer = new Unswer();
                    newUnswer.Id = currentNewObjectIndex;
                    test.Questions.ElementAt(i).Unswers.Add(newUnswer);
                    currentNewObjectIndex--;
                    notifyObservers();
                    return;
                }
            }
            throw new GoTestObjectNotFound();
        }

        public void loadTestForTesting(int testId)
        {
            Subject newSubject = new Subject();
            newSubject.Id = DataSetConverter.fromDsToSingle.toInt.
                    convert(SqlLiteSimpleExecute.execute(queryConfigurator.loadSubjectId(testId)));
            Test loadTest = testManipulator.load(testId, false, false);
            loadTest.IsSelected = true;

            bool testAlreadyPreLoad = false;
            int subjectPosition = -1;
            for (int i = 0; i < store.Count; i++)
            {
                if (store.ElementAt(i).Id == newSubject.Id)
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
                for (int i = 0; i < config.ElementAt(subjectPosition).Tests.Count; i++)
                {
                    if (config.ElementAt(subjectPosition).Tests.ElementAt(i).Id == testId)
                    {
                        config.ElementAt(subjectPosition).Tests.RemoveAt(i);
                        config.ElementAt(subjectPosition).Tests.Insert(i, loadTest);
                        setConfig(config);
                        break;
                    }
                }
            }
            currentQuestionIndex = 0;
            loadStore();
            teacher = new GoTestTeacher(loadTest);
        }

        public Test getCurrentTest()
        {
            for (int i = 0; i < store.Count; i++)
            {
                for (int m = 0; m < store.ElementAt(i).Tests.Count; m++)
                {
                    if (store.ElementAt(i).Tests.ElementAt(m).IsSelected)
                    {
                        return store.ElementAt(i).Tests.ElementAt(m);
                    }
                }
            }
            throw new GoTestObjectNotFound();
        }

        public Question getNextQuestion()
        {
            Test test = getCurrentTest();
            if(test.Questions.Count-1 < currentQuestionIndex)
            {
                throw new QuestionsIsOver();
            }
            else
            {
                currentQuestionIndex++;
                return test.Questions.ElementAt(currentQuestionIndex-1);
            }
        }

        public void userUnswered(int[] id)
        {
            teacher.userUnswered(id);
            notifyObservers();
        }

        public void showTestResults()
        {
            notifyObservers();
        }

        public void addEmptyTest()
        {
            Subject newSubject = new Subject();
            Test newTest = new Test();
            newTest.IsSelected = true;
            newTest.Id = currentNewObjectIndex;
            newSubject.Tests.Add(newTest);
            currentNewObjectIndex--;
            config.Add(newSubject);
            loadStore();
        }

        public void setSubjectForSelectedTest(int subjectId)
        {
            int currentSubjectIndex = getSelectedSubjectIndexBaseOnSelectedTest();
            for (int m = 0; m < store.ElementAt(currentSubjectIndex).Tests.Count; m++)
            {
                if (store.ElementAt(currentSubjectIndex).Tests.ElementAt(m).IsSelected)
                {
                    Test currentTest = store.ElementAt(currentSubjectIndex).Tests.ElementAt(m);
                    store.ElementAt(currentSubjectIndex).Tests.RemoveAt(m);
                    store.ElementAt(getSubjectIndex(subjectId)).Tests.Add(currentTest);
                    notifyObservers();
                    return;
                }
            }
            throw new GoTestObjectNotFound();
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

        private int getSubjectIndex(int subjectId)
        {
            for (int m = 0; m < store.Count; m++)
            {
                if(store.ElementAt(m).Id==subjectId)
                {
                    return m;
                }
            }
            throw new GoTestObjectNotFound();
        }

        private int getSelectedSubjectIndexBaseOnSelectedTest()
        {
            for (int i = 0; i < store.Count; i++)
            {
                for (int m = 0; m < store.ElementAt(i).Tests.Count; m++)
                {
                    if (store.ElementAt(i).Tests.ElementAt(m).IsSelected)
                    {
                        return i;
                    }
                }
            }
            throw new GoTestObjectNotFound();
        }

        private int searchUnswerWithZeroIdInQuestionWithZeroId(Question question)
        {
            for (int i = 0; i < question.Unswers.Count; i++)
            {
                if (question.Unswers.ElementAt(i).Id == 0)
                {
                    return i;
                }
            }
            throw new GoTestObjectNotFound();
        }

        public int getCountOfRightUnswersOnTest()
        {
            return teacher.getCountOfRightUnswers();
        }
    }
}