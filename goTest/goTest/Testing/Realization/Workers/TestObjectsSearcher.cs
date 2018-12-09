using goTest.Testing.Exceptions;
using goTest.Testing.Objects;
using goTest.Testing.Objects.ViewsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization.Workers
{
    class TestObjectsSearcher
    {
        public IntHierarchy getUnswerPosition(List<Subject> subjects, int selectedUnswerId)
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                try
                {
                    IntHierarchy hi = new IntHierarchy(new Subject().GetType(), 
                        subjects.ElementAt(i).searchObjectIndex(selectedUnswerId));
                    hi.value = i;
                    return hi;
                }
                catch (GoTestObjectNotFound ex)
                {
                }
            }

            throw new GoTestObjectNotFound(); 
        }

        public IntHierarchy getQuestionPosition(List<Subject> subjects, int selectedQuestionId)
        {
            return getUnswerPosition(subjects, selectedQuestionId);
        }

        public IntHierarchy getTestPosition(List<Subject> subjects, int selectedTestId)
        {
            return getUnswerPosition(subjects, selectedTestId);
        }

        public int getQuestionPosition(List<VQuestion> questions, int selectedQuestionId)
        {
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions.ElementAt(i).Id.Equals(selectedQuestionId))
                {
                    return i;
                }
            }

            throw new GoTestObjectNotFound();
        }

        public int getSelectedSubject(List<VSubject> subjects)
        {
            for (int i = 0; i < subjects.Count; i++)
            {
                if (subjects.ElementAt(i).IsSelected)
                {
                    return i;
                }
            }

            throw new GoTestObjectNotFound();
        }
    }
}