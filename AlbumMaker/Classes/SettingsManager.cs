
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Items;
using AlbumMaker.Properties;
using System.Windows.Forms;

namespace AlbumMaker.Classes
{
    // Where to begin.... this class handles the UI in the application but not only.
    internal static class SettingsManager
    {
        // Because this class is already a static class we used to store userItem (the current logged user)
        // We also store a list of users in userItems (for admin purposes).
        public static UserItem userItem { get; set; }
        internal static List<UserItem> userItems { get; set; }

        // This function applies theme to an active FORM.
        public static void SetTheme()
        {
            Form form = Form.ActiveForm;

            if (form != null)
            {
                SetTheme(form);
            }
        }
  
        // This function made for limiting the side menu size so it will work properly according to font size.
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
        // This tiny function just returns font size.
        public static Font GetFont()
        {
            return new Font(Form.DefaultFont.FontFamily, Properties.AppSettings.Default.FontSize);
        }

        // This function apply theme to USER-CONTROL (we use User Control for displaying each "page" inside the main form1)
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
                    if (c is Panel p)
                        if (p.Name == "panelPic")
                            continue;
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

        // This function set the theme into a form.
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

        // This function set the theme to the CONTROLS in the side menu 
        public static void SetThemeToMenu(Control c, bool isDark)
        {
            if (c is Button btn)
            {
                btn.Cursor = Cursors.Hand;
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
        // This function set the theme to the side menu 
        public static void SetThemeToMenu(FlowLayoutPanel flp, bool isDark)
        {
            
            flp.BackColor = isDark ?
                   ConvertHexToColor(Properties.DarkThemeSettings.Default.SideMenuBackground)
                   : ConvertHexToColor(Properties.LightThemeSettings.Default.SideMenuBackground);
            flp.ForeColor = isDark ?
                ConvertHexToColor(Properties.DarkThemeSettings.Default.SideMenuForeground)
                : ConvertHexToColor(Properties.LightThemeSettings.Default.SideMenuForeground);
            
        }


        // This function set the theme to controls which are used in the application (see if statement).
        // It is also a recursive function if the control has controls inside it its being called again.
        public static void SetThemeToControls(Control control, bool theme)
        {
            
            if (control is Button btn)
            {
                btn.Cursor = Cursors.Hand;
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
                txtBox.Cursor = Cursors.IBeam;
                
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
            else if(control is ComboBox comboBox)
            {
                comboBox.Cursor = Cursors.Hand;
                comboBox.BackColor = theme ?
            ConvertHexToColor(Properties.DarkThemeSettings.Default.TextBoxBackground)
            : ConvertHexToColor(Properties.LightThemeSettings.Default.TextBoxBackground);
                comboBox.ForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.TextBoxForeground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.TextBoxForeground);
            }
            if(control is MenuStrip menu)
            {
                menu.Cursor = Cursors.Hand;
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
            else if(control is GroupBox grpBox)
            {
                grpBox.BackColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Background)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Background);
                grpBox.ForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Foreground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Foreground);
            }
            else if(control is Panel || control is FlowLayoutPanel | control is TableLayoutPanel)
            {

               

                control.BackColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Background)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Background);
                control.ForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Foreground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Foreground);
            }
            else if(control is DataGridView dgv)
            {
                dgv.BackgroundColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Background)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Background);
                dgv.ForeColor = ConvertHexToColor(Properties.LightThemeSettings.Default.Foreground);
                dgv.GridColor = ConvertHexToColor(Properties.LightThemeSettings.Default.Foreground);

            }
            else if(control is DateTimePicker dtp)
            {
                dtp.CalendarForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Foreground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Foreground);
                dtp.CalendarTitleBackColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Background)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Background);
                dtp.CalendarTitleForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Foreground)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Foreground);
                dtp.CalendarTrailingForeColor = theme ?
                    ConvertHexToColor(Properties.DarkThemeSettings.Default.Background)
                    : ConvertHexToColor(Properties.LightThemeSettings.Default.Background);
                
            }


            foreach (Control child in control.Controls)
            {
                SetThemeToControls(child, theme);  // Recursively apply the theme to each child control
            }

        }

        // This function converts Hexadecimal value to a of Color the .NET controls reads
        // EX: Label.Forecolor = Color.White || so for example #ffffff translate to Color.White
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

        // Does the opposite of the above function but not in used in the application
        // Was created in case will need it in future.
        // kept cause why not ;)
        public static string ConvertColorToHex(Color color)
        {
            return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
        }
        
    }

}
