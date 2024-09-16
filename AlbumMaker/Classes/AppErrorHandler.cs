using System.Diagnostics;


namespace AlbumMaker.Classes
{
    internal static class AppErrorHandler
    {
        private static readonly string LogFilePath = Path.Combine(AppContext.BaseDirectory, $"error_log_{DateTime.Now.ToString("dd-MM-yyyy")}.log");

        public static void LogError(Exception ex)
        {
            try
            {
                // Ensure the log file directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(LogFilePath));

                // Format the error message
                string errorMessage = $"[{DateTime.Now}] {ex.Message}{Environment.NewLine}{ex.StackTrace}{Environment.NewLine}";

                // Append the error message to the log file
                File.AppendAllText(LogFilePath, $"=>{errorMessage}");
                DialogResult dr = MessageBox.Show($"An error occurred and been recorded to the error log file.\nDo you want to open the log?","Alert",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if(dr == DialogResult.Yes)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = LogFilePath,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception logEx)
            {
                
                MessageBox.Show($"Failed to write to log file: {logEx.Message}\n\n{logEx}",logEx.Message);
            }
        }
    }
}
