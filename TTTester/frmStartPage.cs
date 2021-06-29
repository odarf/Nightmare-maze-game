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
    public partial class frmStartPage : Form
    {
        public frmStartPage()
        {
            InitializeComponent();
        }

        private void btnCreateTest_Click(object sender, EventArgs e)
        {
            /*FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            if (fileDialog.ShowDialog()==DialogResult.OK)
            {
                Data.pathToTest = fileDialog.SelectedPath + "xyi" + Data.questionNumber.ToString() + ".xml";
            }
            else
            {
                Data.pathToTest = @"C:\Users\odarf\Desktop\test.xml";
            }*/
            frmCreateTest CreateTest = new frmCreateTest();
            CreateTest.ShowDialog();
           
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            OpenFileDialog FileDialog = new OpenFileDialog();
            FileDialog.InitialDirectory = @"c:\";
            FileDialog.Filter = "Тест формата (*.xml)| *.xml| Все файлы (*.*)| *.*";
            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                Data.pathToOpenTest = FileDialog.FileName;
            }
            frmSolveTest ChooseTest = new frmSolveTest();
            ChooseTest.ShowDialog();
        }
    }
}
