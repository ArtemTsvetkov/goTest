using goTest.Navigator.Basic;
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

        public QuestionsView(Form1 form)
        {
            this.form = form;
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
