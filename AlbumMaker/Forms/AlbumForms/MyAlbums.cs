using AlbumMaker.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumMaker.Forms
{
    public partial class MyAlbums : UserControl
    {
        public MyAlbums()
        {
            InitializeComponent();
        }

        private void createNewAlbumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAlbum albumCreate = new CreateAlbum();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(albumCreate);
                albumCreate.Dock = DockStyle.Fill;
                SettingsManager.SetTheme(albumCreate);
                this.Dispose();
                albumCreate.Show();
            }
        }

        private void MyAlbums_Load(object sender, EventArgs e)
        {
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
        }
    }
}
