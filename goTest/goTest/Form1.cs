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
using goTest.CommonComponents.ExceptionHandler.View.Information.PopupWindow;
using goTest.Testing.Realization.Workers;

namespace goTest
{
    public partial class Form1 : Form
    {
        private InitComponents iniComponents;
        private bool activateValueChangeListeners = true;
        private TestObjectsSearcher searcher;

        public Form1()
        {
            InitializeComponent();
            //Init
            iniComponents = new InitComponents();
            Initialyzer init = new Initialyzer(iniComponents, this);
            init.init();
            searcher = new TestObjectsSearcher();
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

        public ComboBox comboBox1Elem
        {
            get { return comboBox1; }
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
            try
            {
                if (!textBox9.Text.Equals("") & comboBox1.SelectedIndex != -1 &
                    numericUpDown1.Value > 1 & numericUpDown2.Value <= numericUpDown1.Value)
                {
                    Navigator.Navigator.getInstance().navigateTo("QuestionsView");
                    if (dataGridView1.RowCount > 0)
                    {
                        dataGridView1.Rows[0].Selected = false;
                    }
                }
                else
                {
                    throw new NotAllAreasIsFill();
                }
            }
            catch(Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Go to next update test view
        private void button23_Click(object sender, EventArgs e)
        {
            for (int i=0; i<iniComponents.questionsViewAdapter.getResult().Count; i++)
            {
                if(comboBox5.SelectedIndex == iniComponents.questionsViewAdapter.
                    getResult().ElementAt(i).getPosition())
                {
                    VSubject currentSubject = iniComponents.questionsViewAdapter.
                    getResult().ElementAt(i);
                    currentSubject.IsSelected = true;
                    for(int m=0; m<currentSubject.Tests.Count; m++)
                    {
                        if(currentSubject.Tests.ElementAt(m).getPosition()==
                            comboBox4.SelectedIndex)
                        {
                            VTest currenTest = currentSubject.Tests.ElementAt(m);
                            Navigator.Navigator.getInstance().navigateTo("CreateTestView");
                            activateValueChangeListeners = false;
                            iniComponents.goTestController.getFullTestContent(currenTest.Id);
                            activateValueChangeListeners = true;
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
            label27.Visible = false;
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
                int pos = searcher.getSelectedSubject(iniComponents.questionsViewAdapter.
                        getResult());
                VSubject subject = iniComponents.questionsViewAdapter.
                    getResult().ElementAt(pos);
                iniComponents.goTestController.deleteQuestion(subject.getSelectedTest().
                    getSelectedQuestion().Id);
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
            deleteUnswer();
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
                        activateValueChangeListeners = false;
                        questions.ElementAt(i).IsSelected = true;
                        textBox11.Text = questions.ElementAt(i).QuestionsContent;
                        dataGridView2.Rows.Clear();
                        dataGridView2.Rows.Add(questions.ElementAt(i).Unswers.Count);
                        for (int m=0; m<questions.ElementAt(i).Unswers.Count; m++)
                        {
                            dataGridView2.Rows[m].Cells[0].Value =
                                questions.ElementAt(i).Unswers.ElementAt(m).Content;
                            if(questions.ElementAt(i).Unswers.ElementAt(m).IsRight)
                            {
                                dataGridView2.Rows[m].Cells[1].Value = "+";
                            }
                            questions.ElementAt(i).Unswers.ElementAt(m).IsSelected = false;
                        }
                        if (dataGridView2.RowCount > 0)
                        {
                            dataGridView2.Rows[0].Selected = false;
                        }
                        label27.Visible = true;
                        label27.Text = "Вопрос: " + (e.RowIndex+1) + "/" + dataGridView1.RowCount;

                        return;
                    }
                }
                throw new GoTestObjectNotFound();
            }
            catch (GoTestObjectNotFound ex)
            {
                if (e.RowIndex != -1)
                {
                    if (!dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Equals(""))
                    {
                        ExceptionHandler.getInstance().processing(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
            finally
            {
                activateValueChangeListeners = true;
            }
        }

        //Update unswer selection
        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
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
                        for (int n = 0; n < unswers.Count(); n++)
                        {
                            if (unswers.ElementAt(n).getPosition().Equals(e.RowIndex))
                            {
                                for (int k = 0; k < unswers.Count; k++)
                                {
                                    unswers.ElementAt(k).IsSelected = false;
                                }
                                questions.ElementAt(i).Unswers.ElementAt(n).IsSelected = true;
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
                if (e.RowIndex != -1)
                {
                    if (!dataGridView2.Rows[e.RowIndex].Cells[0].Value.
                    ToString().Equals(""))
                    {
                        ExceptionHandler.getInstance().processing(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Update or create Unswer
        private void dataGridView2_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && activateValueChangeListeners)
            {
                Unswer unswer = new Unswer();
                if (dataGridView2.Rows[e.RowIndex].Cells[0].Value == null)
                {
                    deleteUnswer();
                }
                unswer.Content = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (dataGridView2.Rows[e.RowIndex].Cells[1].Value == null)
                {
                    if(!isSelectedQuestionHasMinimumOneRightUnswer())
                    {
                        activateValueChangeListeners = false;
                        dataGridView2.Rows[e.RowIndex].Cells[1].Value = "+";
                        activateValueChangeListeners = true;
                        showMessage("Необходимо, чтобы вопрос имел хотя бы 1 правильный ответ");
                        return;
                    }

                    unswer.IsRight = false;
                }
                else
                {
                    if (dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("+"))
                    {
                        unswer.IsRight = true;
                    }
                    else
                    {
                        if (!isSelectedQuestionHasMinimumOneRightUnswer())
                        {
                            activateValueChangeListeners = false;
                            dataGridView2.Rows[e.RowIndex].Cells[1].Value = "+";
                            activateValueChangeListeners = true;
                            showMessage("Необходимо, чтобы вопрос имел хотя бы 1 правильный ответ");
                            return;
                        }
                        unswer.IsRight = false;
                        activateValueChangeListeners = false;
                        dataGridView2.Rows[e.RowIndex].Cells[1].Value = null;
                        activateValueChangeListeners = true;
                    }
                }
                try
                {
                    int pos = searcher.getSelectedSubject(iniComponents.questionsViewAdapter.
                        getResult());
                    VSubject subject = iniComponents.questionsViewAdapter.
                        getResult().ElementAt(pos);
                    iniComponents.goTestController.update(subject.getSelectedTest().
                        getSelectedQuestion().getSelectedUnswer().Id, unswer);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.getInstance().processing(ex);
                }
            }
        }

        //Update selected subject on edit test view
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            for (int i=0; i<iniComponents.questionsViewAdapter.getResult().Count; i++)
            {
                if(iniComponents.questionsViewAdapter.getResult().
                    ElementAt(i).getPosition() == comboBox5.SelectedIndex)
                {
                    VSubject subject = iniComponents.questionsViewAdapter.getResult().ElementAt(i);
                    for (int m=0; m<subject.Tests.Count(); m++)
                    {
                        comboBox4.Items.Add(subject.Tests.ElementAt(m).Name);
                    }
                    comboBox4.Text = "";
                    comboBox4.SelectedIndex = -1;
                    return;
                }
            }

            throw new GoTestObjectNotFound();
        }

        //Update test name
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (!activateValueChangeListeners)
            {
                return;
            }
            if (textBox9.Text != null && textBox9.Text != "")
            {
                for (int i = 0; i < iniComponents.questionsViewAdapter.getResult().Count; i++)
                {
                    if (iniComponents.questionsViewAdapter.getResult().ElementAt(i).IsSelected)
                    {
                        Test test = iniComponents.questionsViewAdapter.
                            getResult().ElementAt(i).getSelectedTest().unRestore();
                        test.Name = textBox9.Text;
                        iniComponents.goTestController.update(test.Id, test);

                        return;
                    }
                }
            }
            else
            {
                activateValueChangeListeners = false;
                textBox9.Text = "some name";
                activateValueChangeListeners = true;
                showMessage("Пожалуйста, задайте тесту не пустое имя");
            }
        }

        //Update test subject
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Update test questions number
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (!activateValueChangeListeners)
            {
                return;
            }
            if (int.Parse(numericUpDown1.Value.ToString())>0 && 
                int.Parse(numericUpDown1.Value.ToString())>int.
                Parse(numericUpDown2.Value.ToString()))
            {
                for (int i = 0; i < iniComponents.questionsViewAdapter.getResult().Count; i++)
                {
                    if (iniComponents.questionsViewAdapter.getResult().ElementAt(i).IsSelected)
                    {
                        Test test = iniComponents.questionsViewAdapter.
                            getResult().ElementAt(i).getSelectedTest().unRestore();
                        test.QuestionsNumber = int.Parse(numericUpDown1.Value.ToString());
                        iniComponents.goTestController.update(test.Id, test);

                        return;
                    }
                }
            }
            else
            {
                activateValueChangeListeners = false;
                numericUpDown1.Value = 1;
                numericUpDown2.Value = 1;
                activateValueChangeListeners = true;
                showMessage("Количество вопросов в тесте должно быть положительным числом и "+
                    "оно должно быть больше или равно требуемому количеству правильных ответов");
            }
        }

        //Update test required questions Number
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (!activateValueChangeListeners)
            {
                return;
            }
            if (int.Parse(numericUpDown2.Value.ToString()) > 0 &&
                int.Parse(numericUpDown1.Value.ToString()) > int.
                Parse(numericUpDown2.Value.ToString()))
            {
                for (int i = 0; i < iniComponents.questionsViewAdapter.getResult().Count; i++)
                {
                    if (iniComponents.questionsViewAdapter.getResult().ElementAt(i).IsSelected)
                    {
                        Test test = iniComponents.questionsViewAdapter.
                            getResult().ElementAt(i).getSelectedTest().unRestore();
                        test.RequeredUnswersNumber = int.Parse(numericUpDown2.Value.ToString());
                        iniComponents.goTestController.update(test.Id, test);

                        return;
                    }
                }
            }
            else
            {
                activateValueChangeListeners = false;
                numericUpDown1.Value = 1;
                numericUpDown2.Value = 1;
                activateValueChangeListeners = true;
                showMessage("Требуемое количество правильных ответов должно быть "+
                    "положительным числом и оно должно быть меньше или равно, чем "+
                    "общее количество вопросов в тесте");
            }
        }

        //Update question content
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if(!activateValueChangeListeners)
            {
                return;
            }
            if (textBox11.Text == null||textBox11.Text.Equals(""))
            {
                activateValueChangeListeners = false;
                textBox11.Text = "some content";
                activateValueChangeListeners = true;
                return;
            }
            for (int i=0; i<iniComponents.questionsViewAdapter.getResult().Count; i++)
            {
                if(iniComponents.questionsViewAdapter.getResult().ElementAt(i).IsSelected)
                {
                    Question question = iniComponents.questionsViewAdapter.
                        getResult().ElementAt(i).getSelectedTest().
                        getSelectedQuestion().unRestore();
                    question.QuestionsContent = textBox11.Text;
                    iniComponents.goTestController.update(question.Id, question);

                    return;
                }
            }

            throw new GoTestObjectNotFound();
        }


        //
        //Other functions
        //


        //Delete unswer from table
        private void deleteUnswer()
        {
            try
            {
                List<VSubject> subjects = iniComponents.questionsViewAdapter.getResult();
                for (int i = 0; i < subjects.Count; i++)
                {
                    if (subjects.ElementAt(i).IsSelected)
                    {
                        VSubject subject = subjects.ElementAt(i);
                        iniComponents.goTestController.deleteUnswer(subject.getSelectedTest().
                            getSelectedQuestion().getSelectedUnswer().Id);
                        return;
                    }
                }

                throw new GoTestObjectNotFound();
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Check is selected question has minimum 1 right unswer
        private bool isSelectedQuestionHasMinimumOneRightUnswer()
        {
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                if (dataGridView2.Rows[i].Cells[1].Value.ToString().Equals("+"))
                {
                    return true;
                }
            }

            return false;
        }

        private void showMessage(string message)
        {
            InformationPopupWindow view = new InformationPopupWindow();
            InformationPopupWindowConfig config = new InformationPopupWindowConfig(message);
            view.setConfig(config);
            view.show();
        }        
    }
}
