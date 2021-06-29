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
    public partial class frmSolveTest : Form
    {
        public frmSolveTest()
        {
            InitializeComponent();
        }

        private void frmSolveTest_Load(object sender, EventArgs e)
        {
            XML.Deserializable(Data.ListOfQuestions, Data.pathToOpenTest);
            rtbSolveTest.Text = Data.ListOfQuestions[0].question;
            rbtnSolveTest1.Text = Data.ListOfQuestions[0].answers[0];
            rbtnSolveTest2.Text = Data.ListOfQuestions[0].answers[1];
            rbtnSolveTest3.Text = Data.ListOfQuestions[0].answers[2];
            rbtnSolveTest4.Text = Data.ListOfQuestions[0].answers[3];
            richTextBox1.Text = Data.ListOfQuestions[0].answers[0];
        }
    }
}
