using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Items;

namespace AlbumMaker.Forms.AlbumForms
{
    public partial class EditAlbum : UserControl
    {
        private AlbumItem album;
        public EditAlbum(AlbumItem album)
        {
            InitializeComponent();
            this.album= album;

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

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        private void ShowImagesToEdit()
        {
            foreach (ImageItem image in album.GetImages())
            {
                DigiBumPictureBox digi = new DigiBumPictureBox(image, true);
                flpImagesToEdit.Controls.Add(digi);
            }
        }

        private void EditAlbum_Load(object sender, EventArgs e)
        {
            ShowImagesToEdit();
            txtBoxAlbumName.Text = album.GetName();
            txtBoxDesc.Text = album.GetDescription();
            cmbTemplate.SelectedItem = album.GetTemplate();
            labelTitle.Text = $"{album.GetName()}";
        }
    }
}
