using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;


namespace AlbumMaker.Forms
{
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        // This function is a checkbox check event that hides or show password
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
        // This function is a link label click event to navigate user to login 'page'.
        private void lblAlreadyRegistered_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NavigateToLogin();
        }
        // This function navigate the user to login 'page'.
        private void NavigateToLogin()
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

        // This function is a button event click that handle the register logic and check user input
        // If everything is right it register the user and automatically navigate to login.
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                MessageBox.Show("Username cannot be empty");
                textBoxUsername.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                MessageBox.Show("Password 1 cannot be empty");
                textBoxPassword.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxPassword2.Text))
            {
                MessageBox.Show("Password 2 cannot be empty");
                textBoxPassword2.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBoxAnswer.Text))
            {
                MessageBox.Show("Answer cannot be empty");
                textBoxAnswer.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(richTextBoxQuestion.Text)) 
            {
                MessageBox.Show("Question cannot be empty");
                richTextBoxQuestion.Focus();
                return;
            }
            if (textBoxPassword.Text != textBoxPassword2.Text)
            {
                MessageBox.Show("Passwords are not matched!!");
                return;

            }
            if (richTextBoxQuestion.Text == textBoxAnswer.Text || richTextBoxQuestion.Text.Contains(textBoxAnswer.Text))
            {
                MessageBox.Show("The answer cannot match the question or be in the question!");
                textBoxAnswer.Focus();
                return;
            }
            bool isCreated = await AppDataBase.CreateUser(textBoxUsername.Text, textBoxPassword.Text, richTextBoxQuestion.Text, textBoxAnswer.Text);
            if (isCreated)
                NavigateToLogin();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
        }
    }
}
