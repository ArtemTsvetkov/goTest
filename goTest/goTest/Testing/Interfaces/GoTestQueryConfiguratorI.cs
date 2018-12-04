using goTest.Testing.Types;
using goTest.Testing.Types.BasicDBObjects.Interfaces;
using goTest.Testing.Types.Unswer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces
{
    interface GoTestQueryConfiguratorI
    {
        string getObjectIdInDevelopStatus(DbObject typeName);
        string setApproveStatusToObject(DbObject objectName);
        string getObjectIdsInDevelopStatus();
        string getSubjectId(string name);
        string createSubject(string subjectName);
        string createTest(string testName, int subjectId);
        string setTestsQuestionsNumber(int testId, int count);
        string setTestsRequeredUnswersNumber(int testId, int count);
        string createQuestion(int testId);
        string setQuestionContent(int questionId, string content);
        string setQuestionType(int questionId, QuestionType type);
        string createUnswer(int questionId);
        string setUnswerContent(int unswerId, string content);
        string setUnswerType(int unswrId, UnswerType type);
        string updateSubjectName(int subjectId, string newName);
        string updateTestName(int testId, string newName);
        string updateTestsQuestionsNumber(int testId, int count);
        string updateTestsRequeredUnswersNumber(int testId, int count);
        string updateQuestionContent(int questionId, string newContent);
        string updateQuestionType(int questionId, DbObject questionType);
        string updateUnswerContent(int unswerId, string newContent);
        string updateUnswerType(int unswerId, DbObject unswerType);
        string loadSubjectTestIds(int subjectId);
        string loadTestQuestionIds(int testId);
        string loadQuestionUnswersIds(int questionId);
        string loadSubjectName(int subjectId);
        string loadTestName(int testId);
        string loadTestQuestionCount(int testId);
        string loadTestRequiredQuestionCount(int testId);
        string loadQuestionContent(int questionId);
        string loadQuestionTypeId(int questionId);
        string loadUnswerContent(int unswerId);
        string loadUnswerTypeId(int unswerId);
        string loadSubjectId(int testId);
        string getObjectName(int objectId);
    }
}
