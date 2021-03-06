﻿using goTest.CommonComponents.DataConverters.Exceptions;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.WorkWithData.Realization.WorkWithDataBase.SqlLite;
using goTest.SecurityComponent.Encryption.Realization;
using goTest.Testing.Exceptions;
using goTest.Testing.Objects;
using goTest.Testing.Types.BasicDBObjects;
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
        GoTestQueryConfiguratorI queryConfigurator;
        QuestionManipulatorI questionManipulator;

        public TestCreator(UnswerManipalatorI unswerManipalator,
            GoTestQueryConfiguratorI goTestQueryConfigurator,
            QuestionManipulatorI questionManipulator)
        {
            this.unswerManipalator = unswerManipalator;
            queryConfigurator = goTestQueryConfigurator;
            this.questionManipulator = questionManipulator;
        }

        public void create(Test test, int subjectId)
        {
            SqlLiteSimpleExecute.execute(queryConfigurator.createTest(
                EncryptWorker.getInstance().encrypt(test.Name), subjectId));
            
            int id = DataSetConverter.fromDsToSingle.toInt.convert(SqlLiteSimpleExecute.
                execute(queryConfigurator.getObjectIdInDevelopStatus(DbTypes.test)));

            SqlLiteSimpleExecute.execute(queryConfigurator.
                setTestsQuestionsNumber(id, test.QuestionsNumber));

            SqlLiteSimpleExecute.execute(queryConfigurator.
                setTestsRequeredUnswersNumber(id, test.RequeredUnswersNumber));

            for(int i=0; i< test.Questions.Count; i++)
            {
                questionManipulator.create(test.Questions.ElementAt(i),id);
            }
            SqlLiteSimpleExecute.execute(queryConfigurator.setApproveStatusToObject(
                DbTypes.test));
        }
    }
}
