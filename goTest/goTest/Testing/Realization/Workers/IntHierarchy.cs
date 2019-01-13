using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Realization.Workers
{
    class IntHierarchy
    {
        public int value;
        private IntHierarchy child;
        private Type type;

        public IntHierarchy(Type type)
        {
            this.type = type;
        }

        public IntHierarchy(Type type, IntHierarchy child)
        {
            this.type = type;
            this.child = child;
        }

        public bool compare(object obj)
        {
            if(obj.GetType().Equals(type))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IntHierarchy getChild()
        {
            return child;
        }

        public Type getLastListType()
        {
            if(child==null)
            {
                return type;
            }
            else
            {
                return child.getLastListType();
            }
        }
    }
}
