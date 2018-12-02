using goTest.Testing.Interfaces.Manipulators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using goTest.Testing.Objects;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Interfaces;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.Testing.Types.BasicDBObjects;

namespace goTest.Testing.Realization.Workers.Manipulators
{
    class SubjectManipulator : SubjectManipulatorI
    {
        private GoTestQueryConfiguratorI queryConfigurator;
        private TestManipulatorI testManipulator;

        public SubjectManipulator(GoTestQueryConfiguratorI queryConfigurator,
            TestManipulatorI testManipulator)
        {
            this.queryConfigurator = queryConfigurator;
            this.testManipulator = testManipulator;
        }

        public void create(Subject subject)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.createSubject(
                subject.Name));
            for(int i=0; i<subject.Tests.Count; i++)
            {
                testManipulator.create(subject.Tests.ElementAt(i), subject.Id);
            }

            SqlLiteSimpleExecute.execute(queryConfigurator.setApproveStatusToObject(
                DbTypes.subject));
        }

        public Subject load(string name, bool loadOnlySubjectAndTestNamesWithoutChilds,
            bool loadAllQuestions)
        {
            Subject sub = new Subject();
            sub.Id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getSubjectId(name)));
            sub.Name = name;
            int[] testIds = DataSetConverter.fromDsToBuf.toIntBuf.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.loadSubjectTestIds(sub.Id)));
            for(int i=0; i<testIds.Length; i++)
            {
                sub.Tests.Add(testManipulator.load(testIds[i], loadAllQuestions,
                    loadOnlySubjectAndTestNamesWithoutChilds));
            }

            return sub;
        }

        public void update(Subject subject)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.updateSubjectName(
            subject.Id, subject.Name));

            for(int i=0; i<subject.Tests.Count; i++)
            {
                testManipulator.update(subject.Tests.ElementAt(i), subject.Id);
            }
        }
    }
}
