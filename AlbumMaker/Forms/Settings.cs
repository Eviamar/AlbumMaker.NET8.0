using AlbumMaker.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlbumMaker.Forms
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            AddSizesToComboBox();
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
            if (Properties.AppSettings.Default.isDark)
                radioButtonDark.Checked = true;
            else
                radioButtonLight.Checked = true;
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
            var selectedItem = (KeyValuePair<string, float>)comboBoxFontSize.SelectedItem;
            Properties.AppSettings.Default.FontSize = selectedItem.Value;
            Properties.AppSettings.Default.Save();


        }
    }
}
