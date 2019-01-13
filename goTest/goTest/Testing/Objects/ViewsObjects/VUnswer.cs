using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Objects.ViewsObjects
{
    class VUnswer : Unswer
    {
        private int position;
        private bool isSelected;

        public VUnswer(int position, Unswer unswer)
        {
            this.position = position;
            restore(unswer);
        }

        public void restore(Unswer unswer)
        {
            Content = unswer.Content;
            Id = unswer.Id;
            IsRight = unswer.IsRight;
        }

        public Unswer unRestore()
        {
            Unswer unswer = new Unswer();
            unswer.Content = Content;
            unswer.Id = Id;
            unswer.IsRight = IsRight;

            return unswer;
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
    }
}
