using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;


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
                MessageBox.Show("Question cannot be empty","Forgot something?");
                richTextBoxQuestion.Focus();
                return;
            }
            if (richTextBoxQuestion.Text == textBoxAnswer.Text || richTextBoxQuestion.Text.Contains(textBoxAnswer.Text))
            {
                MessageBox.Show("The answer cannot match the question or be in the question!","Answer is too obvious");
                textBoxAnswer.Focus();
                return;
            }

            UserItem tempUser = AppDataBase.userItem;
            tempUser.SetQuestion(richTextBoxQuestion.Text);
            tempUser.SetAnswer(textBoxAnswer.Text);


            bool isUpdated = await AppDataBase.UpdateUser(tempUser);
            if (isUpdated)
            {
                AppDataBase.userItem.SetQuestion(richTextBoxQuestion.Text);
                AppDataBase.userItem.SetAnswer(textBoxAnswer.Text);
                MessageBox.Show($"Updated question and answer.\nNew question: {AppDataBase.userItem.GetQuestion()}\nNew answer: {AppDataBase.userItem.GetAnswer()}", "Success");
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
            richTextBoxQuestion.Text = AppDataBase.userItem.GetQuestion();
            textBoxAnswer.PlaceholderText = AppDataBase.userItem.GetAnswer();
        }

        private async void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (textBoxCurrentPassword.Text != AppDataBase.userItem.GetPassword())
            {
                MessageBox.Show($"Wrong current password, you have to type the password you used to login", "Password is incorrect");
                return;
            }
            if (textBoxPassword.Text != textBoxPassword2.Text)
            {
                MessageBox.Show($"Passwords are not match", "Passwords are not identical");
                return;
            }
            AppDataBase.userItem.SetNewPassword(textBoxPassword2.Text);
            bool isSuccess = await AppDataBase.UpdateUser(AppDataBase.userItem);
            if (isSuccess)
                MessageBox.Show($"Succes update password\nnew password: {AppDataBase.userItem.GetPassword()}", "Success");

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
    }
}
