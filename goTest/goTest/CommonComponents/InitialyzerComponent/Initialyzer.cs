using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.CommonComponents.InitialyzerComponent.ReadConfig;
using goTest.MenuComponent;
using goTest.SecurityComponent.Encryption.Realization;
using goTest.SecurityComponent.Realization;
using goTest.SecurityComponent.Views;
using goTest.Testing.Realization;
using goTest.Testing.Realization.Workers;
using goTest.Testing.Views;
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
            try
            {
                //
                //Config tabs
                //
                form.tabControl1Elem.Appearance = TabAppearance.FlatButtons;
                form.tabControl1Elem.ItemSize = new Size(0, 1);
                form.tabControl1Elem.SizeMode = TabSizeMode.Fixed;
                form.tabControl1Elem.TabStop = false;
                //
                //Config tables
                //
                form.dataGridView1Elem.RowHeadersVisible = false;
                form.dataGridView2Elem.RowHeadersVisible = false;
                //
                //Config other views components
                //
                form.textBox11Elem.ReadOnly = true;
                //
                //Security component
                //
                SecurityModel securityModel = new SecurityModel();
                components.securityController = new SecurityController(securityModel);
                AutorizationSecurityView securityView =
                    new AutorizationSecurityView(form, securityModel);

                EncryptConfig conf = new EncryptConfig(new byte[]{0x7c,0x26,0xf0,0xc6,0x77,
                0xaa,0xba,0x6a,0x66,0x7b,0x56,0x0f,0x98,0x43,0xba,0x2d,0xbb,0x06,0x0a,0xef,
                0xad,0x32,0x88,0xb0,0x5d,0xfb,0xfe,0x98,0xa7,0xa7,0xa5,0x1a});
                EncryptWorker.getInstance().setConfig(conf);
                
                //
                //goTest component
                //
                GoTestModel goTestModel = new GoTestModel();
                components.goTestController = new GoTestController(goTestModel);
                components.questionsViewAdapter = new GoTestAdapter();
                components.updateSubjectViewAdapter = new GoTestAdapter();
                components.сreateSubjectViewAdapter = new GoTestAdapter();
                components.testingViewAdapter = new GoTestAdapter();
                components.deletingSubjectViewAdapter = new GoTestAdapter();
                components.deletingTestViewAdapter = new GoTestAdapter();
                //
                //Navigator
                //
                Navigator.Navigator.getInstance().addView(securityView);
                Navigator.Navigator.getInstance().addView(new CreateAdminView(form));
                Navigator.Navigator.getInstance().addView(new AdminMenuView(form));
                Navigator.Navigator.getInstance().addView(new StudentMenuView(form));
                Navigator.Navigator.getInstance().addView(new ChangePasswordView(form));
                Navigator.Navigator.getInstance().addView(new DeleteSubjectView(form,
                    components.deletingSubjectViewAdapter, goTestModel));
                Navigator.Navigator.getInstance().addView(new DeleteTestView(form,
                    components.deletingTestViewAdapter, goTestModel));
                Navigator.Navigator.getInstance().addView(new UpdateTestView(form,
                    components.questionsViewAdapter, goTestModel));
                Navigator.Navigator.getInstance().addView(new UpdateSubjectView(form, 
                    components.updateSubjectViewAdapter, goTestModel));
                Navigator.Navigator.getInstance().addView(new TestingView(form,
                    components.testingViewAdapter, goTestModel));
                Navigator.Navigator.getInstance().addView(new ProcessingTestingView(form,
                    components.testingViewAdapter, goTestModel));
                Navigator.Navigator.getInstance().addView(new ResultTestingView(form,
                    goTestModel));
                Navigator.Navigator.getInstance().addView(new CreateSubjectView(form, 
                    components.сreateSubjectViewAdapter));
                CreateTestView createTestView = new CreateTestView(form,
                    components.questionsViewAdapter, goTestModel);
                goTestModel.subscribe(createTestView);
                Navigator.Navigator.getInstance().addView(createTestView);

                Navigator.Navigator.getInstance().addView(new QuestionsView(form,
                    components.questionsViewAdapter, goTestModel));
                Navigator.Navigator.getInstance().navigateTo("AutorizationSecurityView");
                //
                //ReadConfig
                //
                ConfigReader.getInstance().read();
                //
                //Check database
                //
                components.securityController.checkDataBase();
                form.button1Elem.Visible = true;
                form.button8Elem.Visible = true;
                /*
                //
                //ТОЛЬКО ДЛЯ ОТЛАДКИ, ПОТОМ УБРАТЬ
                //
                form.textBox1Elem.Text = "Admin";
                form.textBox2Elem.Text = "1234";
                */
            }
            catch (Exception ex)
            {
                form.button1Elem.Visible = false;
                form.button8Elem.Visible = false;
                ExceptionHandler.Realization.ExceptionHandler.getInstance().processing(ex);
            }
        }
    }
}
