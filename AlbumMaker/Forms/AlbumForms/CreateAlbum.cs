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
    // This is a User Control which handles all needs to create an album.
    public partial class CreateAlbum : UserControl
    {
        private string pictureFolderPath = $@"{Properties.AppSettings.Default.AppDataFolder}\{Properties.AppSettings.Default.AppName}\{Properties.AppSettings.Default.AppAlbumsFolderName}\";
        private int imageCount = 0;
        private List<KeyValuePair<int,string>> images = new List<KeyValuePair<int,string>>();
        private string[] albumInfo = new string[2];
        // Default constructor used as the first time arriving to this control.
        public CreateAlbum()
        {
            InitializeComponent();
        }
        // Second constructor made so it can pass information already applied to the form to the next (Scan) form so when going back no need to insert again.
        // EX: for when user type title and description (or images) and going to Scan form this information kept when coming back here.
        public CreateAlbum(List<string> images, string[] albumInfo)
        {
            InitializeComponent();
            LoadImagesFromScan(images,albumInfo);
        }
        // This function loads information coming from Scan form.
        private async void LoadImagesFromScan(List<string> images, string[] albumInfo)
        {
            await Task.Run(() =>
            {
                textBoxAlbumName.Text = albumInfo[0];   
                textBoxAlbumDescription.Text = albumInfo[1];
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
        // This function is a toolstrip click event that takes the user to Scan form
        // It checks if there are images already selected and gives the user options to keep them or discard while going to Scan.
        private void scanFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            albumInfo[0] = textBoxAlbumName.Text;
            albumInfo[1] = textBoxAlbumDescription.Text;
            if(FLPAlbumData.Controls.Count == 0)
            {
                ScanForImages scan = new ScanForImages(new List<string>(),albumInfo);
                Panel p = this.Parent as Panel;
                if (p != null && scan != null)
                {
                    p.Controls.Add(scan);
                    scan.Dock = DockStyle.Fill;
                    this.Dispose();
                    scan.Show();
                }
            }
            if (FLPAlbumData.Controls.Count > 0)
            {
                DialogResult dr = MessageBox.Show("You have images selected, if to keep them click YES?" +
                    "\nClick No to not (this will wipe the already selected)." +
                    "\nCancel ignore and do nothing.", 
                    "Alert", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                ScanForImages scan = null;
                if (dr == DialogResult.Yes)
                {
                    List<string>temp = new List<string>();
                    foreach(var img in images)
                    {
                        temp.Add(img.Value);
                    }
                    scan = new ScanForImages(temp, albumInfo);
                }
                else if (dr == DialogResult.No)
                {
                    scan = new ScanForImages(new List<string>(), albumInfo);
                }
                else if (dr == DialogResult.Cancel)
                    return;
                Panel p = this.Parent as Panel;
                if (p != null  && scan != null)
                {
                    p.Controls.Add(scan);
                    scan.Dock = DockStyle.Fill;
                    this.Dispose();
                    scan.Show();
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
            }
        }

        // This function is toolstrip event click to go back to 'My Albums'.
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
        // This function is a toolstrip event click, opens file dialog to select images.
        // It also check and prevent user to select same image (from same path) more than once.
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

        // This function handles deleting image from the UI and the list of pictures the user selected.
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
        // This function is part of the album creating methods, it takes the images selected by the user and creating ImageItem out of them.
        // Basically it gets image path (D:\image.png) and make it object of ImageItem to make it easier to make it in database.

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
        // This function is also part of album creating methods, this one handles the copying the selected files by the user to a different folder (app folder).
        // This is so the user is keeping the original images so the application will not harm the original images in case of a mistake editing or regret.
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

        // This function is submit button event click that trigger the creating of an album.
        // The function checks if there are images selected, if the title, description and template is not left untouched.
        // It connects to the database, creating the row(s) needed (Albums table and Images).
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
        // This function returns the user back to My Album (one 'page' before).
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
