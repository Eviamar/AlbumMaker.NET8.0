using AlbumMaker.Classes;
using AlbumMaker.Classes.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AlbumMaker.Forms
{
    public partial class ScanForImages : UserControl
    {
        private int id;
        private Task scan;
        private CancellationTokenSource cancellationTokenSource;
        private BindingList<FileItem> scannedFiles; // Use BindingList for automatic UI updates
        public ScanForImages()
        {
            InitializeComponent();
            GetDrives();
            scannedFiles = new BindingList<FileItem>(); // Initialize BindingList
            id = 0;
        }

        private void GetDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in allDrives)
            {
                Button btn = new Button
                {
                    Text = drive.Name
                };
                btn.MouseClick += (sender, args) => Button_MouseClick(sender, args, drive.RootDirectory.Name);
                flowLayoutPanelDrives.Controls.Add(btn);
            }
        }

        private void Button_MouseClick(object? sender, MouseEventArgs e, string drivePath)
        {
            ScanSelectedDrive(drivePath);
        }

        private void ScanSelectedDrive(string drivePath)
        {
            scannedFiles.Clear();
            string[] pictureExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

            progressBarScanning.Visible = true;
            progressBarScanning.Style = ProgressBarStyle.Marquee; // Set ProgressBar style to marquee for ongoing operations

            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            cancellationTokenSource = new CancellationTokenSource();

            scan = Task.Run(() => // Run scanning operation in a background task
            {
                try
                {
                    int fileCount = CountFiles(drivePath, pictureExtensions); // Count files for progress bar max value
                    ScanFolderRecursive(drivePath, pictureExtensions);

                    // Update DataGridView on UI thread
                    Invoke(new Action(() =>
                    {
                        dataGridView1.DataSource = scannedFiles;
                        progressBarScanning.Visible = false;
                        MessageBox.Show($"Finished, {scannedFiles.Count} images were scanned.");
                    }));
                }
                catch (Exception ex)
                {
                    // Handle general exceptions
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            });
        }

        private int CountFiles(string folderPath, string[] pictureExtensions)
        {
            int count = 0;
            try
            {
                foreach (string file in Directory.GetFiles(folderPath))
                {
                    foreach (string extension in pictureExtensions)
                    {
                        if (Path.GetExtension(file) == extension)
                            count++;
                    }
                }
                foreach (string subfolder in Directory.GetDirectories(folderPath))
                {
                    count += CountFiles(subfolder, pictureExtensions);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle access denied exceptions but continue counting
                Console.WriteLine($"Access denied to {folderPath}: {ex.Message}");
            }
            return count;
        }

        private void ScanFolderRecursive(string folderPath, string[] pictureExtensions)
        {
            try
            {
                foreach (string file in Directory.GetFiles(folderPath))
                {
                    foreach (string extension in pictureExtensions)
                    {
                        if (Path.GetExtension(file) == extension)
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            scannedFiles.Add(new FileItem(id++, Path.GetPathRoot(file), file, Path.GetExtension(file), file, fileInfo.CreationTime, fileInfo.LastWriteTime));
                        }
                    }
                }

                foreach (string subfolder in Directory.GetDirectories(folderPath))
                {
                    ScanFolderRecursive(subfolder, pictureExtensions);
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                // Handle access denied exceptions but continue scanning
                Console.WriteLine($"Access denied to {folderPath}: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"An error occurred while scanning {folderPath}: {ex.Message}");
            }
        }

        private void AddScannedItemsToPanel()
        {
            // No need to call AddScannedItemsToPanel since DataGridView is already updated in ScanSelectedDrive
        }

        private void OpenImage(object sender, EventArgs e, PictureBox pb)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = pb.ImageLocation,
                UseShellExecute = true
            });
        }

        private List<FileItem> FilterByRoot(string root)
        {
            return scannedFiles.Where(file => file.GetRootDrive() == root).ToList();
        }

        private List<FileItem> FilterByDate(DateTime date)
        {
            return scannedFiles.Where(file => file.GetCreatedDate() >= date || file.GetModifiedDate() >= date).ToList();
        }

        private void ScanForImages_Leave(object sender, EventArgs e)
        {

        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAlbum createAlbum = new CreateAlbum();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(createAlbum);
                createAlbum.Dock = DockStyle.Fill;
                SettingsManager.SetTheme(createAlbum);
                this.Dispose();
                createAlbum.Show();
            }
        }
    }
}