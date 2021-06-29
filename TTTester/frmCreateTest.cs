using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;

namespace TTTester
{
    public partial class frmCreateTest : Form
    {

        public frmCreateTest()
        {
            InitializeComponent();
        }

        private void tsmiQuit_Click(object sender, EventArgs e)
        {
            XML.Serialazable(Data.ListOfQuestions);
            Close();
        }

        private void frmCreateTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            XML.Serialazable(Data.ListOfQuestions);
        }

        private void frmCreateTest_Load(object sender, EventArgs e)
        {
            Data.questionNumber = 0;
            labelQuestionCounter.Text = (Data.questionNumber+1).ToString();
        }

        private void btnNextQuestion_Click(object sender, EventArgs e)
        {
            if (Data.ListOfQuestions.Count!=Data.questionNumber)
            {
            ShowQuestion(1);
            }
            
        }

        private void btnPrevQuestion_Click(object sender, EventArgs e)
        {
            if (Data.questionNumber != 0)
            {
                ShowQuestion(-1);
            }
        }
        void Clear()
        {
            richTextBox1.Text = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
        }
        void ShowQuestion(int c)
        {
            Clear();
            Data.questionNumber+=c;
            labelQuestionCounter.Text = (Data.questionNumber+1).ToString();
            //обработать сохранение последнего вопроса
            richTextBox1.Text = Data.ListOfQuestions[Data.questionNumber].question;
            //
            textBox1.Text = Data.ListOfQuestions[Data.questionNumber].answers[0];
            textBox2.Text = Data.ListOfQuestions[Data.questionNumber].answers[1];
            textBox3.Text = Data.ListOfQuestions[Data.questionNumber].answers[2];
            textBox4.Text = Data.ListOfQuestions[Data.questionNumber].answers[3];
            if (Data.ListOfQuestions[Data.questionNumber].rightAnswerNumber == 1)
            {
                checkBox1.Checked = true;
            }
            else if (Data.ListOfQuestions[Data.questionNumber].rightAnswerNumber == 2)
            {
                checkBox2.Checked = true;
            }
            else if (Data.ListOfQuestions[Data.questionNumber].rightAnswerNumber == 3)
            {
                checkBox3.Checked = true;
            }
            else if (Data.ListOfQuestions[Data.questionNumber].rightAnswerNumber == 4)
            {
                checkBox4.Checked = true;
            }
        }

        private void btnSaveThatQuestion_Click(object sender, EventArgs e)
        {
                Data.questionNumber++;
                labelQuestionCounter.Text = (Data.questionNumber+1).ToString();
                Questions question = new Questions();
                Data.ListOfQuestions.Add(question);
                question.question = richTextBox1.Text;
                question.answers[0] = textBox1.Text;
                question.answers[1] = textBox2.Text;
                question.answers[2] = textBox3.Text;
                question.answers[3] = textBox4.Text;
                if (checkBox1.Checked)
                {
                    question.rightAnswerNumber = 1;
                }
                else if (checkBox2.Checked)
                {
                    question.rightAnswerNumber = 2;
                }
                else if (checkBox3.Checked)
                {
                    question.rightAnswerNumber = 3;
                }
                else if (checkBox4.Checked)
                {
                    question.rightAnswerNumber = 4;
                }
                if (question.question != "")
                {
                    Data.ListOfQuestions[Data.questionNumber-1] = question;
                }
                else
                {
                    MessageBox.Show("Нельзя сохранить пустой вопрос", "ОШИБКА", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            //сделать кнопку или пошёл он нахуй
            Clear();         
        }
    }
}
