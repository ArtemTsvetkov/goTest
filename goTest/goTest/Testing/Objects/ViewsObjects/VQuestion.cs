using goTest.Testing.Exceptions;
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
        private bool isSelected;

        public VQuestion(int position, Question question)
        {
            unswers = new List<VUnswer>();
            this.position = position;
            IsSelected = false;
            restore(question);
        }

        public void restore(Question question)
        {
            QuestionsContent = question.QuestionsContent;
            QuestionsType = question.QuestionsType;
            Id = question.Id;

            for(int i=0; i<question.Unswers.Count; i++)
            {
                if (!question.Unswers.ElementAt(i).IsDeleted)
                {
                    unswers.Add(new VUnswer(i, question.Unswers.ElementAt(i)));
                }
            }
        }

        public Question unRestore()
        {
            Question question = new Question();
            question.QuestionsContent = QuestionsContent;
            question.QuestionsType = QuestionsType;
            question.Id = Id;

            for (int i = 0; i < unswers.Count; i++)
            {
                question.Unswers.Add(unswers.ElementAt(i).unRestore());
            }

            return question;
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

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
            }
        }


        public VUnswer getSelectedUnswer()
        {
            for (int i = 0; i < unswers.Count; i++)
            {
                if (unswers.ElementAt(i).IsSelected)
                {
                    return unswers.ElementAt(i);
                }
            }

            throw new GoTestObjectNotFound();
        }
    }
}
