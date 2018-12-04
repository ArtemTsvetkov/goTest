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
        private int id;

        public Question()
        {
            unswers = new List<Unswer>();
        }

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

        public Question copy()
        {
            Question copy = new Question();
            copy.id = id;
            copy.questionsContent = questionsContent;
            copy.questionsType = questionsType;
            for(int i=0; i<unswers.Count; i++)
            {
                copy.unswers.Add(unswers.ElementAt(i).copy());
            }

            return copy;
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

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}
