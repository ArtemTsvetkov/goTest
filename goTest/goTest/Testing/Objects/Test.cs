using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects
{
    class Test
    {
        private Subject subject;
        private List<Question> questions;
        private string name;
        private int questionsNumber;
        private int requeredUnswersNumber;

        internal Subject Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
            }
        }

        internal List<Question> Questions
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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int QuestionsNumber
        {
            get
            {
                return questionsNumber;
            }

            set
            {
                questionsNumber = value;
            }
        }

        public int RequeredUnswersNumber
        {
            get
            {
                return requeredUnswersNumber;
            }

            set
            {
                requeredUnswersNumber = value;
            }
        }
    }
}
