namespace AlbumMaker.Forms
{
    partial class CreateAlbum
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
            goBackToolStripMenuItem = new ToolStripMenuItem();
            chooseImagesToolStripMenuItem = new ToolStripMenuItem();
            scanFilesToolStripMenuItem = new ToolStripMenuItem();
            buttonSubmitAlbum = new Button();
            comboBoxTemplates = new ComboBox();
            textBoxAlbumDescription = new TextBox();
            textBoxAlbumName = new TextBox();
            FLPAlbumData = new FlowLayoutPanel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { goBackToolStripMenuItem, chooseImagesToolStripMenuItem, scanFilesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(487, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // goBackToolStripMenuItem
            // 
            goBackToolStripMenuItem.Name = "goBackToolStripMenuItem";
            goBackToolStripMenuItem.Size = new Size(62, 20);
            goBackToolStripMenuItem.Text = "Go back";
            goBackToolStripMenuItem.Click += goBackToolStripMenuItem_Click;
            // 
            // chooseImagesToolStripMenuItem
            // 
            chooseImagesToolStripMenuItem.Name = "chooseImagesToolStripMenuItem";
            chooseImagesToolStripMenuItem.Size = new Size(100, 20);
            chooseImagesToolStripMenuItem.Text = "Choose images";
            chooseImagesToolStripMenuItem.Click += chooseImagesToolStripMenuItem_Click;
            // 
            // scanFilesToolStripMenuItem
            // 
            scanFilesToolStripMenuItem.Name = "scanFilesToolStripMenuItem";
            scanFilesToolStripMenuItem.Size = new Size(68, 20);
            scanFilesToolStripMenuItem.Text = "Scan files";
            scanFilesToolStripMenuItem.Click += scanFilesToolStripMenuItem_Click;
            // 
            // buttonSubmitAlbum
            // 
            buttonSubmitAlbum.Location = new Point(414, 27);
            buttonSubmitAlbum.Name = "buttonSubmitAlbum";
            buttonSubmitAlbum.Size = new Size(65, 23);
            buttonSubmitAlbum.TabIndex = 3;
            buttonSubmitAlbum.Text = "Submit";
            buttonSubmitAlbum.UseVisualStyleBackColor = true;
            buttonSubmitAlbum.Click += buttonSubmitAlbum_Click;
            // 
            // comboBoxTemplates
            // 
            comboBoxTemplates.FormattingEnabled = true;
            comboBoxTemplates.Items.AddRange(new object[] { "Vacation", "Birthday", "Wedding" });
            comboBoxTemplates.Location = new Point(277, 27);
            comboBoxTemplates.Name = "comboBoxTemplates";
            comboBoxTemplates.Size = new Size(131, 23);
            comboBoxTemplates.TabIndex = 2;
            // 
            // textBoxAlbumDescription
            // 
            textBoxAlbumDescription.Location = new Point(3, 27);
            textBoxAlbumDescription.Name = "textBoxAlbumDescription";
            textBoxAlbumDescription.PlaceholderText = "Album description";
            textBoxAlbumDescription.Size = new Size(131, 23);
            textBoxAlbumDescription.TabIndex = 1;
            // 
            // textBoxAlbumName
            // 
            textBoxAlbumName.Location = new Point(140, 27);
            textBoxAlbumName.MaxLength = 20;
            textBoxAlbumName.Name = "textBoxAlbumName";
            textBoxAlbumName.PlaceholderText = "Album name";
            textBoxAlbumName.Size = new Size(131, 23);
            textBoxAlbumName.TabIndex = 0;
            // 
            // FLPAlbumData
            // 
            FLPAlbumData.Dock = DockStyle.Bottom;
            FLPAlbumData.Location = new Point(0, 56);
            FLPAlbumData.Name = "FLPAlbumData";
            FLPAlbumData.Size = new Size(487, 178);
            FLPAlbumData.TabIndex = 2;
            // 
            // CreateAlbum
            // 
            AccessibleName = "Create album";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBoxAlbumDescription);
            Controls.Add(textBoxAlbumName);
            Controls.Add(FLPAlbumData);
            Controls.Add(comboBoxTemplates);
            Controls.Add(menuStrip1);
            Controls.Add(buttonSubmitAlbum);
            Name = "CreateAlbum";
            Size = new Size(487, 234);
            Load += CreateAlbum_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem scanFilesToolStripMenuItem;
        private ToolStripMenuItem goBackToolStripMenuItem;
        private TextBox textBoxAlbumName;
        private ComboBox comboBoxTemplates;
        private TextBox textBoxAlbumDescription;
        private ToolStripMenuItem chooseImagesToolStripMenuItem;
        private Button buttonSubmitAlbum;
        private FlowLayoutPanel FLPAlbumData;
    }
}
