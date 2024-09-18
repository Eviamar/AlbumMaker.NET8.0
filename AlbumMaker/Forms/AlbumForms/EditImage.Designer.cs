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
            panelPic = new Panel();
            pictureBoxPic = new PictureBox();
            panelOptions = new Panel();
            grpBoxButtons = new GroupBox();
            btnClear = new Button();
            btnUndo = new Button();
            btnSave = new Button();
            grpBoxDesc = new GroupBox();
            lblImgeDesc = new Label();
            btnApplyDesc = new Button();
            textBox1 = new TextBox();
            grpBoxFlip = new GroupBox();
            grpBoxBrightness = new GroupBox();
            grpBoxShapes = new GroupBox();
            txtBoxCustomSize = new TextBox();
            btnApplyShape = new Button();
            comboBoxShapeSize = new ComboBox();
            comboBoxShape = new ComboBox();
            grpBoxColors = new GroupBox();
            btnFilter = new Button();
            lblColor1 = new Label();
            lblColor2 = new Label();
            linkLabel1 = new LinkLabel();
            menuStrip1.SuspendLayout();
            panelPic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPic).BeginInit();
            panelOptions.SuspendLayout();
            grpBoxButtons.SuspendLayout();
            grpBoxDesc.SuspendLayout();
            grpBoxShapes.SuspendLayout();
            grpBoxColors.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { goBackToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(683, 24);
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
            // panelPic
            // 
            panelPic.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPic.AutoScroll = true;
            panelPic.Controls.Add(pictureBoxPic);
            panelPic.Location = new Point(0, 27);
            panelPic.Name = "panelPic";
            panelPic.Size = new Size(357, 399);
            panelPic.TabIndex = 1;
            // 
            // pictureBoxPic
            // 
            pictureBoxPic.Location = new Point(19, 14);
            pictureBoxPic.Name = "pictureBoxPic";
            pictureBoxPic.Size = new Size(269, 375);
            pictureBoxPic.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxPic.TabIndex = 0;
            pictureBoxPic.TabStop = false;
            // 
            // panelOptions
            // 
            panelOptions.AutoScroll = true;
            panelOptions.BorderStyle = BorderStyle.Fixed3D;
            panelOptions.Controls.Add(grpBoxButtons);
            panelOptions.Controls.Add(grpBoxDesc);
            panelOptions.Controls.Add(grpBoxFlip);
            panelOptions.Controls.Add(grpBoxBrightness);
            panelOptions.Controls.Add(grpBoxShapes);
            panelOptions.Controls.Add(grpBoxColors);
            panelOptions.Location = new Point(428, 27);
            panelOptions.MaximumSize = new Size(600, 800);
            panelOptions.MinimumSize = new Size(220, 407);
            panelOptions.Name = "panelOptions";
            panelOptions.Size = new Size(248, 407);
            panelOptions.TabIndex = 2;
            // 
            // grpBoxButtons
            // 
            grpBoxButtons.Controls.Add(btnClear);
            grpBoxButtons.Controls.Add(btnUndo);
            grpBoxButtons.Controls.Add(btnSave);
            grpBoxButtons.Location = new Point(9, 328);
            grpBoxButtons.Name = "grpBoxButtons";
            grpBoxButtons.Size = new Size(205, 69);
            grpBoxButtons.TabIndex = 5;
            grpBoxButtons.TabStop = false;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(91, 15);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(109, 25);
            btnClear.TabIndex = 2;
            btnClear.Text = "Clear all  changes";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(6, 15);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(75, 23);
            btnUndo.TabIndex = 1;
            btnUndo.Text = "Undo";
            btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(124, 46);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // grpBoxDesc
            // 
            grpBoxDesc.Controls.Add(lblImgeDesc);
            grpBoxDesc.Controls.Add(btnApplyDesc);
            grpBoxDesc.Controls.Add(textBox1);
            grpBoxDesc.Location = new Point(9, 243);
            grpBoxDesc.Name = "grpBoxDesc";
            grpBoxDesc.Size = new Size(205, 81);
            grpBoxDesc.TabIndex = 4;
            grpBoxDesc.TabStop = false;
            grpBoxDesc.Text = "Image description";
            // 
            // lblImgeDesc
            // 
            lblImgeDesc.AutoSize = true;
            lblImgeDesc.Location = new Point(6, 48);
            lblImgeDesc.Name = "lblImgeDesc";
            lblImgeDesc.Size = new Size(67, 15);
            lblImgeDesc.TabIndex = 2;
            lblImgeDesc.Text = "image desc";
            // 
            // btnApplyDesc
            // 
            btnApplyDesc.Location = new Point(124, 51);
            btnApplyDesc.Name = "btnApplyDesc";
            btnApplyDesc.Size = new Size(75, 23);
            btnApplyDesc.TabIndex = 1;
            btnApplyDesc.Text = "Apply ";
            btnApplyDesc.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 22);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Image description";
            textBox1.Size = new Size(194, 23);
            textBox1.TabIndex = 0;
            // 
            // grpBoxFlip
            // 
            grpBoxFlip.Location = new Point(133, 3);
            grpBoxFlip.Name = "grpBoxFlip";
            grpBoxFlip.Size = new Size(94, 85);
            grpBoxFlip.TabIndex = 3;
            grpBoxFlip.TabStop = false;
            grpBoxFlip.Text = "Flip";
            // 
            // grpBoxBrightness
            // 
            grpBoxBrightness.Location = new Point(9, 186);
            grpBoxBrightness.Name = "grpBoxBrightness";
            grpBoxBrightness.Size = new Size(205, 51);
            grpBoxBrightness.TabIndex = 2;
            grpBoxBrightness.TabStop = false;
            grpBoxBrightness.Text = "Brightness";
            // 
            // grpBoxShapes
            // 
            grpBoxShapes.Controls.Add(txtBoxCustomSize);
            grpBoxShapes.Controls.Add(btnApplyShape);
            grpBoxShapes.Controls.Add(comboBoxShapeSize);
            grpBoxShapes.Controls.Add(comboBoxShape);
            grpBoxShapes.Location = new Point(9, 94);
            grpBoxShapes.Name = "grpBoxShapes";
            grpBoxShapes.Size = new Size(217, 82);
            grpBoxShapes.TabIndex = 1;
            grpBoxShapes.TabStop = false;
            grpBoxShapes.Text = "Shape";
            // 
            // txtBoxCustomSize
            // 
            txtBoxCustomSize.Location = new Point(123, 23);
            txtBoxCustomSize.Name = "txtBoxCustomSize";
            txtBoxCustomSize.PlaceholderText = "Custom size";
            txtBoxCustomSize.Size = new Size(85, 23);
            txtBoxCustomSize.TabIndex = 3;
            // 
            // btnApplyShape
            // 
            btnApplyShape.Location = new Point(123, 50);
            btnApplyShape.Name = "btnApplyShape";
            btnApplyShape.Size = new Size(85, 23);
            btnApplyShape.TabIndex = 2;
            btnApplyShape.Text = "Apply";
            btnApplyShape.UseVisualStyleBackColor = true;
            // 
            // comboBoxShapeSize
            // 
            comboBoxShapeSize.FormattingEnabled = true;
            comboBoxShapeSize.Location = new Point(9, 51);
            comboBoxShapeSize.Name = "comboBoxShapeSize";
            comboBoxShapeSize.Size = new Size(108, 23);
            comboBoxShapeSize.TabIndex = 1;
            // 
            // comboBoxShape
            // 
            comboBoxShape.FormattingEnabled = true;
            comboBoxShape.Location = new Point(9, 23);
            comboBoxShape.Name = "comboBoxShape";
            comboBoxShape.Size = new Size(108, 23);
            comboBoxShape.TabIndex = 0;
            // 
            // grpBoxColors
            // 
            grpBoxColors.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpBoxColors.Controls.Add(btnFilter);
            grpBoxColors.Controls.Add(lblColor1);
            grpBoxColors.Controls.Add(lblColor2);
            grpBoxColors.Controls.Add(linkLabel1);
            grpBoxColors.Location = new Point(9, 7);
            grpBoxColors.Name = "grpBoxColors";
            grpBoxColors.Size = new Size(117, 81);
            grpBoxColors.TabIndex = 0;
            grpBoxColors.TabStop = false;
            grpBoxColors.Text = "Colors";
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(9, 52);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(93, 25);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Active filter";
            btnFilter.UseVisualStyleBackColor = true;
            // 
            // lblColor1
            // 
            lblColor1.Location = new Point(6, 19);
            lblColor1.Name = "lblColor1";
            lblColor1.Size = new Size(45, 15);
            lblColor1.TabIndex = 0;
            lblColor1.Text = "Color 1";
            lblColor1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblColor2
            // 
            lblColor2.Location = new Point(57, 19);
            lblColor2.Name = "lblColor2";
            lblColor2.Size = new Size(45, 15);
            lblColor2.TabIndex = 1;
            lblColor2.Text = "Color 2";
            lblColor2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.Crimson;
            linkLabel1.Location = new Point(24, 34);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(52, 15);
            linkLabel1.TabIndex = 2;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Random";
            linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // EditImage
            // 
            AccessibleName = "Edit Image";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelOptions);
            Controls.Add(panelPic);
            Controls.Add(menuStrip1);
            Name = "EditImage";
            Size = new Size(683, 431);
            Load += EditImage_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelPic.ResumeLayout(false);
            panelPic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPic).EndInit();
            panelOptions.ResumeLayout(false);
            grpBoxButtons.ResumeLayout(false);
            grpBoxDesc.ResumeLayout(false);
            grpBoxDesc.PerformLayout();
            grpBoxShapes.ResumeLayout(false);
            grpBoxShapes.PerformLayout();
            grpBoxColors.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem goBackToolStripMenuItem;
        private Panel panelPic;
        private PictureBox pictureBoxPic;
        private Panel panelOptions;
        private GroupBox grpBoxShapes;
        private ComboBox comboBoxShape;
        private GroupBox grpBoxColors;
        private ComboBox comboBoxShapeSize;
        private GroupBox grpBoxButtons;
        private Button btnClear;
        private Button btnUndo;
        private Button btnSave;
        private GroupBox grpBoxDesc;
        private GroupBox grpBoxFlip;
        private GroupBox grpBoxBrightness;
        private Label lblImgeDesc;
        private Button btnApplyDesc;
        private TextBox textBox1;
        private Button btnFilter;
        private LinkLabel linkLabel1;
        private Label lblColor2;
        private Label lblColor1;
        private TextBox txtBoxCustomSize;
        private Button btnApplyShape;
    }
}
