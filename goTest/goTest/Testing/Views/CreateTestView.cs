using goTest.Navigator.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Views
{
    class CreateTestView : NavigatorsView
    {
        private Form1 form;

        public CreateTestView(Form1 form)
        {
            this.form = form;
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(5);
        }

        public string getName()
        {
            return "CreateTestView";
        }

        public void reset()
        {
            form.textBox9Elem.Text = "";
            form.numericUpDown1Elem.Value = 0;
            form.numericUpDown2Elem.Value = 0;
        }
    }
}
