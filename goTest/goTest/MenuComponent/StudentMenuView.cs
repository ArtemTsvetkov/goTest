using goTest.Navigator.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.MenuComponent
{
    class StudentMenuView : NavigatorsView
    {
        private Form1 form;

        public StudentMenuView(Form1 form)
        {
            this.form = form;
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(4);
        }

        public string getName()
        {
            return "StudentMenuView";
        }

        public void reset()
        {
            throw new NotImplementedException();
        }
    }
}
