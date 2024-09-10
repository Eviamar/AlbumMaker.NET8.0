namespace AlbumMaker.Forms
{
    partial class ScanForImages
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
            flowLayoutPanelDrives = new FlowLayoutPanel();
            labelDrives = new Label();
            progressBarScanning = new ProgressBar();
            panelDisplay = new Panel();
            menuStrip1 = new MenuStrip();
            goBackToolStripMenuItem = new ToolStripMenuItem();
            dataGridView1 = new DataGridView();
            flowLayoutPanelDrives.SuspendLayout();
            panelDisplay.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // flowLayoutPanelDrives
            // 
            flowLayoutPanelDrives.Controls.Add(labelDrives);
            flowLayoutPanelDrives.Dock = DockStyle.Right;
            flowLayoutPanelDrives.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelDrives.Location = new Point(321, 0);
            flowLayoutPanelDrives.Name = "flowLayoutPanelDrives";
            flowLayoutPanelDrives.Size = new Size(92, 306);
            flowLayoutPanelDrives.TabIndex = 1;
            // 
            // labelDrives
            // 
            labelDrives.AutoSize = true;
            labelDrives.Location = new Point(3, 0);
            labelDrives.Name = "labelDrives";
            labelDrives.Size = new Size(68, 15);
            labelDrives.TabIndex = 0;
            labelDrives.Text = "Your drives:";
            // 
            // progressBarScanning
            // 
            progressBarScanning.Dock = DockStyle.Bottom;
            progressBarScanning.Location = new Point(0, 283);
            progressBarScanning.Name = "progressBarScanning";
            progressBarScanning.Size = new Size(321, 23);
            progressBarScanning.TabIndex = 1;
            progressBarScanning.Visible = false;
            // 
            // panelDisplay
            // 
            panelDisplay.Controls.Add(dataGridView1);
            panelDisplay.Controls.Add(menuStrip1);
            panelDisplay.Dock = DockStyle.Fill;
            panelDisplay.Location = new Point(0, 0);
            panelDisplay.Name = "panelDisplay";
            panelDisplay.Size = new Size(321, 283);
            panelDisplay.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { goBackToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(321, 24);
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
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(321, 259);
            dataGridView1.TabIndex = 0;
            // 
            // ScanForImages
            // 
            AccessibleName = "Scan images";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelDisplay);
            Controls.Add(progressBarScanning);
            Controls.Add(flowLayoutPanelDrives);
            Name = "ScanForImages";
            Size = new Size(413, 306);
            Load += ScanForImages_Load;
            Leave += ScanForImages_Leave;
            flowLayoutPanelDrives.ResumeLayout(false);
            flowLayoutPanelDrives.PerformLayout();
            panelDisplay.ResumeLayout(false);
            panelDisplay.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanelDrives;
        private Label labelDrives;
        private ProgressBar progressBarScanning;
        private Panel panelDisplay;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem goBackToolStripMenuItem;
        private DataGridView dataGridView1;
    }
}
