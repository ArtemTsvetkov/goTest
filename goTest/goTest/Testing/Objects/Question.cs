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
        private List<Unswer> unswers;
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

        public bool compare(Question question)
        {
            if(!question.questionsContent.Equals(questionsContent))
            {
                return false;
            }
            if (!question.questionsType.getType().Equals(questionsType.getType()))
            {
                return false;
            }
            for(int i=0; i<unswers.Count; i++)
            {
                if(!unswers.ElementAt(i).compare(question.unswers.ElementAt(i)))
                {
                    return false;
                }
            }

           return true;
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

        internal List<Unswer> Unswers
        {
            get
            {
                return unswers;
            }

            set
            {
                unswers = value;
            }
        }
    }
}
