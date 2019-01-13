using goTest.Testing.Exceptions;
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
        private bool isSelected;

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
            for(int i=0; i<subject.Tests.Count; i++)
            {
                tests.Add(new VTest(0, subject.Tests.ElementAt(i)));
            }
        }

        public int getPosition()
        {
            return position;
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
            }
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

        public VTest getSelectedTest()
        {
            for (int i = 0; i < tests.Count; i++)
            {
                if (tests.ElementAt(i).IsSelected)
                {
                    return tests.ElementAt(i);
                }
            }

            throw new GoTestObjectNotFound();
        }
    }
}
