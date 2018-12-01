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
            return "SELECT id FROM Objects WHERE name=" + name + " AND type="+
                getSubQueryForGettingTypeId(DbTypes.subject.getName());
        }

        public string setApproveStatusToObject(DbObject objectName)
        {
            return "INSERT INTO Objects_references VALUES(" + 
                getObjectIdInDevelopStatus(objectName) + ", " +
                getSubQueryForGettingObjectId(DbObjects.inApproveStatus, DbTypes.developStatus) + 
                ", " +
                getSubQueryForGettingAttrId(DbAttrs.developStatus.getName()) + ");";
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
            return "SELECT id FROM Objects WHERE Type" + 
                "=" + getSubQueryForGettingTypeId(DbTypes.questionT.getName()) + 
                " AND name='" + type.getType() + "'";
        }

        private string getSubQueryForGettingUnswersTypeId(UnswerType type)
        {
            return "SELECT id FROM Objects WHERE Type" +
                "=" + getSubQueryForGettingTypeId(DbTypes.unswerT.getName()) +
                " AND name='" + type.getType() + "'";
        }
    }
}
