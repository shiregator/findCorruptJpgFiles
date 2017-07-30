using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorruptedFileFixer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string selectedFolder;
        private List<string> imagesToFix = new List<string>();

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            statusLabel.Text = "";
            mainProgress.Value = 0;
            imagesToFix.Clear();
            folderNameLabel.Text = "";
            var dial = new FolderBrowserDialog();
            if (dial.ShowDialog() == DialogResult.OK)
            {
                startButton.Enabled = !String.IsNullOrWhiteSpace(dial.SelectedPath);
                folderNameLabel.Text = dial.SelectedPath;
                selectedFolder = dial.SelectedPath;
                statusLabel.Text = "Ready!";
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            selectFolderButton.Enabled = false;
            statusLabel.Text = "Scanning folder for images..";
            check = 0;
            found = 0;
            var filesCount = await ScanFolderForJPG(selectedFolder);
            mainProgress.Maximum = filesCount;
            statusLabel.Text = "Found " + filesCount + " corrupted images.. Fixing..";
            log.Clear();
            foreach(string img in imagesToFix)
            {
                if (simulateCB.Checked || await FixImage(img))
                {
                    log.Text += img + (!simulateCB.Checked ? " *fixed" : "") + Environment.NewLine;
                } else
                {
                    log.Text += img + " *FAILED TO FIX" + Environment.NewLine;
                }
                mainProgress.Value++;
            }
            statusLabel.Text = "Done!";
            selectFolderButton.Enabled = true;
        }

        private void SetStatusLabelText(string text)
        {
            if (InvokeRequired)
            {
                Invoke((Action<string>)SetStatusLabelText, text);
                return;
            }
            statusLabel.Text = text;
        }

        int check;
        int found;

        private async Task<int> ScanFolderForJPG(string path)
        {
            int res = 0;
            try
            {
                foreach (string file in Directory.GetFiles(path))
                {
                    Application.DoEvents();
                    if (Path.GetExtension(file).ToLower() == ".jpg")
                    {
                        check++;
                        SetStatusLabelText("Scanning " + path + " .. Checked " + check + " files. Found " + found + " corrupted files..");
                        using (FileStream str = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.Delete | FileShare.ReadWrite))
                        {
                            if (str.Length < 100) //can image be less than 100 bytes?
                                continue;
                            using (BinaryReader read = new BinaryReader(str))
                            {
                                if (read.ReadUInt64() == 0x0A1A0A0D474E5089L) //checking png signature;
                                {
                                    imagesToFix.Add(file);
                                    res++;
                                    found++;
                                }
                            }
                        }
                    }
                }
                foreach (string dir in Directory.GetDirectories(path))
                {
                    res += await ScanFolderForJPG(dir);
                }
            } catch (Exception e)
            {
                log.Text += e.Message + Environment.NewLine;
            }
            return res;
        }

        private async Task<bool> FixImage(string image)
        {
            try
            {
                using (FileStream str = File.OpenRead(image))
                {
                    using (Image img = Image.FromStream(str))
                    {
                        if (img.RawFormat.Guid == ImageFormat.Png.Guid)
                        {
                            img.Save(image + "tmp", ImageFormat.Jpeg);
                        }
                    }
                }
                File.Delete(image);
                File.Move(image + "tmp", image);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
