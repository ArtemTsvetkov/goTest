using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using goTest.SecurityComponent.Encryption.Realization;
using goTest.CommonComponents.DataConverters.Realization;
using goTest.CommonComponents.InitialyzerComponent;
using goTest.CommonComponents.ExceptionHandler.Realization;
using goTest.SecurityComponent.Exceptions;

namespace goTest
{
    public partial class Form1 : Form
    {
        private InitComponents iniComponents;

        public Form1()
        {
            InitializeComponent();
            //Init
            iniComponents = new InitComponents();
            Initialyzer init = new Initialyzer(iniComponents, this);
            init.init();
        }


        //
        //Getters and setters
        //


        public DataGridView dataGridView1Elem
        {
            get { return dataGridView1; }
        }

        public DataGridView dataGridView2Elem
        {
            get { return dataGridView2; }
        }

        public TabControl tabControl1Elem
        {
            get { return tabControl1; }
        }

        public TextBox textBox1Elem
        {
            get { return textBox1; }
        }

        public TextBox textBox2Elem
        {
            get { return textBox2; }
        }

        public TextBox textBox6Elem
        {
            get { return textBox6; }
        }

        public TextBox textBox7Elem
        {
            get { return textBox7; }
        }

        public TextBox textBox8Elem
        {
            get { return textBox8; }
        }

        public TextBox textBox9Elem
        {
            get { return textBox9; }
        }

        public TextBox textBox10Elem
        {
            get { return textBox10; }
        }

        public TextBox textBox11Elem
        {
            get { return textBox11; }
        }

        public TextBox textBox12Elem
        {
            get { return textBox12; }
        }

        public NumericUpDown numericUpDown1Elem
        {
            get { return numericUpDown1; }
        }

        public NumericUpDown numericUpDown2Elem
        {
            get { return numericUpDown2; }
        }

        public Label label27Elem
        {
            get { return label27; }
        }

        //
        //Events
        //


        //Enter as admin button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.securityController.setConfig(textBox1.Text, textBox2.Text);
                iniComponents.securityController.signIn();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Add password for Admin user button
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text.Equals(textBox3.Text) & textBox5.Text != "")
            {
                try
                {
                    iniComponents.securityController.addNewUser(textBox4.Text,
                        textBox5.Text);
                    iniComponents.securityController.checkDataBase();
                }
                catch (Exception ex)
                {
                    ExceptionHandler.getInstance().processing(ex);
                }
            }
            else
            {
                try
                {
                    throw new BadCheckedPasswords();
                }
                catch (Exception ex)
                {
                    ExceptionHandler.getInstance().processing(ex);
                }
            }
        }

        //Change password button
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox6.Text.Equals(textBox7.Text) & textBox6.Text != "" & textBox8.Text != "")
            {
                iniComponents.securityController.changeUserPassword(textBox8.Text,
                    textBox7.Text);
            }
            else
            {
                try
                {
                    throw new BadCheckedPasswords();
                }
                catch (Exception ex)
                {
                    ExceptionHandler.getInstance().processing(ex);
                }
            }
        }

        //Go to change password view button
        private void button4_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("ChangePasswordView");
        }

        //Inter as student button
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.securityController.setConfig("Student", "Student");
                iniComponents.securityController.signInAsStudent();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Go to create test view button
        private void button6_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("CreateTestView");
        }

        //Go to create subject view button
        private void button9_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("CreateSubjectView");
        }

        //Go to update subject view button
        private void button10_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("UpdateSubjectView");
        }

        //Go to update test view button
        private void button7_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("UpdateTestView");
        }

        //Go to questions view button
        private void button11_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("QuestionsView");
        }

        //Go to next update test view
        private void button23_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("CreateTestView");
        }

        //Cancel from create subject view
        private void button17_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().resetCurrentView();
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }

        //Cancel from create test view
        private void button16_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().resetCurrentView();
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }

        //Cancel from change subject view
        private void button13_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().resetCurrentView();
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }

        //Cancel from questions view
        private void button12_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().resetCurrentView();
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }

        //Cancel from change test view
        private void button22_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().resetCurrentView();
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }

        //Create subject button
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.createSubject(textBox10.Text);
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Create test button
        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.createTest(textBox9.Text, 
                    comboBox1.Text, int.Parse(numericUpDown1.Value.ToString()), 
                    int.Parse(numericUpDown2.Value.ToString()));
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.updateSubject(comboBox3.Text, textBox12.Text);
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Save questions (not cleaning)
        private void button14_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }

        //Add queston into table
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.addEmptyQuestonArea();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Delete queston from table
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.deleteQuestion(dataGridView1.
                    SelectedRows[0].Cells[0].RowIndex);
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Add unswer into table
        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.addEmptyUnswerArea();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Delete unswer from table
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.deleteUnswer(dataGridView2.
                    SelectedRows[0].Cells[0].RowIndex);
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }
    }
}
