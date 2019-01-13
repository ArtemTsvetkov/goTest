using goTest.CommonComponents.Interfaces;
using goTest.Navigator.Basic;
using goTest.Testing.Interfaces;
using goTest.Testing.Objects;
using goTest.Testing.Objects.ViewsObjects;
using goTest.Testing.Realization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.Testing.Views
{
    class ResultTestingView : NavigatorsView, Observer
    {
        private Form1 form;
        private GoTestModel model;

        public ResultTestingView(Form1 form, GoTestModel model)
        {
            this.form = form;
            this.model = model;
            model.subscribe(this);
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(11);
        }

        public string getName()
        {
            return "ResultTestingView";
        }

        public void notify()
        {
            if (Navigator.Navigator.getInstance().getCurrentViewsName().Equals(getName()))
            {
                Test test = model.getCurrentTest();
                int countOfRightUnswers = model.getCountOfRightUnswersOnTest();
                form.label40Elem.Text = test.QuestionsNumber.ToString();
                form.label41Elem.Text = test.RequeredUnswersNumber.ToString();
                form.label42Elem.Text = countOfRightUnswers.ToString();
                if (test.RequeredUnswersNumber <= countOfRightUnswers)
                {
                    form.label43Elem.Text = "Тест сдан";
                }
                else
                {
                    form.label43Elem.Text = "Тест не сдан";
                }
                int fsfsf = 0;
            }
        }

        public void reset()
        {
            throw new NotImplementedException();
        }
    }
}
