using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.Interfaces;
using goTest.Navigator.Basic;
using goTest.Testing.Interfaces;
using goTest.Testing.Objects;
using goTest.Testing.Objects.ViewsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Views
{
    class CreateTestView : NavigatorsView, Observer
    {
        private Form1 form;
        private GoTestAdapterI adapter;
        private BasicModel<List<Subject>, List<Subject>> model;

        public CreateTestView(Form1 form, GoTestAdapterI adapter,
            BasicModel<List<Subject>, List<Subject>> model)
        {
            this.form = form;
            this.adapter = adapter;
            this.model = model;
            model.subscribe(this);
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(5);
        }

        public string getName()
        {
            return "CreateTestView";
        }

        public void notify()
        {
            if (Navigator.Navigator.getInstance().getCurrentViewsName().Equals(getName()))
            {
                adapter.adapte(model.getResult());
                List<VSubject> subjects = adapter.getResult();
                form.comboBox1Elem.Items.Clear();
                for (int i = 0; i < subjects.Count; i++)
                {
                    for (int s = 0; s < subjects.Count; s++)
                    {
                        if (subjects.ElementAt(s).getPosition() == i & 
                            subjects.ElementAt(i).Name!=null)
                        {
                            form.comboBox1Elem.Items.Add(subjects.ElementAt(i).Name);
                        }
                    }
                }
                int subjectPos = -1;
                int testPos = -1;
                for (int i = 0; i < subjects.Count; i++)
                {
                    for (int s = 0; s < subjects.ElementAt(i).Tests.Count; s++)
                    {
                        if(subjects.ElementAt(i).Tests.ElementAt(s).IsSelected
                            || subjects.ElementAt(i).Tests.ElementAt(s).Questions.Count>0)
                        {
                            subjectPos = i;
                            testPos = s;
                            break;
                        }
                    }
                    if(subjectPos != -1)
                    {
                        break;
                    }
                }
                if (subjectPos != -1)
                {
                    try
                    {
                        form.comboBox1Elem.SelectedIndex = subjects.ElementAt(subjectPos).getPosition();
                    }
                    catch(Exception ex)
                    {

                    }
                    adapter.getResult().ElementAt(subjectPos).IsSelected = true;
                    adapter.getResult().ElementAt(subjectPos).Tests.ElementAt(testPos).IsSelected = true;

                    VTest test = subjects.ElementAt(subjectPos).Tests.ElementAt(testPos);
                    form.textBox9Elem.Text = test.Name;
                    form.numericUpDown1Elem.Value = test.QuestionsNumber;
                    form.numericUpDown2Elem.Value = test.RequeredUnswersNumber;
                }
            }
        }

        public void reset()
        {
            form.textBox9Elem.Text = "";
            form.numericUpDown1Elem.Value = 0;
            form.numericUpDown2Elem.Value = 0;
        }
    }
}
