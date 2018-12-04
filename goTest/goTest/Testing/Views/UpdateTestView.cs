using goTest.Navigator.Basic;
using goTest.Testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Views
{
    class UpdateTestView : NavigatorsView
    {
        private Form1 form;
        private GoTestAdapterI adapter;

        public UpdateTestView(Form1 form, GoTestAdapterI adapter)
        {
            this.form = form;
            this.adapter = adapter;
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(9);
        }

        public string getName()
        {
            return "UpdateTestView";
        }

        public void reset()
        {
            throw new NotImplementedException();
        }
    }
}
