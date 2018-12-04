using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects
{
    class Unswer
    {
        private string content;
        private bool isRight;
        private int id;

        public string Content
        {
            get
            {
                return content;
            }

            set
            {
                content = value;
            }
        }

        public bool compare(Unswer unswer)
        {
            if (!unswer.content.Equals(content))
            {
                return false;
            }
            if (!unswer.isRight.Equals(isRight))
            {
                return false;
            }

            return true;
        }

        public Unswer copy()
        {
            Unswer copy = new Unswer();
            copy.content = content;
            copy.id = id;
            copy.isRight = isRight;

            return copy;
        }

        public bool IsRight
        {
            get
            {
                return isRight;
            }

            set
            {
                isRight = value;
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
    }
}
