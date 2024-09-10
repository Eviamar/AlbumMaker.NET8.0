using AlbumMaker.Classes;


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
    }
}
