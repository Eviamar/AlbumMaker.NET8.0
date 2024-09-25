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
            panelOptions = new Panel();
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
            flp4GrpBoxColors = new FlowLayoutPanel();
            lblColor1 = new Label();
            lblColor2 = new Label();
            linkLabelRandomColors = new LinkLabel();
            btnFilter = new Button();
            grpBoxFlip = new GroupBox();
            flp4GrpBoxFlip = new FlowLayoutPanel();
            btnFlipUpDown = new Button();
            btnFlipLeftRight = new Button();
            grpBoxBtnsSaveUndo = new GroupBox();
            flp4GrpBoxUndoSave = new FlowLayoutPanel();
            btnUndo = new Button();
            btnRedo = new Button();
            btnClear = new Button();
            btnSave = new Button();
            pictureBoxPic = new PictureBox();
            panelPic = new Panel();
            menuStrip1.SuspendLayout();
            panelOptions.SuspendLayout();
            tlpOptions.SuspendLayout();
            grpBoxBrightness.SuspendLayout();
            grpBoxShapes.SuspendLayout();
            flp4GrpBoxShape.SuspendLayout();
            grpBoxDesc.SuspendLayout();
            flp4GrpBoxDesc.SuspendLayout();
            grpBoxFilter.SuspendLayout();
            panel4grpBoxFilter.SuspendLayout();
            grpBoxColors.SuspendLayout();
            flp4GrpBoxColors.SuspendLayout();
            grpBoxFlip.SuspendLayout();
            flp4GrpBoxFlip.SuspendLayout();
            grpBoxBtnsSaveUndo.SuspendLayout();
            flp4GrpBoxUndoSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPic).BeginInit();
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
            // panelOptions
            // 
            panelOptions.AutoScroll = true;
            panelOptions.Controls.Add(tlpOptions);
            panelOptions.Dock = DockStyle.Right;
            panelOptions.Location = new Point(806, 24);
            panelOptions.Name = "panelOptions";
            panelOptions.Size = new Size(327, 778);
            panelOptions.TabIndex = 1;
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
            tlpOptions.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tlpOptions.Location = new Point(6, 3);
            tlpOptions.Name = "tlpOptions";
            tlpOptions.RowCount = 5;
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpOptions.Size = new Size(303, 790);
            tlpOptions.TabIndex = 1;
            // 
            // grpBoxBrightness
            // 
            grpBoxBrightness.Controls.Add(flp4GrpBoxBrightness);
            grpBoxBrightness.Dock = DockStyle.Fill;
            grpBoxBrightness.Location = new Point(3, 319);
            grpBoxBrightness.Name = "grpBoxBrightness";
            grpBoxBrightness.Size = new Size(297, 152);
            grpBoxBrightness.TabIndex = 8;
            grpBoxBrightness.TabStop = false;
            grpBoxBrightness.Text = "Brightness";
            // 
            // flp4GrpBoxBrightness
            // 
            flp4GrpBoxBrightness.AutoScroll = true;
            flp4GrpBoxBrightness.Dock = DockStyle.Fill;
            flp4GrpBoxBrightness.FlowDirection = FlowDirection.TopDown;
            flp4GrpBoxBrightness.Location = new Point(3, 19);
            flp4GrpBoxBrightness.Name = "flp4GrpBoxBrightness";
            flp4GrpBoxBrightness.Size = new Size(291, 130);
            flp4GrpBoxBrightness.TabIndex = 1;
            // 
            // grpBoxShapes
            // 
            grpBoxShapes.Controls.Add(flp4GrpBoxShape);
            grpBoxShapes.Dock = DockStyle.Fill;
            grpBoxShapes.Location = new Point(3, 161);
            grpBoxShapes.Name = "grpBoxShapes";
            grpBoxShapes.Size = new Size(297, 152);
            grpBoxShapes.TabIndex = 7;
            grpBoxShapes.TabStop = false;
            grpBoxShapes.Text = "Shape";
            // 
            // flp4GrpBoxShape
            // 
            flp4GrpBoxShape.AutoScroll = true;
            flp4GrpBoxShape.Controls.Add(comboBoxShape);
            flp4GrpBoxShape.Controls.Add(comboBoxShapeSize);
            flp4GrpBoxShape.Controls.Add(txtBoxCustomSize);
            flp4GrpBoxShape.Controls.Add(btnApplyShape);
            flp4GrpBoxShape.Dock = DockStyle.Fill;
            flp4GrpBoxShape.Location = new Point(3, 19);
            flp4GrpBoxShape.Name = "flp4GrpBoxShape";
            flp4GrpBoxShape.Size = new Size(291, 130);
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
            grpBoxDesc.Controls.Add(flp4GrpBoxDesc);
            grpBoxDesc.Dock = DockStyle.Fill;
            grpBoxDesc.Location = new Point(3, 477);
            grpBoxDesc.Name = "grpBoxDesc";
            grpBoxDesc.Padding = new Padding(10);
            grpBoxDesc.RightToLeft = RightToLeft.No;
            grpBoxDesc.Size = new Size(297, 152);
            grpBoxDesc.TabIndex = 10;
            grpBoxDesc.TabStop = false;
            grpBoxDesc.Text = "Image Description";
            // 
            // flp4GrpBoxDesc
            // 
            flp4GrpBoxDesc.AutoScroll = true;
            flp4GrpBoxDesc.Controls.Add(textBoxDesc);
            flp4GrpBoxDesc.Controls.Add(lblImgeDesc);
            flp4GrpBoxDesc.Controls.Add(btnApplyDesc);
            flp4GrpBoxDesc.Dock = DockStyle.Fill;
            flp4GrpBoxDesc.Location = new Point(10, 26);
            flp4GrpBoxDesc.Name = "flp4GrpBoxDesc";
            flp4GrpBoxDesc.Size = new Size(277, 116);
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
            lblImgeDesc.Location = new Point(203, 0);
            lblImgeDesc.Name = "lblImgeDesc";
            lblImgeDesc.Size = new Size(67, 15);
            lblImgeDesc.TabIndex = 2;
            lblImgeDesc.Text = "image desc";
            // 
            // btnApplyDesc
            // 
            btnApplyDesc.AutoSize = true;
            btnApplyDesc.Location = new Point(3, 32);
            btnApplyDesc.Name = "btnApplyDesc";
            btnApplyDesc.Size = new Size(75, 25);
            btnApplyDesc.TabIndex = 1;
            btnApplyDesc.Text = "Apply ";
            btnApplyDesc.UseVisualStyleBackColor = true;
            // 
            // grpBoxFilter
            // 
            grpBoxFilter.Controls.Add(panel4grpBoxFilter);
            grpBoxFilter.Dock = DockStyle.Fill;
            grpBoxFilter.Location = new Point(3, 3);
            grpBoxFilter.Name = "grpBoxFilter";
            grpBoxFilter.Size = new Size(297, 152);
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
            panel4grpBoxFilter.Size = new Size(291, 130);
            panel4grpBoxFilter.TabIndex = 0;
            // 
            // grpBoxColors
            // 
            grpBoxColors.Controls.Add(flp4GrpBoxColors);
            grpBoxColors.Dock = DockStyle.Fill;
            grpBoxColors.Location = new Point(0, 0);
            grpBoxColors.Name = "grpBoxColors";
            grpBoxColors.Size = new Size(167, 130);
            grpBoxColors.TabIndex = 0;
            grpBoxColors.TabStop = false;
            grpBoxColors.Text = "Colors";
            // 
            // flp4GrpBoxColors
            // 
            flp4GrpBoxColors.AutoScroll = true;
            flp4GrpBoxColors.AutoSize = true;
            flp4GrpBoxColors.Controls.Add(lblColor1);
            flp4GrpBoxColors.Controls.Add(lblColor2);
            flp4GrpBoxColors.Controls.Add(linkLabelRandomColors);
            flp4GrpBoxColors.Controls.Add(btnFilter);
            flp4GrpBoxColors.Dock = DockStyle.Fill;
            flp4GrpBoxColors.Location = new Point(3, 19);
            flp4GrpBoxColors.Name = "flp4GrpBoxColors";
            flp4GrpBoxColors.Size = new Size(161, 108);
            flp4GrpBoxColors.TabIndex = 0;
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
            lblColor1.Click += lblColor1_Click;
            // 
            // lblColor2
            // 
            lblColor2.AutoEllipsis = true;
            lblColor2.AutoSize = true;
            lblColor2.Location = new Point(54, 0);
            lblColor2.Name = "lblColor2";
            lblColor2.Size = new Size(45, 15);
            lblColor2.TabIndex = 1;
            lblColor2.Text = "Color 2";
            lblColor2.TextAlign = ContentAlignment.MiddleCenter;
            lblColor2.Click += lblColor2_Click;
            // 
            // linkLabelRandomColors
            // 
            linkLabelRandomColors.ActiveLinkColor = Color.Crimson;
            linkLabelRandomColors.AutoEllipsis = true;
            linkLabelRandomColors.AutoSize = true;
            linkLabelRandomColors.Location = new Point(105, 0);
            linkLabelRandomColors.Name = "linkLabelRandomColors";
            linkLabelRandomColors.Size = new Size(52, 15);
            linkLabelRandomColors.TabIndex = 2;
            linkLabelRandomColors.TabStop = true;
            linkLabelRandomColors.Text = "Random";
            linkLabelRandomColors.TextAlign = ContentAlignment.MiddleCenter;
            linkLabelRandomColors.LinkClicked += linkLabelRandomColors_LinkClicked;
            // 
            // btnFilter
            // 
            btnFilter.AutoSize = true;
            btnFilter.Location = new Point(3, 18);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(85, 25);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Active filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // grpBoxFlip
            // 
            grpBoxFlip.AutoSize = true;
            grpBoxFlip.Controls.Add(flp4GrpBoxFlip);
            grpBoxFlip.Dock = DockStyle.Right;
            grpBoxFlip.Location = new Point(167, 0);
            grpBoxFlip.Name = "grpBoxFlip";
            grpBoxFlip.Size = new Size(124, 130);
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
            flp4GrpBoxFlip.Location = new Point(3, 19);
            flp4GrpBoxFlip.Name = "flp4GrpBoxFlip";
            flp4GrpBoxFlip.Size = new Size(118, 108);
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
            btnFlipLeftRight.Location = new Point(47, 3);
            btnFlipLeftRight.Name = "btnFlipLeftRight";
            btnFlipLeftRight.Size = new Size(68, 25);
            btnFlipLeftRight.TabIndex = 1;
            btnFlipLeftRight.Text = "Left";
            btnFlipLeftRight.UseVisualStyleBackColor = true;
            // 
            // grpBoxBtnsSaveUndo
            // 
            grpBoxBtnsSaveUndo.Controls.Add(flp4GrpBoxUndoSave);
            grpBoxBtnsSaveUndo.Dock = DockStyle.Fill;
            grpBoxBtnsSaveUndo.Location = new Point(3, 635);
            grpBoxBtnsSaveUndo.Name = "grpBoxBtnsSaveUndo";
            grpBoxBtnsSaveUndo.Size = new Size(297, 152);
            grpBoxBtnsSaveUndo.TabIndex = 11;
            grpBoxBtnsSaveUndo.TabStop = false;
            grpBoxBtnsSaveUndo.Text = "Undo or Save";
            // 
            // flp4GrpBoxUndoSave
            // 
            flp4GrpBoxUndoSave.AutoScroll = true;
            flp4GrpBoxUndoSave.Controls.Add(btnUndo);
            flp4GrpBoxUndoSave.Controls.Add(btnRedo);
            flp4GrpBoxUndoSave.Controls.Add(btnClear);
            flp4GrpBoxUndoSave.Controls.Add(btnSave);
            flp4GrpBoxUndoSave.Dock = DockStyle.Fill;
            flp4GrpBoxUndoSave.Location = new Point(3, 19);
            flp4GrpBoxUndoSave.MinimumSize = new Size(270, 32);
            flp4GrpBoxUndoSave.Name = "flp4GrpBoxUndoSave";
            flp4GrpBoxUndoSave.Padding = new Padding(3);
            flp4GrpBoxUndoSave.Size = new Size(291, 130);
            flp4GrpBoxUndoSave.TabIndex = 3;
            // 
            // btnUndo
            // 
            btnUndo.AutoSize = true;
            btnUndo.Location = new Point(6, 6);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(75, 25);
            btnUndo.TabIndex = 1;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnRedo
            // 
            btnRedo.AutoSize = true;
            btnRedo.Location = new Point(87, 6);
            btnRedo.Name = "btnRedo";
            btnRedo.Size = new Size(75, 25);
            btnRedo.TabIndex = 3;
            btnRedo.Text = "Redo";
            btnRedo.UseVisualStyleBackColor = true;
            btnRedo.Click += btnRedo_Click;
            // 
            // btnClear
            // 
            btnClear.AutoSize = true;
            btnClear.Location = new Point(168, 6);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(109, 25);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear all  changes";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.AutoSize = true;
            btnSave.Location = new Point(6, 37);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(68, 25);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPic
            // 
            pictureBoxPic.Location = new Point(3, 6);
            pictureBoxPic.Name = "pictureBoxPic";
            pictureBoxPic.Size = new Size(325, 325);
            pictureBoxPic.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxPic.TabIndex = 0;
            pictureBoxPic.TabStop = false;
            // 
            // panelPic
            // 
            panelPic.AutoSize = true;
            panelPic.Controls.Add(pictureBoxPic);
            panelPic.Dock = DockStyle.Fill;
            panelPic.Location = new Point(0, 24);
            panelPic.Name = "panelPic";
            panelPic.Size = new Size(806, 778);
            panelPic.TabIndex = 2;
            // 
            // EditImage
            // 
            AccessibleName = "Edit Image";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPic);
            Controls.Add(panelOptions);
            Controls.Add(menuStrip1);
            Name = "EditImage";
            Size = new Size(1133, 802);
            Load += EditImage_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelOptions.ResumeLayout(false);
            panelOptions.PerformLayout();
            tlpOptions.ResumeLayout(false);
            grpBoxBrightness.ResumeLayout(false);
            grpBoxShapes.ResumeLayout(false);
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
            flp4GrpBoxColors.ResumeLayout(false);
            flp4GrpBoxColors.PerformLayout();
            grpBoxFlip.ResumeLayout(false);
            grpBoxFlip.PerformLayout();
            flp4GrpBoxFlip.ResumeLayout(false);
            flp4GrpBoxFlip.PerformLayout();
            grpBoxBtnsSaveUndo.ResumeLayout(false);
            flp4GrpBoxUndoSave.ResumeLayout(false);
            flp4GrpBoxUndoSave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPic).EndInit();
            panelPic.ResumeLayout(false);
            panelPic.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem goBackToolStripMenuItem;
        private Panel panelOptions;
        private TableLayoutPanel tlpOptions;
        private GroupBox grpBoxBrightness;
        private FlowLayoutPanel flp4GrpBoxBrightness;
        private GroupBox grpBoxShapes;
        private FlowLayoutPanel flp4GrpBoxShape;
        private ComboBox comboBoxShape;
        private ComboBox comboBoxShapeSize;
        private TextBox txtBoxCustomSize;
        private Button btnApplyShape;
        private GroupBox grpBoxDesc;
        private FlowLayoutPanel flp4GrpBoxDesc;
        private TextBox textBoxDesc;
        private Label lblImgeDesc;
        private Button btnApplyDesc;
        private GroupBox grpBoxFilter;
        private Panel panel4grpBoxFilter;
        private GroupBox grpBoxColors;
        private FlowLayoutPanel flp4GrpBoxColors;
        private Label lblColor1;
        private Label lblColor2;
        private LinkLabel linkLabelRandomColors;
        private Button btnFilter;
        private GroupBox grpBoxFlip;
        private FlowLayoutPanel flp4GrpBoxFlip;
        private Button btnFlipUpDown;
        private Button btnFlipLeftRight;
        private GroupBox grpBoxBtnsSaveUndo;
        private FlowLayoutPanel flp4GrpBoxUndoSave;
        private Button btnUndo;
        private Button btnClear;
        private Button btnSave;
        private PictureBox pictureBoxPic;
        private Panel panelPic;
        private Button btnRedo;
    }
}
