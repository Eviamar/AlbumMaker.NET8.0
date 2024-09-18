using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;


namespace AlbumMaker.Forms.UserForms
{
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
            if (SettingsManager.userItems == null)
            {
                int res = await AppDataBase.GetAllUserItems();
                if (res > 0)
                {
                    //MessageBox.Show("Loaded from database");
                    LoadDataToPanel();

                }
            }
            else
            {
                //MessageBox.Show("Loaded from cache");
                LoadDataToPanel();
            }
            

        }
        private void LoadDataToPanel()
        {
            try
            {
                foreach (UserItem u in SettingsManager.userItems)
                {
                    GroupBox grpBox = new GroupBox();
                    grpBox.Name = u.GetID().ToString();
                    grpBox.Text = $"User: {u.GetName()} - Albums: {u.GetAlbumItems().Count}";
                    grpBox.Size = new Size(255, 300);


                    if (u.GetAlbumItems().Count == 0)
                    {
                        Label lbl = new Label();
                        lbl.Text = $"{u.GetName()} has no albums";
                        lbl.Size = new Size(250, 250);
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
    }
}
