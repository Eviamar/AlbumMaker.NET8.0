using AlbumMaker.Classes;
using AlbumMaker.Classes.Items;
namespace AlbumMaker.Forms.AlbumForms
{
    public partial class EditImage : UserControl
    {
        private ImageItem image;
        public EditImage(ImageItem image)
        {
            InitializeComponent();
            this.image = image;
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EditAlbum editAlbum = new EditAlbum(SettingsManager.userItem.GetAlbumItems().Find(x => x.GetID() == image.GetRelatedAlbumID()));
                Panel p = this.Parent as Panel;
                if (p != null)
                {
                    SettingsManager.SetTheme(editAlbum);
                    p.Controls.Add(editAlbum);
                    editAlbum.Dock = DockStyle.Fill;
                    this.Dispose();
                    editAlbum.Show();
                }
            }
            catch { throw; }

        }

        private void EditImage_Load(object sender, EventArgs e)
        {
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
        }
    }
}
