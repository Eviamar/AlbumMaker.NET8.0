using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Items;
using System.Diagnostics;


namespace AlbumMaker.Forms.AlbumForms
{
    // This User Control is made for displaying the album in a nice view.
    public partial class ViewAlbum : UserControl
    {
        private int albumID;
        private AlbumItem albumItem;
        private int index;
        private int albumSize;
        private int page;
        private Dictionary<int, Image> imageCache = new Dictionary<int, Image>();
        private Dictionary<int, MemoryStream> imageCacheStreams = new Dictionary<int, MemoryStream>();


        public ViewAlbum(AlbumItem albumItem)
        {
            InitializeComponent();
            this.albumItem = albumItem;
            index = 0;
            page = 1;

            //this remove the flickering UI visual while loading the content into the tableLayoutPanelImages
            this.DoubleBuffered = true;
            typeof(Control).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null, tableLayoutPanelImages, new object[] { true });
        }

        // Function to navigate back to My Album 'page'.
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
        
        private void ViewAlbum_Load(object sender, EventArgs e)
        {
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            SettingsManager.SetTheme(this);
            if (albumItem == null)
                return;

            albumSize = albumItem.GetImages().Count;
            LoadImages(index);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {albumItem}";
        }

        // Function that allows the user to click on the image and open it with the default windows picture viewer for a bigger screen view.
        // Used this option to save from our app another window for opening the image in a new form as a background on maximized window
        private void OpenImage(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            Process.Start(new ProcessStartInfo
            {
                FileName = p.ImageLocation,
                UseShellExecute = true
            });
        }
        // This function loads the images from the album to the memory for faster loading to the UI.
        private void PreloadImagesToMemory()
        {
            for (int i = 0; i < albumItem.GetImages().Count; i++)
            {
                try
                {
                    string imagePath = albumItem.GetImages()[i].GetImagePath();
                    using (Image img = Image.FromFile(imagePath))
                    {
                        imageCache[i] = new Bitmap(img); // Store a copy of the image in memory
                    }
                }
                catch { throw; }
            }
        }
        // This function add the stroke visual to the text (the border to the letters) so it will be clearer to watch the text if the image is too bright.
        private void DigiLabelPaint(object sender, PaintEventArgs e)
        {
            Label lbl = sender as Label;

            if (lbl != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                string text = lbl.Text;
                Font font = lbl.Font;

                // Define colors for stroke and fill
                Color strokeColor = Color.Black; // Border color
                Color textColor = lbl.ForeColor; // Text color

                // Stroke width
                float strokeWidth = 2f;

                // Create brushes
                using (Brush textBrush = new SolidBrush(textColor))
                using (Pen strokePen = new Pen(strokeColor, strokeWidth))
                {
                    strokePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round; // Prevent sharp edges

                    // Measure text size
                    SizeF textSize = e.Graphics.MeasureString(text, font);

                    // Get text position
                    PointF textPosition = new PointF(
                        (lbl.Width - textSize.Width) / 2, // Center horizontally
                        (lbl.Height - textSize.Height) / 2 // Center vertically
                    );

                    // Draw stroke (outline) by drawing text multiple times around the position
                    for (float x = -strokeWidth; x <= strokeWidth; x += 1f)
                    {
                        for (float y = -strokeWidth; y <= strokeWidth; y += 1f)
                        {
                            e.Graphics.DrawString(text, font, strokePen.Brush, textPosition.X + x, textPosition.Y + y);
                        }
                    }

                    // Draw the actual text on top of the stroke
                    e.Graphics.DrawString(text, font, textBrush, textPosition);
                }
            }
        }
        // This function loads the images to the UI
        public async void LoadImages(int index)
        {
            // Set album details
            labelTitle.Text = albumItem.GetName();
            labelDesc.Text = albumItem.GetDescription();

            if (index < 0 || index >= albumItem.GetImages().Count)
                return;
            PreloadImagesToMemory();
            // Ensure the TableLayoutPanel has fixed row/column count and doesn't auto-expand
            tableLayoutPanelImages.RowCount = 3; // Fixed row count
            tableLayoutPanelImages.ColumnCount = 3; // Fixed column count
            tableLayoutPanelImages.AutoSize = false; // Disable auto-size to prevent adding extra rows/columns

            // Clear previous controls from the TableLayoutPanel
            tableLayoutPanelImages.Controls.Clear();

            // Loop through the images and place them in the TableLayoutPanel based on the template
            for (int j = index, i = 0; j < albumItem.GetImages().Count && i < 5; j++, i++)
            {
                
                PictureBox p = new PictureBox()
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    //Image = imageCache.ContainsKey(j) ? imageCache[j] : null, // Use preloaded image from cache
                    ImageLocation = albumItem.GetImages()[j].GetImagePath(),
                    
                };
                await Task.Run(() =>
                {
                    // Do the loading in a background task
                    if (imageCache.ContainsKey(j))
                    {
                        p.Image = imageCache[j];
                    }
                    else
                    {
                        Image img = Image.FromFile(albumItem.GetImages()[j].GetImagePath());
                        imageCache[j] = img; // Store in cache
                        p.Image = img;
                    }
                });
               
                // Create the PictureBox for each image
                p.Click += OpenImage;
                p.MouseEnter += (sender, e) => p.Cursor = Cursors.Hand;
                p.MouseLeave += (sender, e) => p.Cursor = Cursors.Default;
                // Create a label for the image description
                Label l = new Label()
                {
                    AutoSize = true,
                    Text = albumItem.GetImages()[j].GetDescription(),
                    Location = new Point(0, 0),
                    BackColor = Color.Transparent
                    
                };
                l.Paint += DigiLabelPaint;
                // Add the label on top of the PictureBox
                p.Controls.Add(l);

                // Initialize row and column
                int row = -1, col = -1;

                // Determine row/column based on template and image index
                switch (albumItem.GetTemplate())
                {
                    case "Birthday":
                        if (i == 0) { row = 1; col = 1; } // Middle
                        else if (i == 1) { row = 0; col = 0; } // Top left
                        else if (i == 2) { row = 0; col = 2; } // Top right
                        else if (i == 3) { row = 2; col = 0; } // Bottom left
                        else { row = 2; col = 2; } // Bottom right
                        break;
                    case "Vacation":
                        if (i == 0) { row = 0; col = 0; } // Top Left
                        else if (i == 1) { row = 0; col = 1; } // Top Middle
                        else if (i == 2) { row = 1; col = 2; } // Middle right
                        else if (i == 3) { row = 2; col = 0; } // Bottom left
                        else { row = 2; col = 1; } // Bottom Middle
                        break;
                    case "Wedding":
                        if (i == 0) { row = 0; col = 1; } // Top Middle
                        else if (i == 1) { row = 1; col = 0; } // Middle Left
                        else if (i == 2) { row = 1; col = 1; } // Middle Middle 
                        else if (i == 3) { row = 1; col = 2; } // Middle Right
                        else { row = 2; col = 1; } // Bottom Middle
                        break;
                    default:
                        return; // Exit the function if the template doesn't match
                }

                if (row == -1 || col == -1)
                {
                    // Exit if the position is invalid
                    this.Dispose();
                    return;
                }

                // Add PictureBox to the TableLayoutPanel
                Invoke((Action)(() => tableLayoutPanelImages.Controls.Add(p, col, row))); // Update UI safely
            }

            // Fill any remaining empty cells in the TableLayoutPanel
            FillRemainingCells();
        }

        // Function to fill empty cells with placeholder PictureBoxes
        private void FillRemainingCells()
        {
            string[] pictures = null; // Placeholder images
            int picturesCount = 0;
            string folderPath = string.Empty;
            switch (albumItem.GetTemplate())
            {
                case "Wedding":
                    folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockImgs", "Wedding");
                    break;
                case "Birthday":
                    folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockImgs", "Birthday");
                    break;
                case "Vacation":
                    folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StockImgs", "Vacation");
                    break;
            }
            if (!String.IsNullOrEmpty(folderPath))
            {
                if(Directory.Exists(folderPath)) 
                    pictures = Directory.GetFiles(folderPath);
            }
            if(pictures != null) 
            for (int row = 0; row < tableLayoutPanelImages.RowCount; row++)
            {
                for (int col = 0; col < tableLayoutPanelImages.ColumnCount; col++)
                {
                    // If there's no control in the current cell, add a placeholder image
                    if (tableLayoutPanelImages.GetControlFromPosition(col, row) == null)
                    {
                        PictureBox pictureBox = new PictureBox()
                        {
                            Dock = DockStyle.Fill,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            ImageLocation = pictures[picturesCount % pictures.Length], // Use a placeholder image
                        };
                        picturesCount++;

                        // Add the PictureBox to the TableLayoutPanel
                        tableLayoutPanelImages.Controls.Add(pictureBox, col, row);
                    }
                }
            }
        }
        // "Navigate" to previous 'page' in the album view 
        private void btnLeft_Click(object sender, EventArgs e)
        {
            // Check if we can move back by 5 images
            if (index >= 5)
            {
                // Clear the panel and load the previous 5 images
                tableLayoutPanelImages.Controls.Clear();
                index -= 5;
                LoadImages(index);
                labelPage.Text = (--page).ToString();
            }

            // Disable the left button if we're at the first set of images
            btnLeft.Enabled = index > 0;

            // Ensure the right button is enabled since we moved left and there are more images
            btnRight.Enabled = index + 5 < albumSize;
        }
        // "Navigate" to previous 'page' in the album view.
        private void btnRight_Click(object sender, EventArgs e)
        {
            // Check if there are more images to show
            if (index + 5 < albumSize)
            {
                // Clear the panel and load the next 5 images
                tableLayoutPanelImages.Controls.Clear();
                index += 5;
                LoadImages(index);
                labelPage.Text = (++page).ToString();
            }

            // Disable the right button if we're at the last set of images
            btnRight.Enabled = index + 5 < albumSize;

            // Ensure the left button is enabled since we moved right
            btnLeft.Enabled = index > 0;
        }


        
    }
}
