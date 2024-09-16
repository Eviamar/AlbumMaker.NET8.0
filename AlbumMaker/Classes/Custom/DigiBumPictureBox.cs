using AlbumMaker.Classes.Db;
using AlbumMaker.Classes.Items;
using AlbumMaker.Forms.AlbumForms;
using AlbumMaker.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        public event EventHandler<int> ImageDeleted;
        public event EventHandler<int> albumView;
        private static readonly string pictureFolderPath = $@"{Properties.AppSettings.Default.AppDataFolder}\{Properties.AppSettings.Default.AppName}\{Properties.AppSettings.Default.AppAlbumsFolderName}\";

        #region constructor for image view
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
            DeleteButton.Click += (sender, e) => { DeleteImage(sender, e, isEdit); };
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

                Title = new Label
                {
                    Name = "lblTitle",
                    Text = image.GetName(),
                    Font = new Font(Font.FontFamily, 20, FontStyle.Bold),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };

                Description = new Label
                {
                    Name = "lblDesc",
                    Text = image.GetDescription(),
                    Font = new Font(Font.FontFamily, 14, FontStyle.Italic),
                    AutoSize = true,
                    BackColor = Color.Transparent
                };
                Image = GenerateSmallerImage(image.GetImagePath(), 200, 200);
                ImageLocation = image.GetImagePath();
                this.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, image.GetDescription());
                EditButton.Location = new Point(Width - EditButton.Width, Height - EditButton.Height);
                Title.Location = new Point(0, 0);
                Description.Location = new Point(0, Height - Description.Height);
                EditButton.MouseEnter += (sender, e) => MouseEnterFunction(sender, e, "Edit");
                EditButton.Click += (sender, e) => { EditImage(sender, e); };
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
            Process.Start(new ProcessStartInfo
            {
                FileName = digi.ImageLocation,
                UseShellExecute = true
            });
        }
        private void DeleteImage(object sender, EventArgs e, bool isEdit)
        {
            if(isEdit)
            {

            }
            else
            {

            }
            int tabIndex = this.TabIndex;
           // this.Dispose();  // Dispose the PictureBox

            // Raise the event with the tabIndex as the event argument
            ImageDeleted?.Invoke(this, tabIndex);
        }

        private void EditImage(object sender,EventArgs e)
        {
           
        }
        #endregion constructor for image view
        #region constructor for album view
        public DigiBumPictureBox(AlbumItem album,bool isEdit)
        {
            Size = new Size(200, 200);

            // Initialize buttons and labels
            if (isEdit)
            { 
                DeleteButton = new Button
                {
                    Name = "btnDelete",
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
                    Name = "btnEdit",
                    Text = "🖉",
                    Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    Width = 30,
                    BackColor = Color.Transparent,
                    ForeColor = Color.Green,
                };
                EditButton.FlatAppearance.BorderSize = 0;
                DeleteButton.Click += (sender, e) => { DeleteAlbum(sender, e, album); };
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

            // Setup image
            if (album.GetImages().Count == 0)
            {
                Image = null;  // Placeholder for "image not found"
                BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                Image = GenerateSmallerImage(album.GetImages()[0].GetImagePath(), 200, 200);
                ImageLocation = album.GetImages()[0].GetImagePath();
            }

            SizeMode = PictureBoxSizeMode.StretchImage;

            // Add controls to the PictureBox
            
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
        private void EditAlbum(object sender, EventArgs e, AlbumItem album)
        {
            MessageBox.Show($"Edit?\n{album}", "Edit");
        }
        private void OpenAlbum(object sender, EventArgs e,AlbumItem album)
        {
           int tabIndex = this.TabIndex;
           albumView?.Invoke(this, tabIndex);

        }
        private async void DeleteAlbum(object sender, EventArgs e,AlbumItem album)
        {
            DialogResult dr = MessageBox.Show($"Delete?\n{album}","Deletion",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
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
                        SettingsManager.userItem.DeleteSpecificAlbum(album);
                        this.Dispose();
                    }
                    
                }
                catch { throw; }
            }

        }
        #endregion  constructor for album view
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
