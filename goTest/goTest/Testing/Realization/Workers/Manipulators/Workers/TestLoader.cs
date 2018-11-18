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
    class TestLoader
    {
        UnswerManipalatorI unswerManipalator;
        SubjectManipulatorI subjectManipulator;
        GoTestQueryConfiguratorI queryConfigurator;
        QuestionManipulatorI questionManipulator;
        RandomQuestionsGetter questionsGetter;

        public TestLoader(UnswerManipalatorI unswerManipalator,
            SubjectManipulatorI subjectManipulator,
            GoTestQueryConfiguratorI goTestQueryConfigurator,
            QuestionManipulatorI questionManipulator)
        {
            this.subjectManipulator = subjectManipulator;
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
            this.questionManipulator = questionManipulator;
            questionsGetter = new RandomQuestionsGetter(unswerManipalator,
            goTestQueryConfigurator, questionManipulator);
        }

        public Test load(string subject, string testName)
        {
            int id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getTestId(subject, testName)));
            Test test = new Test();
            test.Name = testName;

            test.Subject = subjectManipulator.load(subject);

            test.QuestionsNumber = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getQuestionsNumber(id)));

            test.RequeredUnswersNumber = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getRequeredUnswersNumber(id)));

            int[] questionsIds = DataSetConverter.fromDsToBuf.toIntBuf.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getRequeredUnswersNumber(id)));
            
            test.Questions = questionsGetter.get(questionsIds, test.QuestionsNumber);


            return test;
        }
    }
}
