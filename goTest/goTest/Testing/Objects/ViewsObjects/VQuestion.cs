using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects.ViewsObjects
{
    class VQuestion : Question
    {
        private int position;
        private List<VUnswer> unswers;

        public VQuestion(int position, Question question)
        {
            unswers = new List<VUnswer>();
            this.position = position;
            restore(question);
        }

        public void restore(Question question)
        {
            QuestionsContent = question.QuestionsContent;
            QuestionsType = question.QuestionsType;
            Id = question.Id;
        }

        public int getPosition()
        {
            return position;
        }

        internal new List<VUnswer> Unswers
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
