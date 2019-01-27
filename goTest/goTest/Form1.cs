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
using goTest.Testing.Interfaces;

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

        public TextBox textBox13Elem
        {
            get { return textBox13; }
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

        public Label label40Elem
        {
            get { return label40; }
        }

        public Label label41Elem
        {
            get { return label41; }
        }

        public Label label42Elem
        {
            get { return label42; }
        }

        public Label label43Elem
        {
            get { return label43; }
        }

        public ComboBox comboBox1Elem
        {
            get { return comboBox1; }
        }

        public ComboBox comboBox2Elem
        {
            get { return comboBox2; }
        }

        public ComboBox comboBox3Elem
        {
            get { return comboBox3; }
        }

        public ComboBox comboBox4Elem
        {
            get { return comboBox4; }
        }

        public ComboBox comboBox5Elem
        {
            get { return comboBox5; }
        }

        public ComboBox comboBox6Elem
        {
            get { return comboBox6; }
        }

        public ComboBox comboBox7Elem
        {
            get { return comboBox7; }
        }

        public ComboBox comboBox8Elem
        {
            get { return comboBox8; }
        }

        public ComboBox comboBox9Elem
        {
            get { return comboBox9; }
        }

        public RadioButton[] radioButtons
        {
            get {
                RadioButton[] buttons = new RadioButton[10];
                buttons[0] = radioButton1;
                buttons[1] = radioButton2;
                buttons[2] = radioButton3;
                buttons[3] = radioButton4;
                buttons[4] = radioButton5;
                buttons[5] = radioButton6;
                buttons[6] = radioButton7;
                buttons[7] = radioButton8;
                buttons[8] = radioButton9;
                buttons[9] = radioButton10;
                return buttons;
            }
        }

        public CheckBox[] checkBoxes
        {
            get
            {
                CheckBox[] cb = new CheckBox[10];
                cb[0] = checkBox1;
                cb[1] = checkBox2;
                cb[2] = checkBox3;
                cb[3] = checkBox4;
                cb[4] = checkBox5;
                cb[5] = checkBox6;
                cb[6] = checkBox7;
                cb[7] = checkBox8;
                cb[8] = checkBox9;
                cb[9] = checkBox10;
                return cb;
            }
        }

        public Panel panel1Elem
        {
            get { return panel1; }
        }

        public Panel panel2Elem
        {
            get { return panel2; }
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
                Navigator.Navigator.getInstance().navigateTo("TestingView");
                iniComponents.goTestController.loadAllSubjects();
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
            activateValueChangeListeners = false;
            iniComponents.goTestController.loadAllSubjects();
            iniComponents.goTestController.addEmptyTest();
            activateValueChangeListeners = true;
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
                    numericUpDown1.Value >= 1 & numericUpDown2.Value <= numericUpDown1.Value
                    & !comboBox1.SelectedItem.Equals(""))
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
            if (comboBox5.SelectedIndex == -1 || comboBox4.SelectedIndex == -1)
            {
                showMessage("Пожалуйста, выберите предмет и тест.");
                return;
            }
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
                            activateValueChangeListeners = false;
                            Navigator.Navigator.getInstance().resetCurrentView();
                            activateValueChangeListeners = true;
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
            activateValueChangeListeners = false;
            Navigator.Navigator.getInstance().resetCurrentView();
            resetQuestionView();
            activateValueChangeListeners = true;
            Navigator.Navigator.getInstance().navigateToPreviousView();
            if (Navigator.Navigator.getInstance().getCurrentViewsName().Equals("UpdateTestView"))
            {
                Navigator.Navigator.getInstance().navigateToPreviousView();
            }
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
            activateValueChangeListeners = false;
            Navigator.Navigator.getInstance().resetCurrentView();
            activateValueChangeListeners = true;
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }

        //Create subject button
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                iniComponents.goTestController.createSubject(textBox10.Text);
                Navigator.Navigator.getInstance().resetCurrentView();
                Navigator.Navigator.getInstance().navigateToPreviousView();
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
                List<VSubject> subjects = iniComponents.questionsViewAdapter.getResult();
                for(int i=0; i<subjects.Count; i++)
                {
                    for(int m=0; m<subjects.ElementAt(i).Tests.Count; m++)
                    {
                        if (subjects.ElementAt(i).Tests.ElementAt(m).IsSelected)
                        {
                            subjects.ElementAt(i).Tests.ElementAt(m).unRestore().isValid();
                            break;
                        }
                    }
                }
                iniComponents.goTestController.updateTestInBD();
                showMessage("Тест успешно обновлен");
                activateValueChangeListeners = false;
                Navigator.Navigator.getInstance().resetCurrentView();
                resetQuestionView();
                activateValueChangeListeners = true;
                Navigator.Navigator.getInstance().navigateTo("AdminMenuView");
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Update subject button
        private void button20_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1 || textBox12.Text==null || textBox12.Text.Equals(""))
            {
                showMessage("Пожалуйста, выберите предмет и введите новое название для него.");
                return;
            }
            try
            {
                iniComponents.goTestController.updateSubject(iniComponents.
                    updateSubjectViewAdapter.getResult().ElementAt(comboBox3.SelectedIndex).Id,
                    textBox12.Text);
                Navigator.Navigator.getInstance().resetCurrentView();
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
                if (dataGridView1.Rows[i].Cells[0].Value == null)
                {
                    return;
                }
                if ( dataGridView1.Rows[i].Cells[0].Value.ToString().Equals(""))
                {
                    return;
                }
            }
            dataGridView1.Rows.Add(1);
            activateValueChangeListeners = false;
            iniComponents.goTestController.addEmptyQuestion();
            activateValueChangeListeners = true;
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
                activateValueChangeListeners = false;
                iniComponents.goTestController.deleteQuestion(subject.getSelectedTest().
                    getSelectedQuestion().Id);
                activateValueChangeListeners = true;
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
                if (dataGridView2.Rows[i].Cells[0].Value == null)
                {
                    return;
                }
                if (dataGridView2.Rows[i].Cells[0].Value.ToString().Equals(""))
                {
                    return;
                }
            }
            if (dataGridView2.RowCount >= 10)
            {
                MessageBox.Show(
                        "Текущая версия приложения поддерживает максимум 10 вариантов ответа",
                        "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if (dataGridView1.SelectedCells.Count == 0)
            {
                MessageBox.Show(
                        "Выберите вопрос",
                        "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            if (dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value != null)
            {
                if (!dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value.
                ToString().Equals(""))
                {
                    dataGridView2.Rows.Add(1);
                    VQuestion question = getSelectedQuestion(iniComponents.questionsViewAdapter);
                    activateValueChangeListeners = false;
                    iniComponents.goTestController.addEmptyUnswer(question.Id);
                    activateValueChangeListeners = true;
                }
                else
                {
                    MessageBox.Show(
                        "Задайте текст для выбранного вопроса, прежде чем создавать ответ",
                        "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else
            {
                MessageBox.Show(
                    "Задайте текст для выбранного вопроса, прежде чем создавать ответ",
                    "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        //Delete unswer from table
        private void button25_Click(object sender, EventArgs e)
        {
            activateValueChangeListeners = false;
            deleteUnswer();
            activateValueChangeListeners = true;
        }

        //Update question selection
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                VSubject sub = getSelectedSubject(iniComponents.questionsViewAdapter, comboBox1);
                List<VQuestion> questions = sub.getSelectedTest().Questions;
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
                        if (questions.ElementAt(i).Unswers.Count > 0)
                        {
                            dataGridView2.Rows.Add(questions.ElementAt(i).Unswers.Count);
                            for (int m = 0; m < questions.ElementAt(i).Unswers.Count; m++)
                            {
                                dataGridView2.Rows[m].Cells[0].Value =
                                    questions.ElementAt(i).Unswers.ElementAt(m).Content;
                                if (questions.ElementAt(i).Unswers.ElementAt(m).IsRight)
                                {
                                    dataGridView2.Rows[m].Cells[1].Value = "+";
                                }
                                questions.ElementAt(i).Unswers.ElementAt(m).IsSelected = false;
                            }
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
                    if (dataGridView1.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        if (!dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Equals(""))
                        {
                            ExceptionHandler.getInstance().processing(ex);
                        }
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
                VSubject sub = getSelectedSubject(iniComponents.questionsViewAdapter, comboBox1);
                List<VQuestion> questions = sub.getSelectedTest().Questions;
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
                    if (dataGridView2.Rows[e.RowIndex].Cells[0].Value != null)
                    {
                        if (!dataGridView2.Rows[e.RowIndex].Cells[0].Value.
                                ToString().Equals(""))
                        {
                            ExceptionHandler.getInstance().processing(ex);
                        }
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
                    activateValueChangeListeners = false;
                    iniComponents.goTestController.update(subject.getSelectedTest().
                        getSelectedQuestion().getSelectedUnswer().Id, unswer);
                    activateValueChangeListeners = true;
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
            if (activateValueChangeListeners)
            {
                comboBox4.Items.Clear();
                for (int i = 0; i < iniComponents.questionsViewAdapter.getResult().Count; i++)
                {
                    if (iniComponents.questionsViewAdapter.getResult().
                        ElementAt(i).getPosition() == comboBox5.SelectedIndex)
                    {
                        VSubject subject = iniComponents.questionsViewAdapter.getResult().ElementAt(i);
                        for (int m = 0; m < subject.Tests.Count(); m++)
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
        }

        //Update test name
        private void textBox9_Leave(object sender, EventArgs e)
        {
            if (!activateValueChangeListeners)
            {
                return;
            }
            if (textBox9.Text != null && textBox9.Text != "")
            {
                for (int i = 0; i < iniComponents.questionsViewAdapter.getResult().Count; i++)
                {
                    trySetSelection(iniComponents.questionsViewAdapter.getResult().ElementAt(i));
                    if (iniComponents.questionsViewAdapter.getResult().ElementAt(i).IsSelected)
                    {
                        Test test = iniComponents.questionsViewAdapter.
                            getResult().ElementAt(i).getSelectedTest().unRestore();
                        test.Name = textBox9.Text;
                        test.IsSelected = true;
                        activateValueChangeListeners = false;
                        iniComponents.goTestController.update(test.Id, test);
                        activateValueChangeListeners = true;

                        return;
                    }
                }
                throw new GoTestObjectNotFound();
            }
            else
            {
                activateValueChangeListeners = false;
                textBox9.Text = "some name";
                activateValueChangeListeners = true;
                showMessage("Пожалуйста, задайте тесту не пустое имя");
            }
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
                        activateValueChangeListeners = false;
                        iniComponents.goTestController.update(test.Id, test);
                        activateValueChangeListeners = true;

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
                int.Parse(numericUpDown1.Value.ToString()) >= int.
                Parse(numericUpDown2.Value.ToString()))
            {
                for (int i = 0; i < iniComponents.questionsViewAdapter.getResult().Count; i++)
                {
                    if (iniComponents.questionsViewAdapter.getResult().ElementAt(i).IsSelected)
                    {
                        Test test = iniComponents.questionsViewAdapter.
                            getResult().ElementAt(i).getSelectedTest().unRestore();
                        test.RequeredUnswersNumber = int.Parse(numericUpDown2.Value.ToString());
                        activateValueChangeListeners = false;
                        iniComponents.goTestController.update(test.Id, test);
                        activateValueChangeListeners = true;

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
        private void textBox11_Leave(object sender, EventArgs e)
        {
            if (!activateValueChangeListeners)
            {
                return;
            }
            if (textBox11.Text == null || textBox11.Text.Equals(""))
            {
                activateValueChangeListeners = false;
                textBox11.Text = "some content";
                activateValueChangeListeners = true;
                return;
            }
            try
            {
                Question question = getSelectedQuestion(iniComponents.questionsViewAdapter).
                    unRestore();
                question.QuestionsContent = textBox11.Text;
                activateValueChangeListeners = false;
                iniComponents.goTestController.update(question.Id, question);
                activateValueChangeListeners = true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.getInstance().processing(ex);
            }
        }

        //Update selected subject on testing view
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activateValueChangeListeners)
            {
                comboBox6.Items.Clear();
                for (int i = 0; i < iniComponents.testingViewAdapter.getResult().Count; i++)
                {
                    if (iniComponents.testingViewAdapter.getResult().
                        ElementAt(i).getPosition() == comboBox2.SelectedIndex)
                    {
                        VSubject subject = iniComponents.testingViewAdapter.getResult().ElementAt(i);
                        for (int m = 0; m < subject.Tests.Count(); m++)
                        {
                            comboBox6.Items.Add(subject.Tests.ElementAt(m).Name);
                        }
                        comboBox6.Text = "";
                        comboBox6.SelectedIndex = -1;
                        return;
                    }
                }

                throw new GoTestObjectNotFound();
            }
        }

        //Go testing
        private void button5_Click(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == -1 || comboBox6.SelectedIndex ==-1)
            {
                showMessage("Пожалуйста, выберите предмет и тест.");
                return;
            }
            tabControl1.SelectedIndex = 10;
            for (int i = 0; i < iniComponents.testingViewAdapter.getResult().Count; i++)
            {
                if (comboBox2.SelectedIndex == iniComponents.testingViewAdapter.
                    getResult().ElementAt(i).getPosition())
                {
                    VSubject currentSubject = iniComponents.testingViewAdapter.
                    getResult().ElementAt(i);
                    currentSubject.IsSelected = true;
                    for (int m = 0; m < currentSubject.Tests.Count; m++)
                    {
                        if (currentSubject.Tests.ElementAt(m).getPosition() ==
                            comboBox6.SelectedIndex)
                        {
                            VTest currenTest = currentSubject.Tests.ElementAt(m);
                            activateValueChangeListeners = false;
                            Navigator.Navigator.getInstance().resetCurrentView();
                            Navigator.Navigator.getInstance().navigateTo("ProcessingTestingView");
                            iniComponents.goTestController.loadTestForTesting(currenTest.Id);
                            activateValueChangeListeners = true;
                            return;
                        }
                    }
                }
            }
            throw new GoTestObjectNotFound();
        }

        //Send unswer
        private void button12_Click(object sender, EventArgs e)
        {
            if(panel1.Visible)
            {
                sendSingleUnswer();
            }
            else
            {
                sendMultUnswer();
            }
        }

        //Go to menu
        private void button27_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("AutorizationSecurityView");
        }

        //Exit from admin menu
        private void button28_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("AutorizationSecurityView");
        }

        //Exit from view change admin password
        private void button24_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }

        //Update tests subject
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!activateValueChangeListeners)
            {
                return;
            }
            VSubject sub = getSelectedSubject(
                iniComponents.questionsViewAdapter, comboBox1);
            if (sub.Name != null && !sub.Name.Equals(""))
            {
                activateValueChangeListeners = false;
                iniComponents.goTestController.setSubjectForSelectedTest(sub.Id);
                activateValueChangeListeners = true;
            }
            else
            {
                showMessage("Нельзя выбрать пустой предмет");
                if(comboBox1.Items.Count>0)
                {
                    comboBox1.SelectedIndex=0;
                }
            }
        }

        //Go to delete test form
        private void button29_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("DeleteTestView");
            iniComponents.goTestController.loadAllSubjects();
        }

        //Go to delete subject form
        private void button30_Click(object sender, EventArgs e)
        {
            Navigator.Navigator.getInstance().navigateTo("DeleteSubjectView");
            iniComponents.goTestController.loadAllSubjects();
        }


        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activateValueChangeListeners)
            {
                comboBox8.Items.Clear();
                for (int i = 0; i < iniComponents.deletingTestViewAdapter.getResult().Count; i++)
                {
                    if (iniComponents.deletingTestViewAdapter.getResult().
                        ElementAt(i).getPosition() == comboBox7.SelectedIndex)
                    {
                        VSubject subject = iniComponents.deletingTestViewAdapter.getResult().ElementAt(i);
                        for (int m = 0; m < subject.Tests.Count(); m++)
                        {
                            comboBox8.Items.Add(subject.Tests.ElementAt(m).Name);
                        }
                        comboBox8.Text = "";
                        comboBox8.SelectedIndex = -1;
                        return;
                    }
                }

                throw new GoTestObjectNotFound();
            }
        }

        //Go out from delete test view
        private void button31_Click(object sender, EventArgs e)
        {
            activateValueChangeListeners = false;
            Navigator.Navigator.getInstance().resetCurrentView();
            activateValueChangeListeners = true;
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }

        //Go out from delete subject view
        private void button33_Click(object sender, EventArgs e)
        {
            activateValueChangeListeners = false;
            Navigator.Navigator.getInstance().resetCurrentView();
            activateValueChangeListeners = true;
            Navigator.Navigator.getInstance().navigateToPreviousView();
        }


        //Delete test button
        private void button32_Click(object sender, EventArgs e)
        {
            if (comboBox7.SelectedIndex == -1 || comboBox8.SelectedIndex == -1)
            {
                showMessage("Пожалуйста, выберите предмет и тест.");
                return;
            }
            for (int i = 0; i < iniComponents.deletingTestViewAdapter.getResult().Count; i++)
            {
                if (comboBox7.SelectedIndex == iniComponents.deletingTestViewAdapter.
                    getResult().ElementAt(i).getPosition())
                {
                    VSubject currentSubject = iniComponents.deletingTestViewAdapter.
                    getResult().ElementAt(i);
                    currentSubject.IsSelected = true;
                    for (int m = 0; m < currentSubject.Tests.Count; m++)
                    {
                        if (currentSubject.Tests.ElementAt(m).getPosition() ==
                            comboBox8.SelectedIndex)
                        {
                            VTest currentTest = currentSubject.Tests.ElementAt(m);
                            activateValueChangeListeners = false;
                            Navigator.Navigator.getInstance().resetCurrentView();
                            if (MessageBox.Show(
                                "Вы действительно хотите удалить этот предмет:" + currentTest.Name 
                                + "?",
                                "Сообщение",
                                MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                            {
                                currentTest.delete();
                            }
                            activateValueChangeListeners = true;
                            Navigator.Navigator.getInstance().navigateToPreviousView();
                            return;
                        }
                    }
                }
            }
            throw new GoTestObjectNotFound();
        }

        //Delete subject button
        private void button34_Click(object sender, EventArgs e)
        {
            if (comboBox9.SelectedIndex == -1)
            {
                showMessage("Пожалуйста, выберите предмет.");
                return;
            }
            for (int i = 0; i < iniComponents.deletingSubjectViewAdapter.getResult().Count; i++)
            {
                if (comboBox9.SelectedIndex == iniComponents.deletingSubjectViewAdapter.
                    getResult().ElementAt(i).getPosition())
                {
                    VSubject currentSubject = iniComponents.deletingSubjectViewAdapter.
                    getResult().ElementAt(i);
                    currentSubject.IsSelected = true;
                    activateValueChangeListeners = false;
                    Navigator.Navigator.getInstance().resetCurrentView();
                    if (MessageBox.Show(
                        "Вы действительно хотите удалить этот предмет: "+currentSubject.Name+"?",
                        "Сообщение",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.DefaultDesktopOnly) == DialogResult.OK)
                    {
                        currentSubject.delete();
                    }
                    activateValueChangeListeners = true;
                    Navigator.Navigator.getInstance().navigateToPreviousView();
                    return;
                }
            }
            throw new GoTestObjectNotFound();
        }

        //
        //Other functions
        //

        //Send single unswer
        private void sendSingleUnswer()
        {
            RadioButton[] buttons = radioButtons;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    List<VSubject> subjects = iniComponents.testingViewAdapter.getResult();
                    VQuestion question = subjects.ElementAt(0).Tests.ElementAt(0).
                        Questions.ElementAt(0);
                    for (int k = 0; k < question.Unswers.Count; k++)
                    {
                        if (question.Unswers.ElementAt(k).getPosition() == i)
                        {
                            int[] unsw = new int[1];
                            unsw[0] = question.Unswers.ElementAt(k).Id;
                            iniComponents.goTestController.userUnswered(unsw);
                            return;
                        }
                    }
                }
            }
        }

        //Send mult unser
        private void sendMultUnswer()
        {
            CheckBox[] buttons = checkBoxes;
            List<int> unswList = new List<int>();
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Checked)
                {
                    List<VSubject> subjects = iniComponents.testingViewAdapter.getResult();
                    VQuestion question = subjects.ElementAt(0).Tests.ElementAt(0).
                        Questions.ElementAt(0);
                    for (int k = 0; k < question.Unswers.Count; k++)
                    {
                        if (question.Unswers.ElementAt(k).getPosition() == i)
                        {
                            unswList.Add(question.Unswers.ElementAt(k).Id);
                        }
                    }
                }
            }
            int[] unsw = new int[unswList.Count];
            for (int i = 0; i < unsw.Length; i++)
            {
                unsw[i] = unswList.ElementAt(i);
            }
            iniComponents.goTestController.userUnswered(unsw);
        }

        //Reset question view
        private void resetQuestionView()
        {
            textBox11.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            label27.Visible = false;
        }

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
                if (dataGridView2.Rows[i].Cells[1].Value==null)
                {
                    return false;
                }
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

        private VQuestion getSelectedQuestion(GoTestAdapterI adapter)
        {
            for (int i = 0; i < adapter.getResult().Count; i++)
            {
                if (adapter.getResult().ElementAt(i).IsSelected)
                {
                    return adapter.getResult().ElementAt(i).getSelectedTest().
                        getSelectedQuestion();
                }
            }
            throw new GoTestObjectNotFound();
        }

        private VSubject getSelectedSubject(GoTestAdapterI adapter, ComboBox comboBox)
        {
            for (int i = 0; i < adapter.getResult().Count; i++)
            {
                if (adapter.getResult().ElementAt(i).getPosition() == comboBox.SelectedIndex)
                {
                    return adapter.getResult().ElementAt(i);
                }
            }
            throw new GoTestObjectNotFound();
        }

        private void trySetSelection(VSubject sub)
        {
            for(int i=0; i<sub.Tests.Count; i++)
            {
                if(sub.Tests.ElementAt(i).IsSelected)
                {
                    sub.IsSelected = true;
                }
            }
        }
    }
}
