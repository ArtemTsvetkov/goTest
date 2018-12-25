using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.CommonComponents.Interfaces;
using goTest.Navigator.Basic;
using goTest.Testing.Exceptions;
using goTest.Testing.Interfaces;
using goTest.Testing.Objects;
using goTest.Testing.Objects.ViewsObjects;
using goTest.Testing.Realization;
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
                    onRadioButtons(question.Unswers.Count);
                    form.textBox13Elem.Text = question.QuestionsContent;
                    for(int i=0; i<question.Unswers.Count; i++)
                    {
                        form.radioButtons[i].Text = question.Unswers.ElementAt(i).Content;
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

        public void onRadioButtons(int count)
        {
            RadioButton[] buttons = form.radioButtons;
            for (int i=0; i<count; i++)
            {
                buttons[i].Visible = true;
            }
        }

        public void offRadioButtons()
        {
            RadioButton[] buttons = form.radioButtons;
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Visible = false;
            }
        }

        public void reset()
        {
            throw new NotImplementedException();
        }
    }
}
