using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces.Manipulators.Workers
{
    class TestCreator
    {
        UnswerManipalatorI unswerManipalator;
        SubjectManipulatorI subjectManipulator;
        GoTestQueryConfiguratorI queryConfigurator;
        QuestionManipulatorI questionManipulator;

        public TestCreator(UnswerManipalatorI unswerManipalator,
            SubjectManipulatorI subjectManipulator,
            GoTestQueryConfiguratorI goTestQueryConfigurator,
            QuestionManipulatorI questionManipulator)
        {
            this.subjectManipulator = subjectManipulator;
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
            this.questionManipulator = questionManipulator;
        }

        public void create(Test test)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.createTest(test.Subject.Id, test.Name));
            int id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getTestId(test.Subject.Name, test.Name)));

            SqlLiteSimpleExecute.execute(queryConfigurator.
                setTestsQuestionsNumber(id, test.QuestionsNumber));

            SqlLiteSimpleExecute.execute(queryConfigurator.
                setTestsRequeredUnswersNumber(id, test.RequeredUnswersNumber));

            for(int i=0; i<test.Questions.Count; i++)
            {
                questionManipulator.create(test.Questions.ElementAt(i),id);
            }
        }
    }
}
