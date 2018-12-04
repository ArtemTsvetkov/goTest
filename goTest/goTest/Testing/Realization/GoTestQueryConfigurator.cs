using goTest.Testing.Interfaces;
using goTest.Testing.Types;
using goTest.Testing.Types.BasicDBObjects;
using goTest.Testing.Types.BasicDBObjects.Interfaces;
using goTest.Testing.Types.Unswer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization
{
    class GoTestQueryConfigurator : GoTestQueryConfiguratorI
    {
        public string getObjectIdInDevelopStatus(DbObject objectName)
        {
            return "SELECT id FROM Objects o WHERE Type=" + getSubQueryForGettingTypeId(objectName.
                getName()) +
                " AND (SELECT count(*) FROM Objects_references r WHERE " +
                "attr_id=" + getSubQueryForGettingAttrId(DbAttrs.developStatus.getName()) +
                "AND o.id=r.object_id)=0";
        }

        public string getObjectIdsInDevelopStatus()
        {
            return "SELECT id FROM Objects o WHERE (SELECT count(*) " + 
                "FROM Objects_references r WHERE " +
                "attr_id=" + getSubQueryForGettingAttrId(DbAttrs.developStatus.getName()) +
                "AND o.id=r.object_id)=0";
        }

        public string createSubject(string subjectName)
        {
            return "INSERT INTO Objects VALUES(null, null, '" + subjectName + "', " +
                getSubQueryForGettingTypeId(DbTypes.subject.getName()) + ");";
        }

        public string createTest(string testName, int subjectId)
        {
            return "INSERT INTO Objects VALUES(null, " + subjectId + ", '" + testName + "', " +
                getSubQueryForGettingTypeId(DbTypes.test.getName()) + ");";
        }

        public string setTestsQuestionsNumber(int testId, int count)
        {
            return "INSERT INTO Parameters VALUES(" + testId + "," + 
                getSubQueryForGettingAttrId(DbAttrs.questionsCount.getName()) + ",'" + "3" + "');";
        }

        public string setTestsRequeredUnswersNumber(int testId, int count)
        {
            return "INSERT INTO Parameters VALUES(" + testId + "," +
                getSubQueryForGettingAttrId(DbAttrs.requiredQuestions.getName()) + ",'" + 
                "3" + "');";
        }

        public string createQuestion(int testId)
        {
            return "INSERT INTO Objects VALUES(null, " + testId + ", " + 
                "'Question', " + getSubQueryForGettingTypeId(DbTypes.question.getName()) + ");";
        }

        public string setQuestionContent(int questionId, string content)
        {
            return "INSERT INTO Parameters VALUES(" + questionId + ", " +
                getSubQueryForGettingAttrId(DbAttrs.content.getName()) + 
                ", '" + content + "');";
        }

        public string setQuestionType(int questionId, QuestionType type)
        {
            return "INSERT INTO Objects_references VALUES(" + questionId + 
                ", " + getSubQueryForGettingQuestionsTypeId(type) + ", " + 
                getSubQueryForGettingAttrId(DbAttrs.questionsType.getName()) + ");";
        }

        public string createUnswer(int questionId)
        {
            return "INSERT INTO OBJECTS VALUES(null, " + questionId + 
                ", 'Unswer', " + getSubQueryForGettingTypeId("Unswer") + ");";
        }

        public string setUnswerContent(int unswerId, string content)
        {
            return "INSERT INTO Parameters VALUES(" + unswerId + ", " +
                getSubQueryForGettingAttrId(DbAttrs.content.getName()) + ", '" + content + "');";
        }

        public string setUnswerType(int unswrId, UnswerType type)
        {
            return "INSERT INTO Objects_references VALUES(" + unswrId + ", " +
                getSubQueryForGettingUnswersTypeId(type) + ", " + 
                getSubQueryForGettingAttrId(DbAttrs.unswersType.getName()) + ");";
        }

        public string getSubjectId(string name)
        {
            return "SELECT id FROM Objects WHERE name='" + name + "' AND type="+
                getSubQueryForGettingTypeId(DbTypes.subject.getName());
        }

        public string setApproveStatusToObject(DbObject objectName)
        {
            return "INSERT INTO Objects_references VALUES((" + 
                getObjectIdInDevelopStatus(objectName) + "), " +
                getSubQueryForGettingObjectId(DbObjects.inApproveStatus, DbTypes.developStatus) + 
                ", " +
                getSubQueryForGettingAttrId(DbAttrs.developStatus.getName()) + ");";
        }

        public string updateSubjectName(int subjectId, string newName)
        {
            return "UPDATE Objects SET name='" + newName + "' WHERE id=" + subjectId;
        }

        public string updateTestName(int testId, string newName)
        {
            return "UPDATE Objects SET name='" + newName + "' WHERE id=" + testId;
        }

        public string updateTestsQuestionsNumber(int testId, int count)
        {
            return getQueryForUpdateParameters(testId, count.ToString(), 
                DbAttrs.questionsCount);
        }

        public string updateTestsRequeredUnswersNumber(int testId, int count)
        {
            return getQueryForUpdateParameters(testId, count.ToString(),
                DbAttrs.requiredQuestions);
        }

        public string updateQuestionContent(int questionId, string newContent)
        {
            return getQueryForUpdateParameters(questionId, newContent, DbAttrs.content);
        }

        public string updateQuestionType(int questionId, DbObject questionType)
        {
            return getQueryForUpdateReferences(questionId,
                getSubQueryForGettingObjectId(questionType, DbTypes.questionT), 
                DbAttrs.questionsType);
        }

        public string updateUnswerContent(int unswerId, string newContent)
        {
            return getQueryForUpdateParameters(unswerId, newContent, DbAttrs.content);
        }

        public string updateUnswerType(int unswerId, DbObject unswerType)
        {
            return getQueryForUpdateReferences(unswerId,
                getSubQueryForGettingObjectId(unswerType, DbTypes.unswerT),
                DbAttrs.unswersType);
        }

        public string loadSubjectTestIds(int subjectId)
        {
            return getChildIds(subjectId);
        }

        public string loadTestQuestionIds(int testId)
        {
            return getChildIds(testId);
        }

        public string loadQuestionUnswersIds(int questionId)
        {
            return getChildIds(questionId);
        }

        public string loadSubjectName(int subjectId)
        {
            return getObjectName(subjectId);
        }

        public string loadTestName(int testId)
        {
            return getObjectName(testId);
        }

        public string loadTestQuestionCount(int testId)
        {
            return getQueryForLoadParameter(testId, DbAttrs.questionsCount);
        }

        public string loadTestRequiredQuestionCount(int testId)
        {
            return getQueryForLoadParameter(testId, DbAttrs.requiredQuestions);
        }

        public string loadQuestionContent(int questionId)
        {
            return getQueryForLoadParameter(questionId, DbAttrs.content);
        }
        
        public string loadQuestionTypeId(int questionId)
        {
            return getQueryForLoadReference(questionId, DbAttrs.questionsType);
        }

        public string loadUnswerContent(int unswerId)
        {
            return getQueryForLoadParameter(unswerId, DbAttrs.content);
        }

        public string loadUnswerTypeId(int unswerId)
        {
            return getQueryForLoadReference(unswerId, DbAttrs.unswersType);
        }

        public string getObjectName(int objectId)
        {
            return "SELECT name FROM Objects WHERE id=" + objectId;
        }

        public string loadSubjectId(int testId)
        {
            return "SELECT parent_id FROM Objects WHERE id=" + testId;
        }

        public string getAllSubjectIds()
        {
            return "select id from Objects where type="+getSubQueryForGettingTypeId("Subject");
        }

        private string getQueryForLoadReference(int objectId, DbObject attr)
        {
            return "SELECT reference FROM Objects_references WHERE object_id=" + objectId +
                " AND attr_id=" + getSubQueryForGettingAttrId(attr.getName());
        }

        private string getQueryForLoadParameter(int objectId, DbObject attr)
        {
            return "SELECT value FROM Parameters WHERE object_id=" + objectId + 
                " AND attr_id=" + getSubQueryForGettingAttrId(attr.getName());
        }

        private string getChildIds(int parent_id)
        {
            return "SELECT id FROM Objects WHERE parent_id=" + parent_id;
        }

        private string getQueryForUpdateReferences(int objectId, string newReference, DbObject attr)
        {
            return "UPDATE Objects_references SET reference=" + newReference +
                " WHERE object_id=" + objectId + 
                " AND attr_id=" + getSubQueryForGettingAttrId(attr.getName());
        }

        private string getQueryForUpdateParameters(int objectId, string value, DbObject attr)
        {
            return "UPDATE Parameters SET value='" + value + "' WHERE object_id=" +
                objectId + " AND attr_id = " + getSubQueryForGettingAttrId(attr.getName());
        }

        private string getSubQueryForGettingObjectId(DbObject objectName, DbObject objectType)
        {
            return "(SELECT id FROM Objects WHERE name ='" + objectName.getName() + "' AND type=" +
                getSubQueryForGettingTypeId(objectType.getName()) + ")";
        }

        private string getSubQueryForGettingTypeId(string name)
        {
            return "(SELECT id FROM Types WHERE Name='" + name + "')";
        }

        private string getSubQueryForGettingAttrId(string attrName)
        {
            return "(SELECT id FROM Attributes WHERE Name='" + attrName + "')";
        }

        private string getSubQueryForGettingQuestionsTypeId(QuestionType type)
        {
            return "(SELECT id FROM Objects WHERE Type" + 
                "=" + getSubQueryForGettingTypeId(DbTypes.questionT.getName()) + 
                " AND name='" + type.getType() + "')";
        }

        private string getSubQueryForGettingUnswersTypeId(UnswerType type)
        {
            return "(SELECT id FROM Objects WHERE Type" +
                "=" + getSubQueryForGettingTypeId(DbTypes.unswerT.getName()) +
                " AND name='" + type.getType() + "')";
        }
    }
}
