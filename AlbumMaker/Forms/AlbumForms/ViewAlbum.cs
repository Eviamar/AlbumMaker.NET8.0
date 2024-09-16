using AlbumMaker.Classes;
using AlbumMaker.Classes.Items;


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

        public ViewAlbum(int albumID)
        {
            InitializeComponent();
            this.albumID = albumID;
            index = 0;
            page = 1;
            
        }
        private void SetAlbumItem()
        {
            
            this.albumItem = SettingsManager.userItem.GetAlbumItems()[albumID];

        }
        
        //public void LoadImages(int index)
        //{
        //    labelTitle.Text = albumItem.GetName();
        //    labelDesc.Text = albumItem.GetDescription();

        //    if (index < 0 || index >= albumItem.GetImages().Count)
        //        return;
        //    //string[] pictures = Directory.GetFiles($"{picsPath}\\{albumTemplate}");
        //    for (int j = index, i = 0; j < albumItem.GetImages().Count && i < 5; j++, i++)
        //    {

        //        //DigiBumPictureBox digiBumPictureBox = new DigiBumPictureBox(albumItem.GetImages()[i], false);
        //        PictureBox p = new PictureBox()
        //        {
        //            Dock = DockStyle.Fill,
        //            SizeMode = PictureBoxSizeMode.StretchImage,
        //            ImageLocation = albumItem.GetImages()[j].GetImagePath(),

        //        };
        //        Label l = new Label()
        //        {
        //            AutoSize = true,
        //            Text = albumItem.GetImages()[j].GetDescription(),
        //            Location = new Point(0, 0)
        //        };
        //        p.Controls.Add(l);
        //        int row = -1, col = -1;
        //        switch (albumItem.GetTemplate())
        //        {
        //            case "Birthday":
        //                if (i == 0) { row = 1; col = 1; } // Middle
        //                else if (i == 1) { row = 0; col = 0; } // Top left
        //                else if (i == 2) { row = 0; col = 2; } // Top right
        //                else if (i == 3) { row = 2; col = 0; } // Bottom left
        //                else { row = 2; col = 2; } // Bottom right
        //                break;
        //            case "Vacation":
        //                if (i == 0) { row = 0; col = 0; } // Top Left
        //                else if (i == 1) { row = 0; col = 1; } // Top Middle
        //                else if (i == 2) { row = 1; col = 2; } // Middle right
        //                else if (i == 3) { row = 2; col = 0; } // Bottom left
        //                else { row = 2; col = 1; } // Bottom Middle

        //                break;
        //            case "Wedding":
        //                if (i == 0) { row = 0; col = 1; } // Top Middle
        //                else if (i == 1) { row = 1; col = 0; } // Middle Left
        //                else if (i == 2) { row = 1; col = 1; } // Middle Middle 
        //                else if (i == 3) { row = 1; col = 2; } // Middle Right
        //                else { row = 2; col = 1; } // Bottom Middle
        //                break;
        //            default:

        //                break;
        //        }

        //        if (row == -1 || col == -1)
        //        {
        //            this.Dispose();
        //            return;
        //        }

        //        // Add PictureBox to the TableLayoutPanel
        //        tableLayoutPanelImages.Controls.Add(p, col, row);

        //        //add pictures related to the template to empty cells in table layout panel
        //        int picturesCount = 0;
        //        for (int k = 0; k < tableLayoutPanelImages.RowCount; k++)
        //        {

        //            for (int m = 0; m < tableLayoutPanelImages.ColumnCount; m++)
        //            {
        //                if (tableLayoutPanelImages.GetControlFromPosition(k, m) == null)
        //                {
        //                    if (picturesCount >= 4)
        //                        picturesCount = 0;
        //                    PictureBox pictureBox = new PictureBox()
        //                    {
        //                        //Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
        //                        Dock = DockStyle.Fill,
        //                        SizeMode = PictureBoxSizeMode.StretchImage,

        //                    };
        //                    //pictureBox.Image = Image.FromFile(pictures[picturesCount]);
        //                    picturesCount++;
        //                    tableLayoutPanelImages.Controls.Add(pictureBox, k, m);

        //                }
        //            }

        //        }

        //    }
        //}
       

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
            SetAlbumItem();
            if (albumItem == null)
                return;

            albumSize = albumItem.GetImages().Count;
            LoadImages(index);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {albumItem}";
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
                    ImageLocation = albumItem.GetImages()[j].GetImagePath()
                };

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

        //private void btnLeft_Click(object sender, EventArgs e)
        //{
        //    if (index >= 5)
        //    {
        //        tableLayoutPanelImages.Controls.Clear();
        //        LoadImages(index - 5);
        //        index -= 5;
        //        labelPage.Text = (--page).ToString();
        //    }
        //    if (index == 0)
        //        btnLeft.Enabled = false;
        //    else
        //        btnRight.Enabled = true;
        //}

        //private void btnRight_Click(object sender, EventArgs e)
        //{
        //    if (index < albumSize)
        //    {
        //        tableLayoutPanelImages.Controls.Clear();
        //        LoadImages(index + 5);
        //        index += 5;
        //        labelPage.Text = (++page).ToString();
        //    }
        //    if (index == albumSize) // TO DO: need to fix this
        //        btnRight.Enabled = false;
        //    else
        //        btnLeft.Enabled = true;
        //}

        private void labelPage_Click(object sender, EventArgs e)
        {

        }
    }
}
