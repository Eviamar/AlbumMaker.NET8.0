using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;



namespace AlbumMaker.Forms
{
    public partial class Login : UserControl
    {
        private bool isQuestion = false;
        public Login()
        {
            InitializeComponent();
            this.AutoScroll = true;


        }


        private async void lblForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (lblForgot.Text == "Forgot password?")
            {
                if (String.IsNullOrWhiteSpace(textBoxUsername.Text))
                {

                    MessageBox.Show("You need to type your username", "Need username to recover its password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxUsername.Focus();
                    return;
                }
                else
                {
                    isQuestion = await AppDataBase.RecoverPassword(textBoxUsername.Text);
                    richTextBoxQuestion.Text = SettingsManager.userItem.GetQuestion();
                }
            }
            if (isQuestion)
            {
                richTextBoxQuestion.Visible = !richTextBoxQuestion.Visible;
                textBoxAnswer.Visible = !textBoxAnswer.Visible;
                btnForgot.Visible = !btnForgot.Visible;

                if (btnForgot.Visible)
                    lblForgot.Text = "Nevermind I remember it!";
                else
                    lblForgot.Text = "Forgot password?";
            }
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

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show($"Username cannot be empty", "Username is empty!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxUsername.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show($"Password cannot be empty", "Password is empty!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxPassword.Focus();
                return;
            }


            bool isVerfied = await AppDataBase.VerifyUser(textBoxUsername.Text.ToLower(), textBoxPassword.Text);
            if (isVerfied)
            {

                if (checkBoxRememberMe.Checked)
                    Properties.AppSettings.Default.userName = textBoxUsername.Text;
                else
                    Properties.AppSettings.Default.userName = "";

                Properties.AppSettings.Default.isLogged = true;
                Properties.AppSettings.Default.currentUser = textBoxUsername.Text;
                Properties.AppSettings.Default.Save();
                MyAlbums myAlbums = new MyAlbums();
                Panel p = this.Parent as Panel;
                if (p != null)
                {
                    p.Controls.Add(myAlbums);
                    myAlbums.Dock = DockStyle.Fill;
                    SettingsManager.SetTheme(myAlbums);
                    this.Dispose();
                    myAlbums.Show();
                }
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            if (Properties.AppSettings.Default.userName != "")
            {
                textBoxUsername.Text = Properties.AppSettings.Default.userName;
                checkBoxRememberMe.Checked = true;
            }
            else
                checkBoxRememberMe.Checked = false;

        }

        private void checkBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxRememberMe.Checked)
            {
                Properties.AppSettings.Default.userName = "";
                Properties.AppSettings.Default.Save();
            }
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            if (textBoxAnswer.Text == SettingsManager.userItem.GetAnswer())
            {
                MessageBox.Show($"Your password is:\n\n{SettingsManager.userItem.GetPassword()}", "Recovered successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxPassword.Focus();
            }
            else
            {
                MessageBox.Show($"Wrong answer!", "Answer incorrect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


    }
}
