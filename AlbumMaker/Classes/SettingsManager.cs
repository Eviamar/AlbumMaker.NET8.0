
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Items;
using AlbumMaker.Properties;
using System.Windows.Forms;

namespace AlbumMaker.Classes
{
    internal static class SettingsManager
    {
        public static UserItem userItem { get; set; }
        public static void SetTheme()
        {
            Form form = Form.ActiveForm;

            if (form != null)
            {
                SetTheme(form);
            }
        }

        public static int GetMaxWidthMenu()
        {
            float fontSize = GetFont().Size;
            int maxWidthSize = 145;
            if (fontSize == 9)
            {
                maxWidthSize = 145;
            }
            else if (fontSize == 12)
            {
                maxWidthSize = 160;
            }
            else if (fontSize == 16)
            {
                maxWidthSize = 200;
            }
            return maxWidthSize;


        }
        public static Font GetFont()
        {
            return new Font(Form.DefaultFont.FontFamily, Properties.AppSettings.Default.FontSize);
        }
        public static void SetTheme(UserControl uc)
        {
            bool isDark = Properties.AppSettings.Default.isDark;
            if (uc.Name == "MyAlbums")
            {
                uc.ForeColor = Color.White;
                foreach(Control c in uc.Controls)
                {
                    if (c is MenuStrip)
                        SetThemeToControls(c,isDark);
                }
            }
            else
            {
                uc.Font = GetFont();
                foreach (Control c in uc.Controls)
                {
                    SetThemeToControls(c, isDark);
                    if (c.HasChildren)
                    {
                        foreach (Control cControl in c.Controls)
                        {
                            SetThemeToControls(cControl, isDark);
                        }
                    }
                }
            }
            

        }
        public static void SetTheme(Form f)
        {
            bool isDark = Properties.AppSettings.Default.isDark;
            foreach (Control c in f.Controls)
            {
                
                if (c is FlowLayoutPanel)
                {
                    FlowLayoutPanel flp = (FlowLayoutPanel)c;
                    if (flp.Name == "flpMenu")
                    {
                        SetThemeToMenu(flp, isDark);
                        if (flp.HasChildren)
                        {
                            foreach (Control flpControl in flp.Controls)
                            {
                                SetThemeToMenu(flpControl, isDark);
                            }
                        }
                    }
                }
                else
                {
                    SetThemeToControls(c, isDark);
                    if (c.HasChildren)
                    {
                        foreach (Control cControl in c.Controls)
                        {

                            SetThemeToControls(cControl, isDark);
                        }
                    }
                }

            }
        }
        public static void SetThemeToMenu(Control c, bool isDark)
        {
            if (c is Button btn)
            {
                float fontSize = GetFont().Size;
                btn.Font = GetFont();
                btn.BackColor = isDark ?
                  ConvertHexToColor(Properties.DarkThemeSettings.Default.SideMenuButtonBackground)
                  : ConvertHexToColor(Properties.LightThemeSettings.Default.SideMenuButtonBackground);
                btn.ForeColor = isDark ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.SideMenuButtonForeGround)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.SideMenuButtonForeGround);
                if (fontSize == 9)
                {
                    btn.Height = 23;
                }
                else if (fontSize == 12)
                {
                    btn.Height = 30;
                }
                else if (fontSize == 16)
                {
                    btn.Height = 38;
                }

            }
            else
            {
                c.BackColor = isDark ?
                   ConvertHexToColor(Properties.DarkThemeSettings.Default.SideMenuBackground)
                   : ConvertHexToColor(Properties.LightThemeSettings.Default.SideMenuBackground);
                c.ForeColor = isDark ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.SideMenuForeground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.SideMenuForeground);
            }

        }
        public static void SetThemeToMenu(FlowLayoutPanel flp, bool isDark)
        {
            
            flp.BackColor = isDark ?
                   ConvertHexToColor(Properties.DarkThemeSettings.Default.SideMenuBackground)
                   : ConvertHexToColor(Properties.LightThemeSettings.Default.SideMenuBackground);
            flp.ForeColor = isDark ?
                ConvertHexToColor(Properties.DarkThemeSettings.Default.SideMenuForeground)
                : ConvertHexToColor(Properties.LightThemeSettings.Default.SideMenuForeground);
            
        }

        public static void SetThemeToControls(Control control, bool theme)
        {
            
            if (control is Button btn)
            {
                if (btn.Name != "btnDelete" || btn.Name != "btnEdit")
                {
                    btn.BackColor = theme ?
                        ConvertHexToColor(Properties.DarkThemeSettings.Default.ButtonBackground)
                        : ConvertHexToColor(Properties.LightThemeSettings.Default.ButtonBackground);
                    btn.ForeColor = theme ?
                        ConvertHexToColor(Properties.DarkThemeSettings.Default.ButtonForeground)
                        : ConvertHexToColor(Properties.LightThemeSettings.Default.ButtonForeground);
                }   

            }
            
            else if(control is DigiBumPictureBox digiBum)
            {
                
            }
            else if (control is TextBox txtBox)
            {
                txtBox.BackColor = theme ?
             ConvertHexToColor(Properties.DarkThemeSettings.Default.TextBoxBackground)
             : ConvertHexToColor(Properties.LightThemeSettings.Default.TextBoxBackground);
                txtBox.ForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.TextBoxForeground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.TextBoxForeground);

            }
            else if (control is LinkLabel linkLbl)
            {
                linkLbl.LinkColor = theme ?
             ConvertHexToColor(Properties.DarkThemeSettings.Default.LinkLabelForeground)
             : ConvertHexToColor(Properties.LightThemeSettings.Default.LinkLabelForeground);
                linkLbl.ActiveLinkColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.LinkLabelOnClick)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.LinkLabelOnClick);
            }
            else if (control is RichTextBox richTxtBox)
            {
                richTxtBox.BackColor = theme ?
             ConvertHexToColor(Properties.DarkThemeSettings.Default.TextBoxBackground)
             : ConvertHexToColor(Properties.LightThemeSettings.Default.TextBoxBackground);
                richTxtBox.ForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.TextBoxForeground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.TextBoxForeground);
            }
            if(control is MenuStrip menu)
            {
                menu.BackColor = theme ?
              ConvertHexToColor(Properties.DarkThemeSettings.Default.Background)
              : ConvertHexToColor(Properties.LightThemeSettings.Default.Background);
                menu.ForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Foreground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Foreground);
                foreach(ToolStripItem item in menu.Items)
                {
                    item.Font = GetFont();
                }
            }
            else
            {
                control.BackColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Background)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Background);
                control.ForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Foreground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Foreground);
            }



            foreach (Control child in control.Controls)
            {
                SetThemeToControls(child, theme);  // Recursively apply the theme to each child control
            }

        }
        public static Color ConvertHexToColor(string hexColor)
        {
            // Ensure the hex string starts with '#'
            if (!hexColor.StartsWith("#"))
            {
                hexColor = "#" + hexColor;
            }

            // Use ColorTranslator to convert the hex string to a Color object
            return ColorTranslator.FromHtml(hexColor);
        }
        public static string ConvertColorToHex(Color color)
        {
            return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }
        
    }

}
