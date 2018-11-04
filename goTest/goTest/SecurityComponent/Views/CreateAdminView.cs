using goTest.Navigator.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Views
{
    class CreateAdminView : NavigatorsView
    {
        private Form1 form;

        public CreateAdminView(Form1 form)
        {
            this.form = form;
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(1);
        }

        public string getName()
        {
            return "CreateAdminView";
        }
    }
}
