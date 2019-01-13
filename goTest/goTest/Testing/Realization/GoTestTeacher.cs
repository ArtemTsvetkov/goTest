using goTest.Testing.Exceptions;
using goTest.Testing.Objects;
using goTest.Testing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization
{
    class GoTestTeacher
    {
        private List<int[]> unsersIds;
        private Test test;

        public GoTestTeacher(Test test)
        {
            unsersIds = new List<int[]>();
            this.test = test;
        }

        public void userUnswered(int[] id)
        {
            unsersIds.Add(id);
        }

        public int getCountOfRightUnswers()
        {
            int count = 0;
            for (int i=0; i<test.Questions.Count; i++)
            {
                Question question = test.Questions.ElementAt(i);
                if (question.QuestionsType.getType().Equals(
                    QuestionTypes.singleAnswer.getType()))
                {
                    int unswerId = unsersIds.ElementAt(i)[0];
                    if (isRightUnswer(unswerId, question))
                    {
                        count++;
                    }
                }
                else
                {
                    int[] unswerIds = unsersIds.ElementAt(i);
                    if (isRightUnswers(unswerIds, question))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        private bool isRightUnswers(int[] unswerIds, Question question)
        {
            int requiredCount = 0;
            int rightCount = 0;
            for (int i = 0; i < unswerIds.Length; i++)
            {
                if(isRightUnswer(unswerIds[i], question))
                {
                    rightCount++;
                }
            }
            for (int i = 0; i < question.Unswers.Count; i++)
            {
                Unswer unswer = question.Unswers.ElementAt(i);
                if (unswer.IsRight)
                {
                    requiredCount++;
                }
            }
            if(rightCount==requiredCount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isRightUnswer(int unswerId, Question question)
        {
            for (int i = 0; i < question.Unswers.Count; i++)
            {
                Unswer unswer = question.Unswers.ElementAt(i);
                if (unswer.Id==unswerId)
                {
                    if(unswer.IsRight)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            throw new GoTestObjectNotFound();
        }
    }
}
