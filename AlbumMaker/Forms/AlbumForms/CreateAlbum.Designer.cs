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
            panelFillInfo = new Panel();
            progressBar1 = new ProgressBar();
            menuStrip1.SuspendLayout();
            panelFillInfo.SuspendLayout();
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
            buttonSubmitAlbum.Location = new Point(413, 4);
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
            comboBoxTemplates.Location = new Point(276, 4);
            comboBoxTemplates.Name = "comboBoxTemplates";
            comboBoxTemplates.Size = new Size(131, 23);
            comboBoxTemplates.TabIndex = 2;
            // 
            // textBoxAlbumDescription
            // 
            textBoxAlbumDescription.Location = new Point(139, 4);
            textBoxAlbumDescription.Name = "textBoxAlbumDescription";
            textBoxAlbumDescription.PlaceholderText = "Album description";
            textBoxAlbumDescription.Size = new Size(131, 23);
            textBoxAlbumDescription.TabIndex = 1;
            // 
            // textBoxAlbumName
            // 
            textBoxAlbumName.Location = new Point(3, 4);
            textBoxAlbumName.MaxLength = 20;
            textBoxAlbumName.Name = "textBoxAlbumName";
            textBoxAlbumName.PlaceholderText = "Album name";
            textBoxAlbumName.Size = new Size(131, 23);
            textBoxAlbumName.TabIndex = 0;
            // 
            // FLPAlbumData
            // 
            FLPAlbumData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            FLPAlbumData.AutoScroll = true;
            FLPAlbumData.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            FLPAlbumData.Location = new Point(3, 62);
            FLPAlbumData.Name = "FLPAlbumData";
            FLPAlbumData.Size = new Size(481, 143);
            FLPAlbumData.TabIndex = 2;
            // 
            // panelFillInfo
            // 
            panelFillInfo.Controls.Add(textBoxAlbumName);
            panelFillInfo.Controls.Add(buttonSubmitAlbum);
            panelFillInfo.Controls.Add(textBoxAlbumDescription);
            panelFillInfo.Controls.Add(comboBoxTemplates);
            panelFillInfo.Dock = DockStyle.Top;
            panelFillInfo.Location = new Point(0, 24);
            panelFillInfo.Name = "panelFillInfo";
            panelFillInfo.Size = new Size(487, 32);
            panelFillInfo.TabIndex = 4;
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 211);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(487, 23);
            progressBar1.TabIndex = 5;
            progressBar1.Visible = false;
            // 
            // CreateAlbum
            // 
            AccessibleName = "Create album";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(progressBar1);
            Controls.Add(panelFillInfo);
            Controls.Add(FLPAlbumData);
            Controls.Add(menuStrip1);
            Name = "CreateAlbum";
            Size = new Size(487, 234);
            Load += CreateAlbum_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelFillInfo.ResumeLayout(false);
            panelFillInfo.PerformLayout();
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
        private Panel panelFillInfo;
        private ProgressBar progressBar1;
    }
}
