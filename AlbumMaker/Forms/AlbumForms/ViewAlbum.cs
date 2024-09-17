using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Items;
using System.Diagnostics;


namespace AlbumMaker.Forms.AlbumForms
{
    public partial class ViewAlbum : UserControl
    {
        private int albumID;
        private AlbumItem albumItem;
        private int index;
        private int albumSize;
        private int page;
        private Dictionary<int, Image> imageCache = new Dictionary<int, Image>();

        public ViewAlbum(AlbumItem albumItem)
        {
            InitializeComponent();
            this.albumItem = albumItem;
            index = 0;
            page = 1;
            
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

        private void ViewAlbum_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            if (albumItem == null)
                return;

            albumSize = albumItem.GetImages().Count;
            LoadImages(index);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {albumItem}";
        }
        private void OpenImage(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            Process.Start(new ProcessStartInfo
            {
                FileName = p.ImageLocation,
                UseShellExecute = true
            });
        }

        public void LoadImages(int index)
        {
            // Set album details
            labelTitle.Text = albumItem.GetName();
            labelDesc.Text = albumItem.GetDescription();

            if (index < 0 || index >= albumItem.GetImages().Count)
                return;

            // Ensure the TableLayoutPanel has fixed row/column count and doesn't auto-expand
            tableLayoutPanelImages.RowCount = 3; // Fixed row count
            tableLayoutPanelImages.ColumnCount = 3; // Fixed column count
            tableLayoutPanelImages.AutoSize = false; // Disable auto-size to prevent adding extra rows/columns

            // Clear previous controls from the TableLayoutPanel
            tableLayoutPanelImages.Controls.Clear();

            // Loop through the images and place them in the TableLayoutPanel based on the template
            for (int j = index, i = 0; j < albumItem.GetImages().Count && i < 5; j++, i++)
            {
                // Create the PictureBox for each image
                PictureBox p = new PictureBox()
                {
                    Dock = DockStyle.Fill,
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    ImageLocation = albumItem.GetImages()[j].GetImagePath(),
                    
                };
                p.Click += OpenImage;
                p.MouseEnter += (sender, e) => p.Cursor = Cursors.Hand;
                p.MouseLeave += (sender, e) => p.Cursor = Cursors.Default;
                // Create a label for the image description
                Label l = new Label()
                {
                    AutoSize = true,
                    Text = albumItem.GetImages()[j].GetDescription(),
                    Location = new Point(0, 0)
                };

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
                tableLayoutPanelImages.Controls.Add(p, col, row);
            }

            // Fill any remaining empty cells in the TableLayoutPanel
            FillRemainingCells();
        }

        // Function to fill empty cells with placeholder PictureBoxes
        private void FillRemainingCells()
        {
            int picturesCount = 0;
            string[] pictures = { "path/to/placeholder1.png", "path/to/placeholder2.png", "path/to/placeholder3.png", "path/to/placeholder4.png" }; // Placeholder images

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
                            ImageLocation = pictures[picturesCount % pictures.Length] // Use a placeholder image
                        };
                        picturesCount++;

                        // Add the PictureBox to the TableLayoutPanel
                        tableLayoutPanelImages.Controls.Add(pictureBox, col, row);
                    }
                }
            }
        }
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
