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
    }
}
