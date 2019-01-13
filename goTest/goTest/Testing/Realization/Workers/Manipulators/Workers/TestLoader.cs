using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.SecurityComponent.Encryption.Realization;
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
        GoTestQueryConfiguratorI queryConfigurator;
        QuestionManipulatorI questionManipulator;
        RandomQuestionsGetter questionsGetter;

        public TestLoader(UnswerManipalatorI unswerManipalator,
            GoTestQueryConfiguratorI goTestQueryConfigurator,
            QuestionManipulatorI questionManipulator)
        {
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
            this.questionManipulator = questionManipulator;
            questionsGetter = new RandomQuestionsGetter(unswerManipalator,
            goTestQueryConfigurator, questionManipulator);
        }

        public Test load(int testId, bool loadAllQuestions, bool loadOnlyTestNames)
        {
            Test test = new Test();
            test.Id = testId;
            test.Name = EncryptWorker.getInstance().decrypt(
                DataSetConverter.fromDsToSingle.toString.
                convert(SqlLiteSimpleExecute.execute(queryConfigurator.loadTestName(testId))));
            if (!loadOnlyTestNames)
            {
                test.QuestionsNumber = DataSetConverter.fromDsToSingle.toInt.
                    convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.loadTestQuestionCount(testId)));

                test.RequeredUnswersNumber = DataSetConverter.fromDsToSingle.toInt.
                    convert(SqlLiteSimpleExecute.execute(queryConfigurator.
                    loadTestRequiredQuestionCount(testId)));

                int[] questionsIds = DataSetConverter.fromDsToBuf.toIntBuf.convert(
                    SqlLiteSimpleExecute.execute(queryConfigurator.loadTestQuestionIds(testId)));
                if (loadAllQuestions)
                {
                    test.Questions = questionsGetter.get(questionsIds);
                }
                else
                {
                    test.Questions = questionsGetter.get(questionsIds,
                        test.QuestionsNumber);
                }
            }

            return test;
        }
    }
}
