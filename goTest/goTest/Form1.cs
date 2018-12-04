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
using goTest.Testing.Objects;
using goTest.Testing.Types;
using goTest.Testing.Exceptions;
using goTest.Testing.Objects.ViewsObjects;

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

        public Button button1Elem
        {
            get { return button1; }
        }

        public Button button8Elem
        {
            get { return button8; }
        }

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

        public ComboBox comboBox3Elem
        {
            get { return comboBox3; }
        }

        public ComboBox comboBox5Elem
        {
            get { return comboBox5; }
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
            iniComponents.goTestController.loadAllSubjects();
        }

        //Go to update test view button
        private void button7_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("UpdateTestView");
            iniComponents.goTestController.loadAllSubjects();
        }

        //Go to questions view button
        private void button11_Click(object sender, EventArgs e)
        {
            if (!textBox9.Text.Equals("") & comboBox1.SelectedIndex != -1 &
                numericUpDown1.Value > 1 & numericUpDown2.Value <= numericUpDown1.Value)
            {
                Navigator.Navigator.getInstance().navigateTo("QuestionsView");
            }
            else
            {
                throw new NotAllAreasIsFill();
            }
        }

        //Go to next update test view
        private void button23_Click(object sender, EventArgs e)
        {
            for(int i=0; i<iniComponents.updateTestViewAdapter.getResult().Count; i++)
            {
                if(comboBox5.SelectedIndex == iniComponents.updateTestViewAdapter.
                    getResult().ElementAt(i).getPosition())
                {
                    VSubject currentSubject = iniComponents.updateTestViewAdapter.
                    getResult().ElementAt(i);
                    for(int m=0; m<currentSubject.Tests.Count; m++)
                    {
                        if(currentSubject.Tests.ElementAt(m).getPosition()==
                            comboBox4.SelectedIndex)
                        {
                            VTest currenTest = currentSubject.Tests.ElementAt(m);
                            Navigator.Navigator.getInstance().navigateTo("CreateTestView");
                            iniComponents.goTestController.getFullTestContent(currenTest.Id);
                            return;
                        }
                    }
                }
            }
            throw new GoTestObjectNotFound();
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
                /*iniComponents.goTestController.createTest(textBox9.Text, 
                    comboBox1.Text, int.Parse(numericUpDown1.Value.ToString()), 
                    int.Parse(numericUpDown2.Value.ToString()));*/
                //Должно быть что-то вроде save test(в случае update view-update test)
                //Притом без параметров, все данные нового теста уже лежат в модели
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Update subject button
        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.updateSubject(iniComponents.
                    updateSubjectViewAdapter.getResult().ElementAt(0).Id, textBox12.Text);
                Navigator.Navigator.getInstance().navigateToPreviousView();
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
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.ToString().Equals(""))
                {
                    return;
                }
            }
            dataGridView1.Rows.Add(1);
        }

        //Delete queston from table
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.deleteQuestion();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Add unswer into table
        private void button26_Click(object sender, EventArgs e)
        {
            for(int i=0; i<dataGridView2.RowCount; i++)
            {
                if(dataGridView2.Rows[i].Cells[1].Value.ToString().Equals(""))
                {
                    return;
                }
            }
            if (!dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.
                ToString().Equals(""))
            {
                dataGridView2.Rows.Add(1);
            }
            else
            {
                MessageBox.Show(
                    "Задайте текст для выбранного вопроса, прежде чем создавать ответ",
                    "Сообщение", MessageBoxButtons.OK,MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        //Delete unswer from table
        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.deleteUnswer();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Update question selection
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                List<VQuestion> questions = iniComponents.questionsViewAdapter.getResult().
                    ElementAt(0).Tests.ElementAt(0).Questions;
                for (int i = 0; i < questions.Count; i++)
                {
                    questions.ElementAt(i).IsSelected = false;
                }
                for (int i=0; i< questions.Count; i++)
                {
                    if(questions.ElementAt(i).getPosition().Equals(e.RowIndex))
                    {
                        questions.ElementAt(i).IsSelected = true;
                        iniComponents.goTestController.setQuestionSelection(
                            questions.ElementAt(i).Id);
                        iniComponents.goTestController.getFullQuestionContent();
                        return;
                    }
                }
                throw new GoTestObjectNotFound();
            }
            catch (GoTestObjectNotFound ex)
            {
                if(!dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Equals(""))
                {
                    ExceptionHandler.getInstance().processing(ex);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Update answer selection
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                List<VQuestion> questions = iniComponents.questionsViewAdapter.getResult().
                    ElementAt(0).Tests.ElementAt(0).Questions;
                for (int i = 0; i < questions.Count; i++)
                {
                    if (questions.ElementAt(i).IsSelected)
                    {
                        List<VUnswer> unswers = questions.ElementAt(i).Unswers;
                        for(int n=0; n<unswers.Count(); n++)
                        {
                            if(unswers.ElementAt(n).getPosition().Equals(e.RowIndex))
                            {
                                iniComponents.goTestController.setUnswerSelection(
                                    unswers.ElementAt(n).Id);
                                return;
                            }
                        }
                        throw new GoTestObjectNotFound();
                    }
                }
                throw new GoTestObjectNotFound();
            }
            catch (GoTestObjectNotFound ex)
            {
                if (!dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString().Equals(""))
                {
                    ExceptionHandler.getInstance().processing(ex);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Update or create Unswer
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Unswer unswer = new Unswer();
                if (dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString().Equals(""))
                {
                    return;
                }
                else
                {
                    unswer.Content = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("+"))
                    {
                        unswer.IsRight = true;
                    }
                    else
                    {
                        unswer.IsRight = false;
                    }
                    try
                    {
                        iniComponents.goTestController.updateSelected(unswer);
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.getInstance().processing(ex);
                    }
                }
            }
        }

        //Update or create Question
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Question question = new Question();
            question.Unswers = new List<Unswer>();
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (dataGridView2.Rows[i].Cells[0].Value == null)
                {
                    return;
                }
                Unswer unswer = new Unswer();
                unswer.Content = dataGridView2.Rows[i].Cells[0].Value.ToString();
                if (dataGridView2.Rows[i].Cells[1].Value.ToString().Equals("+"))
                {
                    unswer.IsRight = true;
                }
                else
                {
                    unswer.IsRight = false;
                }
                question.Unswers.Add(unswer);
            }
            if (comboBox2.Text.Equals("Единственный ответ"))
            {
                question.QuestionsType = QuestionTypes.singleAnswer;
            }
            else
            {
                question.QuestionsType = QuestionTypes.multiplyAnswer;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Equals(""))
            {
                return;
            }
            else
            {
                question.QuestionsContent = dataGridView2.Rows[e.RowIndex].Cells[1].
                    Value.ToString();
                iniComponents.goTestController.updateSelected(question);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            for (int i=0; i<iniComponents.updateTestViewAdapter.getResult().Count; i++)
            {
                if(iniComponents.updateTestViewAdapter.getResult().
                    ElementAt(i).getPosition() == comboBox5.SelectedIndex)
                {
                    VSubject subject = iniComponents.updateTestViewAdapter.getResult().ElementAt(i);
                    for (int m=0; m<subject.Tests.Count(); m++)
                    {
                        comboBox4.Items.Add(subject.Tests.ElementAt(m).Name);
                    }
                    comboBox4.Text = "";
                    comboBox4.SelectedIndex = -1;
                }
            }
        }
    }
}
