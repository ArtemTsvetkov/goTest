using goTest.Testing.Exceptions;
using goTest.Testing.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization.Workers
{
    class TestObjectsSearcher
    {
        //return 2 arguments - 1)index in questions list, 2)index in unswers list
        public int[] getUnswerPosition(List<Question> questions, Question selectedQuestion,
            Unswer selectedUnswer)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions.ElementAt(i).compare(selectedQuestion))
                {
                    for (int h = 0; h < questions.ElementAt(i).Unswers.Count; h++)
                    {
                        if (questions.ElementAt(i).Unswers.ElementAt(i).
                                compare(selectedUnswer))
                        {
                            int[] arg = new int[2];
                            arg[0] = i;
                            arg[1] = h;

                            return arg;
                        }
                    }

                    throw new GoTestObjectNotFound();
                }
            }

            throw new GoTestObjectNotFound();
        }

        public int getQuestionPosition(List<Question> questions, Question selectedQuestion)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions.ElementAt(i).compare(selectedQuestion))
                {
                    return i;
                }
            }

            throw new GoTestObjectNotFound();
        }
    }
}
