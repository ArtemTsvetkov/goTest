using goTest.Testing.Exceptions;
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
            IsSelected = test.IsSelected;

            for(int i=0; i<test.Questions.Count; i++)
            {
                if (!test.Questions.ElementAt(i).IsDeleted)
                {
                    questions.Add(new VQuestion(i, test.Questions.ElementAt(i)));
                }
            }
        }

        public Test unRestore()
        {
            Test test = new Test();
            test.Name = Name;
            test.QuestionsNumber = QuestionsNumber;
            test.RequeredUnswersNumber = RequeredUnswersNumber;
            test.Id = Id;
            test.IsSelected = IsSelected;

            for (int i = 0; i < questions.Count; i++)
            {
                test.Questions.Add(questions.ElementAt(i).unRestore());
            }

            return test;
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

        public VQuestion getSelectedQuestion()
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions.ElementAt(i).IsSelected)
                {
                    return questions.ElementAt(i);
                }
            }

            throw new GoTestObjectNotFound();
        }
    }
}
