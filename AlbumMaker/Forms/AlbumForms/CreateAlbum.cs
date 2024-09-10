using AlbumMaker.Classes;


namespace AlbumMaker.Forms
{
    public partial class CreateAlbum : UserControl
    {
        public CreateAlbum()
        {
            InitializeComponent();
        }

        private void scanFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanForImages scan = new ScanForImages();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(scan);
                scan.Dock = DockStyle.Fill;
                this.Dispose();
                scan.Show();
            }
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyAlbums myAlbums = new MyAlbums();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(myAlbums);
                myAlbums.Dock = DockStyle.Fill;
                this.Dispose();
                myAlbums.Show();
            }
        }

        private void CreateAlbum_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
        }
    }
}
