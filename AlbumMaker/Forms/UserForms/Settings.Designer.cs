namespace AlbumMaker.Forms
{
    partial class Settings
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
            grpBoxTheme = new GroupBox();
            radioButtonDark = new RadioButton();
            radioButtonLight = new RadioButton();
            comboBoxFontSize = new ComboBox();
            groupBoxFontSize = new GroupBox();
            grpBoxTheme.SuspendLayout();
            groupBoxFontSize.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxTheme
            // 
            grpBoxTheme.Controls.Add(radioButtonDark);
            grpBoxTheme.Controls.Add(radioButtonLight);
            grpBoxTheme.ForeColor = SystemColors.ControlText;
            grpBoxTheme.Location = new Point(155, 14);
            grpBoxTheme.Name = "grpBoxTheme";
            grpBoxTheme.Size = new Size(71, 78);
            grpBoxTheme.TabIndex = 0;
            grpBoxTheme.TabStop = false;
            grpBoxTheme.Text = "Theme";
            // 
            // radioButtonDark
            // 
            radioButtonDark.AutoSize = true;
            radioButtonDark.Location = new Point(6, 47);
            radioButtonDark.Name = "radioButtonDark";
            radioButtonDark.Size = new Size(49, 19);
            radioButtonDark.TabIndex = 1;
            radioButtonDark.TabStop = true;
            radioButtonDark.Text = "Dark";
            radioButtonDark.UseVisualStyleBackColor = true;
            radioButtonDark.CheckedChanged += radioButtonDark_CheckedChanged;
            // 
            // radioButtonLight
            // 
            radioButtonLight.AutoSize = true;
            radioButtonLight.Location = new Point(6, 22);
            radioButtonLight.Name = "radioButtonLight";
            radioButtonLight.Size = new Size(52, 19);
            radioButtonLight.TabIndex = 0;
            radioButtonLight.TabStop = true;
            radioButtonLight.Text = "Light";
            radioButtonLight.UseVisualStyleBackColor = true;
            radioButtonLight.CheckedChanged += radioButtonLight_CheckedChanged;
            // 
            // comboBoxFontSize
            // 
            comboBoxFontSize.FormattingEnabled = true;
            comboBoxFontSize.Location = new Point(6, 22);
            comboBoxFontSize.Name = "comboBoxFontSize";
            comboBoxFontSize.Size = new Size(126, 23);
            comboBoxFontSize.TabIndex = 1;
            comboBoxFontSize.SelectedIndexChanged += comboBoxFontSize_SelectedIndexChanged;
            // 
            // groupBoxFontSize
            // 
            groupBoxFontSize.Controls.Add(comboBoxFontSize);
            groupBoxFontSize.Location = new Point(3, 14);
            groupBoxFontSize.Name = "groupBoxFontSize";
            groupBoxFontSize.Size = new Size(146, 78);
            groupBoxFontSize.TabIndex = 2;
            groupBoxFontSize.TabStop = false;
            groupBoxFontSize.Text = "Text size";
            // 
            // Settings
            // 
            AccessibleName = "Application settings";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBoxFontSize);
            Controls.Add(grpBoxTheme);
            Name = "Settings";
            Size = new Size(262, 144);
            Load += Settings_Load;
            grpBoxTheme.ResumeLayout(false);
            grpBoxTheme.PerformLayout();
            groupBoxFontSize.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBoxTheme;
        private RadioButton radioButtonDark;
        private RadioButton radioButtonLight;
        private ComboBox comboBoxFontSize;
        private GroupBox groupBoxFontSize;
    }
}
