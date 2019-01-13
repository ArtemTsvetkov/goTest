using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.SecurityComponent.Encryption.Realization;
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
            question.QuestionsContent = EncryptWorker.getInstance().decrypt(
                DataSetConverter.fromDsToSingle.toString.convert(
                SqlLiteSimpleExecute.execute(queryConfigurator.loadQuestionContent(id))));
            int[] unswersIds = DataSetConverter.fromDsToBuf.toIntBuf.convert(
                SqlLiteSimpleExecute.execute(queryConfigurator.loadQuestionUnswersIds(id)));

            question.Unswers = new List<Unswer>();
            for (int i=0;i< unswersIds.Count(); i++)
            {
                question.Unswers.Add(unswerManipalator.load(unswersIds[i]));
            }

            int questionTypeId = DataSetConverter.fromDsToSingle.toInt.convert(
                SqlLiteSimpleExecute.execute(queryConfigurator.loadQuestionTypeId(id)));
            string questionType = DataSetConverter.fromDsToSingle.toString.convert(
                SqlLiteSimpleExecute.execute(queryConfigurator.getObjectName(questionTypeId)));

            if (questionType.Equals(QuestionTypes.multiplyAnswer.getType()))
            {
                question.QuestionsType = QuestionTypes.multiplyAnswer;
                return question;
            }
            if(questionType.Equals(QuestionTypes.singleAnswer.getType()))
            {
                question.QuestionsType = QuestionTypes.singleAnswer;
                return question;
            }

            throw new ParamsTypesExceptions();
        }
    }
}
