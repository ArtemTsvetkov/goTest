using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
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
    class QuestionLoader
    {
        UnswerManipalatorI unswerManipalator;
        GoTestQueryConfiguratorI queryConfigurator;

        public QuestionLoader(UnswerManipalatorI unswerManipalator,
            GoTestQueryConfiguratorI goTestQueryConfigurator)
        {
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
        }

        public Question load(int id)
        {
            Question question = new Question();
            question.Id = id;
            question.QuestionsContent = DataSetConverter.fromDsToSingle.toString.convert(
                SqlLiteSimpleExecute.execute(queryConfigurator.getQuestionContent(id)));
            int[] rightUnswersIds = DataSetConverter.fromDsToBuf.toIntBuf.convert(
                SqlLiteSimpleExecute.execute(queryConfigurator.getQuestionParamsIds(id, 
                ParamsTypes.ParamsTypes.rightUnswer)));
            int[] noRigthUnswersIds = DataSetConverter.fromDsToBuf.toIntBuf.convert(
               SqlLiteSimpleExecute.execute(queryConfigurator.getQuestionParamsIds(id,
               ParamsTypes.ParamsTypes.unswer)));

            question.Unswers = new List<Unswer>();
            for (int i=0;i<rightUnswersIds.Count(); i++)
            {
                question.Unswers.Add(unswerManipalator.load(rightUnswersIds[i]));
            }
            for (int i = 0; i < noRigthUnswersIds.Count(); i++)
            {
                question.Unswers.Add(unswerManipalator.load(noRigthUnswersIds[i]));
            }

            if(rightUnswersIds.Count()>1)
            {
                question.QuestionsType = QuestionTypes.multiplyAnswer;
            }
            else
            {
                question.QuestionsType = QuestionTypes.singleAnswer;
            }

            return question;
        }
    }
}
