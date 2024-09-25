using AlbumMaker.Classes;
using AlbumMaker.Classes.Items;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
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

        private const int MaxUndoSteps = 5;
        private Stack<Image> undoStack = new Stack<Image>();
        private Stack<Image> redoStack = new Stack<Image>();
        public EditImage(ImageItem image)
        {
            InitializeComponent();
            this.image = image;
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

        }

        private void SetPoint(object sender, MouseEventArgs e)
        {
            selectedPoint = new Point(e.X, e.Y);
            grpBoxShapes.Text = $"Shape - (X:{e.X},Y:{e.Y})";
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
                string selectedShape = comboBoxShape.Text;
                KeyValuePair<string, int> selectedSize = (KeyValuePair<string, int>)comboBoxShapeSize.SelectedItem;

            }

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
                if (undoStack.Count >= MaxUndoSteps)
                {
                    // Remove the oldest entry when max limit is reached
                    var tempUndoStack = new Stack<Image>(undoStack.Reverse());
                    tempUndoStack.Pop();  // Remove oldest
                    undoStack = new Stack<Image>(tempUndoStack.Reverse());  // Rebuild the stack
                }
                undoStack.Push(new Bitmap(pictureBoxPic.Image)); // Save current state before applying changes

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
                btnUndo.Enabled = true;
                //redoStack.Clear(); // Optionally, you can avoid clearing the redo stack if you don't want to lose redo history
            

            }
            catch (Exception) { }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            {
                if (undoStack.Count > 0)
                {
                    redoStack.Push((Image)pictureBoxPic.Image.Clone()); // Save current state to redo

                    Image lastState = undoStack.Pop();
                    pictureBoxPic.Image = lastState;

                    // Enforce the redo stack size limit
                    if (redoStack.Count > MaxUndoSteps)
                    {
                        redoStack = new Stack<Image>(redoStack.Take(MaxUndoSteps)); // Trim the oldest images
                    }
                }
            }
        }
        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (redoStack.Count > 0)
            {
                undoStack.Push((Image)pictureBoxPic.Image.Clone()); // Save current state to undo

                Image nextState = redoStack.Pop();
                pictureBoxPic.Image = nextState;

                // Enforce the undo stack size limit
                if (undoStack.Count > MaxUndoSteps)
                {
                    undoStack = new Stack<Image>(undoStack.Take(MaxUndoSteps)); // Trim the oldest images
                }
            }
        }
    }
}
