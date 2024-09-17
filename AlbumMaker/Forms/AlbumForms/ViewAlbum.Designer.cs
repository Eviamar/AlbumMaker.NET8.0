namespace AlbumMaker.Forms.AlbumForms
{
    partial class ViewAlbum
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
            panelHeader = new Panel();
            labelPage = new Label();
            labelDesc = new Label();
            labelTitle = new Label();
            menuStrip1 = new MenuStrip();
            goBackToolStripMenuItem = new ToolStripMenuItem();
            panelLeft = new Panel();
            btnLeft = new Button();
            panelRight = new Panel();
            btnRight = new Button();
            tableLayoutPanelImages = new TableLayoutPanel();
            panelHeader.SuspendLayout();
            menuStrip1.SuspendLayout();
            panelLeft.SuspendLayout();
            panelRight.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(labelPage);
            panelHeader.Controls.Add(labelDesc);
            panelHeader.Controls.Add(labelTitle);
            panelHeader.Controls.Add(menuStrip1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(846, 64);
            panelHeader.TabIndex = 0;
            // 
            // labelPage
            // 
            labelPage.AutoSize = true;
            labelPage.Dock = DockStyle.Right;
            labelPage.Location = new Point(833, 39);
            labelPage.Name = "labelPage";
            labelPage.Size = new Size(13, 15);
            labelPage.TabIndex = 2;
            labelPage.Text = "1";
            // 
            // labelDesc
            // 
            labelDesc.AutoSize = true;
            labelDesc.Dock = DockStyle.Bottom;
            labelDesc.Location = new Point(0, 49);
            labelDesc.Name = "labelDesc";
            labelDesc.Size = new Size(38, 15);
            labelDesc.TabIndex = 1;
            labelDesc.Text = "label1";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Location = new Point(0, 24);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(38, 15);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "label1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { goBackToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(846, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // goBackToolStripMenuItem
            // 
            goBackToolStripMenuItem.Name = "goBackToolStripMenuItem";
            goBackToolStripMenuItem.Size = new Size(62, 20);
            goBackToolStripMenuItem.Text = "Go back";
            goBackToolStripMenuItem.Click += goBackToolStripMenuItem_Click;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(btnLeft);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 64);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(38, 426);
            panelLeft.TabIndex = 1;
            // 
            // btnLeft
            // 
            btnLeft.Dock = DockStyle.Left;
            btnLeft.Location = new Point(0, 0);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new Size(36, 426);
            btnLeft.TabIndex = 0;
            btnLeft.Text = "«";
            btnLeft.UseVisualStyleBackColor = true;
            btnLeft.Click += btnLeft_Click;
            // 
            // panelRight
            // 
            panelRight.Controls.Add(btnRight);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(808, 64);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(38, 426);
            panelRight.TabIndex = 2;
            // 
            // btnRight
            // 
            btnRight.Dock = DockStyle.Right;
            btnRight.Location = new Point(2, 0);
            btnRight.Name = "btnRight";
            btnRight.Size = new Size(36, 426);
            btnRight.TabIndex = 0;
            btnRight.Text = "»";
            btnRight.UseVisualStyleBackColor = true;
            btnRight.Click += btnRight_Click;
            // 
            // tableLayoutPanelImages
            // 
            tableLayoutPanelImages.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
            tableLayoutPanelImages.ColumnCount = 3;
            tableLayoutPanelImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelImages.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanelImages.Dock = DockStyle.Fill;
            tableLayoutPanelImages.Location = new Point(38, 64);
            tableLayoutPanelImages.Name = "tableLayoutPanelImages";
            tableLayoutPanelImages.RowCount = 3;
            tableLayoutPanelImages.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3344421F));
            tableLayoutPanelImages.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3344421F));
            tableLayoutPanelImages.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3311157F));
            tableLayoutPanelImages.Size = new Size(770, 426);
            tableLayoutPanelImages.TabIndex = 3;
            // 
            // ViewAlbum
            // 
            AccessibleName = "View Album";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanelImages);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelHeader);
            Name = "ViewAlbum";
            Size = new Size(846, 490);
            Load += ViewAlbum_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelLeft.ResumeLayout(false);
            panelRight.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label labelTitle;
        private Panel panelLeft;
        private Panel panelRight;
        private Label labelPage;
        private Label labelDesc;
        private TableLayoutPanel tableLayoutPanelImages;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem goBackToolStripMenuItem;
        private Button btnLeft;
        private Button btnRight;
    }
}
