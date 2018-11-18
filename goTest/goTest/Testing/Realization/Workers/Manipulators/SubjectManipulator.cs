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

namespace goTest.Testing.Realization.Workers.Manipulators
{
    class SubjectManipulator : SubjectManipulatorI
    {
        private GoTestQueryConfiguratorI queryConfigurator;

        public SubjectManipulator(GoTestQueryConfiguratorI queryConfigurator)
        {
            this.queryConfigurator = queryConfigurator;
        }

        public void create(Subject subject)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.createSubject(
            subject.Name));
        }

        public Subject load(string name)
        {
            Subject sub = new Subject();
            sub.Id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getSubjectId(name)));
            sub.Name = name;

            return sub;
        }

        public void update(Subject subject)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.updateSubject(
            subject.Id, subject.Name));
        }
    }
}
