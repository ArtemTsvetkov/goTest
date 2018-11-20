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
using goTest.Testing.Exceptions;

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
                int paramTypeId = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getParametersTypeId(
                        ParamsTypes.ParamsTypes.rightUnswer)));
                SqlLiteSimpleExecute.execute(queryConfigurator.addQuestionParam(questionId, 
                    paramTypeId, unswer.Content));
            }
            else
            {
                int paramTypeId = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getParametersTypeId(ParamsTypes.ParamsTypes.unswer)));
                SqlLiteSimpleExecute.execute(queryConfigurator.addQuestionParam(questionId, 
                    paramTypeId, unswer.Content));
            }
        }

        public Unswer load(int id)
        {
            Unswer unswer = new Unswer();
            unswer.Id = id;
            unswer.Content = DataSetConverter.fromDsToSingle.toString.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getUnswerContent(id)));
            string type = DataSetConverter.fromDsToSingle.toString.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getUnswerTypeName(id)));
            if(type.Equals(ParamsTypes.ParamsTypes.rightUnswer.getType()))
            {
                unswer.IsRight = true;
                return unswer;
            }
            if(type.Equals(ParamsTypes.ParamsTypes.unswer.getType()))
            {
                unswer.IsRight = false;
            }

            throw new ParamsTypesExceptions();
        }

        public void update(Unswer unswer)
        {
            if (unswer.IsRight)
            {
                int paramTypeId = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getParametersTypeId(
                        ParamsTypes.ParamsTypes.rightUnswer)));
                SqlLiteSimpleExecute.execute(queryConfigurator.updateQuestionParam(unswer.Id,
                    paramTypeId, unswer.Content));
            }
            else
            {
                int paramTypeId = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getParametersTypeId(ParamsTypes.ParamsTypes.unswer)));
                SqlLiteSimpleExecute.execute(queryConfigurator.updateQuestionParam(unswer.Id,
                    paramTypeId, unswer.Content));
            }
        }
    }
}
