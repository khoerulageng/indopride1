using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INDOPRIDE
{
    public partial class indopride : Form
    {
        int mouseX, mouseY, mouse;

        private string installation_path = Path.Combine(Application.StartupPath, "files");
        private string urlServer = "http://localhost/launcher";

        SimpleUpdater updater;

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mouseX, MousePosition.Y - mouseY);

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse = 1;
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = 0;
        }

        public indopride()
        {
            this.BackColor = Color.DimGray;
            this.TransparencyKey = Color.DimGray;
            InitializeComponent();

            ProgressBarDownloading.Maximum = 100;


            // Initialize the Simple Updater
            updater = new SimpleUpdater(urlServer, installation_path);

            // Initalize Events of the SimpleUpdater
            updater.OnCheckFinished += Updater_OnCheckFinished;
            updater.OnDownloadFinished += Updater_OnDownloadFinished;
            updater.OnDownloadProgressChanged += Updater_OnDownloadProgressChanged;
            updater.OnStatusChanged += Updater_OnStatusChanged;
        }

        private void Updater_OnStatusChanged(int code)
        {
            /*
             * 0 - Waiting for action
             * 1 - Contacting server for files to parse
             * 2 - Search and delete local files
             * 3 - Check finished - Triggered after Check_Finished(...) - (not very usefull - duplicate of Check_Finished(...) )
             * 4 - Download started
             * 5 - A file has been successfully downloaded
             * 6 - An error occurered when downloading a file
             * 7 - An error occured will trying to access the server
             * 8 - Download finished - Triggered after Download_Finished(...) - (not very usefull - duplicate of Download_Finished(...) )
             */

            switch (code)
            {
                case 0: Debug.WriteLine("Status: Waiting for action"); return;
                case 1: Debug.WriteLine("Status: Contacting server for files to parse"); return;
                case 2: Debug.WriteLine("Status: Search and delete local files"); return;
                case 3: Debug.WriteLine("Status: Check finished"); return;
                case 4: Debug.WriteLine("Status: Download started"); return;
                case 5: Debug.WriteLine("Status: A file has been successfully downloaded"); return;
                case 6: Debug.WriteLine("Status: An error occurered when downloading a file"); return;
                case 7: Debug.WriteLine("Status: An error occured will trying to access the server"); return;
                case 8: Debug.WriteLine("Status: Download finished"); return;
                default: return;
            }
        }

        private void Updater_OnDownloadProgressChanged(long totalbytesdownloaded, float percent)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TotalBytesDownloaded_Label.Text = "Total bytes downloaded : " + totalbytesdownloaded + " - " + Math.Round(percent) + "%";
                ProgressBarDownloading.Value = (int)Math.Round(percent);
            });
        }

        private void Check_Button_Click(object sender, EventArgs e)
        {
            updater.CheckFilesFromServerAndDeleteOutdated();
        }

        private void Download_Button_Click(object sender, EventArgs e)
        {
            updater.DownloadFiles();
        }

        // Event triggered when the download finished
        private void Updater_OnDownloadFinished(long totalbytesdownloaded)
        {
            this.Invoke((MethodInvoker)delegate
            {
                TotalBytesDownloaded_Label.Text = "Total bytes downloaded : " + totalbytesdownloaded + " - 100%";
            });
            MessageBox.Show("Download finished !");
        }

        private void Updater_OnCheckFinished(int nbrLocalFiles, int nbrServerFiles, int nbrFilesToDownload, int nbrFilesDeleted, long numberOfBytesToDownload)
        {
            this.Invoke((MethodInvoker)delegate
            {
                NbrLocalFiles_Label.Text = "Number of local Files : " + nbrLocalFiles;
                NbrServerFile_Label.Text = "Number of server Files : " + nbrServerFiles;
                NbrFilesToDownload_Label.Text = "Number of files to download : " + nbrFilesToDownload;
                NbrFilesDeleted_Label.Text = "Number of files deleted : " + nbrFilesDeleted;
                TotalBytesToDownload_Label.Text = "Total bytes to download : " + numberOfBytesToDownload;
            });
        }




    }
}
