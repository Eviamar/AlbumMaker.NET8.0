using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;
using AlbumMaker.Properties;

namespace AlbumMaker.Classes.Custom
{
    // This form handles the user editing and deleting (runs via admin panel). 
    public partial class UserEditForm : Form
    {
        private TextBox txtBoxName;
        private TextBox txtBoxPassword;
        private CheckBox checkBox;
        private UserItem user;
        public UserEditForm(UserItem user, string title)
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
            txtBoxName.TabIndex = 0;
            txtBoxPassword.TabIndex = 1;
            checkBox.TabIndex = 2;
            FlowLayoutPanel flp = new FlowLayoutPanel();
            checkBox.Checked = u.GetIsAdmin();
            checkBox.Text = $"{u.GetName()} is admin?";
            Button btnSubmit = new Button();
            Button btnDeleteUser = new Button();
            btnDeleteUser.BackColor = Color.Red;
            btnDeleteUser.ForeColor = Color.Black;
            btnDeleteUser.Text = $"Delete {u.GetName()}";
            btnDeleteUser.Click += BtnDeleteUser_Click;
            btnSubmit.TabIndex = 3;
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
            flp.Controls.Add(btnDeleteUser);
            flp.AutoSize = true;
        }
        // This function is delete button event click that handles the deletion of selected user.
        private async void BtnDeleteUser_Click(object? sender, EventArgs e)
        {
            if (SettingsManager.userItem.GetID() == user.GetID() && SettingsManager.userItem.GetID()!=1)
            {
                MessageBox.Show("You cannot delete yourself.\nTo delete this user login to another admin account or root user if possible.","Alert");
                return;
            }

            if (user.GetID() == 1)
                MessageBox.Show("You cannot delete the root user.\nRoot user is the first user created.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult dr = MessageBox.Show($"Are you sure you want to delete {user.GetName()}?" +
                    $"\n{user.GetName()} has {user.GetAlbumItems().Count} albums.\n" +
                    $"Every album {user.GetName()} created will be deleted from the database and all {user.GetName()}'s images will be deleted from the disk.\n" +
                    $"Are you sure you want to delete {user.GetName()}?","Alert",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int totalAlbumsToDelete = user.GetAlbumItems().Count;
                    foreach(AlbumItem album in user.GetAlbumItems())
                    {
                        DigiBumPictureBox digiAlbum = new DigiBumPictureBox(album,true);      
                        digiAlbum.DeleteAlbum(sender,e,album,true);
                    }
                    int res =  await AppDataBase.GetAllAlbumsOfUser(user);
                    if (res == 0)
                    {
                        await AppDataBase.DeleteUser(user);
                        MessageBox.Show($"User deleted", "Success");
                        this.Close();
                    }
                    else
                        MessageBox.Show($"Failed to delete all albums so user will not be deleted.", "Failed");
                }
                else
                {
                    return;
                }
            }
        }

        // This function is a submit button event click that handles the editing of the selected user.
        // The functions runs few checks before the editing for restrictions made by us and to prevent issues.
        private async void Btn_Click(object? sender, EventArgs e)
        {
            if (user.GetID() == 1 && SettingsManager.userItem.GetID() != 1)
            {
                MessageBox.Show("You are not allowed to edit root user." +
                    "\nTo edit root user login and perform this act from the root user", "Alert");
                return;
            }
            if (user.GetID() == 1 && checkBox.Checked != user.GetIsAdmin())
            {
                MessageBox.Show("This user is the root user, cannot revoke admin rights from this user.",
                   "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            bool userEditSelf = SettingsManager.userItem.GetName() == user.GetName();
            if (!String.IsNullOrEmpty(txtBoxName.Text))
                user.SetNewName(txtBoxName.Text);
            if (!String.IsNullOrEmpty(txtBoxPassword.Text))
                user.SetNewPassword(txtBoxPassword.Text);
            user.SetIsAdmin(checkBox.Checked);
            bool res = await AppDataBase.UpdateUser(user);
            if (res)
            {
                MessageBox.Show($"{user.GetName()} has been updated", "Success");
                if (userEditSelf)
                {
                    MessageBox.Show("Because you edit yourself the application will perform restart now.", "Alert");
                    Properties.AppSettings.Default.isLogged = false;
                    Properties.AppSettings.Default.userName = txtBoxName.Text;
                    Properties.AppSettings.Default.currentUser = "";
                    Properties.AppSettings.Default.UserPassword = "";
                    Properties.AppSettings.Default.Save();
                    // restart happens here to prevent issues with UI and app saved information (data that stored in AppSettings & SettingsManager.userItem).
                    // examples:
                    // 1. If current user is not an admin anymore then the UI will be reload properly without admin button upon next login,
                    // 2. To make the user double check their login information by inserting the new username/password and refresh saved data in the app with a new login.
                    Application.Restart();
                }
                else
                    this.Close();
            }
            else
            {
                MessageBox.Show("You tried to give this user a name that already exist or something else went wrong.\nFailed to edit user", "Failed");
            }
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            this.Font = new Font(Form.DefaultFont.FontFamily, Properties.AppSettings.Default.FontSize);
            this.ForeColor = AppSettings.Default.isDark ? SettingsManager.ConvertHexToColor(DarkThemeSettings.Default.Foreground) : SettingsManager.ConvertHexToColor(LightThemeSettings.Default.Foreground);
            this.BackColor = AppSettings.Default.isDark ? SettingsManager.ConvertHexToColor(DarkThemeSettings.Default.Background) : SettingsManager.ConvertHexToColor(LightThemeSettings.Default.Background);
        }
    }
}
