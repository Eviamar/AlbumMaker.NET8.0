namespace AlbumMaker.Forms
{
    partial class Register
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
            btnSubmit = new Button();
            textBoxAnswer = new TextBox();
            checkBoxPassword = new CheckBox();
            textBoxPassword = new TextBox();
            textBoxUsername = new TextBox();
            lblAlreadyRegistered = new LinkLabel();
            lblRegister = new Label();
            textBoxPassword2 = new TextBox();
            richTextBoxQuestion = new TextBox();
            SuspendLayout();
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(3, 185);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(185, 23);
            btnSubmit.TabIndex = 6;
            btnSubmit.Text = "Register";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.Location = new Point(3, 156);
            textBoxAnswer.MaxLength = 100;
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.PlaceholderText = "Your answer";
            textBoxAnswer.Size = new Size(185, 23);
            textBoxAnswer.TabIndex = 5;
            // 
            // checkBoxPassword
            // 
            checkBoxPassword.AutoSize = true;
            checkBoxPassword.Location = new Point(3, 102);
            checkBoxPassword.Name = "checkBoxPassword";
            checkBoxPassword.Size = new Size(108, 19);
            checkBoxPassword.TabIndex = 3;
            checkBoxPassword.Text = "Show password";
            checkBoxPassword.UseVisualStyleBackColor = true;
            checkBoxPassword.CheckedChanged += checkBoxPassword_CheckedChanged;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(3, 47);
            textBoxPassword.MaxLength = 20;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Password";
            textBoxPassword.Size = new Size(183, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(3, 18);
            textBoxUsername.MaxLength = 20;
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Username";
            textBoxUsername.Size = new Size(183, 23);
            textBoxUsername.TabIndex = 0;
            // 
            // lblAlreadyRegistered
            // 
            lblAlreadyRegistered.AutoSize = true;
            lblAlreadyRegistered.Location = new Point(3, 225);
            lblAlreadyRegistered.Name = "lblAlreadyRegistered";
            lblAlreadyRegistered.Size = new Size(185, 15);
            lblAlreadyRegistered.TabIndex = 7;
            lblAlreadyRegistered.TabStop = true;
            lblAlreadyRegistered.Text = "Already have account? login now!";
            lblAlreadyRegistered.LinkClicked += lblAlreadyRegistered_LinkClicked;
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.Location = new Point(3, 0);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(49, 15);
            lblRegister.TabIndex = 10;
            lblRegister.Text = "Register";
            // 
            // textBoxPassword2
            // 
            textBoxPassword2.Location = new Point(3, 76);
            textBoxPassword2.MaxLength = 20;
            textBoxPassword2.Name = "textBoxPassword2";
            textBoxPassword2.PasswordChar = '*';
            textBoxPassword2.PlaceholderText = "Password";
            textBoxPassword2.Size = new Size(183, 23);
            textBoxPassword2.TabIndex = 2;
            // 
            // richTextBoxQuestion
            // 
            richTextBoxQuestion.Location = new Point(3, 127);
            richTextBoxQuestion.Name = "richTextBoxQuestion";
            richTextBoxQuestion.PlaceholderText = "Secret question (For acc recovery)";
            richTextBoxQuestion.Size = new Size(185, 23);
            richTextBoxQuestion.TabIndex = 11;
            // 
            // Register
            // 
            AccessibleName = "Register";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(richTextBoxQuestion);
            Controls.Add(textBoxPassword2);
            Controls.Add(btnSubmit);
            Controls.Add(textBoxAnswer);
            Controls.Add(checkBoxPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(lblAlreadyRegistered);
            Controls.Add(lblRegister);
            Name = "Register";
            Size = new Size(193, 258);
            Load += Register_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBoxAnswer;
        private Button btnSubmit;
        private CheckBox checkBoxPassword;
        private TextBox textBoxPassword;
        private TextBox textBoxUsername;
        private LinkLabel lblAlreadyRegistered;
        private Label lblRegister;
        private TextBox textBoxPassword2;
        private TextBox richTextBoxQuestion;
    }
}
