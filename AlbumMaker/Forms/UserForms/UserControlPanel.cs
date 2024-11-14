using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;
using AlbumMaker.Properties;


namespace AlbumMaker.Forms
{
    // This User Control made so user can change their information and more QoL:
    // such us keep me logged on next app opens or just remember user name for login 'page'.
    public partial class UserControlPanel : UserControl
    {
        public UserControlPanel()
        {
            InitializeComponent();
            this.AutoScroll = true;


        }
        // This function updates the input to the database for the secret question used for restoring forgotten password.
        private async void btnUpdateQuestion_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxAnswer.Text))
            {
                MessageBox.Show("Answer cannot be empty", "Forgot something?");
                textBoxAnswer.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(richTextBoxQuestion.Text))
            {
                MessageBox.Show("Question cannot be empty", "Forgot something?");
                richTextBoxQuestion.Focus();
                return;
            }
            if (richTextBoxQuestion.Text == textBoxAnswer.Text || richTextBoxQuestion.Text.Contains(textBoxAnswer.Text))
            {
                MessageBox.Show("The answer cannot match the question or be in the question!", "Answer is too obvious");
                textBoxAnswer.Focus();
                return;
            }

            UserItem tempUser = SettingsManager.userItem;
            tempUser.SetQuestion(richTextBoxQuestion.Text);
            tempUser.SetAnswer(textBoxAnswer.Text);


            bool isUpdated = await AppDataBase.UpdateUser(tempUser);
            if (isUpdated)
            {
                SettingsManager.userItem.SetQuestion(richTextBoxQuestion.Text);
                SettingsManager.userItem.SetAnswer(textBoxAnswer.Text);
                MessageBox.Show($"Updated question and answer.\nNew question: {SettingsManager.userItem.GetQuestion()}\nNew answer: {SettingsManager.userItem.GetAnswer()}", "Success");
            }
        }

        // This function is check box event change that handles the information-
        // saving of user name for future login 'page' landing the name will be filled in user name text box.
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
            SettingsManager.SetTheme(this);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            if (Properties.AppSettings.Default.userName != "")
            {
                checkBoxRememberMe.Checked = true;
            }
            else
            {
                checkBoxRememberMe.Checked = false;
            }
            if (Properties.AppSettings.Default.UserPassword != "")
            {
                checkBoxLoginAuto.Checked = true;
            }
            richTextBoxQuestion.Text = SettingsManager.userItem.GetQuestion();
            textBoxAnswer.PlaceholderText = SettingsManager.userItem.GetAnswer();
        }
        // Function of a button event click to update the password
        // it checks logic if the old password is current and not same as the new password
        // checks if new password is match (new password1 == new password2)
        private async void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (textBoxCurrentPassword.Text != SettingsManager.userItem.GetPassword())
            {
                MessageBox.Show($"Wrong current password, you have to type the password you used to login", "Password is incorrect");
                return;
            }
            if (textBoxPassword.Text != textBoxPassword2.Text)
            {
                MessageBox.Show($"Passwords are not match", "Passwords are not identical");
                return;
            }
            SettingsManager.userItem.SetNewPassword(textBoxPassword2.Text);
            bool isSuccess = await AppDataBase.UpdateUser(SettingsManager.userItem);
            if (isSuccess)
                MessageBox.Show($"Succes update password\nnew password: {SettingsManager.userItem.GetPassword()}", "Success");

        }

        // Function for check box change to display/hide password
        private void checkBoxShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowHide.Checked)
            {
                textBoxCurrentPassword.PasswordChar = '\0';
                textBoxPassword.PasswordChar = '\0';
                textBoxPassword2.PasswordChar = '\0';
            }
            else
            {
                textBoxCurrentPassword.PasswordChar = '*';
                textBoxPassword2.PasswordChar = '*';
                textBoxPassword.PasswordChar = '*';
            }
        }

        // Function for check box change if marked the next time the user open the application it will be automatically logged in.
        private void checkBoxLoginAuto_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxLoginAuto.Checked)
            {
                AppSettings.Default.userName = SettingsManager.userItem.GetName();
                AppSettings.Default.UserPassword = SettingsManager.userItem.GetPassword();
            }
            else
            {
                AppSettings.Default.UserPassword = "";
                if (!checkBoxRememberMe.Checked)
                {
                    AppSettings.Default.userName = "";
                } 

            }
        }
    }
}
