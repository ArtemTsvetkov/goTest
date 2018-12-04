using goTest.Testing.Types.BasicDBObjects.Interfaces;
using goTest.Testing.Types.BasicDBObjects.Realization;
using goTest.Testing.Types.BasicDBObjects.Realization.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Types.BasicDBObjects
{
    static class DbTypes
    {
        public static DbObject developStatus = new DevelopStatusType();
        public static DbObject user = new User();
        public static DbObject questionT = new QuestionTType();
        public static DbObject question = new Types.BasicDBObjects.Realization.QuestionType();
        public static DbObject schema = new SchemaType();
        public static DbObject subject = new SubjectType();
        public static DbObject test = new TestType();
        public static DbObject unswerT = new UnswerTType();
        public static DbObject unswer = new UnswerType();
    }
}
