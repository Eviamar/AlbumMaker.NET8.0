using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;


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

        private void chooseImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FLPAlbumData.Controls.Clear();
                List<string> images = new List<string>();
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";
                    while (!(ofd.ShowDialog() == DialogResult.Cancel))
                    {
                        string path = ofd.FileName;
                        for (int i = 0; i < ofd.FileNames.Length; i++)
                        {
                            if (images.Count == Properties.AppSettings.Default.AlbumSize)
                            {
                                MessageBox.Show($"The limit is {Properties.AppSettings.Default.AlbumSize} \nYou've selected:{images.Count}.\nThe first {Properties.AppSettings.Default.AlbumSize} images will be added.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                            images.Add(ofd.FileNames[i]);
                        }
                        MessageBox.Show($"You've chosen {images.Count} pictures.\nYou have {Properties.AppSettings.Default.AlbumSize - (images.Count)} remaining pictures to choose.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (images.Count == Properties.AppSettings.Default.AlbumSize)
                            break;
                    }
                    //LoadImagesToPanel(images, FLPAlbumData);

                }
                for (int i = 0; i < images.Count; i++)
                {
                    DigiBumPictureBox digiBumPictureBox = new DigiBumPictureBox(images[i])
                    {
                        TabIndex = i
                    };
                    FLPAlbumData.Controls.Add(digiBumPictureBox);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        private List<string> GetActualImagesInFLP()
        {
            List<string> images = new List<string>();
            foreach (Control c in FLPAlbumData.Controls)
            {
                if (c is DigiBumPictureBox dbpx)
                {
                    images.Add(dbpx.ImageLocation);
                }
            }
            return images;
        }

        private void buttonSubmitAlbum_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetActualImagesInFLP().Count.ToString());
        }
    }
}
