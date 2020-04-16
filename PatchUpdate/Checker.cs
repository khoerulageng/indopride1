using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PatchUpdate
{
    partial class SimpleUpdater
    {
        private void Check()
        {
            // Check if installation_path folder exists, otherwise create it
            if (!Directory.Exists(this.installation_path))
            {
                Directory.CreateDirectory(this.installation_path);
            }

            // Get server files
            Status_Changed(1);
            this.server_files = parseFileServer();
            int nbrServerFiles = this.server_files.Count;
            int nbrFilesDeleted = 0;
            int nbrLocalFiles = 0;

            // Check local files with server files
            Status_Changed(2);
            SearchLocalFiles(this.installation_path, this.installation_path, this.server_files, this.ignore_list_files, this.ignore_list_folders, ref nbrLocalFiles, ref nbrFilesDeleted, false, false);
            nbrLocalFiles = nbrLocalFiles - nbrFilesDeleted;
            int nbrFilesToDownload = this.server_files.Count;

            // Get number of bytes to download
            numberOfBytesToDownload = 0;
            foreach (KeyValuePair<string, File> entry in this.server_files)
            {
                this.numberOfBytesToDownload += entry.Value.filesize;
            }

            Check_Finished(nbrLocalFiles, nbrServerFiles, nbrFilesToDownload, nbrFilesDeleted);
        }

        private static bool SearchLocalFiles(string installation_path, string dir, Dictionary<string, File> server_files, List<string> ignore_list_files, Dictionary<string, bool> ignore_list_folders, ref int nbrFilesLocal, ref int nbrFilesDeleted, bool ignoreFilesInThisFolder, bool ignoreAllSubfolder)
        {
            bool checkFolderEmpty = false;

            try
            {
                // Add all files from current folder
                foreach (string file in Directory.GetFiles(dir))
                {
                    string md5 = getMD5(file);
                    string file_path = file.Substring(installation_path.Length + 1);
                    nbrFilesLocal++;

                    // Check the ignore list
                    if (ignore_list_files.Contains(file_path) || (!server_files.ContainsKey(file_path) && ignoreFilesInThisFolder))
                    {
                        // Skip this file
                    }
                    else if (server_files.ContainsKey(file_path) && (server_files[file_path].md5 == md5 || ignoreFilesInThisFolder))
                    {
                        // So the file is correct - delete it from server files list dictionary (will be used to download missing files)
                        server_files.Remove(file_path);
                    }
                    else
                    {
                        // The server do not contains this file so delete it in local file
                        System.IO.File.Delete(file);
                        checkFolderEmpty = true;
                        nbrFilesDeleted++;
                    }
                }

                // Delete the directory if it's empty
                if (!Directory.EnumerateFileSystemEntries(dir).Any())
                    Directory.Delete(dir);
                else
                {
                    // Search and add all files from directories
                    bool oldValueIgnore = ignoreAllSubfolder;
                    foreach (string directory in Directory.GetDirectories(dir))
                    {
                        // Check if this folder is ignored
                        // Do not check if a parent folder is already ignored with 'all_subfolders' set to true

                        string path_dir = directory.Substring(installation_path.Length + 1);
                        ignoreFilesInThisFolder = ignoreAllSubfolder || ignore_list_folders.ContainsKey(path_dir);

                        if (!ignoreAllSubfolder && ignore_list_folders.ContainsKey(path_dir))
                            ignoreAllSubfolder = ignore_list_folders[path_dir];

                        if (SearchLocalFiles(installation_path, directory, server_files, ignore_list_files, ignore_list_folders, ref nbrFilesLocal, ref nbrFilesDeleted, ignoreFilesInThisFolder, ignoreAllSubfolder))
                        {
                            // Delete the directory if it's empty
                            if (Directory.Exists(dir) && !Directory.EnumerateFileSystemEntries(dir).Any())
                            {
                                Directory.Delete(dir);
                                checkFolderEmpty = true;
                            }
                        }

                        ignoreAllSubfolder = oldValueIgnore;
                    }
                }

                return checkFolderEmpty;
            }
            catch
            {
                return false;
            }
        }

        private static string getMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = System.IO.File.OpenRead(filename))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }

        private Dictionary<string, File> parseFileServer()
        {
            List<File> files_server = new List<File>();
            string jsonFile = "";
            using (var client = new System.Net.WebClient())
            {
                try
                {
                    jsonFile = client.DownloadString(this.server_url);
                }
                catch
                {
                    Status_Changed(7);
                    return new Dictionary<string, File>();
                }
            }

            if (!string.IsNullOrEmpty(jsonFile))
            {
                ServerResponse jsonResult = JSONSerializer<ServerResponse>.DeSerialize(jsonFile);

                // Set up the dictionary for server files
                Dictionary<string, File> files_arr_tmp = new Dictionary<string, File>();
                foreach (File file in jsonResult.files)
                {
                    files_arr_tmp.Add(file.filename, file);
                }

                // Get Ignore list
                this.ignore_list_files = new List<string>();
                this.ignore_list_folders = new Dictionary<string, bool>();

                foreach (IgnoreFolderConfig folder in jsonResult.ignore.folders)
                {
                    this.ignore_list_folders.Add(folder.folder_path, folder.all_subfolders);
                }

                foreach (string file in jsonResult.ignore.files)
                {
                    this.ignore_list_files.Add(file);
                }

                this.version1 = jsonResult.version;
                MessageBoxEx.Show(version1);

                return files_arr_tmp;
            }
            else
            {
                // Any json result from the server, maybe a bad config of the server (blank page)
                return new Dictionary<string, File>();
            }
        }
    }
}
