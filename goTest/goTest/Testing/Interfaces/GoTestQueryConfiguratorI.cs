using goTest.Testing.ParamsTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces
{
    interface GoTestQueryConfiguratorI
    {
        string updateSubject(int id, string newName);
        string createSubject(string name);
        string getSubjectId(string subjectName);
        string getSubjectId(int testId);
        string getTestName(int id);
        string getSubjectName(int testId);
        string createTest(int subjectId, string name);
        string updateTestName(int subjectId, string name);
        string getTestId(int subjectId, string testName);
        string setTestsQuestionsNumber(int testId, int count);
        string setTestsRequeredUnswersNumber(int testId, int count);
        string updateTestsQuestionsNumber(int testId, int count);
        string updateTestsRequeredUnswersNumber(int testId, int count);
        string getQuestionsIds(int testId);
        string getQuestionsNumber(int testsId);
        string createQuestion(int testId, string content);
        string getQuestionId(int testId, string content);
        string getQuestionContent(int questionId);
        string checkEqualsQuestions(int testId, string content);
        string checkEqualsTests(int subjectId, string name);
        string getRequeredUnswersNumber(int testsId);
        string addQuestionParam(int questionId, int parametersTypeId, string value);
        string getParametersTypeId(ParamsType typeName);
        string getQuestionParamsIds(int questionId, ParamsType paramsTypeName);
        string updateQuestion(int id, string content);
        string getUnswerContent(int id);
        string getUnswerTypeName(int id);
        string updateQuestionParam(int unswerId, int paramTypeId, string content);
    }
}
