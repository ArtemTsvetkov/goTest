using goTest.Navigator.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Views
{
    class UpdateSubjectView : NavigatorsView
    {
        private Form1 form;

        public UpdateSubjectView(Form1 form)
        {
            this.form = form;
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(7);
        }

        public string getName()
        {
            return "UpdateSubjectView";
        }

        public void reset()
        {
            form.textBox12Elem.Text = "";
        }
    }
}
