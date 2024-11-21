using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;
using AlbumMaker.Forms;
using AlbumMaker.Forms.UserForms;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace AlbumMaker.Classes.Custom
{
    // this class is to make a custom picture box fitting our needs
    internal class DigiBumPictureBox : PictureBox
    {
        public Button DeleteButton { get; private set; }
        public Button EditButton { get; private set; }
        public Label Title { get; private set; }
        public Label Description { get; private set; }
        private ToolTip imageToolTip = new ToolTip();
        public event EventHandler<int> ImageDeleted;
        public event EventHandler<int> albumView;
        private static readonly string pictureFolderPath = $@"{Properties.AppSettings.Default.AppDataFolder}\{Properties.AppSettings.Default.AppName}\{Properties.AppSettings.Default.AppAlbumsFolderName}\";

        #region constructor for image view
        // this constructor for image view only with 2 options inside it depending on isEdit)
        public DigiBumPictureBox(ImageItem image,bool isEdit)
        {
            Size = new Size(200, 200);
            TabIndex = image.GetID();
            SizeMode = PictureBoxSizeMode.StretchImage;
          
            DeleteButton = new Button
            {
                Name = "btnDelete",
                Text = "X",
                Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Width = 30,
                BackColor = Color.Red,
                ForeColor = Color.White,
            };
            DeleteButton.FlatAppearance.BorderSize = 0;
            DeleteButton.Location = new Point(Width - DeleteButton.Width, 0);
            DeleteButton.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, "Delete");
            DeleteButton.Click += (sender, e) => { DeleteImage(sender, e, image,isEdit); };
            Controls.Add(DeleteButton);

            this.MouseLeave += (sender, e) => Cursor = Cursors.Default;
            
            if (isEdit)
            {
                EditButton = new Button
                {
                    Name = "btnEdit",
                    Text = "🖉",
                    Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Width = 30,
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                };
                EditButton.FlatAppearance.BorderSize = 0;

                Description = new Label
                {
                    Name = "lblDesc",
                    Text = image.GetDescription(),
                    Font = new Font(Font.FontFamily, 14, FontStyle.Italic),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                Image = GenerateSmallerImage(image.GetImagePath(), 200, 200);
                Description.Paint += DigiLabelPaint;

                //ImageLocation = image.GetImagePath();
                this.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, image.GetDescription());
                EditButton.Location = new Point(Width - EditButton.Width, Height - EditButton.Height);
                //Title.Location = new Point(0, 0);
                Description.Location = new Point(0, Height - Description.Height);
                EditButton.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, "Edit");
                EditButton.Click += (sender, e) => { EditImage(sender, e, image); };
                this.Click += (sender, e) => { OpenImage(sender, e, isEdit); };
                Controls.Add(EditButton);
                Controls.Add(Title);
                Controls.Add(Description);
            }
            else
            {
                this.Click += (sender, e) => { OpenImage(sender, e, isEdit); };
                Image = GenerateSmallerImage(image.GetName(), 200, 200);
                ImageLocation = image.GetName();
                this.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, image.GetName());
            }


        }
        private void MouseEnterFunction(object sender, EventArgs e, string msg)
        {
            Cursor = Cursors.Hand;
            imageToolTip.SetToolTip(sender as Control, msg);
        }
        private void OpenImage(object sender, EventArgs e,bool isEdit)
        {
            DigiBumPictureBox digi = (DigiBumPictureBox)sender;
            if (String.IsNullOrEmpty(digi.ImageLocation))
                return;
            Process.Start(new ProcessStartInfo
            {
                FileName = digi.ImageLocation,
                UseShellExecute = true
            });
        }
        private async void DeleteImage(object sender, EventArgs e, ImageItem image,bool isEdit)
        {
            try
            {
                if (isEdit)
                {
                    DialogResult dr = MessageBox.Show($"Are you sure to delete {image.GetName()}?", "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        bool res = await AppDataBase.DeleteImage(image);
                        if (res)
                        {
                            //delete file
                            File.Delete(image.GetImagePath());
                            if (!File.Exists(image.GetImagePath()))
                            {
                                AlbumItem album = SettingsManager.userItem.GetAlbumItems().Find(x => x.GetID() == image.GetRelatedAlbumID());
                                if (album != null)
                                    album.DeleteImageItem(image);
                                else
                                {
                                    if (SettingsManager.userItem.GetIsAdmin())
                                    {
                                        if (SettingsManager.userItems != null)
                                        {
                                            bool foundMatch = false;
                                            foreach (UserItem u in SettingsManager.userItems)
                                            {
                                                foreach (AlbumItem a in u.GetAlbumItems())
                                                {
                                                    if (a.GetID() == image.GetID())
                                                    {
                                                        album.DeleteImageItem(image);
                                                        MessageBox.Show($"Image removed from {u.GetName}'s {a.GetName()} album", "Success");
                                                        foundMatch = true;
                                                        break;

                                                    }
                                                    if (foundMatch)
                                                        break;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }
                    else
                        return;
                    
                }
                int tabIndex = this.TabIndex;
                // Raise the event with the tabIndex as the event argument
                ImageDeleted?.Invoke(this, tabIndex);
            }
            catch { throw; }
        }

        private void EditImage(object sender,EventArgs e,ImageItem image)
        {
            AlbumMaker.Forms.AlbumForms.EditImage editImage = new Forms.AlbumForms.EditImage(image);
            Panel p = this.Parent.Parent.Parent as Panel;
            if (p != null)
            {
                p.Controls.Clear();
                SettingsManager.SetTheme(editImage);
                p.Controls.Add(editImage);
                editImage.Dock = DockStyle.Fill;
                this.Dispose();
                editImage.Show();
            }
        }
        #endregion constructor for image view
        #region constructor for album view
        //mostly like image view but this one is for album view with options fitting to album this also have 2 options with isEdit
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
        public DigiBumPictureBox(AlbumItem album,bool isEdit)
        {
            Size = new Size(200, 200);           
            if (isEdit)
            { 
                DeleteButton = new Button
                {
                    Name = "btnDelete",
                    Text = "X",
                    Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Width = 30,
                    BackColor = Color.Red,
                    ForeColor = Color.White,
                };
                DeleteButton.FlatAppearance.BorderSize = 0;
                EditButton = new Button
                {
                    Name = "btnEdit",
                    Text = "🖉",
                    Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Width = 30,
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                };
                EditButton.FlatAppearance.BorderSize = 0;
                DeleteButton.Click += (sender, e) => { DeleteAlbum(sender, e, album,false); };
                EditButton.Click += (sender, e) => { EditAlbum(sender, e, album); };
                DeleteButton.Location = new Point(Width - DeleteButton.Width, 0);
                EditButton.Location = new Point(Width - EditButton.Width, Height - EditButton.Height);
                DeleteButton.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, "Delete");
                EditButton.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, "Edit");
                Controls.Add(DeleteButton);
                Controls.Add(EditButton);
            }
            Title = new Label
            {
                Name = "lblTitle",
                Text = album.GetName(),
                Font = new Font(Font.FontFamily, 20, FontStyle.Bold),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            Description = new Label
            {
                Name = "lblDesc",
                Text = album.GetDescription(),
                Font = new Font(Font.FontFamily, 14, FontStyle.Italic),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            Title.Paint += DigiLabelPaint;
            Description.Paint += DigiLabelPaint;
            if (album.GetImages().Count == 0)
            {
                Image = null;  // Placeholder for "image not found"
                BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                Image = GenerateSmallerImage(album.GetImages()[0].GetImagePath(), 200, 200);
            }
            SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(Title);
            Controls.Add(Description);
            // Position controls
            Title.Location = new Point(0, 0);
            Description.Location = new Point(0, Height - Description.Height);
            // Assign event handlers (you can add more as needed)   
            Click += (sender, e) => { OpenAlbum(sender,e,album); };
            this.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, album.GetDescription());
            this.MouseLeave += (sender, e) => Cursor = Cursors.Default;
        }
        private void AdminGoBack(object sender, EventArgs e)
        {
            ToolStripMenuItem m = sender as ToolStripMenuItem;
            AdminPanel adminPanel = new AdminPanel();
            Panel p = m.Owner.Parent.Parent as Panel;
            if (p != null)
            {
                p.Controls.Clear();
                p.Controls.Add(adminPanel);
                adminPanel.Dock = DockStyle.Fill;
                adminPanel.Show();
            }
        }
        private void EditAlbum(object sender, EventArgs e, AlbumItem album)
        {
            Forms.AlbumForms.EditAlbum editAlbum = new Forms.AlbumForms.EditAlbum(album);
            Panel p = this.Parent.Parent.Parent as Panel;
            if(p.Name == "flpUsers")
            {
                p = p.Parent.Parent as Panel;
                editAlbum.menuStrip1.Hide();
                MenuStrip menu = new MenuStrip();
                menu.Name = "menuA";
                ToolStripMenuItem subMenu = new ToolStripMenuItem();
                subMenu.Name = "menuB";
                subMenu.Text = "Go back";
                subMenu.Click += AdminGoBack;
                menu.Items.Add(subMenu);
                editAlbum.Controls.Add(menu);
            }
            if (p != null)
            {
                p.Controls.Clear();
                SettingsManager.SetTheme(editAlbum);
                p.Controls.Add(editAlbum);
                editAlbum.Dock = DockStyle.Fill;
                this.Dispose();
                editAlbum.Show();
            }
        }
        private void OpenAlbum(object sender, EventArgs e,AlbumItem album)
        {
           int tabIndex = this.TabIndex;
           albumView?.Invoke(this, tabIndex);
        }
        internal async void DeleteAlbum(object sender, EventArgs e,AlbumItem album, bool skipDialog)
        {
            if(skipDialog || MessageBox.Show($"Delete?\n{album}", "Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool res =  await AppDataBase.DeleteAlbum(album);
                    if (res)
                    {
                        string albumFolderPath = pictureFolderPath + $@"{album.GetID()}\";
                        if (Directory.Exists(albumFolderPath))
                        {
                            Directory.Delete(albumFolderPath,true);
                        }

                        if(SettingsManager.userItems !=null && SettingsManager.userItems.Count > 0)
                        {
                           
                            foreach (AlbumItem item in SettingsManager.userItem.GetAlbumItems())
                            {
                                if(item == album)
                                    await AppDataBase.VerifyUser(SettingsManager.userItem.GetName(), SettingsManager.userItem.GetPassword());

                            }
                            await AppDataBase.GetAllUserItems();
                        }
                        else
                        {
                            await AppDataBase.VerifyUser(SettingsManager.userItem.GetName(), SettingsManager.userItem.GetPassword());
                        }
                        this.Dispose();
                    }
                    
                }
                catch { throw; }
            }

        }
        #endregion  constructor for album view

        // This function makes a smaller image of the original image for viewing purpose to reduce memory and make displaying them smoother on the UI(a thumbnail)
        private static Image GenerateSmallerImage(string path, int width, int height)
        {
            Bitmap b = null;
            try
            {
                // Open the file and load it into a MemoryStream
                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        memoryStream.Seek(0, SeekOrigin.Begin); // Reset the position for reading

                        // Load the image from the MemoryStream
                        using (Image img = Image.FromStream(memoryStream))
                        {
                            // Create a smaller bitmap based on the desired width and height
                            b = new Bitmap(img, width, height);
                        }
                    }
                }
                return b;
            }
            catch { return null; throw; }
        }   
    }
}
