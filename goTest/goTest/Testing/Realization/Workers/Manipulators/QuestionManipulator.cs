using goTest.Testing.Interfaces.Manipulators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using goTest.Testing.Objects;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.Testing.Interfaces;
using goTest.Testing.Exceptions;
using goTest.CommonComponents.DataConverters.Exceptions;
using goTest.Testing.Realization.Workers.Manipulators.Workers;

namespace goTest.Testing.Realization.Workers.Manipulators
{
    class QuestionManipulator : QuestionManipulatorI
    {
        UnswerManipalatorI unswerManipalator;
        GoTestQueryConfiguratorI queryConfigurator;

        public QuestionManipulator(UnswerManipalatorI unswerManipalator,
            GoTestQueryConfiguratorI goTestQueryConfigurator)
        {
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
        }

        public void create(Question question, int testId)
        {
            QuestionCreator questionCreator = new QuestionCreator(unswerManipalator,
               queryConfigurator);
            questionCreator.create(question, testId);
        }

        public Question load(int id)
        {
            QuestionLoader questionLoader = new QuestionLoader(unswerManipalator,
               queryConfigurator);
            return questionLoader.load(id);
        }

        public void update(Question question)
        {
            QuestionUpdater updater = new QuestionUpdater(unswerManipalator,
               queryConfigurator);
            updater.update(question);
        }
    }
}
