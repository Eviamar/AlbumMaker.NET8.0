using AlbumMaker.Classes;
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
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void lblForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            richTextBoxQuestion.Visible = !richTextBoxQuestion.Visible;
            textBoxAnswer.Visible = !textBoxAnswer.Visible;
            btnForgot.Visible = !btnForgot.Visible;

            if (btnForgot.Visible)
                lblForgot.Text = "Nevermind I remember it!";
            else
                lblForgot.Text = "Forgot login credentials?";
        }

        private void lblAlreadyRegistered_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(register);
                register.Dock = DockStyle.Fill;
                SettingsManager.SetTheme(register);
                this.Dispose();
                register.Show();
            }
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
                textBoxPassword.PasswordChar = '\0';
            else
                textBoxPassword.PasswordChar = '*';
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (checkBoxRememberMe.Checked)
            {
                Properties.AppSettings.Default.userName = textBoxUsername.Text;
                Properties.AppSettings.Default.Save();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

            //move it to the end after checking if user exist and password is matched
            string savedUserName = Properties.AppSettings.Default.userName;
            if (Properties.AppSettings.Default.userName != "")
            {
                textBoxUsername.Text = savedUserName;
            }
        }

        private void linkLabelForgetMe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Properties.AppSettings.Default.userName = "";
            Properties.AppSettings.Default.Save();
            textBoxUsername.Text = Properties.AppSettings.Default.userName;
        }
    }
}
