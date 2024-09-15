namespace AlbumMaker.Forms
{
    partial class MyAlbums
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            createNewAlbumToolStripMenuItem = new ToolStripMenuItem();
            editAlbumsToolStripMenuItem = new ToolStripMenuItem();
            flpDisplayAlbums = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { createNewAlbumToolStripMenuItem, editAlbumsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(433, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // createNewAlbumToolStripMenuItem
            // 
            createNewAlbumToolStripMenuItem.Name = "createNewAlbumToolStripMenuItem";
            createNewAlbumToolStripMenuItem.Size = new Size(115, 20);
            createNewAlbumToolStripMenuItem.Text = "Create new album";
            createNewAlbumToolStripMenuItem.Click += createNewAlbumToolStripMenuItem_Click;
            // 
            // editAlbumsToolStripMenuItem
            // 
            editAlbumsToolStripMenuItem.Name = "editAlbumsToolStripMenuItem";
            editAlbumsToolStripMenuItem.Size = new Size(81, 20);
            editAlbumsToolStripMenuItem.Text = "Edit albums";
            // 
            // flpDisplayAlbums
            // 
            flpDisplayAlbums.Dock = DockStyle.Fill;
            flpDisplayAlbums.Location = new Point(0, 24);
            flpDisplayAlbums.Name = "flpDisplayAlbums";
            flpDisplayAlbums.Size = new Size(433, 276);
            flpDisplayAlbums.TabIndex = 1;
            // 
            // MyAlbums
            // 
            AccessibleName = "My albums";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpDisplayAlbums);
            Controls.Add(menuStrip1);
            Name = "MyAlbums";
            Size = new Size(433, 300);
            Load += MyAlbums_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem createNewAlbumToolStripMenuItem;
        private ToolStripMenuItem editAlbumsToolStripMenuItem;
        private FlowLayoutPanel flpDisplayAlbums;
    }
}
