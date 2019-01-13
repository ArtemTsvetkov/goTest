using goTest.Testing.Objects;
using goTest.Testing.Objects.ViewsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Interfaces
{
    interface GoTestAdapterI
    {
        void adapte(List<Subject> subject);
        List<VSubject> getResult();
    }
}
