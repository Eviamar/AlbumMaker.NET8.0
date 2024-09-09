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
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
            {
                textBoxPassword.PasswordChar = '\0';
                textBoxPassword2.PasswordChar = '\0';
            }
            else
            {
                textBoxPassword.PasswordChar = '*';
                textBoxPassword2.PasswordChar = '*';
            }
        }

        private void lblAlreadyRegistered_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(login);
                login.Dock = DockStyle.Fill;
                SettingsManager.SetTheme(login);
                this.Dispose();
                login.Show();
            }
        }
    }
}
