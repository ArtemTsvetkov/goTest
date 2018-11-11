using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.DataConverters;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Interfaces;
using goTest.Testing.Objects;
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
        private GoTestQueryConfiguratorI queryConfigurator;
        private TestCreator testCreator;

        public GoTestModel()
        {
            //queryConfigurator = new GoTestQueryConfigurator();
            currentTest = new Test();
        }

        public void addQueston(string shortContent)
        {
            throw new NotImplementedException();
        }

        public void addUnswer(string content, bool isRightAnswer)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void deleteUnswer()
        {
            throw new NotImplementedException();
        }

        public void getQuestionsFullContent()
        {
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

        public void setAnswerSelection(int position)
        {
            throw new NotImplementedException();
        }

        public override void setConfig(NullType configData)
        {
            throw new NotImplementedException();
        }

        public void setQuestionSelection(int position)
        {
            throw new NotImplementedException();
        }

        public void updateSubject(string oldName, string newName)
        {
            throw new NotImplementedException();
        }
    }
}