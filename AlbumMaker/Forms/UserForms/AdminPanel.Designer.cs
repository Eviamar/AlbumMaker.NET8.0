namespace AlbumMaker.Forms.UserForms
{
    partial class AdminPanel
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
            flpUsers = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flpUsers
            // 
            flpUsers.Dock = DockStyle.Fill;
            flpUsers.Location = new Point(0, 0);
            flpUsers.Name = "flpUsers";
            flpUsers.Size = new Size(410, 326);
            flpUsers.TabIndex = 0;
            // 
            // AdminPanel
            // 
            AccessibleName = "Admin panel";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flpUsers);
            Name = "AdminPanel";
            Size = new Size(410, 326);
            Load += AdminPanel_Load;
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpUsers;
    }
}
