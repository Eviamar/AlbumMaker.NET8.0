using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;


namespace AlbumMaker.Forms
{
    public partial class CreateAlbum : UserControl
    {
        private string pictureFolderPath = $@"{Properties.AppSettings.Default.AppDataFolder}\Albums\";
        private int imageCount = 0;
        List<KeyValuePair<int,string>> images = new List<KeyValuePair<int,string>>();
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

        private async void chooseImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;
                    ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;";

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        // Initialize the progress bar
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = ofd.FileNames.Length;
                        progressBar1.Value = 0;
                        progressBar1.Visible = true;

                        // Run image processing in a background task
                        await Task.Run(() =>
                        {
                            foreach (string image in ofd.FileNames)
                            {
                                // Check if the image is already added
                                if (!images.Any(item => item.Value == image))
                                {
                                    int tabIndex = imageCount++;
                                    images.Add(new KeyValuePair<int, string>(tabIndex, image));
                                    Invoke((Action)(() =>
                                    {
                                        DigiBumPictureBox picture = new DigiBumPictureBox(image)
                                        {
                                            TabIndex = tabIndex
                                        };
                                        picture.ImageDeleted += Picture_ImageDeleted;
                                        FLPAlbumData.Controls.Add(picture);
                                        progressBar1.Value++;
                                    }));
                                }
                                else
                                {
                                    Invoke((Action)(() =>
                                    {
                                        MessageBox.Show($"You already added this image to the list:\n{Path.GetFileName(image)}", $"Image is already selected");
                                    }));
                                }
                            }
                        });

                        // Hide the progress bar when done
                        progressBar1.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Picture_ImageDeleted(object sender, int tabIndex)
        {
            // Find and remove the PictureBox from the FlowLayoutPanel based on TabIndex
            var controlToRemove = FLPAlbumData.Controls.Cast<Control>().FirstOrDefault(c => c.TabIndex == tabIndex);
            images.RemoveAt(controlToRemove.TabIndex);
            if (controlToRemove != null)
            {
                FLPAlbumData.Controls.Remove(controlToRemove);
            }
        }
        private async Task<List<ImageItem>> ConvertSelectedPicturesToImageItem()
        {
            List<ImageItem> imageList = new List<ImageItem>();
            foreach(var image in images)
            {
                imageList.Add(new ImageItem(image.Key, image.Value, ""));
            }
            //int count = 0;
            //foreach (Control c in FLPAlbumData.Controls)
            //{
            //    if (c is DigiBumPictureBox image)
            //    {
            //        images.Add(new ImageItem(count++, image.ImageLocation,""));
            //    }
            //}
            await Task.CompletedTask;
            return imageList;
        }

        private async void buttonSubmitAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                string albumTitle, albumDesc, albumTemplate = null;
                albumTitle = textBoxAlbumName.Text;
                albumDesc = textBoxAlbumDescription.Text;
                if (comboBoxTemplates.SelectedItem != null)
                    albumTemplate = comboBoxTemplates.SelectedItem.ToString();
                if (string.IsNullOrWhiteSpace(albumTitle) || string.IsNullOrWhiteSpace(albumDesc) || string.IsNullOrEmpty(albumTemplate))
                {
                    MessageBox.Show("All fields are required!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (FLPAlbumData.Controls.Count == 0)
                {
                    MessageBox.Show("Cannot create album with no pictures.\nYou need to add pictures to your album.", "Choose images!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool success = false;
                
                int albumID = await AppDataBase.CreateAlbum(AppDataBase.userItem.GetID(), albumTitle, albumDesc, albumTemplate);
                string path = pictureFolderPath + $@"{albumID}\";

                if (albumID > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    List<ImageItem> imageItems = await ConvertSelectedPicturesToImageItem();
                    for (int i = 0; i < images.Count; i++)
                    {
                        success = false;
                        Directory.CreateDirectory(path);
                        using (FileStream sourceStream = new FileStream(imageItems[i].GetName(), FileMode.Open))
                        using (FileStream destinationStream = new FileStream(path + Path.GetFileName(imageItems[i].GetName()), FileMode.Create))
                        {
                            sourceStream.CopyTo(destinationStream);
                            sourceStream.Close();
                            sourceStream.Dispose();

                        }
                        success = await AppDataBase.CreateImage(albumID, imageItems[i].GetName(),"");
                        Cursor = Cursors.Default;
                    }
                }
                else
                    return;
                if (success)
                {
                    MessageBox.Show("Album created successfully!\nYou are being redirected to your user panel where you can view and edit your albums.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    


                }

            }
            catch(Exception ex) { throw; }
        }
    }
}
