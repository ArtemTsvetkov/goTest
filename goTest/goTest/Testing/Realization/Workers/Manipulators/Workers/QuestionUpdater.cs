using goTest.Testing.Interfaces;
using goTest.Testing.Interfaces.Manipulators;
using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization.Workers.Manipulators.Workers
{
    class QuestionUpdater
    {
        UnswerManipalatorI unswerManipalator;
        GoTestQueryConfiguratorI queryConfigurator;

        public QuestionUpdater(UnswerManipalatorI unswerManipalator,
            GoTestQueryConfiguratorI goTestQueryConfigurator)
        {
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
        }

        public void update(Question question)
        {
            /*try
            {
                int count = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.checkEqualsQuestions(testId,
                    question.QuestionsContent)));
                if (count > 0)
                {
                    throw new EqualsQuestionsExceptions();
                }
            }
            catch (СonversionError ex)
            {
                throw new EqualsQuestionsExceptions();
            }

            SqlLiteSimpleExecute.execute(queryConfigurator.createQuestion(testId,
                    question.QuestionsContent));
            int id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getQuestionId(testId,
                    question.QuestionsContent)));

            for (int i = 0; i < question.Unswers.Count; i++)
            {
                unswerManipalator.create(question.Unswers.ElementAt(i), id);
            }*/
        }
    }
}
