﻿using goTest.CommonComponents.BasicObjects;
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
    class UpdateTestView : NavigatorsView, Observer
    {
        private Form1 form;
        private GoTestAdapterI adapter;
        private BasicModel<List<Subject>, List<Subject>> model;

        public UpdateTestView(Form1 form, GoTestAdapterI adapter,
            BasicModel<List<Subject>, List<Subject>> model)
        {
            this.form = form;
            this.adapter = adapter;
            this.model = model;
            model.subscribe(this);
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

        public void notify()
        {
            if (Navigator.Navigator.getInstance().getCurrentViewsName().Equals(getName()))
            {
                adapter.adapte(model.getResult());
                List<VSubject> subjects = adapter.getResult();
                for (int i = 0; i < subjects.Count; i++)
                {
                    for (int s = 0; s < subjects.Count; s++)
                    {
                        if (subjects.ElementAt(s).getPosition() == i)
                        {
                            form.comboBox5Elem.Items.Add(subjects.ElementAt(i).Name);
                        }
                    }
                }
            }
        }
    }
}
