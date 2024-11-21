using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;
using AlbumMaker.Properties;


namespace AlbumMaker.Forms.UserForms
{
    // This User Control made for admin to handle the application users.
    public partial class AdminPanel : UserControl
    {
        public AdminPanel()
        {
            InitializeComponent();
            this.AutoScroll = true;
        }

        private async void AdminPanel_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            await AppDataBase.GetAllUserItems();
            LoadDataToPanel();
        }
        // This function loads all users in users table into a flow layout panel into a group box for each user and there user's album can be display/edit/delete.
        // Also by clicking on said group box DOUBLE CLICK admin can edit the user itself (can change name,password and admin status).
        private void LoadDataToPanel()
        {
            try
            {
                foreach (UserItem u in SettingsManager.userItems)
                {
                    GroupBox grpBox = new GroupBox();
                    grpBox.Name = u.GetID().ToString();
                    grpBox.Text = $"User: {u.GetName()} - Albums: {u.GetAlbumItems().Count}";
                    grpBox.Size = new Size(260, 260);
                    grpBox.ForeColor = Properties.AppSettings.Default.isDark ? Color.White : Color.Black;
                    grpBox.MouseEnter+= (sender, e) => Cursor = Cursors.Hand;
                    grpBox.MouseLeave += (sender, e) => Cursor = Cursors.Default;
                    grpBox.DoubleClick += (sender,args) => GrpBox_DoubleClick(sender,args,u);
                    grpBox.MouseEnter += GrpBox_MouseEnter;
                    if (u.GetAlbumItems().Count == 0)
                    {
                        Label lbl = new Label();
                        lbl.Text = $"{u.GetName()} has no albums";
                        lbl.AutoSize = true;
                        lbl.Dock = DockStyle.Fill;
                        grpBox.Controls.Add(lbl);
                    }
                    else
                    {
                        FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                        flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                        flowLayoutPanel.AutoScroll = true;
                        flowLayoutPanel.Location = new Point(0, 0);
                        flowLayoutPanel.Dock = DockStyle.Fill;
                        flowLayoutPanel.Size = new Size(250, 250);
                        
                        foreach (AlbumItem album in u.GetAlbumItems())
                        {
                            DigiBumPictureBox digiBumPictureBox = new DigiBumPictureBox(album, true);
                            flowLayoutPanel.Controls.Add(digiBumPictureBox);
                        }
                        grpBox.Controls.Add(flowLayoutPanel);
                    }

                    flpUsers.Controls.Add(grpBox);
                }
            }
            catch { throw; }
            
        }

        private void GrpBox_MouseEnter(object? sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip((GroupBox)sender, "Double click to edit user.");
        }

        private void GrpBox_DoubleClick(object? sender, EventArgs e,UserItem u)
        {
            UserEditForm userEditForm = new UserEditForm(u,$"Editing user - {u.GetName()}");
            SettingsManager.SetTheme(userEditForm);
            userEditForm.ShowDialog();
            this.Controls.Clear();
            InitializeComponent();
            AdminPanel_Load(this, EventArgs.Empty); 
            
        }
    }
}
