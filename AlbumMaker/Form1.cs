using AlbumMaker.Classes;
using AlbumMaker.Forms;

namespace AlbumMaker
{
    public partial class Form1 : Form
    {
        private bool menuOpen = true;
   
        public Form1()
        {
            InitializeComponent();
            this.Text = Properties.AppSettings.Default.AppName;
            
        }

        private void btnMenuToggle_Click(object sender, EventArgs e)
        {
            timerMenuToggle.Interval = 10;
            timerMenuToggle.Start();
        }

        private void timerMenuToggle_Tick(object sender, EventArgs e)
        {
            int shrinkSpeed = 5;
            if (menuOpen)
            {
                if (flpMenu.Width > 50)
                {
                    flpMenu.Width -= shrinkSpeed;
                    foreach (Control c in flpMenu.Controls)
                    {
                        c.Width -= shrinkSpeed;
                        c.Invalidate();
                    }

                    flpMenu.Invalidate();
                }
                else
                {
                    timerMenuToggle.Stop();
                    menuOpen = false;
                }
            }
            else
            {
                if (flpMenu.Width < 145)
                {

                    flpMenu.Width += shrinkSpeed;
                    foreach (Control c in flpMenu.Controls)
                    {
                        c.Width += shrinkSpeed;
                        c.Invalidate();
                    }

                    flpMenu.Invalidate();
                }
                else
                {
                    timerMenuToggle.Stop();
                    menuOpen = true;
                }
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            SettingsManager.SetTheme(settings);
            panelMain.Controls.Add(settings);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Dock = DockStyle.Fill;
            login.Parent = FindForm();
            panelMain.Controls.Clear();
            SettingsManager.SetTheme(login);
            panelMain.Controls.Add(login);
        }
    }
}
