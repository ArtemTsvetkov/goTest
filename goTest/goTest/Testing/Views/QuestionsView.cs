using goTest.Navigator.Basic;
using goTest.Testing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Views
{
    class QuestionsView : NavigatorsView
    {
        private Form1 form;
        private GoTestAdapterI adapter;

        public QuestionsView(Form1 form, GoTestAdapterI adapter)
        {
            this.form = form;
            this.adapter = adapter;
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(8);
        }

        public string getName()
        {
            return "QuestionsView";
        }

        public void reset()
        {
            form.textBox11Elem.Text = "";
            form.dataGridView1Elem.Rows.Clear();
            form.dataGridView2Elem.Rows.Clear();
            form.label27Elem.Text = "Вопрос 0/0";
        }
    }
}
