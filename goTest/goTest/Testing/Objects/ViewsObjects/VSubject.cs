using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects.ViewsObjects
{
    class VSubject : Subject
    {
        private int position;
        private List<VTest> tests;

        public VSubject(int position, Subject subject)
        {
            tests = new List<VTest>();
            this.position = position;
            restore(subject);
        }

        public void restore(Subject subject)
        {
            Id = subject.Id;
            Name = subject.Name;
        }

        public int getPosition()
        {
            return position;
        }

        internal new List<VTest> Tests
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
