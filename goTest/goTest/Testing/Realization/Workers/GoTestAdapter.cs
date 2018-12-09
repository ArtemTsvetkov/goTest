using goTest.Testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using goTest.Testing.Objects;
using goTest.Testing.Objects.ViewsObjects;
using goTest.Testing.Exceptions;

namespace goTest.Testing.Realization.Workers
{
    class GoTestAdapter : GoTestAdapterI
    {
        private List<VSubject> result;

        public void adapte(List<Subject> subject)
        {
            result = new List<VSubject>();
            for(int i=0; i<subject.Count; i++)
            {
                result.Add(new VSubject(i, subject.ElementAt(i)));
            }
        }

        public List<VSubject> getResult()
        {
            return result;
        }
    }
}
