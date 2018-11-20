﻿using goTest.Testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using goTest.Testing.ParamsTypes.Interfaces;

namespace goTest.Testing.Realization
{
    class GoTestQueryConfigurator : GoTestQueryConfiguratorI
    {
        public string addQuestionParam(int questionId, int parametersTypeId, string value)
        {
            return "INSERT INTO Parameters VALUES(null, "+questionId+", "+parametersTypeId+
                ", "+value+")";
        }

        public string checkEqualsQuestions(int testId, string content)
        {
            return "SELECT COUNT(*) FROM Questions WHERE tests_id="+testId+
                " AND content="+content+"";
        }

        public string checkEqualsTests(int subjectId, string name)
        {
            throw new NotImplementedException();
        }

        public string createQuestion(int testId, string content)
        {
            return "INSERT INTO Questions values(null, "+testId+", "+content+")";
        }

        public string createSubject(string name)
        {
            return "INSERT INTO Disciplines VALUES(null, "+name+");";
        }

        public string createTest(int subjectId, string name)
        {
            return "INSERT INTO Tests VALUES(null, "+subjectId+", "+name+");";
        }

        public string getParametersTypeId(ParamsType typeName)
        {
            return "SELECT id FROM Parameters_types WHERE name="+typeName.getType()+"";
        }

        public string getQuestionContent(int questionId)
        {
            return "SELECT content FROM Questions where id="+questionId+"";
        }

        public string getQuestionId(int testId, string content)
        {
            return "SELECT id FROM Questions where tests_id="+testId+
                " AND content="+content+"";
        }

        public string getQuestionParamsIds(int questionId, ParamsType paramsTypeName)
        {
            return "SELECT id from Parameters WHERE questions_id="+questionId+
                " AND parameters_type_id="+paramsTypeName.getType()+"";
        }

        public string getQuestionsIds(int testId)
        {
            return "SELECT id FROM Questions WHERE tests_id="+testId;
        }

        public string getQuestionsNumber(int testsId)
        {
            return "SELECT questions_count FROM Test_params WHERE tests_id="+testsId;
        }

        public string getRequeredUnswersNumber(int testsId)
        {
            return "SELECT required_questions_count FROM Test_params WHERE tests_id="+testsId;
        }

        public string getSubjectId(int testId)
        {
            throw new NotImplementedException();
        }

        public string getSubjectId(string subjectName)
        {
            return "SELECT id FROM Disciplines WHERE name='"+subjectName+"'";
        }

        public string getSubjectName(int testId)
        {
            throw new NotImplementedException();
        }

        public string getTestId(string subject, string testName)
        {
            throw new NotImplementedException();
        }

        public string getTestName(int id)
        {
            throw new NotImplementedException();
        }

        public string getUnswerContent(int id)
        {
            throw new NotImplementedException();
        }

        public string getUnswerTypeName(int id)
        {
            throw new NotImplementedException();
        }

        public string setTestsQuestionsNumber(int testId, int count)
        {
            throw new NotImplementedException();
        }

        public string setTestsRequeredUnswersNumber(int testId, int count)
        {
            throw new NotImplementedException();
        }

        public string updateQuestion(int id, string content)
        {
            throw new NotImplementedException();
        }

        public string updateQuestionParam(int unswerId, int paramTypeId, string content)
        {
            throw new NotImplementedException();
        }

        public string updateSubject(int id, string newName)
        {
            throw new NotImplementedException();
        }

        public string updateTestName(int subjectId, string name)
        {
            throw new NotImplementedException();
        }

        public string updateTestsQuestionsNumber(int testId, int count)
        {
            throw new NotImplementedException();
        }

        public string updateTestsRequeredUnswersNumber(int testId, int count)
        {
            throw new NotImplementedException();
        }
    }
}
