using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;

namespace AlbumMaker.Forms.AlbumForms
{
    // This User Control class handles all editing of an album
    public partial class EditAlbum : UserControl
    {
        private AlbumItem album;
        public EditAlbum(AlbumItem album)
        {
            InitializeComponent();
            this.album= album;
            this.AutoScroll = true;


        }
        // This function is a toolstrip menu click that takes back the user one 'page' back
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

        // This function handles deleting of an image; it deletes the iamge from the UI.
        private void Picture_ImageDeleted(object sender, int tabIndex)
        {
            // Find and remove the PictureBox from the FlowLayoutPanel based on TabIndex
            var controlToRemove = flpImagesToEdit.Controls.Cast<Control>().FirstOrDefault(c => c.TabIndex == tabIndex);

            if (controlToRemove != null)
            {
                flpImagesToEdit.Controls.Remove(controlToRemove);
            }
        }

        // This function updates in the database the album's name/description/template according to the user decides.
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
                }
                else
                    MessageBox.Show($"Album {album.GetName()} failed to update!", "Fail");
            }
            else
                MessageBox.Show($"All fields required", "Alert");

        }
        
        // This fucntion loads the images that in the album to the UI.
        private async void ShowImagesToEdit()
        {
            flpImagesToEdit.SuspendLayout();
            flpImagesToEdit.AutoScroll = false;
            await Task.Run(() =>
            {
                foreach (ImageItem image in album.GetImages())
                {
                    // Load the image on the UI thread
                    flpImagesToEdit.Invoke(new Action(() =>
                    {
                        DigiBumPictureBox digi = new DigiBumPictureBox(image, true);
                        digi.ImageDeleted += Picture_ImageDeleted;
                        flpImagesToEdit.Controls.Add(digi);
                    }));
                }
            });
            flpImagesToEdit.AutoScroll = true;
            flpImagesToEdit.ResumeLayout();
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
