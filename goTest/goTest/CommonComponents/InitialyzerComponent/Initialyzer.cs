using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.CommonComponents.InitialyzerComponent.ReadConfig;
using goTest.SecurityComponent.Realization;
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
            //AutorizationSecurityView securityView =
            //    new AutorizationSecurityView(form, securityModel);
            //components.securityController = new SecurityController(securityModel);
            //Navigator.Navigator.getInstance().addView(securityView);
            //
            //Menu
            //
            //Navigator.Navigator.getInstance().addView(new MenuView(form));
            //
            //Navigator
            //
            //Navigator.Navigator.getInstance().navigateTo("AutorizationSecurityView");
        }
    }
}
