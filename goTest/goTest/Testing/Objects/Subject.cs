using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects
{
    class Subject
    {
        private string name;
        private int id;
        private List<Test> tests;

        public Subject()
        {
            tests = new List<Test>();
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

        internal List<Test> Tests
        {
            get
            {
                return tests;
            }

            set
            {
                tests = value;
            }
        }
    }
}
