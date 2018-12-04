using goTest.Navigator.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Views
{
    class ChangePasswordView : NavigatorsView
    {
        private Form1 form;

        public ChangePasswordView(Form1 form)
        {
            this.form = form;
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(2);
        }

        public string getName()
        {
            return "ChangePasswordView";
        }

        public void reset()
        {
            form.textBox6Elem.Text = "";
            form.textBox7Elem.Text = "";
            form.textBox8Elem.Text = "";
        }
    }
}
