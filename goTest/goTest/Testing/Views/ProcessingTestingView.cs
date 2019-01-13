using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.CommonComponents.Interfaces;
using goTest.Navigator.Basic;
using goTest.Testing.Exceptions;
using goTest.Testing.Interfaces;
using goTest.Testing.Objects;
using goTest.Testing.Objects.ViewsObjects;
using goTest.Testing.Realization;
using goTest.Testing.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goTest.Testing.Views
{
    class ProcessingTestingView : NavigatorsView, Observer
    {
        private Form1 form;
        private GoTestAdapterI adapter;
        private GoTestModel model;

        public ProcessingTestingView(Form1 form, GoTestAdapterI adapter,
            GoTestModel model)
        {
            this.form = form;
            this.adapter = adapter;
            this.model = model;
            model.subscribe(this);
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(10);
        }

        public string getName()
        {
            return "ProcessingTestingView";
        }

        public void notify()
        {
            if (Navigator.Navigator.getInstance().getCurrentViewsName().Equals(getName()))
            {
                offRadioButtons();
                try
                {
                    Question question = model.getNextQuestion();
                    List<Subject> subjects = new List<Subject>();
                    Subject subject = new Subject();
                    Test test = new Test();
                    test.Questions.Add(question);
                    subject.Tests.Add(test);
                    subjects.Add(subject);
                    adapter.adapte(subjects);
                    if (question.QuestionsType.getType().Equals(
                        QuestionTypes.singleAnswer.getType()))
                    {
                        onRadioButtons(question.Unswers.Count);
                        offCheckBoxes();
                        form.textBox13Elem.Text = question.QuestionsContent;
                        for (int i = 0; i < question.Unswers.Count; i++)
                        {
                            form.radioButtons[i].Text = question.Unswers.ElementAt(i).Content;
                        }
                    }
                    else
                    {
                        onCheckBoxes(question.Unswers.Count);
                        offRadioButtons();
                        form.textBox13Elem.Text = question.QuestionsContent;
                        for (int i = 0; i < question.Unswers.Count; i++)
                        {
                            form.checkBoxes[i].Text = question.Unswers.ElementAt(i).Content;
                        }
                    }
                }
                catch(QuestionsIsOver ex)
                {
                    Navigator.Navigator.getInstance().navigateTo("ResultTestingView");
                }
                catch(Exception ex)
                {
                    ExceptionHandler.getInstance().processing(ex);
                }
            }
        }


        public void reset()
        {
            throw new NotImplementedException();
        }

        private void onRadioButtons(int count)
        {
            activatePanel(false);
            RadioButton[] buttons = form.radioButtons;
            for (int i=0; i<count; i++)
            {
                buttons[i].Visible = true;
                buttons[i].Checked = false;
            }
        }

        private void offRadioButtons()
        {
            RadioButton[] buttons = form.radioButtons;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Checked = false;
                buttons[i].Visible = false;
            }
        }

        private void onCheckBoxes(int count)
        {
            activatePanel(true);
            CheckBox[] buttons = form.checkBoxes;
            for (int i = 0; i < count; i++)
            {
                buttons[i].Visible = true;
                buttons[i].Checked = false;
            }
        }

        private void offCheckBoxes()
        {
            CheckBox[] buttons = form.checkBoxes;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Checked = false;
                buttons[i].Visible = false;
            }
        }

        private void activatePanel(bool onCheckBoxes)
        {
            if(onCheckBoxes)
            {
                form.panel2Elem.Visible = true;
                form.panel1Elem.Visible = false;
            }
            else
            {
                form.panel2Elem.Visible = false;
                form.panel1Elem.Visible = true;
            }
        }
    }
}
