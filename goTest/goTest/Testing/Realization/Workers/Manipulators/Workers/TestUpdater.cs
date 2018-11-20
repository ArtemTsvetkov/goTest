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

        public void update(Subject subject)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.updateTestName(
                subject.Id, subject.Tests.ElementAt(0).Name));
            int id = subject.Tests.ElementAt(0).Id;

            SqlLiteSimpleExecute.execute(queryConfigurator.
                updateTestsQuestionsNumber(id, subject.Tests.ElementAt(0).QuestionsNumber));

            SqlLiteSimpleExecute.execute(queryConfigurator.
                updateTestsRequeredUnswersNumber(id, subject.Tests.ElementAt(0).
                RequeredUnswersNumber));

            for (int i = 0; i < subject.Tests.ElementAt(0).Questions.Count; i++)
            {
                questionManipulator.update(subject.Tests.ElementAt(0).Questions.ElementAt(i));
            }
        }
    }
}
