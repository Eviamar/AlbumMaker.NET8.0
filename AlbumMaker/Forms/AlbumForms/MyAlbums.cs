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
            this.AutoScroll = true;
        }
        private void Picture_AlbumView(AlbumItem album)
        {
            // Find and remove the PictureBox from the FlowLayoutPanel based on TabIndex
            ViewAlbum va = new ViewAlbum(album);
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
                if (SettingsManager.userItem.GetAlbumItems().Count == 0) 
                {
                    flpDisplayAlbums.Hide();
                    Label lblNoAlbums = new Label();
                    lblNoAlbums.Text = $"Hello {SettingsManager.userItem.GetName()},\nYou do not have any albums.\nCreate albums and they will be displayed here.";
                    lblNoAlbums.AutoSize = true;
                    lblNoAlbums.AutoEllipsis = true;
                    lblNoAlbums.BorderStyle = BorderStyle.FixedSingle;
                    lblNoAlbums.Location = new Point(this.Width/5, this.Height/2);
                    lblNoAlbums.Font = new Font(this.Font.FontFamily, Properties.AppSettings.Default.FontSize);
                    lblNoAlbums.ForeColor = Properties.AppSettings.Default.isDark ? Color.White : Color.Black;
                    this.Controls.Add(lblNoAlbums);  
                }
                else
                foreach(AlbumItem album in SettingsManager.userItem.GetAlbumItems())
                {
                    DigiBumPictureBox digiBumPictureBox = new DigiBumPictureBox(album,true);
                    digiBumPictureBox.albumView +=(sender,args)=> Picture_AlbumView(album);
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
