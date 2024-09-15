using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Items;
using AlbumMaker.Properties;


namespace AlbumMaker.Forms
{
    public partial class MyAlbums : UserControl
    {
        public MyAlbums()
        {
            InitializeComponent();
        }

        private void createNewAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAlbum albumCreate = new CreateAlbum();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(albumCreate);
                albumCreate.Dock = DockStyle.Fill;
                this.Dispose();
                albumCreate.Show();
            }
        }
        private void LoadAlbums()
        {
            try
            {
                
                foreach(AlbumItem album in SettingsManager.userItem.GetAlbumItems())
                {
                    DigiBumPictureBox digiBumPictureBox = new DigiBumPictureBox(album,false);
                    flpDisplayAlbums.Controls.Add(digiBumPictureBox);
                }
            }
            catch { throw; }
        }

        private void MyAlbums_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            this.LoadAlbums();
        }
    }
}
