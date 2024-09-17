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
            panelHeader = new Panel();
            flpUpdateSector = new FlowLayoutPanel();
            txtBoxAlbumName = new TextBox();
            txtBoxDesc = new TextBox();
            cmbTemplate = new ComboBox();
            btnUpdate = new Button();
            labelTitle = new Label();
            menuStrip1.SuspendLayout();
            panelHeader.SuspendLayout();
            flpUpdateSector.SuspendLayout();
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
            flpImagesToEdit.Location = new Point(0, 135);
            flpImagesToEdit.Name = "flpImagesToEdit";
            flpImagesToEdit.Size = new Size(545, 222);
            flpImagesToEdit.TabIndex = 1;
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(flpUpdateSector);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(545, 105);
            panelHeader.TabIndex = 0;
            // 
            // flpUpdateSector
            // 
            flpUpdateSector.Controls.Add(txtBoxAlbumName);
            flpUpdateSector.Controls.Add(txtBoxDesc);
            flpUpdateSector.Controls.Add(cmbTemplate);
            flpUpdateSector.Controls.Add(btnUpdate);
            flpUpdateSector.Dock = DockStyle.Bottom;
            flpUpdateSector.Location = new Point(0, 53);
            flpUpdateSector.Name = "flpUpdateSector";
            flpUpdateSector.Size = new Size(545, 52);
            flpUpdateSector.TabIndex = 5;
            // 
            // txtBoxAlbumName
            // 
            txtBoxAlbumName.Dock = DockStyle.Top;
            txtBoxAlbumName.Location = new Point(3, 3);
            txtBoxAlbumName.Name = "txtBoxAlbumName";
            txtBoxAlbumName.PlaceholderText = "Album name";
            txtBoxAlbumName.Size = new Size(154, 23);
            txtBoxAlbumName.TabIndex = 1;
            // 
            // txtBoxDesc
            // 
            txtBoxDesc.Dock = DockStyle.Top;
            txtBoxDesc.Location = new Point(163, 3);
            txtBoxDesc.Name = "txtBoxDesc";
            txtBoxDesc.PlaceholderText = "Album description";
            txtBoxDesc.Size = new Size(161, 23);
            txtBoxDesc.TabIndex = 2;
            // 
            // cmbTemplate
            // 
            cmbTemplate.Dock = DockStyle.Top;
            cmbTemplate.FormattingEnabled = true;
            cmbTemplate.Items.AddRange(new object[] { "Vacation", "Birthday", "Wedding" });
            cmbTemplate.Location = new Point(330, 3);
            cmbTemplate.Name = "cmbTemplate";
            cmbTemplate.Size = new Size(121, 23);
            cmbTemplate.TabIndex = 3;
            // 
            // btnUpdate
            // 
            btnUpdate.Dock = DockStyle.Top;
            btnUpdate.Location = new Point(457, 3);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
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
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            flpUpdateSector.ResumeLayout(false);
            flpUpdateSector.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ToolStripMenuItem goBackToolStripMenuItem;
        private FlowLayoutPanel flpImagesToEdit;
        private Panel panelHeader;
        private Label labelTitle;
        private ComboBox cmbTemplate;
        private TextBox txtBoxDesc;
        private TextBox txtBoxAlbumName;
        private Button btnUpdate;
        private FlowLayoutPanel flpUpdateSector;
        public MenuStrip menuStrip1;
    }
}
