using goTest.Navigator.Basic;
using goTest.Testing.Interfaces;
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
        private GoTestAdapterI adapter;

        public CreateSubjectView(Form1 form, GoTestAdapterI adapter)
        {
            this.form = form;
            this.adapter = adapter;
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
