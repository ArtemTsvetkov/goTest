using goTest.Testing.Interfaces.Manipulators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using goTest.Testing.Objects;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.Testing.Interfaces;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;

namespace goTest.Testing.Realization.Workers.Manipulators
{
    class UnswerManipalator : UnswerManipalatorI
    {
        private GoTestQueryConfiguratorI queryConfigurator;

        public UnswerManipalator(GoTestQueryConfiguratorI goTestQueryConfigurator)
        {
            queryConfigurator = goTestQueryConfigurator;
        }

        public void create(Unswer unswer, int questionId)
        {
            if (unswer.IsRight)
            {
                int paramId = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getParametersTypeId(
                        ParamsTypes.ParamsTypes.rightUnswer)));
                SqlLiteSimpleExecute.execute(queryConfigurator.addQuestionParam(questionId, paramId,
                    unswer.Content));
            }
            else
            {
                int paramId = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getParametersTypeId(ParamsTypes.ParamsTypes.unswer)));
                SqlLiteSimpleExecute.execute(queryConfigurator.addQuestionParam(questionId, paramId,
                    unswer.Content));
            }
        }

        public Unswer load(int id)
        {
            throw new NotImplementedException();
        }

        public void update(Unswer unswer)
        {
            throw new NotImplementedException();
        }
    }
}
