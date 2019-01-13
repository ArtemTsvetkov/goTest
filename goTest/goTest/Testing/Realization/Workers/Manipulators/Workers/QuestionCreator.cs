using goTest.CommonComponents.DataConverters.Exceptions;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.SecurityComponent.Encryption.Realization;
using goTest.Testing.Exceptions;
using goTest.Testing.Interfaces;
using goTest.Testing.Interfaces.Manipulators;
using goTest.Testing.Objects;
using goTest.Testing.Types.BasicDBObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization.Workers.Manipulators.Workers
{
    class QuestionCreator
    {
        UnswerManipalatorI unswerManipalator;
        GoTestQueryConfiguratorI queryConfigurator;

        public QuestionCreator(UnswerManipalatorI unswerManipalator,
            GoTestQueryConfiguratorI goTestQueryConfigurator)
        {
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
        }

        public void create(Question question, int testId)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.createQuestion(testId));
            question.Id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getObjectIdInDevelopStatus(DbTypes.question)));
            SqlLiteSimpleExecute.execute(queryConfigurator.setQuestionContent(question.Id,
                EncryptWorker.getInstance().encrypt(question.QuestionsContent)));
            SqlLiteSimpleExecute.execute(queryConfigurator.setQuestionType(question.Id,
                question.QuestionsType));


            for (int i = 0; i < question.Unswers.Count; i++)
            {
                unswerManipalator.create(question.Unswers.ElementAt(i), question.Id);
            }
            SqlLiteSimpleExecute.execute(queryConfigurator.setApproveStatusToObject(
                DbTypes.question));
        }
    }
}
