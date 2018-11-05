using goTest.Navigator.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Views
{
    class CreateSubjectView : NavigatorsView
    {
        private Form1 form;

        public CreateSubjectView(Form1 form)
        {
            this.form = form;
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(6);
        }

        public string getName()
        {
            return "CreateSubjectView";
        }

        public void reset()
        {
            form.textBox10Elem.Text = "";
        }
    }
}
