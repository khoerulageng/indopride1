namespace INDOPRIDE
{
    partial class indopride
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(indopride));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProgressBarDownloading = new System.Windows.Forms.ProgressBar();
            this.TotalBytesDownloaded_Label = new System.Windows.Forms.Label();
            this.TotalBytesToDownload_Label = new System.Windows.Forms.Label();
            this.Download_Button = new System.Windows.Forms.Button();
            this.NbrFilesDeleted_Label = new System.Windows.Forms.Label();
            this.NbrFilesToDownload_Label = new System.Windows.Forms.Label();
            this.NbrServerFile_Label = new System.Windows.Forms.Label();
            this.NbrLocalFiles_Label = new System.Windows.Forms.Label();
            this.Check_Button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.ProgressBarDownloading);
            this.panel1.Controls.Add(this.TotalBytesDownloaded_Label);
            this.panel1.Controls.Add(this.TotalBytesToDownload_Label);
            this.panel1.Controls.Add(this.Download_Button);
            this.panel1.Controls.Add(this.NbrFilesDeleted_Label);
            this.panel1.Controls.Add(this.NbrFilesToDownload_Label);
            this.panel1.Controls.Add(this.NbrServerFile_Label);
            this.panel1.Controls.Add(this.NbrLocalFiles_Label);
            this.panel1.Controls.Add(this.Check_Button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // ProgressBarDownloading
            // 
            this.ProgressBarDownloading.Location = new System.Drawing.Point(462, 293);
            this.ProgressBarDownloading.Name = "ProgressBarDownloading";
            this.ProgressBarDownloading.Size = new System.Drawing.Size(129, 23);
            this.ProgressBarDownloading.TabIndex = 17;
            // 
            // TotalBytesDownloaded_Label
            // 
            this.TotalBytesDownloaded_Label.AutoSize = true;
            this.TotalBytesDownloaded_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalBytesDownloaded_Label.Location = new System.Drawing.Point(459, 251);
            this.TotalBytesDownloaded_Label.Name = "TotalBytesDownloaded_Label";
            this.TotalBytesDownloaded_Label.Size = new System.Drawing.Size(126, 13);
            this.TotalBytesDownloaded_Label.TabIndex = 16;
            this.TotalBytesDownloaded_Label.Text = "Total bytes downloaded :";
            // 
            // TotalBytesToDownload_Label
            // 
            this.TotalBytesToDownload_Label.AutoSize = true;
            this.TotalBytesToDownload_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TotalBytesToDownload_Label.Location = new System.Drawing.Point(459, 224);
            this.TotalBytesToDownload_Label.Name = "TotalBytesToDownload_Label";
            this.TotalBytesToDownload_Label.Size = new System.Drawing.Size(126, 13);
            this.TotalBytesToDownload_Label.TabIndex = 15;
            this.TotalBytesToDownload_Label.Text = "Total bytes to download :";
            // 
            // Download_Button
            // 
            this.Download_Button.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Download_Button.Location = new System.Drawing.Point(462, 168);
            this.Download_Button.Name = "Download_Button";
            this.Download_Button.Size = new System.Drawing.Size(129, 42);
            this.Download_Button.TabIndex = 14;
            this.Download_Button.Text = "Download";
            this.Download_Button.UseVisualStyleBackColor = true;
            this.Download_Button.Click += new System.EventHandler(this.Download_Button_Click);
            // 
            // NbrFilesDeleted_Label
            // 
            this.NbrFilesDeleted_Label.AutoSize = true;
            this.NbrFilesDeleted_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NbrFilesDeleted_Label.Location = new System.Drawing.Point(212, 303);
            this.NbrFilesDeleted_Label.Name = "NbrFilesDeleted_Label";
            this.NbrFilesDeleted_Label.Size = new System.Drawing.Size(121, 13);
            this.NbrFilesDeleted_Label.TabIndex = 13;
            this.NbrFilesDeleted_Label.Text = "Number of files deleted :";
            // 
            // NbrFilesToDownload_Label
            // 
            this.NbrFilesToDownload_Label.AutoSize = true;
            this.NbrFilesToDownload_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NbrFilesToDownload_Label.Location = new System.Drawing.Point(212, 277);
            this.NbrFilesToDownload_Label.Name = "NbrFilesToDownload_Label";
            this.NbrFilesToDownload_Label.Size = new System.Drawing.Size(144, 13);
            this.NbrFilesToDownload_Label.TabIndex = 12;
            this.NbrFilesToDownload_Label.Text = "Number of files to download :";
            // 
            // NbrServerFile_Label
            // 
            this.NbrServerFile_Label.AutoSize = true;
            this.NbrServerFile_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NbrServerFile_Label.Location = new System.Drawing.Point(212, 251);
            this.NbrServerFile_Label.Name = "NbrServerFile_Label";
            this.NbrServerFile_Label.Size = new System.Drawing.Size(118, 13);
            this.NbrServerFile_Label.TabIndex = 11;
            this.NbrServerFile_Label.Text = "Number of server Files :";
            // 
            // NbrLocalFiles_Label
            // 
            this.NbrLocalFiles_Label.AutoSize = true;
            this.NbrLocalFiles_Label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NbrLocalFiles_Label.Location = new System.Drawing.Point(212, 224);
            this.NbrLocalFiles_Label.Name = "NbrLocalFiles_Label";
            this.NbrLocalFiles_Label.Size = new System.Drawing.Size(111, 13);
            this.NbrLocalFiles_Label.TabIndex = 10;
            this.NbrLocalFiles_Label.Text = "Number of local Files :";
            // 
            // Check_Button
            // 
            this.Check_Button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Check_Button.Location = new System.Drawing.Point(215, 168);
            this.Check_Button.Name = "Check_Button";
            this.Check_Button.Size = new System.Drawing.Size(129, 42);
            this.Check_Button.TabIndex = 9;
            this.Check_Button.Text = "Check files from server and delete old";
            this.Check_Button.UseVisualStyleBackColor = true;
            this.Check_Button.Click += new System.EventHandler(this.Check_Button_Click);
            // 
            // indopride
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "indopride";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "indopride";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar ProgressBarDownloading;
        private System.Windows.Forms.Label TotalBytesDownloaded_Label;
        private System.Windows.Forms.Label TotalBytesToDownload_Label;
        private System.Windows.Forms.Button Download_Button;
        private System.Windows.Forms.Label NbrFilesDeleted_Label;
        private System.Windows.Forms.Label NbrFilesToDownload_Label;
        private System.Windows.Forms.Label NbrServerFile_Label;
        private System.Windows.Forms.Label NbrLocalFiles_Label;
        private System.Windows.Forms.Button Check_Button;
    }
}

