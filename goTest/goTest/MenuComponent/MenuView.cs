using goTest.Navigator.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.MenuComponent
{
    class MenuView : NavigatorsView
    {
        private Form1 form;

        public MenuView(Form1 form)
        {
            this.form = form;
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(3);
        }

        public string getName()
        {
            return "MenuView";
        }
    }
}
