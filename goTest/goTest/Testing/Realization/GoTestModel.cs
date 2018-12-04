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
                store = copy(config);
                result = copy(config);
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
                testManipulator.update(store.ElementAt(0).Tests.ElementAt(0), store.ElementAt(0).Id);
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
            List<Subject> newConfig = new List<Subject>();
            Subject newSubject = new Subject();
            newSubject.Tests.Add(testManipulator.load(testId, true, false));
            newSubject.Id = DataSetConverter.fromDsToSingle.toInt.
                convert(SqlLiteSimpleExecute.execute(queryConfigurator.loadSubjectId(testId)));
            newSubject.Name = DataSetConverter.fromDsToSingle.toString.
                convert(SqlLiteSimpleExecute.execute(queryConfigurator.
                loadSubjectName(newSubject.Id)));
            newConfig.Add(newSubject);

            setConfig(newConfig);
            loadStore();
        }
    }
}