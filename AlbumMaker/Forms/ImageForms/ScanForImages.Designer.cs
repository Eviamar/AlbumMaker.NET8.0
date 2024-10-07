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
            components = new System.ComponentModel.Container();
            flowLayoutPanelDrives = new FlowLayoutPanel();
            labelDrives = new Label();
            progressBarScanning = new ProgressBar();
            panelDisplay = new Panel();
            dataGridView1 = new DataGridView();
            panelFilter = new Panel();
            btnAdd = new Button();
            btnFilter = new Button();
            dateTimePicker1 = new DateTimePicker();
            flpSelectedImages = new FlowLayoutPanel();
            menuStrip1 = new MenuStrip();
            goBackToolStripMenuItem = new ToolStripMenuItem();
            fileItemBindingSource3 = new BindingSource(components);
            fileItemBindingSource1 = new BindingSource(components);
            fileItemBindingSource = new BindingSource(components);
            fileItemBindingSource2 = new BindingSource(components);
            flowLayoutPanelDrives.SuspendLayout();
            panelDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelFilter.SuspendLayout();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource2).BeginInit();
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
            panelDisplay.Controls.Add(panelFilter);
            panelDisplay.Controls.Add(flpSelectedImages);
            panelDisplay.Controls.Add(menuStrip1);
            panelDisplay.Dock = DockStyle.Fill;
            panelDisplay.Location = new Point(0, 0);
            panelDisplay.Name = "panelDisplay";
            panelDisplay.Size = new Size(321, 283);
            panelDisplay.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 24);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(195, 139);
            dataGridView1.TabIndex = 4;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(btnAdd);
            panelFilter.Controls.Add(btnFilter);
            panelFilter.Controls.Add(dateTimePicker1);
            panelFilter.Dock = DockStyle.Right;
            panelFilter.Location = new Point(195, 24);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(126, 139);
            panelFilter.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(6, 110);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(114, 23);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add selected";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnFilter
            // 
            btnFilter.Location = new Point(6, 32);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new Size(75, 23);
            btnFilter.TabIndex = 1;
            btnFilter.Text = "Filter";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(6, 3);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(114, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // flpSelectedImages
            // 
            flpSelectedImages.AutoScroll = true;
            flpSelectedImages.Dock = DockStyle.Bottom;
            flpSelectedImages.Location = new Point(0, 163);
            flpSelectedImages.Name = "flpSelectedImages";
            flpSelectedImages.Size = new Size(321, 120);
            flpSelectedImages.TabIndex = 1;
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
            // fileItemBindingSource3
            // 
            fileItemBindingSource3.DataSource = typeof(Classes.Items.FileItem);
            // 
            // fileItemBindingSource1
            // 
            fileItemBindingSource1.DataSource = typeof(Classes.Items.FileItem);
            // 
            // fileItemBindingSource
            // 
            fileItemBindingSource.DataSource = typeof(Classes.Items.FileItem);
            // 
            // fileItemBindingSource2
            // 
            fileItemBindingSource2.DataSource = typeof(Classes.Items.FileItem);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelFilter.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource3).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)fileItemBindingSource2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanelDrives;
        private Label labelDrives;
        private ProgressBar progressBarScanning;
        private Panel panelDisplay;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem goBackToolStripMenuItem;
        private BindingSource fileItemBindingSource1;
        private BindingSource fileItemBindingSource;
        private BindingSource fileItemBindingSource2;
        private BindingSource fileItemBindingSource3;
        private FlowLayoutPanel flpSelectedImages;
        private Panel panelFilter;
        private DateTimePicker dateTimePicker1;
        private Button btnAdd;
        private Button btnFilter;
        private DataGridView dataGridView1;
    }
}
