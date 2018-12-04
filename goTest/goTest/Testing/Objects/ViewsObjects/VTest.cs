using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects.ViewsObjects
{
    class VTest : Test
    {
        private int position;
        private List<VQuestion> questions;

        public VTest(int position, Test test)
        {
            questions = new List<VQuestion>();
            this.position = position;
            restore(test);
        }

        public void restore(Test test)
        {
            Name = test.Name;
            QuestionsNumber = test.QuestionsNumber;
            RequeredUnswersNumber = test.RequeredUnswersNumber;
            Id = test.Id;

            for(int i=0; i<test.Questions.Count; i++)
            {
                questions.Add(new VQuestion(i, test.Questions.ElementAt(i)));
            }
        }

        public int getPosition()
        {
            return position;
        }

        internal new List<VQuestion> Questions
        {
            get
            {
                return questions;
            }

            set
            {
                questions = value;
            }
        }
    }
}
