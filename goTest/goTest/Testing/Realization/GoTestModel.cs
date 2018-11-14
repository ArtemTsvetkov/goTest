using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.DataConverters;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Exceptions;
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
    class GoTestModel : BasicModel<NullType, NullType>, GoTestModelI 
    {
        private Test currentTest;
        private Question selectedQuestion;
        private Unswer selectedUnswer;
        private GoTestQueryConfiguratorI queryConfigurator;
        private TestCreator testCreator;

        public GoTestModel()
        {
            //queryConfigurator = new GoTestQueryConfigurator();
            currentTest = new Test();
        }

        public void addQuestion(string shortContent, QuestionType questionsType)
        {
            Question queston = new Question();
            queston.QuestionsContent = shortContent;
            queston.QuestionsType = questionsType;

            currentTest.Questions.Add(queston);
        }

        public void addUnswer(string content, bool isRightAnswer)
        {
            //ДОБАВИТЬ ПРОВЕРКУ, ЭТОТ ВОПРОС С ЕДИНСТВЕННЫМ ОТВЕТОМ, ИЛИ С МНОЖЕСТВЕННЫМ
            Unswer unswer = new Unswer();
            unswer.Content = content;
            unswer.IsRight = isRightAnswer;
            //ДОБАВИТЬ ЕДИНЫЙ МЕТОД ПОИСКА ВМЕСТО ЭТОГО И АНАЛОГИЧНЫХ БЛОКОВ МОДЕЛИ
            for (int i = 0; i < currentTest.Questions.Count; i++)
            {
                if (currentTest.Questions.ElementAt(i).compare(selectedQuestion))
                {
                    currentTest.Questions.ElementAt(i).Unswers.Add(unswer);
                    selectedQuestion.Unswers.Add(unswer);
                }
            }

            throw new GoTestObjectNotFound();
        }

        public void createSubject(string name)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.createSubject(
            name));
        }

        public void createTest(string name, string subjectName, int questionsNumber, 
            int requeredUnswersNumber)
        {
            currentTest.Name = name;
            currentTest.RequeredUnswersNumber = requeredUnswersNumber;
            currentTest.QuestionsNumber = questionsNumber;

            Subject subject = new Subject();
            subject.Id = DataSetConverter.fromDsToSingle.toString.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getSubjectId(subjectName)));
            currentTest.Subject = subject;


            testCreator.create(currentTest);
        }

        public void deleteQuestion()
        {
            for (int i = 0; i < currentTest.Questions.Count; i++)
            {
                if (currentTest.Questions.ElementAt(i).compare(selectedQuestion))
                {
                    selectedQuestion = null;
                    currentTest.Questions.RemoveAt(i);
                    return;
                }
            }

            throw new GoTestObjectNotFound();
        }

        public void deleteUnswer()
        {
            for (int i = 0; i < currentTest.Questions.Count; i++)
            {
                if (currentTest.Questions.ElementAt(i).compare(selectedQuestion))
                {
                    for (int h = 0; h < currentTest.Questions.ElementAt(i).Unswers.Count; h++)
                    {
                        if (currentTest.Questions.ElementAt(i).Unswers.ElementAt(i).
                                compare(selectedUnswer))
                        {
                            selectedUnswer = null;
                            currentTest.Questions.ElementAt(i).Unswers.RemoveAt(i);
                            return;
                        }
                    }

                    throw new GoTestObjectNotFound();
                }
            }

            throw new GoTestObjectNotFound();
        }

        public void getQuestionsFullContent()
        {
            //ВМЕСТО ЭТОГО УВЕДОМИТЬ ОБСЕРВЕРА ЧТО ЕСТЬ ИЗМЕНЕНИЕ
            //ПОСЛЕ ЧЕГО ОБСЕРВЕР ЧЕРЕЗ ГЕТ РЕЗУЛЬТ ВОЗЬМЕТ ПОЛНЫЙ КОНТЕНТ ОТВЕТА
            throw new NotImplementedException();
        }

        public override NullType getResult()
        {
            throw new NotImplementedException();
        }

        public override void loadStore()
        {
            throw new NotImplementedException();
        }

        public void setUnswerSelection(Unswer unswer)
        {
            for (int i = 0; i < currentTest.Questions.Count; i++)
            {
                if (currentTest.Questions.ElementAt(i).compare(selectedQuestion))
                {
                    for (int h = 0; h < currentTest.Questions.ElementAt(i).Unswers.Count; h++)
                    {
                        if (currentTest.Questions.ElementAt(i).Unswers.ElementAt(i).
                                compare(unswer))
                        {
                            selectedUnswer = currentTest.Questions.ElementAt(i).
                                Unswers.ElementAt(i);
                            return;
                        }
                    }

                    throw new GoTestObjectNotFound();
                }
            }

            throw new GoTestObjectNotFound();
        }

        public override void setConfig(NullType configData)
        {
            throw new NotImplementedException();
        }

        public void setQuestionSelection(Question question)
        {
            for(int i=0; i<currentTest.Questions.Count; i++)
            {
                if(currentTest.Questions.ElementAt(i).compare(question))
                {
                    selectedQuestion = currentTest.Questions.ElementAt(i);
                    return;
                }
            }

            throw new GoTestObjectNotFound();
        }

        public void updateSubject(string oldName, string newName)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.updateSubject(
            oldName, newName));
        }
    }
}