using goTest.Testing.Interfaces;
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
            throw new NotImplementedException();
        }

        public string checkEqualsQuestions(int testId, string content)
        {
            throw new NotImplementedException();
        }

        public string createQuestion(int testId, string content)
        {
            throw new NotImplementedException();
        }

        public string createSubject(string name)
        {
            throw new NotImplementedException();
        }

        public string createTest(int subjectId, string name)
        {
            throw new NotImplementedException();
        }

        public string getParametersTypeId(ParamsType typeName)
        {
            throw new NotImplementedException();
        }

        public string getQuestionContent(int questionId)
        {
            throw new NotImplementedException();
        }

        public string getQuestionId(int testId, string content)
        {
            throw new NotImplementedException();
        }

        public string getQuestionParamsIds(int questionId, ParamsType paramsTypeName)
        {
            throw new NotImplementedException();
        }

        public string getQuestionsIds(int testId)
        {
            throw new NotImplementedException();
        }

        public string getQuestionsNumber(int testsId)
        {
            throw new NotImplementedException();
        }

        public string getRequeredUnswersNumber(int testsId)
        {
            throw new NotImplementedException();
        }

        public string getSubjectId(string subjectName)
        {
            throw new NotImplementedException();
        }

        public string getTestId(string subject, string testName)
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

        public string updateSubject(int id, string newName)
        {
            throw new NotImplementedException();
        }

        public string updateSubject(string oldName, string newName)
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
