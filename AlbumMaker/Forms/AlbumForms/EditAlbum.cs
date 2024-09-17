using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Db;
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
        private void Picture_ImageDeleted(object sender, int tabIndex)
        {
            // Find and remove the PictureBox from the FlowLayoutPanel based on TabIndex
            var controlToRemove = flpImagesToEdit.Controls.Cast<Control>().FirstOrDefault(c => c.TabIndex == tabIndex);

            if (controlToRemove != null)
            {
                flpImagesToEdit.Controls.Remove(controlToRemove);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string newAlbumName = txtBoxAlbumName.Text;
            string newAlbumDesc = txtBoxDesc.Text;
            string newTemplate = cmbTemplate.Text;
            album.SetNewName(newAlbumName);
            album.SetDescription(newAlbumDesc);
            album.SetTemplate(newTemplate);
            if(!String.IsNullOrWhiteSpace(newAlbumName) && !String.IsNullOrWhiteSpace(newAlbumDesc) && !String.IsNullOrWhiteSpace(newTemplate))
            {
                bool res = await AppDataBase.UpdateAlbum(album);
                if (res)
                {
                    MessageBox.Show($"Album {album.GetName()} has been updated!", "Success");
                    EditAlbum_Load(this,null);
                }
                else
                    MessageBox.Show($"Album {album.GetName()} failed to update!", "Fail");
            }
            else
                MessageBox.Show($"All fields required", "Alert");

        }
        private void ShowImagesToEdit()
        {
            foreach (ImageItem image in album.GetImages())
            {
                DigiBumPictureBox digi = new DigiBumPictureBox(image, true);
                //TODO: find a way to transfer some kind of variable so it will display the description instead of name(which is image path)
                digi.ImageDeleted += Picture_ImageDeleted;
                flpImagesToEdit.Controls.Add(digi);
            }
        }

        private void EditAlbum_Load(object sender, EventArgs e)
        {
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            ShowImagesToEdit();
            txtBoxAlbumName.Text = album.GetName();
            txtBoxDesc.Text = album.GetDescription();
            cmbTemplate.SelectedItem = album.GetTemplate();
            labelTitle.Text = $"{album.GetName()}";
            
        }
    }
}
