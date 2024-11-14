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
            this.AutoScroll = true;


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
                }
                else
                    MessageBox.Show($"Album {album.GetName()} failed to update!", "Fail");
            }
            else
                MessageBox.Show($"All fields required", "Alert");

        }
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
