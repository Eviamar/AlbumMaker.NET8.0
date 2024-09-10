using AlbumMaker.Classes;


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

        private void MyAlbums_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
        }
    }
}
