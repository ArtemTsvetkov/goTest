﻿using goTest.Testing.Interfaces.Manipulators;
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
using goTest.Testing.Types.BasicDBObjects;
using goTest.Testing.Types.Unswer.Interfaces;

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
                SqlLiteSimpleExecute.execute(queryConfigurator.createUnswer(questionId));
                unswer.Id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getObjectIdInDevelopStatus(DbTypes.unswer)));
                SqlLiteSimpleExecute.execute(queryConfigurator.setUnswerContent(unswer.Id, 
                    unswer.Content));
                SqlLiteSimpleExecute.execute(queryConfigurator.setUnswerType(unswer.Id,
                    UnswerTypes.rightUnswer));
            }
            else
            {
                SqlLiteSimpleExecute.execute(queryConfigurator.createUnswer(questionId));
                unswer.Id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getObjectIdInDevelopStatus(DbTypes.unswer)));
                SqlLiteSimpleExecute.execute(queryConfigurator.setUnswerContent(unswer.Id,
                    unswer.Content));
                SqlLiteSimpleExecute.execute(queryConfigurator.setUnswerType(unswer.Id,
                    UnswerTypes.unswer));
            }
            SqlLiteSimpleExecute.execute(queryConfigurator.setApproveStatusToObject(
                DbTypes.unswer));
        }

        public Unswer load(int id)
        {
            Unswer unswer = new Unswer();
            unswer.Id = id;
            unswer.Content = DataSetConverter.fromDsToSingle.toString.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.loadUnswerContent(id)));
            int typeId = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.loadUnswerTypeId(id)));
            string type = DataSetConverter.fromDsToSingle.toString.convert(SqlLiteSimpleExecute.
                    execute(queryConfigurator.getObjectName(typeId)));
            if(type.Equals(DbObjects.rightUnswer.getName()))
            {
                unswer.IsRight = true;
                return unswer;
            }
            if(type.Equals(DbObjects.unswer.getName()))
            {
                unswer.IsRight = false;
                return unswer;
            }

            throw new ParamsTypesExceptions();
        }

        public void update(Unswer unswer)
        {
            if (unswer.IsRight)
            {
                SqlLiteSimpleExecute.execute(queryConfigurator.updateUnswerContent(
                    unswer.Id, unswer.Content));
                SqlLiteSimpleExecute.execute(queryConfigurator.updateUnswerType(
                    unswer.Id, DbObjects.rightUnswer));
            }
            else
            {
                SqlLiteSimpleExecute.execute(queryConfigurator.updateUnswerContent(
                    unswer.Id, unswer.Content));
                SqlLiteSimpleExecute.execute(queryConfigurator.updateUnswerType(
                    unswer.Id, DbObjects.unswer));
            }
        }
    }
}
