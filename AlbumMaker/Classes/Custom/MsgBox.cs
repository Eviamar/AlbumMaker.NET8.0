using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;
using AlbumMaker.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumMaker.Classes.Custom
{
    public partial class MsgBox : Form
    {
        private TextBox txtBoxName;
        private TextBox txtBoxPassword;
        private CheckBox checkBox;
        private UserItem user;
        private string msgBoxTitle;
        public MsgBox(UserItem user, string title)
        {
            InitializeComponent();
            this.user = user;
            txtBoxName = new TextBox();
            txtBoxPassword = new TextBox();
            checkBox = new CheckBox();
            UserEdit(this.user);
            this.Text = title;
            SettingsManager.SetTheme(this);
        }
        private void UserEdit(UserItem u)
        {
            //TextBox txt = new TextBox();
            //txt.Text = u.GetName();
            FlowLayoutPanel flp = new FlowLayoutPanel();
            checkBox.Checked = u.GetIsAdmin();
            checkBox.Text = $"{u.GetName()} is admin?";
            Button btnSubmit = new Button();
            txtBoxName.PlaceholderText = u.GetName();
            txtBoxPassword.PlaceholderText = $"new password";
            btnSubmit.Click += Btn_Click;
            btnSubmit.Text = "Apply";
            btnSubmit.AutoSize = true;
            btnSubmit.AutoEllipsis = true;
            btnSubmit.Location = new Point(0, checkBox.Height);
            this.Controls.Add(flp);
            flp.Controls.Add(txtBoxName);
            flp.Controls.Add(txtBoxPassword);
            flp.Controls.Add(checkBox);
            flp.Controls.Add(btnSubmit);
        }

        private async void Btn_Click(object? sender, EventArgs e)
        {

            if(user.GetID() == 1 && checkBox.Checked != user.GetIsAdmin())
            {
                MessageBox.Show("This user is the root user, cannot revoke admin rights from this user.",
                   "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (!String.IsNullOrWhiteSpace(txtBoxPassword.Text) && !String.IsNullOrWhiteSpace(txtBoxName.Text))
            {
                if (SettingsManager.userItem.GetName() == user.GetName())
                {
                    DialogResult dr = MessageBox.Show("Because you are trying to change your own name the application needs to perform restart.\nClick OK to change and restart.\nClick cancel to cancel", "Changing name", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK)
                    {
                        user.SetNewName(txtBoxName.Text);
                        user.SetNewPassword(txtBoxPassword.Text);
                        await AppDataBase.UpdateUser(user);
                        Properties.AppSettings.Default.userName = "";
                        Properties.AppSettings.Default.isLogged = false;
                        Properties.AppSettings.Default.currentUser = "";
                        Properties.AppSettings.Default.UserPassword = "";
                        Properties.AppSettings.Default.Save();
                        Application.Restart();
                    }
                    else
                        return;
                }
                else
                {
                    user.SetNewName(txtBoxName.Text);
                    user.SetNewPassword(txtBoxPassword.Text);
                    bool res = await AppDataBase.UpdateUser(user);
                    if (res) 
                        MessageBox.Show("User updated.","Success");
                    this.Close();
                }
            }
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {
            this.Font = new Font(Form.DefaultFont.FontFamily, Properties.AppSettings.Default.FontSize);
            this.ForeColor = AppSettings.Default.isDark ? SettingsManager.ConvertHexToColor(DarkThemeSettings.Default.Foreground) : SettingsManager.ConvertHexToColor(LightThemeSettings.Default.Foreground);
            this.BackColor = AppSettings.Default.isDark ? SettingsManager.ConvertHexToColor(DarkThemeSettings.Default.Background) : SettingsManager.ConvertHexToColor(LightThemeSettings.Default.Background);
            
        }
    }
}
