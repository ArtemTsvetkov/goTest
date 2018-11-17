using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.DataConverters;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Exceptions;
using goTest.Testing.Interfaces;
using goTest.Testing.Objects;
using goTest.Testing.Realization.Workers;
using goTest.Testing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization
{
    class GoTestModel : BasicModel<Test, int>, GoTestModelI 
    {
        private Test currentTest;
        private Test result;
        private Question selectedQuestion;
        private Unswer selectedUnswer;
        private TestObjectsSearcher searcher;
        private GoTestQueryConfiguratorI queryConfigurator;
        private TestCreator testCreator;
        private TestLoader testLoader;

        public GoTestModel()
        {
            //queryConfigurator = new GoTestQueryConfigurator();
            currentTest = new Test();
            searcher = new TestObjectsSearcher();
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

            int pos = searcher.getQuestionPosition(currentTest.Questions, selectedQuestion);
            currentTest.Questions.ElementAt(pos).Unswers.Add(unswer);
            selectedQuestion = currentTest.Questions.ElementAt(pos);
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
            currentTest = testLoader.load(config);
            notifyObservers();
        }

        public void setUnswerSelection(Unswer unswer)
        {
            int[] arg = searcher.getUnswerPosition(currentTest.Questions, selectedQuestion,
                selectedUnswer);

            selectedUnswer = currentTest.Questions.ElementAt(arg[0]).
                Unswers.ElementAt(arg[1]);
        }

        public override void setConfig(int configData)
        {
            config = configData;
        }

        public void setQuestionSelection(Question question)
        {
            int pos = searcher.getQuestionPosition(currentTest.Questions, selectedQuestion);
            selectedQuestion = currentTest.Questions.ElementAt(pos);
        }

        public void updateSubject(string oldName, string newName)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.updateSubject(
            oldName, newName));
        }
    }
}