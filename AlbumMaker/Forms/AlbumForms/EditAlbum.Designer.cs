namespace AlbumMaker.Forms.AlbumForms
{
    partial class EditAlbum
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
            flpImagesToEdit = new FlowLayoutPanel();
            labelTitle = new Label();
            panelUpdate = new Panel();
            btnUpdate = new Button();
            txtBoxAlbumName = new TextBox();
            cmbTemplate = new ComboBox();
            txtBoxDesc = new TextBox();
            panelHeader = new Panel();
            menuStrip1.SuspendLayout();
            panelUpdate.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { goBackToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(545, 24);
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
            // flpImagesToEdit
            // 
            flpImagesToEdit.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flpImagesToEdit.AutoScroll = true;
            flpImagesToEdit.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpImagesToEdit.Location = new Point(0, 120);
            flpImagesToEdit.Name = "flpImagesToEdit";
            flpImagesToEdit.Size = new Size(545, 237);
            flpImagesToEdit.TabIndex = 1;
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(3, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(76, 15);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Album name";
            // 
            // panelUpdate
            // 
            panelUpdate.Controls.Add(btnUpdate);
            panelUpdate.Controls.Add(txtBoxAlbumName);
            panelUpdate.Controls.Add(cmbTemplate);
            panelUpdate.Controls.Add(txtBoxDesc);
            panelUpdate.Dock = DockStyle.Fill;
            panelUpdate.Location = new Point(0, 0);
            panelUpdate.Name = "panelUpdate";
            panelUpdate.Size = new Size(545, 90);
            panelUpdate.TabIndex = 0;
            // 
            // btnUpdate
            // 
            btnUpdate.AutoSize = true;
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Location = new Point(457, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(65, 25);
            btnUpdate.TabIndex = 3;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtBoxAlbumName
            // 
            txtBoxAlbumName.Cursor = Cursors.IBeam;
            txtBoxAlbumName.Location = new Point(3, 4);
            txtBoxAlbumName.Name = "txtBoxAlbumName";
            txtBoxAlbumName.PlaceholderText = "Album name";
            txtBoxAlbumName.Size = new Size(154, 23);
            txtBoxAlbumName.TabIndex = 0;
            // 
            // cmbTemplate
            // 
            cmbTemplate.FormattingEnabled = true;
            cmbTemplate.Items.AddRange(new object[] { "Vacation", "Birthday", "Wedding" });
            cmbTemplate.Location = new Point(330, 4);
            cmbTemplate.Name = "cmbTemplate";
            cmbTemplate.Size = new Size(121, 23);
            cmbTemplate.TabIndex = 2;
            // 
            // txtBoxDesc
            // 
            txtBoxDesc.Cursor = Cursors.IBeam;
            txtBoxDesc.Location = new Point(163, 4);
            txtBoxDesc.Name = "txtBoxDesc";
            txtBoxDesc.PlaceholderText = "Album description";
            txtBoxDesc.Size = new Size(161, 23);
            txtBoxDesc.TabIndex = 1;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(panelUpdate);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(545, 90);
            panelHeader.TabIndex = 0;
            // 
            // EditAlbum
            // 
            AccessibleName = "Edit Album";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpImagesToEdit);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip1);
            Name = "EditAlbum";
            Size = new Size(545, 357);
            Load += EditAlbum_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelUpdate.ResumeLayout(false);
            panelUpdate.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem goBackToolStripMenuItem;
        private FlowLayoutPanel flpImagesToEdit;
        public MenuStrip menuStrip1;
        private Label labelTitle;
        private Panel panelUpdate;
        private Button btnUpdate;
        private TextBox txtBoxAlbumName;
        private ComboBox cmbTemplate;
        private TextBox txtBoxDesc;
        private Panel panelHeader;
    }
}
