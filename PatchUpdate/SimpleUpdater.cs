using System;
using System.Collections.Generic;
using System.Threading;

namespace PatchUpdate
{
    public partial class SimpleUpdater
    {
        #region Public vars Declaration

        private string server_url;
        public string Server_Url
        {
            get => this.server_url;
        }

        private string installation_path;
        public string Installation_path
        {
            get => this.installation_path;
        }

        private bool canDownload;
        public bool CanDownload
        {
            get => canDownload;
        }

        private bool canCheck;
        public bool CanCheck
        {
            get => canCheck;
        }

        private long numberOfBytesToDownload;
        public long NumberOfBytesToDownload
        {
            get => this.numberOfBytesToDownload;
        }

        private int statusCode;
        public int StatusCode
        {
            get => this.statusCode;
        }

        #endregion

        #region Events Declaration

        public delegate void CheckFinished(int nbrLocalFiles, int nbrServerFiles, int nbrFilesToDownload, int nbrFilesDeleted, long numberOfBytesToDownload);
        public event CheckFinished OnCheckFinished;

        public delegate void DownloadFinished(long totalbytesdownloaded);
        public event DownloadFinished OnDownloadFinished;

        public delegate void DownloadProgressChanged(long totalbytesdownloaded, float percent);
        public event DownloadProgressChanged OnDownloadProgressChanged;

        public delegate void StatusChanged(int code);
        public event StatusChanged OnStatusChanged;

        #endregion

        #region Private Variables Declaration

        // Var - Global of the Updater (Check + Download)
        private Dictionary<string, File> server_files;
        private List<string> ignore_list_files;
        private Dictionary<string, bool> ignore_list_folders;
        public string version1;
        public string version2;


        #endregion

        #region Constructor

        public SimpleUpdater(string server_url, string installation_path)
        {
            this.server_url = server_url;
            this.installation_path = installation_path;
            canDownload = false;
            canCheck = true;
            statusCode = 0;
        }

        #endregion

        public void CheckFilesFromServerAndDeleteOutdated()
        {
            if (!canCheck)
            {
                throw new Exception("Check not authorized. Are you downloading ?");
            }

            server_files = new Dictionary<string, File>();

            this.canCheck = false;
            this.canDownload = false;

            Thread checker = new Thread(() => Check());
            checker.Start();
        }

        public void DownloadFiles()
        {
            if (!canDownload || server_files == null)
            {
                throw new Exception("Download not authorized. Have you checked out server files ?");
            }

            this.canDownload = false;
            this.canCheck = false;
            DownloadFiles_Downloader();
        }

        #region Events Redirection

        private void Check_Finished(int nbrLocalFiles, int nbrServerFiles, int nbrFilesToDownload, int nbrFilesDeleted)
        {
            this.canCheck = true;
            this.canDownload = true;

            this.OnCheckFinished(nbrLocalFiles, nbrServerFiles, nbrFilesToDownload, nbrFilesDeleted, this.numberOfBytesToDownload);
            Status_Changed(3);
            Status_Changed(0);
        }

        private void Download_Finished()
        {
            this.canDownload = true;
            this.canCheck = true;
            this.OnDownloadFinished(this.bytesdownloaded);
            Status_Changed(8);
            Status_Changed(0);
        }

        private void DownloadProgress_Changed(long totalbytesdownloaded)
        {
            float percent;
            // Division by 0 ? Don't know if it can occur
            try
            {
                percent = (float)(totalbytesdownloaded) / (float)numberOfBytesToDownload;
            }
            catch
            {
                percent = 100;
            }

            // Trigger event
            OnDownloadProgressChanged(totalbytesdownloaded, percent * 100);
        }

        private void Status_Changed(int code)
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

            this.statusCode = code;
            this.OnStatusChanged(code);
        }

        #endregion
    }
}
