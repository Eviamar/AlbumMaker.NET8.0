using AlbumMaker.Classes.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker.Classes.Custom
{
    internal class DigiBumPictureBox : PictureBox
    {
        public Button DeleteButton { get; private set; }
        public Button EditButton { get; private set; }
        public Label Title { get; private set; }
        public Label Description { get; private set; }
        private ToolTip imageToolTip = new ToolTip();
        //public void SetDeleteButtonVisiblity(bool visible)=> DeleteButton.Visible = visible;
        //public void SetEditButtonVisibility(bool visible)=> EditButton.Visible = visible;
        //public void SetTitleVisiblity(bool visible) => Title.Visible = visible;
        //public void SetDescriptionVisiblity(bool visible) => Description.Visible = visible;    

        public DigiBumPictureBox(string imagePath)
        {
            DeleteButton = new Button
            {
                Text = "X",
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Width = 30,
                BackColor = Color.Transparent,
                ForeColor = Color.Red,
            };
            DeleteButton.FlatAppearance.BorderSize = 0;
            Size = new Size(200, 200);

            Image = GenerateSmallerImage(imagePath, this.Width, this.Height);
            ImageLocation = imagePath;
            SizeMode = PictureBoxSizeMode.StretchImage;
            this.Click += (sender, e) => OpenImage(sender, e);
            this.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, this.ImageLocation);
            this.MouseLeave += (sender, e) => Cursor = Cursors.Default;
            DeleteButton.Location = new Point(Width - DeleteButton.Width, 0);
            DeleteButton.MouseEnter += (sender, e) => MouseEnterFunction(sender,e,"Delete");
            DeleteButton.MouseLeave += (sender, e) => Cursor = Cursors.Default;
            DeleteButton.Click += (sender, e) => { DeleteImage(sender,e); };

            Controls.Add(DeleteButton);
        }
        private void MouseEnterFunction(object sender, EventArgs e,string msg)
        {
            
            Cursor = Cursors.Hand;
            imageToolTip.SetToolTip(sender as Control, msg);
        }
        private void OpenImage(object sender,EventArgs e)
        {
            DigiBumPictureBox digi = (DigiBumPictureBox)sender;
            Process.Start(new ProcessStartInfo
            {
                FileName = digi.ImageLocation,
                UseShellExecute = true
            });
        }
        private int DeleteImage(object sender, EventArgs e)
        {
            int tabIndex = this.TabIndex;
            this.Dispose();
            return tabIndex;
        }
        public DigiBumPictureBox(AlbumItem album)
        {
            // Initialize buttons and labels
            DeleteButton = new Button
            {
                Text = "X",
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Width = 30,
                BackColor = Color.Transparent,
                ForeColor = Color.Red,
            };
            DeleteButton.FlatAppearance.BorderSize = 0;

            EditButton = new Button
            {
                Text = "🖉",
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Width = 30,
                BackColor = Color.Transparent,
                ForeColor = Color.Green,
            };
            EditButton.FlatAppearance.BorderSize = 0;

            Title = new Label
            {
                Text = album.GetName(),
                Font = new Font(Font.FontFamily, 20, FontStyle.Bold),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Description = new Label
            {
                Text = album.GetDescription(),
                Font = new Font(Font.FontFamily, 14, FontStyle.Italic),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            // Setup image
            Size = new Size(200, 200);
            if (album.GetImages().Count == 0)
            {
                Image = null;  // Placeholder for "image not found"
                BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                Image = GenerateSmallerImage(album.GetImages()[0].GetName(), 200, 200);
                ImageLocation = album.GetImages()[0].GetName();
            }

            SizeMode = PictureBoxSizeMode.StretchImage;

            // Add controls to the PictureBox
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(Title);
            Controls.Add(Description);

            // Position controls
            DeleteButton.Location = new Point(Width - DeleteButton.Width, 0);
            EditButton.Location = new Point(Width - EditButton.Width, Height - EditButton.Height);
            Title.Location = new Point(0, 0);
            Description.Location = new Point(0, Height - Description.Height);

            // Assign event handlers (you can add more as needed)
            DeleteButton.Click += (sender, e) => { /* Handle delete click */ };
            EditButton.Click += (sender, e) => { /* Handle edit click */ };
            Click += (sender, e) => { OpenImage(sender,e); };
        }
        private static Image GenerateSmallerImage(string path, int width, int height)
        {
            Bitmap b = null;
            try
            {
                using (Image img = Image.FromFile(path))
                {
                    b = new Bitmap(img, width, height);
                    img.Dispose();
                    return b;
                }

            }
            catch (Exception ex) { return null; }

        }
    }
}
