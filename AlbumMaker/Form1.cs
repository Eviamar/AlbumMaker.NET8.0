using AlbumMaker.Classes;
using AlbumMaker.Classes.Db;
using AlbumMaker.Forms;
using AlbumMaker.Forms.UserForms;
using AlbumMaker.Properties;
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
        // Button click event that triggers timer to close/open side menu.
        private void btnMenuToggle_Click(object sender, EventArgs e)
        {

            if (menuOpen)
                timerMenuClose.Start();
            else
                timerMenuOpen.Start();
        }
        // The timer function that does the 'animation' of menu closing
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
        // The timer function that does the 'animation' of menu opening
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

        // Function for button event (in side menu) click for navigating to Application Settings 'page'.
        private void btnSettings_Click(object sender, EventArgs e)
        {
            Navigate(new Settings(timerMenuClose, timerMenuOpen));
        }
        private async void Form1_Load(object sender, EventArgs e)
        {

            Properties.AppSettings.Default.AppEXELocation = AppDomain.CurrentDomain.BaseDirectory;
            if(String.IsNullOrEmpty(Properties.AppSettings.Default.AppDataFolder))
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

        // Function for button event (in side menu) click for navigating to Settings 'page'.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Navigate(new Login());
        }
        // Function for button event (in side menu) click for navigating to User Settings 'page'.
        private void btnUserControlPanel_Click(object sender, EventArgs e)
        {
            Navigate(new UserControlPanel());
        }
        // Function for button event (in side menu) click for navigating to User's Albums 'page'.
        private void btnMyAlbums_Click(object sender, EventArgs e)
        {
            Navigate(new MyAlbums());
        }

        // Function for button event (in side menu) click closing the application.
        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitMethod();
            Application.Exit();
        }

        // Function for button event (in side menu) click that handles logout.
        // AppSettings for saved current user 'reset' and takes the user to the login 'page'
        private void btnLogout_Click(object sender, EventArgs e)
        {
            ExitMethod();
            SettingsManager.userItem = null;
            Properties.AppSettings.Default.UserPassword = "";
            Properties.AppSettings.Default.Save();
            Navigate(new Login());
        }

        // Function that handles the opening the menu while application opens 
        // Made for checking if user is logged or not and display the buttons in side menu accordingly.
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

        // Function for button event (in side menu) click for navigating to Admin 'page'.
        private void btnAdminPanel_Click(object sender, EventArgs e)
        {
            Navigate(new AdminPanel());
        }

        // The main function that handles the logic to display the selected 'page' to the UI.
        public void Navigate(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelMain.AutoScroll = true;
            panelMain.VerticalScroll.Enabled = true;
            panelMain.AutoScroll = true;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(userControl);
        }
       
    }
}
