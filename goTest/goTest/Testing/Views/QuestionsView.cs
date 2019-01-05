using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.Interfaces;
using goTest.Navigator.Basic;
using goTest.Testing.Interfaces;
using goTest.Testing.Objects;
using goTest.Testing.Objects.ViewsObjects;
using goTest.Testing.Realization.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Views
{
    class QuestionsView : NavigatorsView, Observer
    {
        private Form1 form;
        private GoTestAdapterI adapter;
        private BasicModel<List<Subject>, List<Subject>> model;

        public QuestionsView(Form1 form, GoTestAdapterI adapter,
            BasicModel<List<Subject>, List<Subject>> model)
        {
            this.form = form;
            this.adapter = adapter;
            this.model = model;
            model.subscribe(this);
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(8);
        }

        public string getName()
        {
            return "QuestionsView";
        }

        public void notify()
        {
            CreateTestView createTestView = new CreateTestView(form, adapter, model);
            if (Navigator.Navigator.getInstance().getCurrentViewsName().Equals(getName()) |
                Navigator.Navigator.getInstance().getCurrentViewsName().
                Equals(createTestView.getName()))
            {
                int questionId = -1;
                try
                {
                    for(int i=0; i<adapter.getResult().Count; i++)
                    {
                        if(adapter.getResult().ElementAt(i).IsSelected)
                        {
                            questionId = adapter.getResult().ElementAt(i).getSelectedTest().
                                getSelectedQuestion().Id;
                        }
                    }
                }
                catch(Exception ex)
                {

                }

                adapter.adapte(model.getResult());
             
                List<VSubject> subjects = adapter.getResult();
                int subjectPos = -1;
                int testPos = -1;
                for (int i = 0; i < subjects.Count; i++)
                {
                    for (int s = 0; s < subjects.ElementAt(i).Tests.Count; s++)
                    {
                        if (subjects.ElementAt(i).Tests.ElementAt(s).Questions.Count > 0)
                        {
                            subjectPos = i;
                            testPos = s;
                            break;
                        }
                    }
                    if (subjectPos != -1)
                    {
                        break;
                    }
                }
                if (subjectPos != -1)
                {
                    adapter.getResult().ElementAt(subjectPos).IsSelected = true;
                    adapter.getResult().ElementAt(subjectPos).Tests.ElementAt(testPos).IsSelected = true;
                    form.dataGridView2Elem.Rows.Clear();
                    if (questionId != -1)
                    {
                        try
                        {
                            TestObjectsSearcher searcher = new TestObjectsSearcher();
                            int selectedSubjectPosition = searcher.getSelectedSubject(adapter.getResult());
                            int selectedQuestionPosition = searcher.getQuestionPosition(
                                adapter.getResult().ElementAt(selectedSubjectPosition).getSelectedTest().
                                Questions, questionId);
                            adapter.getResult().ElementAt(selectedSubjectPosition).getSelectedTest().
                                Questions.ElementAt(selectedQuestionPosition).IsSelected = true;
                            VQuestion question = adapter.getResult().ElementAt(selectedSubjectPosition).getSelectedTest().
                                Questions.ElementAt(selectedQuestionPosition);
                            form.dataGridView2Elem.Rows.Add(question.Unswers.Count);
                            form.dataGridView2Elem.Rows[0].Selected = false;
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    VTest test = subjects.ElementAt(subjectPos).Tests.ElementAt(testPos);
                    form.dataGridView1Elem.Rows.Clear();
                    form.dataGridView1Elem.Rows.Add(test.Questions.Count);
                    for (int i = 0; i < test.Questions.Count; i++)
                    {
                        for (int s = 0; s < test.Questions.Count; s++)
                        {
                            if (test.Questions.ElementAt(s).getPosition() == i)
                            {
                                form.dataGridView1Elem.Rows[i].Cells[0].Value = test.Questions.
                                    ElementAt(s).QuestionsContent;
                            }
                        }
                    }
                    if (form.dataGridView1Elem.RowCount > 0)
                    {
                        form.dataGridView1Elem.Rows[0].Selected = false;
                    }
                }
            }
        }

        public void reset()
        {
            form.textBox11Elem.Text = "";
            form.dataGridView1Elem.Rows.Clear();
            form.dataGridView2Elem.Rows.Clear();
            form.label27Elem.Visible = false;
        }
    }
}
