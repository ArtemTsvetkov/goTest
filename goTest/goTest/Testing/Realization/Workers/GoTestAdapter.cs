using goTest.Testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using goTest.Testing.Objects;
using goTest.Testing.Objects.ViewsObjects;

namespace goTest.Testing.Realization.Workers
{
    class GoTestAdapter : GoTestAdapterI
    {
        private List<VSubject> result;

        public void adapte(List<Subject> subject, int position)
        {
            result = new List<VSubject>();
            //for()

            //for (int i = 0; i < test.)
        }

        public List<VSubject> getResult()
        {
            return result;
        }
    }
}
