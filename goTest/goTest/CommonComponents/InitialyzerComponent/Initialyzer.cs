using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.CommonComponents.InitialyzerComponent.ReadConfig;
using goTest.MenuComponent;
using goTest.SecurityComponent.Realization;
using goTest.SecurityComponent.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace goTest.CommonComponents.InitialyzerComponent
{
    class Initialyzer
    {
        private InitComponents components;
        private Form1 form;

        public Initialyzer(InitComponents components, Form1 form)
        {
            this.form = form;
            this.components = components;
        }

        public void init()
        {
            //
            //Exceptions init
            //
            ConcreteExceptionHandlerInitializer.initThisExceptionHandler(
                ExceptionHandler.Realization.ExceptionHandler.getInstance());
            //
            //Config tabs
            form.tabControl1Elem.Appearance = TabAppearance.FlatButtons;
            form.tabControl1Elem.ItemSize = new Size(0, 1);
            form.tabControl1Elem.SizeMode = TabSizeMode.Fixed;
            form.tabControl1Elem.TabStop = false;
            //
            //ReadConfig
            //
            ConfigReader.getInstance().read();
            //
            //Security component
            //
            SecurityModel securityModel = new SecurityModel();
            components.securityController = new SecurityController(securityModel);
            AutorizationSecurityView securityView =
                new AutorizationSecurityView(form, securityModel);
            Navigator.Navigator.getInstance().addView(securityView);
            Navigator.Navigator.getInstance().addView(new CreateAdminView(form));
            Navigator.Navigator.getInstance().addView(new AdminMenuView(form));
            Navigator.Navigator.getInstance().addView(new StudentMenuView(form));
            Navigator.Navigator.getInstance().addView(new ChangePasswordView(form));
            //
            //Navigator
            //
            Navigator.Navigator.getInstance().navigateTo("AutorizationSecurityView");
            //
            //Check database
            //
            try
            {
                components.securityController.checkDataBase();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Realization.ExceptionHandler.getInstance().processing(ex);
            }
        }
    }
}
