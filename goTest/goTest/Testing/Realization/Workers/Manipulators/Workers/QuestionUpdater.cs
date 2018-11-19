using goTest.CommonComponents.DataConverters.Exceptions;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.Testing.Exceptions;
using goTest.Testing.Interfaces;
using goTest.Testing.Interfaces.Manipulators;
using goTest.Testing.Objects;
using goTest.Testing.Types;
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
            SqlLiteSimpleExecute.execute(queryConfigurator.updateQuestion(question.Id,
                    question.QuestionsContent));


            int rightUnswersCount = 0;
            for (int i = 0; i < question.Unswers.Count; i++)
            {
                if(question.Unswers.ElementAt(i).IsRight)
                {
                    rightUnswersCount++;
                }
            }
            if ((question.QuestionsType.getType().Equals(QuestionTypes.singleAnswer))&
                (rightUnswersCount==0 | rightUnswersCount>1))
            {
                throw new QuestionTypeException();
            }
            if (question.QuestionsType.getType().Equals(QuestionTypes.multiplyAnswer)&
                rightUnswersCount<2)
            {
                throw new QuestionTypeException();
            }
            

            for (int i = 0; i < question.Unswers.Count; i++)
            {
                unswerManipalator.update(question.Unswers.ElementAt(i));
            }
        }
    }
}
