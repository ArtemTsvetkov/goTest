using goTest.Testing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects
{
    class Question
    {
        private string questionsContent;
        private QuestionType questionsType;

        public string QuestionsContent
        {
            get
            {
                return questionsContent;
            }

            set
            {
                questionsContent = value;
            }
        }

        internal QuestionType QuestionsType
        {
            get
            {
                return questionsType;
            }

            set
            {
                questionsType = value;
            }
        }
    }
}
