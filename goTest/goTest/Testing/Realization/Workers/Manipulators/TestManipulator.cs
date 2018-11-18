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

        public void create(Test test)
        {
            testCreator.create(test);
        }

        public Test load(string subject, string testName)
        {
            return testloader.load(subject, testName);
        }

        public void update(Test test)
        {
            testUpdater.update(test);
        }
    }
}
