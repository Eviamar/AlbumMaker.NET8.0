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
        private string msgBoxTitle;
        public MsgBox(UserItem user, string title)
        {
            InitializeComponent();
            UserEdit(user);
            this.Text = title;
            SettingsManager.SetTheme(this);
        }
        private void UserEdit(UserItem u)
        {
            //TextBox txt = new TextBox();
            //txt.Text = u.GetName();
            CheckBox checkBox = new CheckBox();
            checkBox.Checked = u.GetIsAdmin();
            checkBox.Text = $"{u.GetName()} is admin?";
            Button btn = new Button();
            btn.Click += (sender, args) => Btn_Click(sender, args, u);
            //FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            ////flowLayoutPanel.Controls.Add(txt);
            //flowLayoutPanel.Controls.Add(checkBox);
            //flowLayoutPanel.Dock = DockStyle.Fill;
            //this.Controls.Add(flowLayoutPanel);
            this.Controls.Add(checkBox);
            //btn.Dock = DockStyle.Bottom;
            btn.Text = "Apply";
            btn.AutoSize = true;
            btn.AutoEllipsis = true;
            btn.Location = new Point(0, checkBox.Height);
            this.Controls.Add(btn);
        }

        private async void Btn_Click(object? sender, EventArgs e, UserItem u)
        {
            u.SetIsAdmin(!u.GetIsAdmin());
            await AppDataBase.UpdateUser(u);
            this.Close();
        }

        private void MsgBox_Load(object sender, EventArgs e)
        {
            this.Font = new Font(Form.DefaultFont.FontFamily, Properties.AppSettings.Default.FontSize);
            this.ForeColor = AppSettings.Default.isDark ? SettingsManager.ConvertHexToColor(DarkThemeSettings.Default.Foreground) : SettingsManager.ConvertHexToColor(LightThemeSettings.Default.Foreground);
            this.BackColor = AppSettings.Default.isDark ? SettingsManager.ConvertHexToColor(DarkThemeSettings.Default.Background) : SettingsManager.ConvertHexToColor(LightThemeSettings.Default.Background);
            
        }
    }
}
