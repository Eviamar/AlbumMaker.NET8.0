using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Items;
using AlbumMaker.Forms.AlbumForms;
using AlbumMaker.Properties;


namespace AlbumMaker.Forms
{
    public partial class MyAlbums : UserControl
    {
        public MyAlbums()
        {
            InitializeComponent();
        }
        private void Picture_AlbumView(object sender, int tabIndex)
        {
            // Find and remove the PictureBox from the FlowLayoutPanel based on TabIndex
            ViewAlbum va = new ViewAlbum(tabIndex);
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(va);
                va.Dock = DockStyle.Fill;
                this.Dispose();
                va.Show();
            }
            

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
                    DigiBumPictureBox digiBumPictureBox = new DigiBumPictureBox(album,true);
                    digiBumPictureBox.albumView += Picture_AlbumView;
                    flpDisplayAlbums.Controls.Add(digiBumPictureBox);
                }
            }
            catch { throw; }
        }

        private void MyAlbums_Load(object sender, EventArgs e)
        {
            this.LoadAlbums();
            SettingsManager.SetTheme(this);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
        }
    }
}
