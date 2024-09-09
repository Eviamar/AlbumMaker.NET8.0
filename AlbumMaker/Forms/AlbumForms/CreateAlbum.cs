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
    public partial class CreateAlbum : UserControl
    {
        public CreateAlbum()
        {
            InitializeComponent();
        }

        private void scanFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanForImages scan = new ScanForImages();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(scan);
                scan.Dock = DockStyle.Fill;
                SettingsManager.SetTheme(scan);
                this.Dispose();
                scan.Show();
            }
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyAlbums myAlbums = new MyAlbums();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(myAlbums);
                myAlbums.Dock = DockStyle.Fill;
                SettingsManager.SetTheme(myAlbums);
                this.Dispose();
                myAlbums.Show();
            }
        }
    }
}
