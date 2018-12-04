using goTest.Navigator.Basic;
using goTest.Testing.Interfaces;
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
        private GoTestAdapterI adapter;

        public UpdateSubjectView(Form1 form, GoTestAdapterI adapter)
        {
            this.form = form;
            this.adapter = adapter;
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
