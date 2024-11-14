using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;



namespace AlbumMaker.Forms
{
    // This User Control handles the login
    public partial class Login : UserControl
    {
        private bool isQuestion = false;
        public Login()
        {
            InitializeComponent();
            this.AutoScroll = true;


        }

        // This function is label event click used to let the user go into hidden section (in UI) for retrieving forgotten password. 
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


        // This function navigate the user to the register 'page'
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
        // This function is check box event check to show password or hide it with ****
        private void checkBoxPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPassword.Checked)
                textBoxPassword.PasswordChar = '\0';
            else
                textBoxPassword.PasswordChar = '*';
        }

        // This function is a button event click to submit input by user and handles the login logic.
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
         
         /* This function is check box event change that makes the application remember the user's user name for next login 
          * so it will automatically will be filled in and only password will be required. */
        private void checkBoxRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxRememberMe.Checked)
            {
                Properties.AppSettings.Default.userName = "";
                Properties.AppSettings.Default.Save();
            }
        }
        /* This funciton is a button event click that handles the forget password logic to retrive forgotten password.
         * The user needs to answer to their question to get their password */
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
