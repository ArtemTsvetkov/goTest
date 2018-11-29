using goTest.CommonComponents.DataConverters.Exceptions;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Exceptions;
using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces.Manipulators.Workers
{
    class TestCreator
    {
        UnswerManipalatorI unswerManipalator;
        SubjectManipulatorI subjectManipulator;
        GoTestQueryConfiguratorI queryConfigurator;
        QuestionManipulatorI questionManipulator;

        public TestCreator(UnswerManipalatorI unswerManipalator,
            SubjectManipulatorI subjectManipulator,
            GoTestQueryConfiguratorI goTestQueryConfigurator,
            QuestionManipulatorI questionManipulator)
        {
            this.subjectManipulator = subjectManipulator;
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
            this.questionManipulator = questionManipulator;
        }

        public void create(Subject subject)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.createTest(subject.Id, subject.Tests.
                ElementAt(0).Name));
            try
            {
                int count = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.checkEqualsTests(subject.Id, subject.Tests.
                    ElementAt(0).Name)));
                if (count > 0)
                {
                    throw new EqualsTestExceptions();
                }
            }
            catch (СonversionError ex)
            {
                throw new EqualsTestExceptions();
            }
            
            
            int id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getTestId(subject.Id, subject.Tests.ElementAt(0).Name)));

            SqlLiteSimpleExecute.execute(queryConfigurator.
                setTestsQuestionsNumber(id, subject.Tests.ElementAt(0).QuestionsNumber));

            SqlLiteSimpleExecute.execute(queryConfigurator.
                setTestsRequeredUnswersNumber(id, subject.Tests.ElementAt(0).RequeredUnswersNumber));

            for(int i=0; i< subject.Tests.ElementAt(0).Questions.Count; i++)
            {
                questionManipulator.create(subject.Tests.ElementAt(0).Questions.ElementAt(i),id);
            }
        }
    }
}
