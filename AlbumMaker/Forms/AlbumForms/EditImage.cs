using AlbumMaker.Classes;
using AlbumMaker.Classes.Items;
using System.Windows.Forms;
namespace AlbumMaker.Forms.AlbumForms
{
    public partial class EditImage : UserControl
    {
        private ImageItem image;
        private List<string> shapes;
        private List<KeyValuePair<string,int>> sizes;


        private bool isResizing = false;
        private int previousMouseX;
        public EditImage(ImageItem image)
        {
            InitializeComponent();
            if (SettingsManager.GetFont().Size > 9)
                panelOptions.Width = 500;
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
            grpBoxColors.Size = grpBoxColors.PreferredSize;
            grpBoxColors.AutoSize = true;
            grpBoxColors.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelOptions.Size = panelOptions.PreferredSize;
            panelOptions.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelOptions.AutoSize = true;
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            using (FileStream fileStream = new FileStream(image.GetImagePath(), FileMode.Open, FileAccess.Read))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Copy the file's content to the memory stream
                    fileStream.CopyTo(memoryStream);
                    // Reset the position of the stream to the beginning
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    // Load the image from the MemoryStream
                    pictureBoxPic.Image = Image.FromStream(memoryStream);
                } // MemoryStream is disposed of here
            } // FileStream is disposed of here

            comboBoxShape.DataSource = shapes;
            comboBoxShapeSize.DataSource = sizes;
           
        }
    }
}
