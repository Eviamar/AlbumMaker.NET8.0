namespace AlbumMaker.Forms
{
    partial class Login
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
            lblLogin = new Label();
            lblAlreadyRegistered = new LinkLabel();
            lblForgot = new LinkLabel();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            checkBoxPassword = new CheckBox();
            btnSubmit = new Button();
            richTextBoxQuestion = new RichTextBox();
            textBoxAnswer = new TextBox();
            btnForgot = new Button();
            checkBoxRememberMe = new CheckBox();
            linkLabelForgetMe = new LinkLabel();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(3, 1);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(37, 15);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Login";
            // 
            // lblAlreadyRegistered
            // 
            lblAlreadyRegistered.AutoSize = true;
            lblAlreadyRegistered.Location = new Point(3, 149);
            lblAlreadyRegistered.Name = "lblAlreadyRegistered";
            lblAlreadyRegistered.Size = new Size(148, 15);
            lblAlreadyRegistered.TabIndex = 1;
            lblAlreadyRegistered.TabStop = true;
            lblAlreadyRegistered.Text = "No account? Register now!";
            lblAlreadyRegistered.LinkClicked += lblAlreadyRegistered_LinkClicked;
            // 
            // lblForgot
            // 
            lblForgot.AutoSize = true;
            lblForgot.Location = new Point(3, 175);
            lblForgot.Name = "lblForgot";
            lblForgot.Size = new Size(137, 15);
            lblForgot.TabIndex = 2;
            lblForgot.TabStop = true;
            lblForgot.Text = "Forgot login credentials?";
            lblForgot.LinkClicked += lblForgot_LinkClicked;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(3, 19);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Username";
            textBoxUsername.Size = new Size(183, 23);
            textBoxUsername.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(3, 48);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Password";
            textBoxPassword.Size = new Size(183, 23);
            textBoxPassword.TabIndex = 4;
            // 
            // checkBoxPassword
            // 
            checkBoxPassword.AutoSize = true;
            checkBoxPassword.Location = new Point(3, 77);
            checkBoxPassword.Name = "checkBoxPassword";
            checkBoxPassword.Size = new Size(108, 19);
            checkBoxPassword.TabIndex = 5;
            checkBoxPassword.Text = "Show password";
            checkBoxPassword.UseVisualStyleBackColor = true;
            checkBoxPassword.CheckedChanged += checkBoxPassword_CheckedChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(3, 123);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(183, 23);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Login";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // richTextBoxQuestion
            // 
            richTextBoxQuestion.Location = new Point(3, 193);
            richTextBoxQuestion.Name = "richTextBoxQuestion";
            richTextBoxQuestion.ReadOnly = true;
            richTextBoxQuestion.Size = new Size(183, 48);
            richTextBoxQuestion.TabIndex = 7;
            richTextBoxQuestion.Text = "";
            richTextBoxQuestion.Visible = false;
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.Location = new Point(3, 247);
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.PlaceholderText = "Your answer";
            textBoxAnswer.Size = new Size(185, 23);
            textBoxAnswer.TabIndex = 8;
            textBoxAnswer.Visible = false;
            // 
            // btnForgot
            // 
            btnForgot.Location = new Point(3, 276);
            btnForgot.Name = "btnForgot";
            btnForgot.Size = new Size(185, 23);
            btnForgot.TabIndex = 9;
            btnForgot.Text = "Remind me!";
            btnForgot.UseVisualStyleBackColor = true;
            btnForgot.Visible = false;
            // 
            // checkBoxRememberMe
            // 
            checkBoxRememberMe.AutoSize = true;
            checkBoxRememberMe.Location = new Point(3, 98);
            checkBoxRememberMe.Name = "checkBoxRememberMe";
            checkBoxRememberMe.Size = new Size(104, 19);
            checkBoxRememberMe.TabIndex = 10;
            checkBoxRememberMe.Text = "Remember me";
            checkBoxRememberMe.UseVisualStyleBackColor = true;
            // 
            // linkLabelForgetMe
            // 
            linkLabelForgetMe.AutoSize = true;
            linkLabelForgetMe.Location = new Point(124, 98);
            linkLabelForgetMe.Name = "linkLabelForgetMe";
            linkLabelForgetMe.Size = new Size(64, 15);
            linkLabelForgetMe.TabIndex = 11;
            linkLabelForgetMe.TabStop = true;
            linkLabelForgetMe.Text = "Forget Me!";
            linkLabelForgetMe.LinkClicked += linkLabelForgetMe_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(linkLabelForgetMe);
            Controls.Add(checkBoxRememberMe);
            Controls.Add(btnForgot);
            Controls.Add(textBoxAnswer);
            Controls.Add(richTextBoxQuestion);
            Controls.Add(btnSubmit);
            Controls.Add(checkBoxPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(lblForgot);
            Controls.Add(lblAlreadyRegistered);
            Controls.Add(lblLogin);
            Name = "Login";
            Size = new Size(205, 316);
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblLogin;
        private LinkLabel lblAlreadyRegistered;
        private LinkLabel lblForgot;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private CheckBox checkBoxPassword;
        private Button btnSubmit;
        private RichTextBox richTextBoxQuestion;
        private TextBox textBoxAnswer;
        private Button btnForgot;
        private CheckBox checkBoxRememberMe;
        private LinkLabel linkLabelForgetMe;
    }
}
