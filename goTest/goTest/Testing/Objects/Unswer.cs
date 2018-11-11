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
        private int position;
        private bool isRight;

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

        public int Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
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
    }
}
