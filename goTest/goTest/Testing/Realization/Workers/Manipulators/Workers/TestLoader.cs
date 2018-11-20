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

        public Subject load(int testId)
        {
            int subjId = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getSubjectId(testId)));
            Subject sub = new Subject();
            sub.Tests.ElementAt(0).Id = testId;
            sub.Tests.ElementAt(0).Name = DataSetConverter.fromDsToSingle.toString.
                convert(SqlLiteSimpleExecute.execute(queryConfigurator.getTestName(testId)));

            sub = subjectManipulator.load(DataSetConverter.fromDsToSingle.toString.
                convert(SqlLiteSimpleExecute.execute(queryConfigurator.getSubjectName(testId))));

            sub.Tests.ElementAt(0).QuestionsNumber = DataSetConverter.fromDsToSingle.toInt.
                convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getQuestionsNumber(testId)));

            sub.Tests.ElementAt(0).RequeredUnswersNumber = DataSetConverter.fromDsToSingle.toInt.
                convert(SqlLiteSimpleExecute.execute(queryConfigurator.getRequeredUnswersNumber(
                    testId)));

            int[] questionsIds = DataSetConverter.fromDsToBuf.toIntBuf.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getRequeredUnswersNumber(testId)));

            sub.Tests.ElementAt(0).Questions = questionsGetter.get(questionsIds, 
                sub.Tests.ElementAt(0).QuestionsNumber);


            return sub;
        }
    }
}
