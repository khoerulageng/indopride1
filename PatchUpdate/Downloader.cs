using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;

namespace PatchUpdate
{
    partial class SimpleUpdater
    {
        // Private vars for the Downloader
        private Queue<string> file_to_download;
        private long bytesdownloaded;
        private long totalbytestoreceive;
        private bool completed;

        private void DownloadFiles_Downloader()
        {
            // Initialize vars
            completed = false;
            bytesdownloaded = 0;
            file_to_download = new Queue<string>();

            foreach (KeyValuePair<string, File> entry in this.server_files)
            {
                // Create the directory
                try
                {
                    string dest_path_file = Path.Combine(this.installation_path, entry.Value.filename);
                    string new_dir_path = Path.GetDirectoryName(dest_path_file);
                    Directory.CreateDirectory(new_dir_path);
                }
                catch
                {
                    // Already exists
                }

                // Enqueue all files to the queue and all files will be processed one by one 
                this.file_to_download.Enqueue(entry.Value.filename);
            }

            // Don't block the main thread => Async thread
            Status_Changed(4);
            Thread download = new Thread(() => DownloadFile());
            download.Start();
        }

        private void DownloadFile()
        {
            // Check if there is any file in the queue
            if (this.file_to_download.Any())
            {
                WebClient client = new WebClient();

                // Set events for the client downloader
                client.DownloadProgressChanged += client_DownloadProgressChanged;
                client.DownloadFileCompleted += client_DownloadFileCompleted;

                string filename = file_to_download.Dequeue();

                Uri uri = new Uri(this.server_url + "/files/" + filename);
                string dest_path_file = Path.Combine(this.installation_path, filename);

                client.DownloadFileAsync(uri, dest_path_file);
            }
            else
            {
                // Download finished
                Download_Finished();
            }
        }

        private void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Status_Changed(6);
                throw e.Error;
            }

            this.bytesdownloaded += this.totalbytestoreceive;

            this.totalbytestoreceive = 0;
            this.completed = false;

            Status_Changed(5);

            DownloadFile();
        }

        private void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.totalbytestoreceive = e.TotalBytesToReceive;

            // Weird fix, this event is triggered two times for 100% - So check with 'completed' to avoid duplicates additions
            if (!this.completed && e.ProgressPercentage == 100)
            {
                this.completed = true;
                DownloadProgress_Changed(this.bytesdownloaded + e.BytesReceived);
            }
            else if (!this.completed)
            {
                DownloadProgress_Changed(this.bytesdownloaded + e.BytesReceived);
            }
        }
    }
}
