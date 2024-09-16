using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;
using System.Windows.Forms;


namespace AlbumMaker.Forms
{
    public partial class Settings : UserControl
    {
        private bool isLoading = true;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.Timer timerOpen;
        public Settings()
        {
            InitializeComponent();
            AddSizesToComboBox();
        }
        public Settings(System.Windows.Forms.Timer timerClose, System.Windows.Forms.Timer timerOpen)
        {
            InitializeComponent();
            AddSizesToComboBox();
            this.timerClose = timerClose;
            this.timerOpen = timerOpen;
        }

        private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
        {
            Properties.AppSettings.Default.isDark = false;
            Properties.AppSettings.Default.Save();
            SettingsManager.SetTheme();

        }

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

        private void comboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isLoading)
            {
                var selectedItem = (KeyValuePair<string, float>)comboBoxFontSize.SelectedItem;
                Properties.AppSettings.Default.FontSize = selectedItem.Value;
                Properties.AppSettings.Default.Save();
                if (timerClose != null && timerOpen != null)
                {
                    timerClose.Interval = 1;
                    timerOpen.Interval = 1;
                    timerClose.Start();

                    //timerOpen.Start();

                }
                SettingsManager.SetTheme();
                SettingsManager.SetTheme(this);

            }
        }

        private void btnChangeDataLocation_Click(object sender, EventArgs e)
        {
            if (!Properties.AppSettings.Default.isLogged)
            {
                MessageBox.Show("You need to login to the program to change path.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string location = Properties.AppSettings.Default.AppDataFolder;
            string oldPath = Properties.AppSettings.Default.AppDataFolder; //might not be needed this cause can use folderBroswerDialog.SelectedPath
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                location = folderBrowserDialog.SelectedPath;
                //=> TO COPY ALL CONTENT FROM OLD PATH TO NEW PATH AND THEN CHANGE IN THE AppSettings
                //Properties.AppSettings.Default.AppDataFolder = location;
                //Properties.AppSettings.Default.Save();
            }
            lblDataLocation.Text = location;
            Size textSize = TextRenderer.MeasureText(lblDataLocation.Text, lblDataLocation.Font);
            lblDataLocation.MinimumSize = new Size(textSize.Width, lblDataLocation.Height);





        }

        private void btnDropTables_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("YOU ARE ABOUT TO DELETE EVERYTHING FROM THE DATABASE\nARE YOU SURE ABOUT THAT?", "!!!ALERT!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(dr == DialogResult.Yes)
            {
                AppDataBase.DropTables();
                SettingsManager.userItem = null;
            }
        }
    }
}
