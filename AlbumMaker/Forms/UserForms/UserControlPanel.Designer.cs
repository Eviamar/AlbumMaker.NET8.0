namespace AlbumMaker.Forms
{
    partial class UserControlPanel
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
            textBoxPassword2 = new TextBox();
            textBoxPassword = new TextBox();
            textBoxAnswer = new TextBox();
            richTextBoxQuestion = new RichTextBox();
            btnUpdatePassword = new Button();
            btnUpdateQuestion = new Button();
            grpBoxPassword = new GroupBox();
            checkBoxShowHide = new CheckBox();
            textBoxCurrentPassword = new TextBox();
            grpBoxQuestion = new GroupBox();
            grpBoxOther = new GroupBox();
            checkBoxRememberMe = new CheckBox();
            checkBoxLoginAuto = new CheckBox();
            grpBoxPassword.SuspendLayout();
            grpBoxQuestion.SuspendLayout();
            grpBoxOther.SuspendLayout();
            SuspendLayout();
            // 
            // textBoxPassword2
            // 
            textBoxPassword2.Location = new Point(6, 75);
            textBoxPassword2.MaxLength = 20;
            textBoxPassword2.Name = "textBoxPassword2";
            textBoxPassword2.PasswordChar = '*';
            textBoxPassword2.PlaceholderText = "Confirm new password";
            textBoxPassword2.Size = new Size(157, 23);
            textBoxPassword2.TabIndex = 22;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(6, 47);
            textBoxPassword.MaxLength = 20;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "new password";
            textBoxPassword.Size = new Size(157, 23);
            textBoxPassword.TabIndex = 21;
            // 
            // textBoxAnswer
            // 
            textBoxAnswer.Location = new Point(6, 75);
            textBoxAnswer.MaxLength = 100;
            textBoxAnswer.Name = "textBoxAnswer";
            textBoxAnswer.PlaceholderText = "Your answer";
            textBoxAnswer.Size = new Size(185, 23);
            textBoxAnswer.TabIndex = 24;
            // 
            // richTextBoxQuestion
            // 
            richTextBoxQuestion.BorderStyle = BorderStyle.None;
            richTextBoxQuestion.Location = new Point(6, 22);
            richTextBoxQuestion.MaxLength = 200;
            richTextBoxQuestion.Name = "richTextBoxQuestion";
            richTextBoxQuestion.Size = new Size(185, 48);
            richTextBoxQuestion.TabIndex = 23;
            richTextBoxQuestion.Text = "Type here a question of your own.\nThis question will be used to recover your account in case you forget it.";
            // 
            // btnUpdatePassword
            // 
            btnUpdatePassword.Location = new Point(100, 104);
            btnUpdatePassword.Name = "btnUpdatePassword";
            btnUpdatePassword.Size = new Size(63, 23);
            btnUpdatePassword.TabIndex = 25;
            btnUpdatePassword.Text = "Update password";
            btnUpdatePassword.UseVisualStyleBackColor = true;
            btnUpdatePassword.Click += btnUpdatePassword_Click;
            // 
            // btnUpdateQuestion
            // 
            btnUpdateQuestion.Location = new Point(122, 104);
            btnUpdateQuestion.Name = "btnUpdateQuestion";
            btnUpdateQuestion.Size = new Size(68, 23);
            btnUpdateQuestion.TabIndex = 26;
            btnUpdateQuestion.Text = "Update";
            btnUpdateQuestion.UseVisualStyleBackColor = true;
            btnUpdateQuestion.Click += btnUpdateQuestion_Click;
            // 
            // grpBoxPassword
            // 
            grpBoxPassword.Controls.Add(checkBoxShowHide);
            grpBoxPassword.Controls.Add(textBoxCurrentPassword);
            grpBoxPassword.Controls.Add(textBoxPassword);
            grpBoxPassword.Controls.Add(textBoxPassword2);
            grpBoxPassword.Controls.Add(btnUpdatePassword);
            grpBoxPassword.Location = new Point(205, 3);
            grpBoxPassword.Name = "grpBoxPassword";
            grpBoxPassword.Size = new Size(171, 133);
            grpBoxPassword.TabIndex = 27;
            grpBoxPassword.TabStop = false;
            grpBoxPassword.Text = "Password";
            // 
            // checkBoxShowHide
            // 
            checkBoxShowHide.AutoSize = true;
            checkBoxShowHide.Location = new Point(6, 107);
            checkBoxShowHide.Name = "checkBoxShowHide";
            checkBoxShowHide.Size = new Size(55, 19);
            checkBoxShowHide.TabIndex = 27;
            checkBoxShowHide.Text = "Show";
            checkBoxShowHide.UseVisualStyleBackColor = true;
            checkBoxShowHide.CheckedChanged += checkBoxShowHide_CheckedChanged;
            // 
            // textBoxCurrentPassword
            // 
            textBoxCurrentPassword.Location = new Point(6, 19);
            textBoxCurrentPassword.MaxLength = 20;
            textBoxCurrentPassword.Name = "textBoxCurrentPassword";
            textBoxCurrentPassword.PasswordChar = '*';
            textBoxCurrentPassword.PlaceholderText = "Current password";
            textBoxCurrentPassword.Size = new Size(157, 23);
            textBoxCurrentPassword.TabIndex = 26;
            // 
            // grpBoxQuestion
            // 
            grpBoxQuestion.Controls.Add(richTextBoxQuestion);
            grpBoxQuestion.Controls.Add(textBoxAnswer);
            grpBoxQuestion.Controls.Add(btnUpdateQuestion);
            grpBoxQuestion.Location = new Point(3, 3);
            grpBoxQuestion.Name = "grpBoxQuestion";
            grpBoxQuestion.Size = new Size(196, 133);
            grpBoxQuestion.TabIndex = 28;
            grpBoxQuestion.TabStop = false;
            grpBoxQuestion.Text = "Question";
            // 
            // grpBoxOther
            // 
            grpBoxOther.Controls.Add(checkBoxLoginAuto);
            grpBoxOther.Controls.Add(checkBoxRememberMe);
            grpBoxOther.Location = new Point(4, 142);
            grpBoxOther.Name = "grpBoxOther";
            grpBoxOther.Size = new Size(195, 100);
            grpBoxOther.TabIndex = 29;
            grpBoxOther.TabStop = false;
            grpBoxOther.Text = "Misc";
            // 
            // checkBoxRememberMe
            // 
            checkBoxRememberMe.AutoSize = true;
            checkBoxRememberMe.Location = new Point(6, 22);
            checkBoxRememberMe.Name = "checkBoxRememberMe";
            checkBoxRememberMe.Size = new Size(160, 19);
            checkBoxRememberMe.TabIndex = 0;
            checkBoxRememberMe.Text = "Remember me next login";
            checkBoxRememberMe.UseVisualStyleBackColor = true;
            checkBoxRememberMe.CheckedChanged += checkBoxRememberMe_CheckedChanged;
            // 
            // checkBoxLoginAuto
            // 
            checkBoxLoginAuto.AutoSize = true;
            checkBoxLoginAuto.Location = new Point(6, 47);
            checkBoxLoginAuto.Name = "checkBoxLoginAuto";
            checkBoxLoginAuto.Size = new Size(154, 19);
            checkBoxLoginAuto.TabIndex = 1;
            checkBoxLoginAuto.Text = "Log me in automatically";
            checkBoxLoginAuto.UseVisualStyleBackColor = true;
            checkBoxLoginAuto.CheckedChanged += checkBoxLoginAuto_CheckedChanged;
            // 
            // UserControlPanel
            // 
            AccessibleName = "User settings";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(grpBoxOther);
            Controls.Add(grpBoxQuestion);
            Controls.Add(grpBoxPassword);
            Name = "UserControlPanel";
            Size = new Size(403, 260);
            Load += UserControlPanel_Load;
            grpBoxPassword.ResumeLayout(false);
            grpBoxPassword.PerformLayout();
            grpBoxQuestion.ResumeLayout(false);
            grpBoxQuestion.PerformLayout();
            grpBoxOther.ResumeLayout(false);
            grpBoxOther.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBoxPassword2;
        private TextBox textBoxPassword;
        private TextBox textBoxAnswer;
        private RichTextBox richTextBoxQuestion;
        private Button btnUpdatePassword;
        private Button btnUpdateQuestion;
        private GroupBox grpBoxPassword;
        private GroupBox grpBoxQuestion;
        private GroupBox grpBoxOther;
        private CheckBox checkBoxRememberMe;
        private TextBox textBoxCurrentPassword;
        private CheckBox checkBoxShowHide;
        private CheckBox checkBoxLoginAuto;
    }
}
