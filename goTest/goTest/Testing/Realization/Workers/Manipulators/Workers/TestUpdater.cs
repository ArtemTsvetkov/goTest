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
    class TestUpdater
    {
        UnswerManipalatorI unswerManipalator;
        SubjectManipulatorI subjectManipulator;
        GoTestQueryConfiguratorI queryConfigurator;
        QuestionManipulatorI questionManipulator;

        public TestUpdater(UnswerManipalatorI unswerManipalator,
            SubjectManipulatorI subjectManipulator,
            GoTestQueryConfiguratorI goTestQueryConfigurator,
            QuestionManipulatorI questionManipulator)
        {
            this.subjectManipulator = subjectManipulator;
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
            this.questionManipulator = questionManipulator;
        }

        public void update(Test test, int subjectId)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.updateTestName(
                subjectId, test.Name));
            int id = test.Id;

            SqlLiteSimpleExecute.execute(queryConfigurator.
                updateTestsQuestionsNumber(id, test.QuestionsNumber));

            SqlLiteSimpleExecute.execute(queryConfigurator.
                updateTestsRequeredUnswersNumber(id, test.RequeredUnswersNumber));

            for (int i = 0; i < test.Questions.Count; i++)
            {
                questionManipulator.update(test.Questions.ElementAt(i));
            }
        }
    }
}
