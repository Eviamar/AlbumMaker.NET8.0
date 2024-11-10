using AlbumMaker.Classes;
using AlbumMaker.Classes.Custom;
using AlbumMaker.Classes.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace AlbumMaker.Forms
{
    public partial class ScanForImages : UserControl
    {
        private int id;
        private Task scan;
        private CancellationTokenSource cancellationTokenSource;
        private BindingList<FileItem> scannedFiles; // Use BindingList for automatic UI updates
        private List<string> accessDeniedFiles;
        private List<string> images;
        private FileItem selectedFile;

        private SortOrder sortOrder;
        private string lastSortedColumn;
        public ScanForImages(List<string> images)
        {
            InitializeComponent();
            GetDrives();
            scannedFiles = new BindingList<FileItem>(); // Initialize BindingList
            accessDeniedFiles = new List<string>();

            id = 0;
            cancellationTokenSource = new CancellationTokenSource();
            dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            dataGridView1.CellClick += DataGridView1_CellClick;
            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;

            sortOrder = SortOrder.None;
            lastSortedColumn = string.Empty;

            if (images.Count == 0 || images is null)
                this.images = new List<string>();
            else
                this.images = images;
        }

        private void DataGridView1_ColumnHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the column that was clicked
            string columnName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;

            // Toggle the sort order if the same column is clicked again
            if (lastSortedColumn == columnName)
            {
                sortOrder = (sortOrder == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                sortOrder = SortOrder.Ascending;
            }

            lastSortedColumn = columnName; // Update the last sorted column

            // Sort the data based on the column clicked
            switch (columnName)
            {
                case "Name": // Assuming the property is called Name in FileItem
                case "Extension":
                case "RootDrive":
                    SortDataAlphabetically(columnName);
                    break;
                case "CreatedDate":
                case "ModifiedDate":
                    SortDataByDate(columnName);
                    break;
                default:
                    break;
            }
        }

        private void SortDataAlphabetically(string columnName)
        {
            // Sort alphabetically based on the sortOrder
            if (sortOrder == SortOrder.Ascending)
            {
                dataGridView1.DataSource = new BindingList<FileItem>(scannedFiles.OrderBy(f => typeof(FileItem).GetProperty(columnName).GetValue(f, null)).ToList());
            }
            else
            {
                dataGridView1.DataSource = new BindingList<FileItem>(scannedFiles.OrderByDescending(f => typeof(FileItem).GetProperty(columnName).GetValue(f, null)).ToList());
            }
        }

        private void SortDataByDate(string columnName)
        {
            // Sort by date based on the sortOrder
            if (sortOrder == SortOrder.Ascending)
            {
                dataGridView1.DataSource = new BindingList<FileItem>(scannedFiles.OrderBy(f => (DateTime)typeof(FileItem).GetProperty(columnName).GetValue(f, null)).ToList());
            }
            else
            {
                dataGridView1.DataSource = new BindingList<FileItem>(scannedFiles.OrderByDescending(f => (DateTime)typeof(FileItem).GetProperty(columnName).GetValue(f, null)).ToList());
            }
        }



        private void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FileItem file = scannedFiles[e.RowIndex];
                if (file != null)
                {
                    selectedFile = file;
                }

            }
        }

        private void DataGridView1_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FileItem selectedFile = scannedFiles[e.RowIndex];
                if (selectedFile != null)
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = selectedFile.GetName(),
                        UseShellExecute = true
                    });

                }
            }
        }

        private void GetDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            int tabIndex = 0;
            foreach (DriveInfo drive in allDrives)
            {
                Button btn = new Button
                {
                    Text = drive.Name,
                    TabIndex = tabIndex++
                };
                btn.MouseClick += (sender, args) => Button_MouseClick(sender, args, drive.RootDirectory.Name);
                flowLayoutPanelDrives.Controls.Add(btn);
            }
        }

        private void Button_MouseClick(object? sender, MouseEventArgs e, string drivePath)
        {
            ScanSelectedDrive(drivePath);
        }

        private async void ScanSelectedDrive(string drivePath)
        {
            scannedFiles.Clear();
            accessDeniedFiles.Clear();
            string[] pictureExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

            progressBarScanning.Visible = true;
            progressBarScanning.Style = ProgressBarStyle.Blocks; // Set to blocks for visual feedback
            progressBarScanning.Value = 0; // Reset the progress bar value

            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            cancellationTokenSource = new CancellationTokenSource();

            try
            {
                var progress = new Progress<int>(value => progressBarScanning.Value = value);

                await Task.Run(() =>
                {
                    var token = cancellationTokenSource.Token; // Get the new token
                    token.ThrowIfCancellationRequested(); // Check for cancellation at the start

                    // Get total number of files to scan
                    int totalFiles = CountFiles(drivePath, pictureExtensions);

                    // Scan the folder and report progress
                    ScanFolderRecursive(drivePath, pictureExtensions, token, progress, totalFiles); // Pass token and progress to recursive scan
                });


                dataGridView1.DataSource = scannedFiles;
                lblInfoFilter.Text = $"Finished!\n{scannedFiles.Count} imgs found.";

                if (accessDeniedFiles.Count > 0)
                {
                    DialogResult dr = MessageBox.Show($"{accessDeniedFiles.Count} files were unabled to be scanned due to access denied.\nWould you like to review which files?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        string files = "";
                        int count = 0;
                        foreach (string file in accessDeniedFiles)
                            files += $"{++count}) {file}\n";
                        MessageBox.Show(files, "Accessed denied files");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                lblInfoFilter.Text = "Scanning was canceled.";
            }
            finally
            {
                progressBarScanning.Visible = false; // Hide progress bar after completion
            }
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
                Debug.WriteLine($"Access denied to {folderPath}: {ex.Message}");
            }
            return count;
        }

        private void ScanFolderRecursive(string folderPath, string[] pictureExtensions, CancellationToken token, IProgress<int> progress, int totalFiles)
        {
            if (token.IsCancellationRequested) return; // Stop if cancellation is requested

            try
            {
                foreach (string file in Directory.GetFiles(folderPath))
                {
                    token.ThrowIfCancellationRequested(); // Check for cancellation in the loop
                    foreach (string extension in pictureExtensions)
                    {
                        if (Path.GetExtension(file).Equals(extension, StringComparison.OrdinalIgnoreCase))
                        {
                            FileInfo fileInfo = new FileInfo(file);
                            FileItem fileItem = new FileItem(id++, Path.GetPathRoot(file), file, Path.GetExtension(file), file, fileInfo.CreationTime, fileInfo.LastWriteTime);
                            scannedFiles.Add(fileItem);

                            // Report progress based on the number of scanned files
                            progress.Report((int)((double)scannedFiles.Count / totalFiles * 100)); // Report progress as a percentage
                        }
                    }
                }

                foreach (string subfolder in Directory.GetDirectories(folderPath))
                {
                    token.ThrowIfCancellationRequested(); // Check before scanning subfolders
                    ScanFolderRecursive(subfolder, pictureExtensions, token, progress, totalFiles); // Recursive call
                }
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("Scanning was canceled.", "Canceled");
            }
            catch (UnauthorizedAccessException ex)
            {
                accessDeniedFiles.Add($"{folderPath} => {ex.Message}");
            }
            catch
            {
                throw;
            }
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
            return scannedFiles.Where(file => file.RootDrive == root).ToList();
        }

        private List<FileItem> FilterByDate(DateTime date)
        {
            return scannedFiles.Where(file => file.CreatedDate >= date || file.ModifiedDate >= date).ToList();
        }

        private void ScanForImages_Leave(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }

        private void goBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAlbum createAlbum = new CreateAlbum();
            Panel p = this.Parent as Panel;
            if (p != null)
            {
                p.Controls.Add(createAlbum);
                createAlbum.Dock = DockStyle.Fill;
                this.Dispose();
                createAlbum.Show();
            }
        }

        private void ScanForImages_Load(object sender, EventArgs e)
        {
            SettingsManager.SetTheme(this);
            this.Parent.FindForm().Text = $"{Properties.AppSettings.Default.AppName} - {this.AccessibleName}";
            if (images.Count > 0)
            {
                //int count = 0;
                foreach (string image in images)
                {
                    DigiBumPictureBox digiBox = new DigiBumPictureBox(new ImageItem(0, image, "", 0), false);
                    digiBox.ImageDeleted += Picture_ImageDeleted;
                    flpSelectedImages.Controls.Add(digiBox);
                }
            }


        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (scannedFiles.Count == 0)
            {
                //MessageBox.Show("Scan first please.", "Nothing to filter");
                lblInfoFilter.Text = "Scan a drive first please.";
                return;
            }

            BindingList<FileItem> filteredFiles = new BindingList<FileItem>();
            BindingList<FileItem> filteredFilesByYear = new BindingList<FileItem>();
            foreach (FileItem file in scannedFiles)
            {
                if (file.CreatedDate.Date == dateTimePicker1.Value.Date || file.ModifiedDate.Date == dateTimePicker1.Value.Date)
                {
                    filteredFiles.Add(file);
                }
                else if (file.CreatedDate.Year == dateTimePicker1.Value.Year || file.ModifiedDate.Year == dateTimePicker1.Value.Year)
                {
                    filteredFilesByYear.Add(file);
                }
            }
            if (filteredFiles.Count > 0)
            {
                scannedFiles = filteredFiles;
                dataGridView1.DataSource = scannedFiles;
                return;
            }
            if (filteredFilesByYear.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Could not find any files with the date you selected..\nBUT I found some files that match the year you selected.\nWould you like to see them?", "Search completed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    scannedFiles = filteredFilesByYear;
                    dataGridView1.DataSource = scannedFiles;
                }
                return;
            }
            lblInfoFilter.Text = "Could not find any files matched to the date you picked";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedFile != null)
            {
                var alreadyExist = flpSelectedImages.Controls.Cast<DigiBumPictureBox>().FirstOrDefault(c => c.ImageLocation == selectedFile.GetName());
                if (alreadyExist == null)
                {

                    ImageItem imageItem = new ImageItem(selectedFile.GetID(), selectedFile.GetName(), "", -1);
                    DigiBumPictureBox digiBumPictureBox = new DigiBumPictureBox(imageItem, false);
                    digiBumPictureBox.ImageDeleted += Picture_ImageDeleted;
                    flpSelectedImages.Controls.Add(digiBumPictureBox);
                }
                else
                {
                    MessageBox.Show("The picture is already added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void Picture_ImageDeleted(object? sender, int e)
        {
            DigiBumPictureBox digi = (DigiBumPictureBox)sender;
            if (digi != null)
            {
                var controlToRemove = flpSelectedImages.Controls.Cast<DigiBumPictureBox>().FirstOrDefault(c => c.ImageLocation == digi.ImageLocation);
                if (controlToRemove != null)
                {
                    flpSelectedImages.Controls.Remove(controlToRemove);
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (flpSelectedImages.Controls.Count == 0 && this.images.Count == 0 || flpSelectedImages.Controls.Count == 0)
            {
                MessageBox.Show($"You didn't select any image(s) yet.\nPlease scan and select and then click confirm.","No images");
                return;
            }
            List<string> images = new List<string>();
            foreach(Control c in flpSelectedImages.Controls)
            {
                if(c is DigiBumPictureBox digi)
                {
                    images.Add(digi.ImageLocation);
                }
            }
            if(images.Count > 0)
            {
                CreateAlbum createAlbum = new CreateAlbum(images);
                Panel p = this.Parent as Panel;
                if (p != null)
                {
                    p.Controls.Add(createAlbum);
                    createAlbum.Dock = DockStyle.Fill;
                    this.Dispose();
                    createAlbum.Show();
                }
            }
        }
    }
}