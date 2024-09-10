using AlbumMaker.Classes.Db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumMaker.Forms
{
    public partial class UserControlPanel : UserControl
    {
        public UserControlPanel()
        {
            InitializeComponent();
           
        }

        private void btnUpdateQuestion_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBoxRememberMe.Checked)
                Properties.AppSettings.Default.userName = Properties.AppSettings.Default.currentUser;
            else
                Properties.AppSettings.Default.userName = "";
                
            Properties.AppSettings.Default.Save();
        }

        private void UserControlPanel_Load(object sender, EventArgs e)
        {
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            if (Properties.AppSettings.Default.userName != "")
            {
                checkBoxRememberMe.Checked = true;
            }
            else
            {
                checkBoxRememberMe.Checked = false;
            }
            richTextBoxQuestion.Text = AppDataBase.userItem.GetQuestion();
            textBoxAnswer.PlaceholderText = AppDataBase.userItem.GetAnswer();
        }
    }
}
