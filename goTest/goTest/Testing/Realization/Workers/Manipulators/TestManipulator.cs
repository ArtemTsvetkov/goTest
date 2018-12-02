using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Interfaces;
using goTest.Testing.Interfaces.Manipulators;
using goTest.Testing.Interfaces.Manipulators.Workers;
using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization.Workers.Manipulators
{
    class TestManipulator : TestManipulatorI
    {
        private TestLoader testloader;
        private TestUpdater testUpdater;
        private TestCreator testCreator;

        public TestManipulator(UnswerManipalatorI unswerManipalator,
            SubjectManipulatorI subjectManipulator, 
            GoTestQueryConfiguratorI goTestQueryConfigurator,
            QuestionManipulatorI questionManipulator)
        {
            testloader = new TestLoader(unswerManipalator, subjectManipulator,
                goTestQueryConfigurator, questionManipulator);
            testUpdater = new TestUpdater(unswerManipalator, subjectManipulator,
                goTestQueryConfigurator, questionManipulator);
            testCreator = new TestCreator(unswerManipalator, subjectManipulator,
                goTestQueryConfigurator, questionManipulator);
        }

        public void create(Test test, int subjectId)
        {
            testCreator.create(test, subjectId);
        }

        public Test load(int testId, bool loadAllQuestions, bool loadOnlyTestNames)
        {
            return testloader.load(testId, loadAllQuestions, loadOnlyTestNames);
        }

        public void update(Test test, int subjectId)
        {
            testUpdater.update(test, subjectId);
        }
    }
}
