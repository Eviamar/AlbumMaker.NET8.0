using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;
using AlbumMaker.Forms;
using AlbumMaker.Forms.UserForms;
using AlbumMaker.Properties;
using System.Windows.Forms;


namespace AlbumMaker
{
    /*
     
    // optional: 
        -allow to change app save images location (this option will need to update the entire database image paths...
     */
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

        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            Properties.AppSettings.Default.AppEXELocation = AppDomain.CurrentDomain.BaseDirectory;
            Properties.AppSettings.Default.AppDataFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            Properties.AppSettings.Default.Save();
            AppDataBase.CreateDataBase();
            SettingsManager.SetTheme(this);
            timerMenuOpen.Start();

            if(!String.IsNullOrWhiteSpace(AppSettings.Default.userName) && !String.IsNullOrWhiteSpace(AppSettings.Default.UserPassword))
            {
                bool isVerfied = await AppDataBase.VerifyUser(AppSettings.Default.userName.ToLower(), AppSettings.Default.UserPassword);
                if (isVerfied)
                {
                    AppSettings.Default.isLogged = true;
                    AppSettings.Default.Save();
                    MyAlbums myAlbums = new MyAlbums();
                    myAlbums.Dock = DockStyle.Fill;
                    SettingsManager.SetTheme(myAlbums);
                    panelMain.Controls.Add(myAlbums);
                    myAlbums.Show();
                }
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Navigate(new Login());

        }

        private void btnUserControlPanel_Click(object sender, EventArgs e)
        {

            Navigate(new UserControlPanel());

        }

        private void btnMyAlbums_Click(object sender, EventArgs e)
        {

            Navigate(new MyAlbums());

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitMethod();
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            ExitMethod();
            SettingsManager.userItem = null;
            Navigate(new Login());
        }

        private void timerCheckUserLoggedIn_Tick(object sender, EventArgs e)
        {

            btnLogin.Visible = !Properties.AppSettings.Default.isLogged;
            btnMyAlbums.Visible = Properties.AppSettings.Default.isLogged;
            btnUserControlPanel.Visible = Properties.AppSettings.Default.isLogged;
            btnLogout.Visible = Properties.AppSettings.Default.isLogged;
            btnLogin.Visible = !Properties.AppSettings.Default.isLogged;
            if (Properties.AppSettings.Default.isLogged)
            {
                if(SettingsManager.userItem != null) 
                    btnAdminPanel.Visible = SettingsManager.userItem.GetIsAdmin();
            }
            else
                btnAdminPanel.Visible = false;


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
        public void Navigate(UserControl userControl)
        {
            //TO DO: apply visual sizing according to control opens
            userControl.Dock = DockStyle.Fill;
            panelMain.AutoScroll = true;
            panelMain.VerticalScroll.Enabled = true;
            panelMain.AutoScroll = true;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControl);
           
        }
       
    }
}
