using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.SecurityComponent.Encryption.Realization;
using goTest.Testing.Exceptions;
using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces.Manipulators.Workers
{
    class TestUpdater
    {
        UnswerManipalatorI unswerManipalator;
        GoTestQueryConfiguratorI queryConfigurator;
        QuestionManipulatorI questionManipulator;

        public TestUpdater(UnswerManipalatorI unswerManipalator,
            GoTestQueryConfiguratorI goTestQueryConfigurator,
            QuestionManipulatorI questionManipulator)
        {
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
            this.questionManipulator = questionManipulator;
        }

        public void update(Test test, int subjectId)
        {
            if(DataSetConverter.fromDsToSingle.toInt.convert(
                SqlLiteSimpleExecute.execute(queryConfigurator.countOfObject(test.Id)))==0)
            {
                throw new ObjectIsNotExistYet();
            }

            SqlLiteSimpleExecute.execute(queryConfigurator.updateTestsSubject(
                test.Id, subjectId));

            SqlLiteSimpleExecute.execute(queryConfigurator.updateTestName(
                test.Id, EncryptWorker.getInstance().encrypt(test.Name)));
            int id = test.Id;

            SqlLiteSimpleExecute.execute(queryConfigurator.
                updateTestsQuestionsNumber(id, test.QuestionsNumber));

            SqlLiteSimpleExecute.execute(queryConfigurator.
                updateTestsRequeredUnswersNumber(id, test.RequeredUnswersNumber));

            for (int i = 0; i < test.Questions.Count; i++)
            {
                try
                {
                    questionManipulator.update(test.Questions.ElementAt(i));
                }
                catch(ObjectIsNotExistYet ex)
                {
                    questionManipulator.create(test.Questions.ElementAt(i), test.Id);
                }
            }
        }
    }
}
