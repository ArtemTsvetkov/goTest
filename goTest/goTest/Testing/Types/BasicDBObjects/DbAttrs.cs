using goTest.Testing.Types.BasicDBObjects.Interfaces;
using goTest.Testing.Types.BasicDBObjects.Realization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Types.BasicDBObjects
{
    static class DbAttrs
    {
        public static DbObject content = new ContentAttr();
        public static DbObject password = new Password();
        public static DbObject sult = new Sult();
        public static DbObject developStatus = new DevelopStatusAttr();
        public static DbObject questionsCount = new QuestionsCountAttr();
        public static DbObject questionsType = new QuestionsTypeAttr();
        public static DbObject requiredQuestions = new RequiredQuestionsAttr();
        public static DbObject unswersType = new UnswersTypeAttr();
    }
}
