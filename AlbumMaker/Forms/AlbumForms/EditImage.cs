using AlbumMaker.Classes;
using AlbumMaker.Classes.Items;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using AlbumMaker.Classes.Db;
namespace AlbumMaker.Forms.AlbumForms
{
    public partial class EditImage : UserControl
    {
        private ImageItem image;
        private List<string> shapes;
        private List<KeyValuePair<string, int>> sizes;
        private static Random rnd = new Random();
        private Point selectedPoint;
        private Color c1;
        private Color c2;
        private Image originalImage;
        private int shapeSize;
        private bool flipUpDown = false;
        private bool flipSide = false;
        private const int MaxUndoSteps = 5;
        private Stack<Image> undoStack = new Stack<Image>();
        private Stack<Image> redoStack = new Stack<Image>();
        private Image brightnessImage;
        private bool brightnessScroll = false;
        private KeyValuePair<string,int> selectedShape = default;
        public EditImage(ImageItem image)
        {
            InitializeComponent();

            this.image = image;
            using (FileStream fs = new FileStream(image.GetImagePath(), FileMode.Open, FileAccess.Read))
            {
                byte[] imageData = new byte[fs.Length];
                fs.Read(imageData, 0, (int)fs.Length);

                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    originalImage = new Bitmap(ms);
                    pictureBoxPic.Image = originalImage;
                }
            }
            lblImgeDesc.Text = image.GetDescription();
            shapes = new List<string>
            {
                "Circle",
                "Ellipse",
                "Diamond",
                "Square",
                "Rectangle",
            };
            sizes = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string,int>("Small",300),
                new KeyValuePair<string,int>("Medium",500),
                new KeyValuePair<string,int>("Large",1000),
                new KeyValuePair<string,int>("Very Large",1500),
            };
            this.AutoScroll = true;

            trackBarBrightness.Value = (trackBarBrightness.Minimum + trackBarBrightness.Maximum) / 2;


        }
        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                EditAlbum editAlbum = new EditAlbum(SettingsManager.userItem.GetAlbumItems().Find(x => x.GetID() == image.GetRelatedAlbumID()));
                Panel p = this.Parent as Panel;
                if (p != null)
                {
                    SettingsManager.SetTheme(editAlbum);
                    p.Controls.Add(editAlbum);
                    editAlbum.Dock = DockStyle.Fill;
                    this.Dispose();
                    editAlbum.Show();
                }
            }
            catch { throw; }

        }
        private void EditImage_Load(object sender, EventArgs e)
        {
            panelPic.AutoScroll = true;

            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";







            //using (FileStream fileStream = new FileStream(image.GetImagePath(), FileMode.Open, FileAccess.Read))
            //{
            //    using (MemoryStream memoryStream = new MemoryStream())
            //    {
            //        // Copy the file's content to the memory stream
            //        fileStream.CopyTo(memoryStream);
            //        // Reset the position of the stream to the beginning
            //        memoryStream.Seek(0, SeekOrigin.Begin);

            //        // Load the image from the MemoryStream
            //        pictureBoxPic.Image = Image.FromStream(memoryStream);
            //    } // MemoryStream is disposed of here
            //} // FileStream is disposed of here

            pictureBoxPic.SizeMode = PictureBoxSizeMode.AutoSize;
            if (pictureBoxPic.Image.Width > panelPic.Width || pictureBoxPic.Image.Height > panelPic.Height)
            {
                panelPic.AutoScroll = true;
            }

            tlpOptions.AutoScroll = true;
            //tlpOptions.AutoSize = true;
            comboBoxShapeSize.DataSource = sizes;
            comboBoxShape.DataSource = shapes;
            pictureBoxPic.MouseClick += SetPoint;
            pictureBoxPic.MouseEnter += (sender, args) => Cursor = Cursors.Hand;
            pictureBoxPic.MouseLeave += (sender, args) => Cursor = Cursors.Default;
        }
        private void btnApplyShape_Click(object sender, EventArgs e)
        {
            if (!selectedPoint.IsEmpty)
            {
                //if(selectedShape.Key == null && selectedShape.Value == 0)
                    selectedShape = new KeyValuePair<string, int>(comboBoxShape.Text, ((KeyValuePair<string, int>)comboBoxShapeSize.SelectedItem).Value);
                //MessageBox.Show(selectedShape.ToString());

                if (!String.IsNullOrWhiteSpace(txtBoxCustomSize.Text))
                {
                    //just here to check if user typed any custom size...
                }
                else
                {
                    KeyValuePair<string, int> selectedSize = (KeyValuePair<string, int>)comboBoxShapeSize.SelectedItem;
                    this.shapeSize = selectedSize.Value;
                }
                switch (comboBoxShape.SelectedItem)
                {
                    case "Circle":
                        ShapeCircle();
                        break;
                    case "Ellipse":
                        ShapeEllipse();
                        break;
                    case "Diamond":
                        ShapeDiamod();
                        break;
                    case "Square":
                        ShapeSquare();
                        break;
                    case "Rectangle":
                        ShapeRectangle();
                        break;
                    default:
                        break;
                }
            }

        }
        private void txtBoxCustomSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bool tryParse = int.TryParse(txtBoxCustomSize.Text, out int size);
                if (tryParse)
                {
                    shapeSize = size;
                }
                else
                {
                    MessageBox.Show("Only digits are allowed", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBoxCustomSize.Clear();
                    txtBoxCustomSize.Focus();
                }
            }
            catch { throw; }
        }
        private void lblColor1_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                c1 = c.Color;
                lblColor1.BackColor = c1;
                lblColor1.Text = c1.Name;

            }
        }
        private void lblColor2_Click(object sender, EventArgs e)
        {
            ColorDialog c = new ColorDialog();
            if (c.ShowDialog() == DialogResult.OK)
            {
                c2 = c.Color;
                lblColor2.BackColor = c2;
                lblColor2.Text = c2.Name;
            }
        }
        private void linkLabelRandomColors_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                c1 = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                c2 = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                lblColor1.BackColor = c1;
                lblColor2.BackColor = c2;
                lblColor1.Text = c1.Name;
                lblColor2.Text = c2.Name;
                //if (shapedImage == null)
                //    Filter((Bitmap)originImage, c1, c2);
                //else
                //    Filter((Bitmap)shapedImage, c1, c2);

            }
            catch { throw; }
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (c1.IsEmpty || c2.IsEmpty)
                {
                    MessageBox.Show("Choose colors", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                
                UndoFunc();

                // Create a filtered bitmap
                Bitmap filteredBitmap = new Bitmap(originalImage);

                // Apply filter using ColorMatrix
                using (Graphics g = Graphics.FromImage(filteredBitmap))
                {
                    ColorMatrix colorMatrix = new ColorMatrix(
                        new float[][]
                        {
                    new float[] {1, 0, 0, 0, 0}, // Red
                    new float[] {0, 1, 0, 0, 0}, // Green
                    new float[] {0, 0, 1, 0, 0}, // Blue
                    new float[] {0, 0, 0, 1, 0}, // Alpha
                    new float[] {  // Constant factor for the adjustment
                        c1.R / 255f - c2.R / 255f,
                        c1.G / 255f - c2.G / 255f,
                        c1.B / 255f - c2.B / 255f,
                        0, 1
                    }
                        });

                    using (ImageAttributes attributes = new ImageAttributes())
                    {
                        attributes.SetColorMatrix(colorMatrix);
                        g.DrawImage(originalImage,
                            new System.Drawing.Rectangle(0, 0, originalImage.Width, originalImage.Height),
                            0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
                    }
                }

                // Set the PictureBox's Image to the filtered image
                pictureBoxPic.Image = filteredBitmap;

                // Enable Undo and clear Redo stack

                //redoStack.Clear(); // Optionally, you can avoid clearing the redo stack if you don't want to lose redo history
                if (selectedShape.Key != null && selectedShape.Value != 0)
                {
                    
                    btnApplyShape_Click(sender, e);
                }

            }
            catch (Exception) { }
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undoStack.Count > 0)
            {
                // Save the current image state in the redo stack
                if (pictureBoxPic.Image != null)
                {
                    redoStack.Push(new Bitmap(pictureBoxPic.Image));
                }
                Image imageToDispose = pictureBoxPic.Image;

                // Restore the last image from the undo stack
                pictureBoxPic.Image = undoStack.Pop();
                imageToDispose?.Dispose();
                btnRedo.Enabled = true;  // Enable redo button

            }

            // Disable the undo button if no more steps are left
            if (undoStack.Count == 0)
            {
                btnUndo.Enabled = false;
            }
        }
        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                // Save the current image state in the undo stack
                if (pictureBoxPic.Image != null)
                {
                    undoStack.Push(new Bitmap(pictureBoxPic.Image));
                }
                Image imageToDispose = pictureBoxPic.Image;
                // Restore the last image from the redo stack
                pictureBoxPic.Image = redoStack.Pop();
                imageToDispose?.Dispose();
                btnUndo.Enabled = true;  // Enable undo button

            }

            // Disable the redo button if no more steps are left
            if (redoStack.Count == 0)
            {
                btnRedo.Enabled = false;
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBoxPic.Image = null;
            foreach (var img in undoStack)
                img.Dispose();
            foreach (var img in redoStack)
                img.Dispose();

            undoStack.Clear();
            redoStack.Clear();
            c1 = new Color();
            c2 = new Color();
            lblColor1.Text = "Color1";
            lblColor2.Text = "Color2";
            selectedPoint = new Point();
            grpBoxShapes.Text = "Shape";
            lblColor1.BackColor = c1;
            lblColor2.BackColor = c2;
            btnUndo.Enabled = false;
            btnRedo.Enabled = false;
            flipUpDown = false;
            flipSide = false;
            btnFlipLeftRight.Text = "Left";
            btnFlipUpDown.Text = "Up";
            GC.Collect();
            GC.WaitForPendingFinalizers();
            pictureBoxPic.Image = originalImage;

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            UndoFunc();
            if (!brightnessScroll)
            {
                brightnessImage = new Bitmap(pictureBoxPic.Image); // Clone the image to avoid modifying the original
                brightnessScroll = true;
            }


            if (trackBarBrightness.Value == trackBarBrightness.Maximum / 2)
            {
                // Reset to the original brightness when trackbar is in the middle position
                pictureBoxPic.Image?.Dispose(); // Dispose of the current image before replacing it
                pictureBoxPic.Image = new Bitmap(brightnessImage);  // Restore from the original unmodified image

                grpBoxBrightness.Text = $"Brightness -  ({trackBarBrightness.Value})";
                brightnessScroll = false; // Reset the scroll flag
                return;
            }

            // Calculate the brightness value based on the trackbar position
            float brightnessValue = CalculateBrightness(trackBarBrightness.Value);

            // Adjust the brightness of the image
            AdjustBrightness(brightnessValue);
            grpBoxBrightness.Text = $"Brightness -  ({trackBarBrightness.Value})";

        }

        private void btnFlipUpDown_Click(object sender, EventArgs e)
        {
            try
            {
                UndoFunc();

                flipUpDown = !flipUpDown;
                Bitmap flippedImage = new Bitmap(pictureBoxPic.Image);
                // processedBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                flippedImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
                pictureBoxPic.Image = flippedImage;

                if (flipUpDown == true)
                    btnFlipUpDown.Text = "Down";
                else
                    btnFlipUpDown.Text = "Up";
            }
            catch { throw; }
        }

        private void btnFlipLeftRight_Click(object sender, EventArgs e)
        {
            try
            {
                UndoFunc();
                flipSide = !flipSide;
                Bitmap flippedImage = new Bitmap(pictureBoxPic.Image);
                flippedImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                pictureBoxPic.Image = flippedImage;
                if (flipSide == true)
                    btnFlipLeftRight.Text = "Right";
                else
                    btnFlipLeftRight.Text = "Left";

            }
            catch { throw; }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(lblImgeDesc.Text))
                {
                    DialogResult dr = MessageBox.Show("Seems like you forgot to add description to this image\nWould you like to?", "No description", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                        textBoxDesc.Focus();
                    else
                        SaveImage();
                }
                else
                    SaveImage();

            }
            catch { throw; }
        }
        private async void btnApplyDesc_Click(object sender, EventArgs e)
        {

            //TODO: connect to database and update image there
            if (!String.IsNullOrWhiteSpace(textBoxDesc.Text))
            {

                image.SetDescription(textBoxDesc.Text);
                bool res = await AppDataBase.UpdateImage(image);
                if (!res)
                    MessageBox.Show("Failed to update image description", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    lblImgeDesc.Text = textBoxDesc.Text;
            }
        }

        #region Functions
        private void UndoFunc()
        {
            if (undoStack.Count >= MaxUndoSteps)
            {
                // Remove and dispose of the oldest entry when max limit is reached
                var tempUndoStack = new Stack<Image>(undoStack.Reverse());
                Image oldestImage = tempUndoStack.Pop();  // Remove oldest image
                oldestImage?.Dispose();  // Dispose of the oldest image to free memory

                // Rebuild the undoStack with the remaining images
                undoStack = new Stack<Image>(tempUndoStack.Reverse());
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            // Save current state before applying changes
            undoStack.Push(new Bitmap(pictureBoxPic.Image));
            btnUndo.Enabled = true;
        }
        private void SetPoint(object sender, MouseEventArgs e)
        {
            selectedPoint = new Point(e.X, e.Y);
            grpBoxShapes.Text = $"Shape - (X:{e.X},Y:{e.Y})";
        }
        private void ShapeCircle()
        {
            try
            {

                if (selectedPoint.IsEmpty)
                {
                    MessageBox.Show("No focus point\nClick anywhere on the image where you want the shape to take place", "Pick position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (shapeSize == 0)
                {
                    MessageBox.Show("Choose shape size or type your desired size manually in the textbox where sizes are.", "Pick size", MessageBoxButtons.OK, MessageBoxIcon.Information); return;
                }
                UndoFunc();
                GraphicsPath path = new GraphicsPath();
                Bitmap modifiedBitmap = new Bitmap(pictureBoxPic.Image);
                using (Graphics g = Graphics.FromImage(modifiedBitmap))
                {
                    // Draw the original image onto the bitmap
                    g.DrawImage(pictureBoxPic.Image, new Point(0, 0));

                    // Add the circular region to the GraphicsPath
                    path.AddEllipse(selectedPoint.X - shapeSize / 2, selectedPoint.Y - shapeSize / 2, shapeSize, shapeSize);

                    // Set the clip region of the Graphics object to the circular region
                    g.SetClip(path, CombineMode.Exclude);

                    // Clear the region outside the circular area
                    g.Clear(Color.Transparent);
                }
                pictureBoxPic.Image = modifiedBitmap;
                pictureBoxPic.Invalidate();
                btnUndo.Enabled = true;
            }
            catch { throw; }
        }
        private void ShapeEllipse()
        {
            try
            {
                if (selectedPoint.IsEmpty)
                {
                    MessageBox.Show("No focus point\nClick anywhere on the image where you want the shape to take place", "Pick position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (shapeSize == 0)
                {
                    MessageBox.Show("Choose shape size or type your desired size manually in the textbox where sizes are.", "Pick size", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                UndoFunc();
                GraphicsPath path = new GraphicsPath();
                Bitmap modifiedBitmap = new Bitmap(pictureBoxPic.Image);
                using (Graphics g = Graphics.FromImage(modifiedBitmap))
                {
                    // Draw the original image onto the bitmap
                    g.DrawImage(pictureBoxPic.Image, new Point(0, 0));

                    // Add the circular region to the GraphicsPath
                    path.AddEllipse(selectedPoint.X - shapeSize / 2, selectedPoint.Y - shapeSize / 2, shapeSize, shapeSize * 1.5f); // Adjust the second parameter for the height

                    // Set the clip region of the Graphics object to the circular region
                    g.SetClip(path, CombineMode.Exclude);

                    // Clear the region outside the circular area
                    g.Clear(Color.Transparent);
                }
                pictureBoxPic.Image = modifiedBitmap;
                pictureBoxPic.Invalidate();
                btnUndo.Enabled = true;
            }
            catch { throw; }
        }
        private void ShapeDiamod()
        {
            try
            {
                if (selectedPoint.IsEmpty)
                {
                    MessageBox.Show("No focus point\nClick anywhere on the image where you want the shape to take place", "Pick position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (shapeSize == 0)
                {
                    MessageBox.Show("Choose shape size or type your desired size manually in the textbox where sizes are.", "Pick size", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                UndoFunc();
                GraphicsPath path = new GraphicsPath();
                Bitmap modifiedBitmap = new Bitmap(pictureBoxPic.Image);
                using (Graphics g = Graphics.FromImage(modifiedBitmap))
                {
                    // Draw the original image onto the bitmap
                    g.DrawImage(pictureBoxPic.Image, new Point(0, 0));

                    // Add the diamond region to the GraphicsPath
                    PointF[] diamondPoints = new PointF[]
                    {
            new PointF(selectedPoint.X, selectedPoint.Y - shapeSize / 2),
            new PointF(selectedPoint.X + shapeSize / 2, selectedPoint.Y),
            new PointF(selectedPoint.X, selectedPoint.Y + shapeSize / 2),
            new PointF(selectedPoint.X - shapeSize / 2, selectedPoint.Y)
                    };
                    path.AddPolygon(diamondPoints);

                    // Set the clip region of the Graphics object to the diamond region
                    g.SetClip(path, CombineMode.Exclude);

                    // Clear the region outside the diamond area
                    g.Clear(Color.Transparent);
                }
                pictureBoxPic.Image = modifiedBitmap;
                pictureBoxPic.Invalidate();
                btnUndo.Enabled = true;
            }
            catch { throw; }
        }
        private void ShapeSquare()
        {
            try
            {
                if (selectedPoint.IsEmpty)
                {
                    MessageBox.Show("No focus point\nClick anywhere on the image where you want the shape to take place", "Pick position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (shapeSize == 0)
                {
                    MessageBox.Show("Choose shape size or type your desired size manually in the textbox where sizes are.", "Pick size", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                UndoFunc();
                GraphicsPath path = new GraphicsPath();
                Bitmap modifiedBitmap = new Bitmap(pictureBoxPic.Image);
                using (Graphics g = Graphics.FromImage(modifiedBitmap))
                {
                    // Draw the original image onto the bitmap
                    g.DrawImage(pictureBoxPic.Image, new Point(0, 0));

                    // Add the square region to the GraphicsPath
                    path.AddRectangle(new RectangleF(selectedPoint.X - shapeSize / 2, selectedPoint.Y - shapeSize / 2, shapeSize, shapeSize));

                    // Set the clip region of the Graphics object to the square region
                    g.SetClip(path, CombineMode.Exclude);

                    // Clear the region outside the square area
                    g.Clear(Color.Transparent);
                }
                pictureBoxPic.Image = modifiedBitmap;
                pictureBoxPic.Invalidate();
                btnUndo.Enabled = true;
            }
            catch { throw; }
        }
        private void ShapeRectangle()
        {
            try
            {
                if (selectedPoint.IsEmpty)
                {
                    MessageBox.Show("No focus point\nClick anywhere on the image where you want the shape to take place", "Pick position", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (shapeSize == 0)
                {
                    MessageBox.Show("Choose shape size or type your desired size manually in the textbox where sizes are.", "Pick size", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                UndoFunc();
                GraphicsPath path = new GraphicsPath();
                Bitmap modifiedBitmap = new Bitmap(pictureBoxPic.Image);
                using (Graphics g = Graphics.FromImage(modifiedBitmap))
                {
                    // Draw the original image onto the bitmap
                    g.DrawImage(pictureBoxPic.Image, new Point(0, 0));

                    // Add the rectangular region to the GraphicsPath
                    float rectangleWidth = shapeSize * 2; // You can adjust the width as needed
                    float rectangleHeight = shapeSize * 1.5f; // You can adjust the height as needed

                    path.AddRectangle(new RectangleF(selectedPoint.X - rectangleWidth / 2, selectedPoint.Y - rectangleHeight / 2, rectangleWidth, rectangleHeight));

                    // Set the clip region of the Graphics object to the rectangular region
                    g.SetClip(path, CombineMode.Exclude);

                    // Clear the region outside the rectangular area
                    g.Clear(Color.Transparent);
                }
                pictureBoxPic.Image = modifiedBitmap;
                pictureBoxPic.Invalidate();
                btnUndo.Enabled = true;
            }
            catch { throw; }
        }

        private float CalculateBrightness(int trackbarValue)
        {
            // Convert trackbar value to a brightness multiplier
            float brightness = 1.0f + (trackbarValue - (trackBarBrightness.Maximum / 2)) * 0.1f;
            return brightness;
        }

        private void AdjustBrightness(float brightnessValue)
        {
            try
            {
                if (brightnessImage == null) return;

                // Clone the original unmodified image for editing
                Bitmap originalBitmap = new Bitmap(brightnessImage);

                // Create a new bitmap for the adjusted image
                Bitmap adjustedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                using (Graphics g = Graphics.FromImage(adjustedBitmap))
                {
                    // Set up a brightness adjustment matrix
                    float[][] brightnessMatrix =
                    {
                new float[] { brightnessValue, 0, 0, 0, 0 },
                new float[] { 0, brightnessValue, 0, 0, 0 },
                new float[] { 0, 0, brightnessValue, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            };

                    ColorMatrix colorMatrix = new ColorMatrix(brightnessMatrix);
                    using (ImageAttributes attributes = new ImageAttributes())
                    {
                        attributes.SetColorMatrix(colorMatrix);
                        g.DrawImage(originalBitmap, new Rectangle(0, 0, adjustedBitmap.Width, adjustedBitmap.Height),
                            0, 0, originalBitmap.Width, originalBitmap.Height, GraphicsUnit.Pixel, attributes);
                    }
                }

                // Dispose of the previous image in the PictureBox before setting the new one
                pictureBoxPic.Image?.Dispose();
                pictureBoxPic.Image = adjustedBitmap;

                // Dispose the original bitmap to free resources
                originalBitmap.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void SaveImage()
        {
            try
            {
                Image img = pictureBoxPic.Image;
                img.Save(image.GetImagePath());
                goBackToolStripMenuItem.PerformClick();
            }
            catch { throw; }

        }

        #endregion Functions






        private void trackBarBrightness_MouseLeave(object sender, EventArgs e)
        {
            if(brightnessImage!=null)
                brightnessImage.Dispose();
            brightnessScroll = false;
        }
    }
}
