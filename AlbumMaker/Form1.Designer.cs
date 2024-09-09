namespace AlbumMaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            flpMenu = new FlowLayoutPanel();
            panelMenu = new Panel();
            btnMenuToggle = new Button();
            btnLogin = new Button();
            btnMyAlbums = new Button();
            btnUserControlPanel = new Button();
            btnSettings = new Button();
            btnLogout = new Button();
            btnExit = new Button();
            timerMenuToggle = new System.Windows.Forms.Timer(components);
            panelMain = new Panel();
            timerCheckUserLoggedIn = new System.Windows.Forms.Timer(components);
            flpMenu.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // flpMenu
            // 
            flpMenu.BackColor = SystemColors.ControlDark;
            flpMenu.BorderStyle = BorderStyle.FixedSingle;
            flpMenu.Controls.Add(panelMenu);
            flpMenu.Controls.Add(btnLogin);
            flpMenu.Controls.Add(btnMyAlbums);
            flpMenu.Controls.Add(btnUserControlPanel);
            flpMenu.Controls.Add(btnSettings);
            flpMenu.Controls.Add(btnLogout);
            flpMenu.Controls.Add(btnExit);
            flpMenu.Dock = DockStyle.Left;
            flpMenu.Location = new Point(0, 0);
            flpMenu.MaximumSize = new Size(145, 0);
            flpMenu.MinimumSize = new Size(47, 0);
            flpMenu.Name = "flpMenu";
            flpMenu.Size = new Size(145, 450);
            flpMenu.TabIndex = 0;
            // 
            // panelMenu
            // 
            panelMenu.Controls.Add(btnMenuToggle);
            panelMenu.Location = new Point(3, 3);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(142, 22);
            panelMenu.TabIndex = 1;
            // 
            // btnMenuToggle
            // 
            btnMenuToggle.BackColor = Color.SteelBlue;
            btnMenuToggle.Dock = DockStyle.Left;
            btnMenuToggle.Location = new Point(0, 0);
            btnMenuToggle.Name = "btnMenuToggle";
            btnMenuToggle.Size = new Size(47, 22);
            btnMenuToggle.TabIndex = 0;
            btnMenuToggle.Text = "☰";
            btnMenuToggle.UseVisualStyleBackColor = false;
            btnMenuToggle.Click += btnMenuToggle_Click;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnLogin.Location = new Point(3, 31);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(131, 23);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnMyAlbums
            // 
            btnMyAlbums.Location = new Point(3, 60);
            btnMyAlbums.Name = "btnMyAlbums";
            btnMyAlbums.Size = new Size(131, 23);
            btnMyAlbums.TabIndex = 5;
            btnMyAlbums.Text = "My Albums";
            btnMyAlbums.UseVisualStyleBackColor = true;
            btnMyAlbums.Click += btnMyAlbums_Click;
            // 
            // btnUserControlPanel
            // 
            btnUserControlPanel.Location = new Point(3, 89);
            btnUserControlPanel.Name = "btnUserControlPanel";
            btnUserControlPanel.Size = new Size(131, 23);
            btnUserControlPanel.TabIndex = 4;
            btnUserControlPanel.Text = "User Panel";
            btnUserControlPanel.UseVisualStyleBackColor = true;
            btnUserControlPanel.Click += btnUserControlPanel_Click;
            // 
            // btnSettings
            // 
            btnSettings.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnSettings.Location = new Point(3, 118);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(131, 23);
            btnSettings.TabIndex = 3;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(3, 147);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(131, 23);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(3, 176);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(131, 23);
            btnExit.TabIndex = 7;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // timerMenuToggle
            // 
            timerMenuToggle.Tick += timerMenuToggle_Tick;
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.ActiveCaption;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(145, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(655, 450);
            panelMain.TabIndex = 1;
            // 
            // timerCheckUserLoggedIn
            // 
            timerCheckUserLoggedIn.Tick += timerCheckUserLoggedIn_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panelMain);
            Controls.Add(flpMenu);
            MaximumSize = new Size(1080, 720);
            MinimumSize = new Size(400, 200);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            flpMenu.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpMenu;
        private Button btnMenuToggle;
        private System.Windows.Forms.Timer timerMenuToggle;
        private Panel panelMenu;
        private Button btnLogin;
        private Button btnSettings;
        private Panel panelMain;
        private Button btnUserControlPanel;
        private Button btnMyAlbums;
        private Button btnLogout;
        private Button btnExit;
        private System.Windows.Forms.Timer timerCheckUserLoggedIn;
    }
}
