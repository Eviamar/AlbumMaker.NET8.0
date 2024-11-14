using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;
using AlbumMaker.Properties;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;


namespace AlbumMaker.Forms
{
    // This User Control gives the user the ability to change application look and saved app files location.
    // It gets the timer because there was a UI bug when changing font size, the size didn't apply to the menu, so it makes it "refresh".
    public partial class Settings : UserControl
    {
        private bool isLoading = true;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.Timer timerOpen;
        public Settings(System.Windows.Forms.Timer timerClose, System.Windows.Forms.Timer timerOpen)
        {
            InitializeComponent();
            AddSizesToComboBox();
            this.timerClose = timerClose;
            this.timerOpen = timerOpen;
            this.AutoScroll = true;
        }
        // Function of a raido button that applies light theme to the application
        private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
        {
            Properties.AppSettings.Default.isDark = false;
            Properties.AppSettings.Default.Save();
            SettingsManager.SetTheme();

        }

        // Function of a raido button button that applies dark theme to the application
        private void radioButtonDark_CheckedChanged(object sender, EventArgs e)
        {
            Properties.AppSettings.Default.isDark = true;
            Properties.AppSettings.Default.Save();
            SettingsManager.SetTheme();

        }

        private void Settings_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            isLoading = true;
            if (Properties.AppSettings.Default.AppDataFolder[Properties.AppSettings.Default.AppDataFolder.Length-1] == '\\')
                lblDataLocation.Text = Properties.AppSettings.Default.AppDataFolder + $@"{Properties.AppSettings.Default.AppName}";
            else
                lblDataLocation.Text = Properties.AppSettings.Default.AppDataFolder + $@"\{Properties.AppSettings.Default.AppName}";
            Size textSize = TextRenderer.MeasureText(lblDataLocation.Text, lblDataLocation.Font);
            lblDataLocation.MinimumSize = new Size(textSize.Width, lblDataLocation.Height);

            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            if (Properties.AppSettings.Default.isDark)
                radioButtonDark.Checked = true;
            else
                radioButtonLight.Checked = true;

            for (int i = 0; i < comboBoxFontSize.Items.Count; i++)
            {
                var item = (KeyValuePair<string, float>)comboBoxFontSize.Items[i];

                if (item.Value == Properties.AppSettings.Default.FontSize)
                {
                    comboBoxFontSize.SelectedItem = item;
                    break;
                }

            }

            isLoading = false;
        }
        // Function that populate the comboBox for sizes
        private void AddSizesToComboBox()
        {
            List<KeyValuePair<string, float>> keyValuePairs = new List<KeyValuePair<string, float>>()
            {
                new KeyValuePair<string, float>("Normal",9),
                new KeyValuePair<string, float>("Big",12),
                new KeyValuePair<string, float>("Very big",16)
            };
            comboBoxFontSize.DataSource = keyValuePairs;
            comboBoxFontSize.DisplayMember = "Key";
            comboBoxFontSize.ValueMember = "Value";

        }
        // Function that handles the selected font size.
        private void comboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                var selectedItem = (KeyValuePair<string, float>)comboBoxFontSize.SelectedItem;
                Properties.AppSettings.Default.FontSize = selectedItem.Value;
                Properties.AppSettings.Default.Save();
                if (timerClose != null && timerOpen != null)
                {
                    timerOpen.Interval = 1;
                    timerClose.Interval = 1;
                    timerClose.Start();
                }
                SettingsManager.SetTheme();
                SettingsManager.SetTheme(this);
                
            }
        }

        // The function handles the change of application location, it does only copy and does not delete previous old folder.
        public void CopyDirectory(string sourceDir, string destinationDir, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDir);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDir);
            }

            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                DirectoryInfo[] subDirs = dir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                {
                    string temppath = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, temppath, copySubDirs);
                }
            }
        }
        // Function that handles the change location button event click
        // It opens a file dialog so user select where to move the application data folder to.
        // Runs the CopyDirectory functions 
        private void btnChangeDataLocation_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Properties.AppSettings.Default.isLogged)
                {
                    MessageBox.Show("You need to login to the program to change path.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string location = Properties.AppSettings.Default.AppDataFolder;
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                folderBrowserDialog.ShowNewFolderButton = true;
                bool folderExist = false;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    //=> TO COPY ALL CONTENT FROM OLD PATH TO NEW PATH AND THEN CHANGE IN THE AppSettings
                    if (Directory.Exists($@"{folderBrowserDialog.SelectedPath}\{Properties.AppSettings.Default.AppName}\")) 
                    {
                        folderExist = true;
                        DialogResult dr = MessageBox.Show($"Selelected path already have a folder named: {Properties.AppSettings.Default.AppName}" +
                            $"\nWould you like to delete it and proceed to copy?",
                            "Folder exist",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                        if (dr == DialogResult.Yes)
                        {
                           Directory.Delete(folderBrowserDialog.SelectedPath + $@"\{Properties.AppSettings.Default.AppName}\", true);
                            folderExist = false;
                        }
                        else
                            return;
                    }
                    if (!folderExist)
                    {
                        CopyDirectory(location + $@"\{Properties.AppSettings.Default.AppName}\", folderBrowserDialog.SelectedPath + $@"\{Properties.AppSettings.Default.AppName}\", true);
                        Properties.AppSettings.Default.AppDataFolder = folderBrowserDialog.SelectedPath;
                        Properties.AppSettings.Default.Save();
                        Settings_Load(this, null);

                        if (folderBrowserDialog.SelectedPath[folderBrowserDialog.SelectedPath.Length - 1] == '\\')
                            lblDataLocation.Text = folderBrowserDialog.SelectedPath + $@"{Properties.AppSettings.Default.AppName}";
                        else
                            lblDataLocation.Text = folderBrowserDialog.SelectedPath + $@"\{Properties.AppSettings.Default.AppName}";

                        Size textSize = TextRenderer.MeasureText(lblDataLocation.Text, lblDataLocation.Font);
                        lblDataLocation.MinimumSize = new Size(textSize.Width, lblDataLocation.Height);
                    }
                    else
                        MessageBox.Show("Cannot copy because a folder with the same name of the application exist in the location you have selected." +
                            "\nPlease try again and click Yes to delete or delete it manually.","Folder exist.");

                }

                
            }
            catch { throw; }
        }

        // A hidden button (not available for users) used for developing progress easier to clear tables (when we ruined the tables and had to start over).
        private void btnDropTables_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("YOU ARE ABOUT TO DELETE EVERYTHING FROM THE DATABASE\nARE YOU SURE ABOUT THAT?", "!!!ALERT!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                AppDataBase.DropTables();
                SettingsManager.userItem = null;
      
                Application.Restart();
            }
        }

        // Function of label click event that opens the folder in the windows explorer.exe (just a QoL for user to open app data folder). 
        private void lblDataLocation_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", lblDataLocation.Text);
            }
            catch { throw; }
        }


        // This function restore all settings to their default value (default vaules can be found in Properties=>AppSettings).
        // It does not reset the database
        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("This will reset all saved settings to default (just like first time launching the app\nAre you sure?","Reset?",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                string oldPath = Properties.AppSettings.Default.AppDataFolder;
                AppSettings.Default.Reset();
                MessageBox.Show(oldPath);
                MessageBox.Show(Properties.AppSettings.Default.AppDataFolder);
               // CopyDirectory(oldPath + $@"\{Properties.AppSettings.Default.AppName}\", Properties.AppSettings.Default.AppDataFolder + $@"\{Properties.AppSettings.Default.AppName}\", true);
                Application.Restart();
            }
            
        }
    }
}
