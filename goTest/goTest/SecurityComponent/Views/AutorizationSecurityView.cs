using goTest.CommonComponents.BasicObjects;
using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.CommonComponents.Interfaces;
using goTest.Navigator.Basic;
using goTest.SecurityComponent.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goTest.SecurityComponent.Views
{
    class AutorizationSecurityView : Observer, NavigatorsView
    {
        private Form1 form;
        private BasicModel<SecurityUserInterface, SecurityUserInterface> model;

        public AutorizationSecurityView(Form1 form,
            BasicModel<SecurityUserInterface, SecurityUserInterface> model)
        {
            this.form = form;
            this.model = model;
            this.model.subscribe(this);
        }

        public void notify()
        {
            if (Navigator.Navigator.getInstance().getCurrentViewsName().Equals(
                "AutorizationSecurityView"))
            {
                SecurityUserInterface currentUser = model.getResult();
                if (currentUser.isEnterIntoSystem())
                {
                    try
                    {
                        if (currentUser.isAdmin())
                        {
                            Navigator.Navigator.getInstance().navigateTo("AdminMenuView");
                        }
                        else
                        {
                            Navigator.Navigator.getInstance().navigateTo("StudentMenuView");
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.getInstance().processing(ex);
                    }
                }
                else
                {
                    form.textBox2Elem.Text = "";
                    Navigator.Navigator.getInstance().navigateTo("AutorizationSecurityView");
                }
            }
        }

        public void show()
        {
            form.tabControl1Elem.SelectTab(0);
        }

        public string getName()
        {
            return "AutorizationSecurityView";
        }
    }
}
