using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;
using AlbumMaker.Forms;
using AlbumMaker.Forms.UserForms;
using System.Windows.Forms;


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
            timerMenuClose.Interval = 1;
            timerMenuOpen.Interval = 1;

        }

        private void btnMenuToggle_Click(object sender, EventArgs e)
        {

            if (menuOpen)
                timerMenuClose.Start();
            else
                timerMenuOpen.Start();
        }

        private void timerMenuToggle_Tick(object sender, EventArgs e)
        {
            int shrinkSpeed = 5;
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
                timerMenuClose.Stop();
                menuOpen = false;
            }



        }
        private void timerMenuOpen_Tick(object sender, EventArgs e)
        {
            int shrinkSpeed = 5;
            int maxWidthSize = SettingsManager.GetMaxWidthMenu();
            if (flpMenu.Width < maxWidthSize)
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
                timerMenuOpen.Stop();
                menuOpen = true;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            Navigate(new Settings(timerMenuClose, timerMenuOpen));
            //Settings settings = new Settings();
            //settings.Dock = DockStyle.Fill;
            //panelMain.Controls.Clear();
            //SettingsManager.SetTheme(settings);
            //panelMain.Controls.Add(settings);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Properties.AppSettings.Default.AppLocation = AppDomain.CurrentDomain.BaseDirectory;
            Properties.AppSettings.Default.AppDataFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Properties.AppSettings.Default.Save();
            AppDataBase.CreateDataBase();
            SettingsManager.SetTheme(this);
            timerMenuOpen.Start();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Navigate(new Login());
            //Login login = new Login();
            //login.Dock = DockStyle.Fill;
            //login.Parent = FindForm();
            //panelMain.Controls.Clear();
            //SettingsManager.SetTheme(login);
            //panelMain.Controls.Add(login);
        }

        private void btnUserControlPanel_Click(object sender, EventArgs e)
        {

            Navigate(new UserControlPanel());
            //ucp.Dock = DockStyle.Fill;
            //ucp.Parent = FindForm();
            //panelMain.Controls.Clear();
            //SettingsManager.SetTheme(ucp);
            //panelMain.Controls.Add(ucp);
        }

        private void btnMyAlbums_Click(object sender, EventArgs e)
        {

            Navigate(new MyAlbums());

            //albums.Dock = DockStyle.Top;
            //albums.Parent = FindForm();
            //panelMain.Controls.Clear();
            //SettingsManager.SetTheme(albums);
            //panelMain.Controls.Add(albums);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitMethod();
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ExitMethod();
            AppDataBase.userItem = null;
            Navigate(new Login());

            //Login login = new Login();
            //login.Dock = DockStyle.Fill;
            //login.Parent = FindForm();
            //panelMain.Controls.Clear();
            //SettingsManager.SetTheme(login);
            //panelMain.Controls.Add(login);
        }

        private void timerCheckUserLoggedIn_Tick(object sender, EventArgs e)
        {

            btnLogin.Visible = !Properties.AppSettings.Default.isLogged;
            btnMyAlbums.Visible = Properties.AppSettings.Default.isLogged;
            btnUserControlPanel.Visible = Properties.AppSettings.Default.isLogged;
            btnLogout.Visible = Properties.AppSettings.Default.isLogged;
            btnLogin.Visible = !Properties.AppSettings.Default.isLogged;
            if (Properties.AppSettings.Default.isLogged)
                btnAdminPanel.Visible = AppDataBase.userItem.GetIsAdmin();
            else
                btnAdminPanel.Visible = false;





            //if (Properties.AppSettings.Default.isLogged)
            //{
            //    btnLogin.Visible = false;
            //    btnMyAlbums.Visible = true;
            //    btnUserControlPanel.Visible = true;
            //    btnLogout.Visible = true;
            //    btnAdminPanel.Visible = AppDataBase.userItem.IsAdmin();
            //}
            //else
            //{
            //    btnLogin.Visible = true;
            //    btnMyAlbums.Visible = false;
            //    btnUserControlPanel.Visible = false;
            //    btnLogout.Visible = false;
            //}
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

        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            Navigate(new AdminPanel());
        }
        private void Navigate(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelMain.AutoScroll = true;
            panelMain.VerticalScroll.Enabled = true;
            panelMain.HorizontalScroll.Enabled = true;
            //userControl.Parent = FindForm();
            panelMain.Controls.Clear();
            //SettingsManager.SetTheme(userControl);
            panelMain.Controls.Add(userControl);
           
        }
       
    }
}
