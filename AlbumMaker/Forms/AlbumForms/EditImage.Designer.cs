namespace AlbumMaker.Forms.AlbumForms
{
    partial class EditImage
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
            pictureBoxPic = new PictureBox();
            tlpOptions = new TableLayoutPanel();
            grpBoxBrightness = new GroupBox();
            flp4GrpBoxBrightness = new FlowLayoutPanel();
            grpBoxShapes = new GroupBox();
            flp4GrpBoxShape = new FlowLayoutPanel();
            comboBoxShape = new ComboBox();
            comboBoxShapeSize = new ComboBox();
            txtBoxCustomSize = new TextBox();
            btnApplyShape = new Button();
            grpBoxDesc = new GroupBox();
            flp4GrpBoxDesc = new FlowLayoutPanel();
            textBoxDesc = new TextBox();
            lblImgeDesc = new Label();
            btnApplyDesc = new Button();
            grpBoxFilter = new GroupBox();
            panel4grpBoxFilter = new Panel();
            grpBoxColors = new GroupBox();
            flp4grpboxColors = new FlowLayoutPanel();
            lblColor1 = new Label();
            lblColor2 = new Label();
            linkLabelRandomColors = new LinkLabel();
            btnFilter = new Button();
            grpBoxFlip = new GroupBox();
            flp4GrpBoxFlip = new FlowLayoutPanel();
            btnFlipUpDown = new Button();
            btnFlipLeftRight = new Button();
            grpBoxBtnsSaveUndo = new GroupBox();
            flp4UndoSave = new FlowLayoutPanel();
            btnUndo = new Button();
            btnClear = new Button();
            btnSave = new Button();
            panelPic = new Panel();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPic).BeginInit();
            tlpOptions.SuspendLayout();
            grpBoxBrightness.SuspendLayout();
            grpBoxShapes.SuspendLayout();
            flp4GrpBoxShape.SuspendLayout();
            grpBoxDesc.SuspendLayout();
            flp4GrpBoxDesc.SuspendLayout();
            grpBoxFilter.SuspendLayout();
            panel4grpBoxFilter.SuspendLayout();
            grpBoxColors.SuspendLayout();
            flp4grpboxColors.SuspendLayout();
            grpBoxFlip.SuspendLayout();
            flp4GrpBoxFlip.SuspendLayout();
            grpBoxBtnsSaveUndo.SuspendLayout();
            flp4UndoSave.SuspendLayout();
            panelPic.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { goBackToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1133, 24);
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
            // pictureBoxPic
            // 
            pictureBoxPic.Location = new Point(-45, 78);
            pictureBoxPic.Name = "pictureBoxPic";
            pictureBoxPic.Size = new Size(325, 325);
            pictureBoxPic.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxPic.TabIndex = 0;
            pictureBoxPic.TabStop = false;
            // 
            // tlpOptions
            // 
            tlpOptions.AutoScroll = true;
            tlpOptions.AutoSize = true;
            tlpOptions.ColumnCount = 1;
            tlpOptions.ColumnStyles.Add(new ColumnStyle());
            tlpOptions.Controls.Add(grpBoxBrightness, 0, 2);
            tlpOptions.Controls.Add(grpBoxShapes, 0, 1);
            tlpOptions.Controls.Add(grpBoxDesc, 0, 3);
            tlpOptions.Controls.Add(grpBoxFilter, 0, 0);
            tlpOptions.Controls.Add(grpBoxBtnsSaveUndo, 0, 4);
            tlpOptions.Dock = DockStyle.Right;
            tlpOptions.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpOptions.Location = new Point(837, 24);
            tlpOptions.Name = "tlpOptions";
            tlpOptions.RowCount = 5;
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 22.727272F));
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 22.727272F));
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 22.727272F));
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 22.727272F));
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 9.090909F));
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpOptions.Size = new Size(296, 778);
            tlpOptions.TabIndex = 1;
            // 
            // grpBoxBrightness
            // 
            grpBoxBrightness.AutoSize = true;
            grpBoxBrightness.Controls.Add(flp4GrpBoxBrightness);
            grpBoxBrightness.Dock = DockStyle.Fill;
            grpBoxBrightness.Location = new Point(3, 355);
            grpBoxBrightness.Name = "grpBoxBrightness";
            grpBoxBrightness.Size = new Size(290, 170);
            grpBoxBrightness.TabIndex = 8;
            grpBoxBrightness.TabStop = false;
            grpBoxBrightness.Text = "Brightness";
            // 
            // flp4GrpBoxBrightness
            // 
            flp4GrpBoxBrightness.AutoScroll = true;
            flp4GrpBoxBrightness.AutoSize = true;
            flp4GrpBoxBrightness.Dock = DockStyle.Fill;
            flp4GrpBoxBrightness.FlowDirection = FlowDirection.TopDown;
            flp4GrpBoxBrightness.Location = new Point(3, 19);
            flp4GrpBoxBrightness.Name = "flp4GrpBoxBrightness";
            flp4GrpBoxBrightness.Size = new Size(284, 148);
            flp4GrpBoxBrightness.TabIndex = 1;
            // 
            // grpBoxShapes
            // 
            grpBoxShapes.AutoSize = true;
            grpBoxShapes.Controls.Add(flp4GrpBoxShape);
            grpBoxShapes.Dock = DockStyle.Fill;
            grpBoxShapes.Location = new Point(3, 179);
            grpBoxShapes.Name = "grpBoxShapes";
            grpBoxShapes.Size = new Size(290, 170);
            grpBoxShapes.TabIndex = 7;
            grpBoxShapes.TabStop = false;
            grpBoxShapes.Text = "Shape";
            // 
            // flp4GrpBoxShape
            // 
            flp4GrpBoxShape.AutoScroll = true;
            flp4GrpBoxShape.AutoSize = true;
            flp4GrpBoxShape.Controls.Add(comboBoxShape);
            flp4GrpBoxShape.Controls.Add(comboBoxShapeSize);
            flp4GrpBoxShape.Controls.Add(txtBoxCustomSize);
            flp4GrpBoxShape.Controls.Add(btnApplyShape);
            flp4GrpBoxShape.Dock = DockStyle.Fill;
            flp4GrpBoxShape.FlowDirection = FlowDirection.TopDown;
            flp4GrpBoxShape.Location = new Point(3, 19);
            flp4GrpBoxShape.Name = "flp4GrpBoxShape";
            flp4GrpBoxShape.Size = new Size(284, 148);
            flp4GrpBoxShape.TabIndex = 1;
            // 
            // comboBoxShape
            // 
            comboBoxShape.FormattingEnabled = true;
            comboBoxShape.Location = new Point(3, 3);
            comboBoxShape.Name = "comboBoxShape";
            comboBoxShape.Size = new Size(141, 23);
            comboBoxShape.TabIndex = 0;
            // 
            // comboBoxShapeSize
            // 
            comboBoxShapeSize.FormattingEnabled = true;
            comboBoxShapeSize.Location = new Point(3, 32);
            comboBoxShapeSize.Name = "comboBoxShapeSize";
            comboBoxShapeSize.Size = new Size(141, 23);
            comboBoxShapeSize.TabIndex = 1;
            // 
            // txtBoxCustomSize
            // 
            txtBoxCustomSize.Location = new Point(3, 68);
            txtBoxCustomSize.Margin = new Padding(3, 10, 3, 3);
            txtBoxCustomSize.Name = "txtBoxCustomSize";
            txtBoxCustomSize.PlaceholderText = "Custom size";
            txtBoxCustomSize.Size = new Size(141, 23);
            txtBoxCustomSize.TabIndex = 3;
            // 
            // btnApplyShape
            // 
            btnApplyShape.AutoSize = true;
            btnApplyShape.Location = new Point(3, 97);
            btnApplyShape.Name = "btnApplyShape";
            btnApplyShape.Size = new Size(141, 25);
            btnApplyShape.TabIndex = 2;
            btnApplyShape.Text = "Apply";
            btnApplyShape.UseVisualStyleBackColor = true;
            btnApplyShape.Click += btnApplyShape_Click;
            // 
            // grpBoxDesc
            // 
            grpBoxDesc.AutoSize = true;
            grpBoxDesc.Controls.Add(flp4GrpBoxDesc);
            grpBoxDesc.Dock = DockStyle.Fill;
            grpBoxDesc.Location = new Point(3, 531);
            grpBoxDesc.Name = "grpBoxDesc";
            grpBoxDesc.Padding = new Padding(10);
            grpBoxDesc.RightToLeft = RightToLeft.No;
            grpBoxDesc.Size = new Size(290, 170);
            grpBoxDesc.TabIndex = 10;
            grpBoxDesc.TabStop = false;
            grpBoxDesc.Text = "Image description";
            // 
            // flp4GrpBoxDesc
            // 
            flp4GrpBoxDesc.AutoScroll = true;
            flp4GrpBoxDesc.Controls.Add(textBoxDesc);
            flp4GrpBoxDesc.Controls.Add(lblImgeDesc);
            flp4GrpBoxDesc.Controls.Add(btnApplyDesc);
            flp4GrpBoxDesc.Dock = DockStyle.Fill;
            flp4GrpBoxDesc.FlowDirection = FlowDirection.TopDown;
            flp4GrpBoxDesc.Location = new Point(10, 26);
            flp4GrpBoxDesc.Name = "flp4GrpBoxDesc";
            flp4GrpBoxDesc.Size = new Size(270, 134);
            flp4GrpBoxDesc.TabIndex = 1;
            // 
            // textBoxDesc
            // 
            textBoxDesc.Location = new Point(3, 3);
            textBoxDesc.Name = "textBoxDesc";
            textBoxDesc.PlaceholderText = "Image description";
            textBoxDesc.RightToLeft = RightToLeft.No;
            textBoxDesc.Size = new Size(194, 23);
            textBoxDesc.TabIndex = 0;
            // 
            // lblImgeDesc
            // 
            lblImgeDesc.AutoSize = true;
            lblImgeDesc.Location = new Point(3, 29);
            lblImgeDesc.Name = "lblImgeDesc";
            lblImgeDesc.Size = new Size(67, 15);
            lblImgeDesc.TabIndex = 2;
            lblImgeDesc.Text = "image desc";
            // 
            // btnApplyDesc
            // 
            btnApplyDesc.AutoSize = true;
            btnApplyDesc.Location = new Point(3, 47);
            btnApplyDesc.Name = "btnApplyDesc";
            btnApplyDesc.Size = new Size(75, 25);
            btnApplyDesc.TabIndex = 1;
            btnApplyDesc.Text = "Apply ";
            btnApplyDesc.UseVisualStyleBackColor = true;
            // 
            // grpBoxFilter
            // 
            grpBoxFilter.AutoSize = true;
            grpBoxFilter.Controls.Add(panel4grpBoxFilter);
            grpBoxFilter.Dock = DockStyle.Fill;
            grpBoxFilter.Location = new Point(3, 3);
            grpBoxFilter.Name = "grpBoxFilter";
            grpBoxFilter.Size = new Size(290, 170);
            grpBoxFilter.TabIndex = 6;
            grpBoxFilter.TabStop = false;
            grpBoxFilter.Text = "Filter n Angle";
            // 
            // panel4grpBoxFilter
            // 
            panel4grpBoxFilter.AutoScroll = true;
            panel4grpBoxFilter.Controls.Add(grpBoxColors);
            panel4grpBoxFilter.Controls.Add(grpBoxFlip);
            panel4grpBoxFilter.Dock = DockStyle.Fill;
            panel4grpBoxFilter.Location = new Point(3, 19);
            panel4grpBoxFilter.Name = "panel4grpBoxFilter";
            panel4grpBoxFilter.Size = new Size(284, 148);
            panel4grpBoxFilter.TabIndex = 0;
            // 
            // grpBoxColors
            // 
            grpBoxColors.AutoSize = true;
            grpBoxColors.Controls.Add(flp4grpboxColors);
            grpBoxColors.Dock = DockStyle.Fill;
            grpBoxColors.Location = new Point(0, 0);
            grpBoxColors.Name = "grpBoxColors";
            grpBoxColors.Size = new Size(204, 148);
            grpBoxColors.TabIndex = 0;
            grpBoxColors.TabStop = false;
            grpBoxColors.Text = "Colors";
            // 
            // flp4grpboxColors
            // 
            flp4grpboxColors.AutoScroll = true;
            flp4grpboxColors.AutoSize = true;
            flp4grpboxColors.Controls.Add(lblColor1);
            flp4grpboxColors.Controls.Add(lblColor2);
            flp4grpboxColors.Controls.Add(linkLabelRandomColors);
            flp4grpboxColors.Controls.Add(btnFilter);
            flp4grpboxColors.Dock = DockStyle.Fill;
            flp4grpboxColors.FlowDirection = FlowDirection.TopDown;
            flp4grpboxColors.Location = new Point(3, 19);
            flp4grpboxColors.Name = "flp4grpboxColors";
            flp4grpboxColors.Size = new Size(198, 126);
            flp4grpboxColors.TabIndex = 0;
            // 
            // lblColor1
            // 
            lblColor1.AutoEllipsis = true;
            lblColor1.AutoSize = true;
            lblColor1.Location = new Point(3, 0);
            lblColor1.Name = "lblColor1";
            lblColor1.Size = new Size(45, 15);
            lblColor1.TabIndex = 0;
            lblColor1.Text = "Color 1";
            lblColor1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblColor2
            // 
            lblColor2.AutoEllipsis = true;
            lblColor2.AutoSize = true;
            lblColor2.Location = new Point(3, 15);
            lblColor2.Name = "lblColor2";
            lblColor2.Size = new Size(45, 15);
            lblColor2.TabIndex = 1;
            lblColor2.Text = "Color 2";
            lblColor2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkLabelRandomColors
            // 
            linkLabelRandomColors.ActiveLinkColor = Color.Crimson;
            linkLabelRandomColors.AutoEllipsis = true;
            linkLabelRandomColors.AutoSize = true;
            linkLabelRandomColors.Location = new Point(3, 30);
            linkLabelRandomColors.Name = "linkLabelRandomColors";
            linkLabelRandomColors.Size = new Size(52, 15);
            linkLabelRandomColors.TabIndex = 2;
            linkLabelRandomColors.TabStop = true;
            linkLabelRandomColors.Text = "Random";
            linkLabelRandomColors.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnFilter
            // 
            btnFilter.AutoSize = true;
            btnFilter.Location = new Point(3, 48);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(85, 25);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Active filter";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // grpBoxFlip
            // 
            grpBoxFlip.AutoSize = true;
            grpBoxFlip.Controls.Add(flp4GrpBoxFlip);
            grpBoxFlip.Dock = DockStyle.Right;
            grpBoxFlip.Location = new Point(204, 0);
            grpBoxFlip.Name = "grpBoxFlip";
            grpBoxFlip.Size = new Size(80, 148);
            grpBoxFlip.TabIndex = 9;
            grpBoxFlip.TabStop = false;
            grpBoxFlip.Text = "Flip";
            // 
            // flp4GrpBoxFlip
            // 
            flp4GrpBoxFlip.AutoScroll = true;
            flp4GrpBoxFlip.AutoSize = true;
            flp4GrpBoxFlip.Controls.Add(btnFlipUpDown);
            flp4GrpBoxFlip.Controls.Add(btnFlipLeftRight);
            flp4GrpBoxFlip.Dock = DockStyle.Fill;
            flp4GrpBoxFlip.FlowDirection = FlowDirection.TopDown;
            flp4GrpBoxFlip.Location = new Point(3, 19);
            flp4GrpBoxFlip.Name = "flp4GrpBoxFlip";
            flp4GrpBoxFlip.Size = new Size(74, 126);
            flp4GrpBoxFlip.TabIndex = 1;
            // 
            // btnFlipUpDown
            // 
            btnFlipUpDown.AutoSize = true;
            btnFlipUpDown.Location = new Point(3, 3);
            btnFlipUpDown.Name = "btnFlipUpDown";
            btnFlipUpDown.Size = new Size(38, 25);
            btnFlipUpDown.TabIndex = 0;
            btnFlipUpDown.Text = "Up";
            btnFlipUpDown.UseVisualStyleBackColor = true;
            // 
            // btnFlipLeftRight
            // 
            btnFlipLeftRight.AutoSize = true;
            btnFlipLeftRight.Location = new Point(3, 34);
            btnFlipLeftRight.Name = "btnFlipLeftRight";
            btnFlipLeftRight.Size = new Size(68, 25);
            btnFlipLeftRight.TabIndex = 1;
            btnFlipLeftRight.Text = "Left";
            btnFlipLeftRight.UseVisualStyleBackColor = true;
            // 
            // grpBoxBtnsSaveUndo
            // 
            grpBoxBtnsSaveUndo.AutoSize = true;
            grpBoxBtnsSaveUndo.Controls.Add(flp4UndoSave);
            grpBoxBtnsSaveUndo.Dock = DockStyle.Fill;
            grpBoxBtnsSaveUndo.Location = new Point(3, 707);
            grpBoxBtnsSaveUndo.Name = "grpBoxBtnsSaveUndo";
            grpBoxBtnsSaveUndo.Padding = new Padding(10);
            grpBoxBtnsSaveUndo.Size = new Size(290, 68);
            grpBoxBtnsSaveUndo.TabIndex = 11;
            grpBoxBtnsSaveUndo.TabStop = false;
            grpBoxBtnsSaveUndo.Text = "Undo or Save";
            // 
            // flp4UndoSave
            // 
            flp4UndoSave.AutoScroll = true;
            flp4UndoSave.AutoSize = true;
            flp4UndoSave.Controls.Add(btnUndo);
            flp4UndoSave.Controls.Add(btnClear);
            flp4UndoSave.Controls.Add(btnSave);
            flp4UndoSave.Dock = DockStyle.Fill;
            flp4UndoSave.FlowDirection = FlowDirection.TopDown;
            flp4UndoSave.Location = new Point(10, 26);
            flp4UndoSave.MinimumSize = new Size(270, 32);
            flp4UndoSave.Name = "flp4UndoSave";
            flp4UndoSave.Size = new Size(270, 32);
            flp4UndoSave.TabIndex = 3;
            // 
            // btnUndo
            // 
            btnUndo.AutoSize = true;
            btnUndo.Location = new Point(3, 3);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(75, 25);
            btnUndo.TabIndex = 1;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.AutoSize = true;
            btnClear.Location = new Point(84, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(109, 25);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear all  changes";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Location = new Point(199, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(68, 25);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // panelPic
            // 
            panelPic.AutoScroll = true;
            panelPic.Controls.Add(pictureBoxPic);
            panelPic.Dock = DockStyle.Fill;
            panelPic.Location = new Point(0, 24);
            panelPic.Name = "panelPic";
            panelPic.Size = new Size(837, 778);
            panelPic.TabIndex = 2;
            // 
            // EditImage
            // 
            AccessibleName = "Edit Image";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPic);
            Controls.Add(tlpOptions);
            Controls.Add(menuStrip1);
            Name = "EditImage";
            Size = new Size(1133, 802);
            Load += EditImage_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPic).EndInit();
            tlpOptions.ResumeLayout(false);
            tlpOptions.PerformLayout();
            grpBoxBrightness.ResumeLayout(false);
            grpBoxBrightness.PerformLayout();
            grpBoxShapes.ResumeLayout(false);
            grpBoxShapes.PerformLayout();
            flp4GrpBoxShape.ResumeLayout(false);
            flp4GrpBoxShape.PerformLayout();
            grpBoxDesc.ResumeLayout(false);
            flp4GrpBoxDesc.ResumeLayout(false);
            flp4GrpBoxDesc.PerformLayout();
            grpBoxFilter.ResumeLayout(false);
            panel4grpBoxFilter.ResumeLayout(false);
            panel4grpBoxFilter.PerformLayout();
            grpBoxColors.ResumeLayout(false);
            grpBoxColors.PerformLayout();
            flp4grpboxColors.ResumeLayout(false);
            flp4grpboxColors.PerformLayout();
            grpBoxFlip.ResumeLayout(false);
            grpBoxFlip.PerformLayout();
            flp4GrpBoxFlip.ResumeLayout(false);
            flp4GrpBoxFlip.PerformLayout();
            grpBoxBtnsSaveUndo.ResumeLayout(false);
            grpBoxBtnsSaveUndo.PerformLayout();
            flp4UndoSave.ResumeLayout(false);
            flp4UndoSave.PerformLayout();
            panelPic.ResumeLayout(false);
            panelPic.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem goBackToolStripMenuItem;
        private PictureBox pictureBoxPic;
        private TableLayoutPanel tlpOptions;
        private Panel panelPic;
        private Button btnClear;
        private Button btnUndo;
        private Button btnSave;
        private GroupBox grpBoxFilter;
        private GroupBox grpBoxFlip;
        private Button btnFilter;
        private LinkLabel linkLabelRandomColors;
        private Label lblColor2;
        private Label lblColor1;
        private GroupBox grpBoxBrightness;
        private GroupBox grpBoxShapes;
        private TextBox txtBoxCustomSize;
        private Button btnApplyShape;
        private ComboBox comboBoxShapeSize;
        private ComboBox comboBoxShape;
        private GroupBox grpBoxDesc;
        private Label lblImgeDesc;
        private Button btnApplyDesc;
        private TextBox textBoxDesc;
        private GroupBox grpBoxColors;
        private GroupBox grpBoxBtnsSaveUndo;
        private Button btnFlipLeftRight;
        private Button btnFlipUpDown;
        private Panel panel4grpBoxFilter;
        private FlowLayoutPanel flp4grpboxColors;
        private FlowLayoutPanel flp4GrpBoxFlip;
        private FlowLayoutPanel flp4UndoSave;
        private FlowLayoutPanel flp4GrpBoxShape;
        private FlowLayoutPanel flp4GrpBoxDesc;
        private FlowLayoutPanel flp4GrpBoxBrightness;
    }
}
