using goTest.Navigator.Basic;
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

        public UpdateTestView(Form1 form)
        {
            this.form = form;
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
