using goTest.Testing.Exceptions;
using goTest.Testing.Realization.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects
{
    class Test
    {
        private List<Question> questions;
        private string name;
        private int questionsNumber;
        private int requeredUnswersNumber;
        private int id;

        public Test()
        {
            questions = new List<Question>();
        }

        public IntHierarchy searchObjectIndex(int objectId)
        {
            try
            {
                return getQuestionIndex(objectId);
            }
            catch (GoTestObjectNotFound ex)
            {
                return getChildIndex(objectId);
            }
        }

        private IntHierarchy getQuestionIndex(int questionId)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions.ElementAt(i).Id == questionId)
                {
                    IntHierarchy hi = new IntHierarchy(new Question().GetType());
                    hi.value = i;
                    return hi;
                }
            }

            throw new GoTestObjectNotFound();
        }

        private IntHierarchy getChildIndex(int id)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                try
                {
                    IntHierarchy hi = new IntHierarchy(new Unswer().GetType());
                    hi.value = questions.ElementAt(i).getUnswerIndex(id);
                    IntHierarchy hi2 = new IntHierarchy(new Question().GetType(), hi);
                    hi2.value = i;
                    return hi2;
                }
                catch (GoTestObjectNotFound ex)
                {
                }
            }

            throw new GoTestObjectNotFound();
        }

        public Test copy()
        {
            Test copy = new Test();
            copy.name = name;
            copy.questionsNumber = questionsNumber;
            copy.requeredUnswersNumber = requeredUnswersNumber;
            copy.id = id;
            for(int i=0; i<questions.Count; i++)
            {
                copy.questions.Add(questions.ElementAt(i).copy());
            }

            return copy;
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
