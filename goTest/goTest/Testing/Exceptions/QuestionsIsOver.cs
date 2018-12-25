using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Exceptions
{
    class QuestionsIsOver : Exception
    {
        public QuestionsIsOver() : base() { }

        public QuestionsIsOver(string message) : base(message) { }
    }
}