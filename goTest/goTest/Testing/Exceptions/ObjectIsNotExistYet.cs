using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Exceptions
{
    class ObjectIsNotExistYet : Exception
    {
        public ObjectIsNotExistYet() : base() { }

        public ObjectIsNotExistYet(string message) : base(message) { }
    }
}
