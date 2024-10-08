using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;


namespace AlbumMaker.Forms
{
    public partial class CreateAlbum : UserControl
    {
        private string pictureFolderPath = $@"{Properties.AppSettings.Default.AppDataFolder}\{Properties.AppSettings.Default.AppName}\{Properties.AppSettings.Default.AppAlbumsFolderName}\";
        private int imageCount = 0;
        List<KeyValuePair<int,string>> images = new List<KeyValuePair<int,string>>();
        public CreateAlbum()
        {
            InitializeComponent();
        }
        public CreateAlbum(List<string> images)
        {
            InitializeComponent();
            LoadImagesFromScan(images);
        }
        private async void LoadImagesFromScan(List<string> images)
        {
            await Task.Run(() =>
            {
                for (int i = 0; i < images.Count; i++)
                {
                    ImageItem imageItem = new ImageItem(i, images[i], "", -1);
                    this.images.Add(new KeyValuePair<int, string>(i, images[i]));

                    Invoke((Action)(() =>
                    {
                        DigiBumPictureBox picture = new DigiBumPictureBox(imageItem, false);
                        picture.ImageDeleted += Picture_ImageDeleted;
                        FLPAlbumData.Controls.Add(picture);
                        progressBar1.Value++;
                    }));
                }
            });
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
                if(FLPAlbumData.Controls.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("This will wipe all images displayed!\nProceed?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.No)
                        return;
                }
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
                                    ImageItem imageItem = new ImageItem(tabIndex, image, "", -1);
                                    images.Add(new KeyValuePair<int, string>(tabIndex, image));
                                    Invoke((Action)(() =>
                                    {
                                        DigiBumPictureBox picture = new DigiBumPictureBox(imageItem,false);
                                        picture.ImageDeleted += Picture_ImageDeleted;
                                        FLPAlbumData.Controls.Add(picture);
                                        progressBar1.Value++;
                                    }));
                                }
                            }
                        });

                        // Hide the progress bar when done
                        progressBar1.Visible = false;
                    }
                }
            }
            catch { throw; }
        }
        private void Picture_ImageDeleted(object sender, int tabIndex)
        {
            // Find the image in the list that has the matching TabIndex
            var imageToRemove = images.FirstOrDefault(item => item.Key == tabIndex);

            // If found, remove the image from the list
            if (imageToRemove.Key != 0 || imageToRemove.Value != null)
            {
                images.Remove(imageToRemove);

                // Find and remove the PictureBox from the FlowLayoutPanel based on TabIndex
                var controlToRemove = FLPAlbumData.Controls.Cast<Control>().FirstOrDefault(c => c.TabIndex == tabIndex);
                if (controlToRemove != null)
                {
                    FLPAlbumData.Controls.Remove(controlToRemove);
                }
            }
        }
        private async Task<List<ImageItem>> ConvertSelectedPicturesToImageItem(int albumID)
        {
            List<ImageItem> imageList = new List<ImageItem>();
            foreach(var image in images)
            {
                imageList.Add(new ImageItem(image.Key, image.Value, "", albumID));
            }
            await Task.CompletedTask;
            return imageList;
        }
        private async Task<List<KeyValuePair<int, string>>> CopyFilesToAppFolder(List<KeyValuePair<int,string>> selectedFiles,int albumID)
        {
            try
            {
                string path = $@"{pictureFolderPath}\{albumID}\";
                Directory.CreateDirectory(path);
                Cursor = Cursors.WaitCursor;
                for (int i = 0; i < selectedFiles.Count; i++)
                {
                    
                    await using (FileStream sourceStream = new FileStream(selectedFiles[i].Value, FileMode.Open))
                    {
                        await using (FileStream destinationStream = new FileStream(path + Path.GetFileName(selectedFiles[i].Value), FileMode.Create))
                        {
                            sourceStream.CopyTo(destinationStream);
                           
                        }
                    }

                }
                string[] files = Directory.GetFiles(path);
                List < KeyValuePair<int, string>> newFiles = new List < KeyValuePair<int, string>>();
                int count = 0;
                foreach (string file in files)
                {
                    string relativePath = $@"{albumID}\{Path.GetFileName(file)}";
                    newFiles.Add(new KeyValuePair<int, string>(count++, relativePath));
                }
                Cursor = Cursors.Default;
                return newFiles;
            }
            catch { Cursor = Cursors.Default; return null; throw; }
            
        }
        private async void buttonSubmitAlbum_Click(object sender, EventArgs e)
        {
            try
            {
                if (FLPAlbumData.Controls.Count == 0)
                {
                    MessageBox.Show("Cannot create album with no pictures.\nYou need to add pictures to your album.", "Choose images!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
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
                
                bool dataBaseSuccess = false;
                bool copySuccess = false;
                
                int albumID = await AppDataBase.CreateAlbum(SettingsManager.userItem, albumTitle, albumDesc, albumTemplate);
                string path = pictureFolderPath + $@"{albumID}\";

                if (albumID > 0)
                {
                    // TO DO: Checked! VVV need to copy the files, then get the new location and update the image list value with the new location AND THEN run the database create
                    // perhaps need to add more logic if a database fail need to retry or if copy fail to retry x times and return success accordingly 
                    images = await CopyFilesToAppFolder(images,albumID);
                    if (images != null)
                    {
                        copySuccess = true;
                        List<ImageItem> imageItems = await ConvertSelectedPicturesToImageItem(albumID);
                        foreach(ImageItem imageItem in imageItems)
                        {
                             await AppDataBase.CreateImage(SettingsManager.userItem.GetAlbumItems().LastOrDefault(), imageItem.GetName(), "");
                        }
                        dataBaseSuccess = true;
                    }
                    
                }
                else
                    return;

                if (dataBaseSuccess && copySuccess)
                {
                    MessageBox.Show("Album created successfully!\nYou are being redirected to your user panel where you can view and edit your albums.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NavigateToMyAlbums();
                }

            }
            catch { throw; }
        }
        private void NavigateToMyAlbums()
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
    }
}
