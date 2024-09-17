using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;
using AlbumMaker.Properties;


namespace AlbumMaker.Forms
{
    public partial class UserControlPanel : UserControl
    {
        public UserControlPanel()
        {
            InitializeComponent();


        }

        private async void btnUpdateQuestion_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(textBoxAnswer.Text))
            {
                MessageBox.Show("Answer cannot be empty", "Forgot something?");
                textBoxAnswer.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(richTextBoxQuestion.Text)) //add default placeholder here too
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
