using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;
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
            timerCheckUserLoggedIn.Start();
            AppDataBase.CreateDataBase();
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
            Properties.AppSettings.Default.AppLocation = AppDomain.CurrentDomain.BaseDirectory;
            Properties.AppSettings.Default.AppDataFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Properties.AppSettings.Default.Save();
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

        private void btnUserControlPanel_Click(object sender, EventArgs e)
        {
            UserControlPanel ucp = new UserControlPanel();
            ucp.Dock = DockStyle.Fill;
            ucp.Parent = FindForm();
            panelMain.Controls.Clear();
            SettingsManager.SetTheme(ucp);
            panelMain.Controls.Add(ucp);
        }

        private void btnMyAlbums_Click(object sender, EventArgs e)
        {
            MyAlbums albums = new MyAlbums();
            albums.Dock = DockStyle.Top;
            albums.Parent = FindForm();
            panelMain.Controls.Clear();
            SettingsManager.SetTheme(albums);
            panelMain.Controls.Add(albums);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitMethod();
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ExitMethod();
            Login login = new Login();
            login.Dock = DockStyle.Fill;
            login.Parent = FindForm();
            panelMain.Controls.Clear();
            SettingsManager.SetTheme(login);
            panelMain.Controls.Add(login);
        }

        private void timerCheckUserLoggedIn_Tick(object sender, EventArgs e)
        {
            if (Properties.AppSettings.Default.isLogged)
            {
                btnLogin.Visible = false;
                btnMyAlbums.Visible = true;
                btnUserControlPanel.Visible = true;
                btnLogout.Visible = true;


            }
            else
            {
                btnLogin.Visible = true;
                btnMyAlbums.Visible = false;
                btnUserControlPanel.Visible = false;
                btnLogout.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitMethod();
        }
        private void ExitMethod()
        {
            Properties.AppSettings.Default.isLogged = false;
            Properties.AppSettings.Default.currentUser = "";
            Properties.AppSettings.Default.Save();
        }
    }
}
