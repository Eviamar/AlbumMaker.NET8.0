using AlbumMaker.Classes;

namespace AlbumMaker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.ThreadException += (sender, e) => AppErrorHandler.LogError(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    AppErrorHandler.LogError(ex);
                }
                else
                {
                    AppErrorHandler.LogError(new Exception(e.ExceptionObject.ToString()));
                }
            };

            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                AppErrorHandler.LogError(ex);
            }
        }
        
    }
}