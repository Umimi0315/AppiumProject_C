namespace Simulation_Forensics_Project
{
    partial class DownloadFileForm
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
            this.attachmentListBox = new System.Windows.Forms.ListBox();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.downloadFileBgw = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // attachmentListBox
            // 
            this.attachmentListBox.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.attachmentListBox.FormattingEnabled = true;
            this.attachmentListBox.ItemHeight = 14;
            this.attachmentListBox.Location = new System.Drawing.Point(3, 31);
            this.attachmentListBox.Name = "attachmentListBox";
            this.attachmentListBox.Size = new System.Drawing.Size(530, 256);
            this.attachmentListBox.TabIndex = 0;
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(218, 301);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(75, 23);
            this.downloadBtn.TabIndex = 1;
            this.downloadBtn.Text = "下载";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "下载列表";
            // 
            // downloadFileBgw
            // 
            this.downloadFileBgw.WorkerReportsProgress = true;
            this.downloadFileBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DownloadFileBgw_DoWork);
            // 
            // DownloadFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 336);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.attachmentListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DownloadFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DownloadFile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloadFileForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox attachmentListBox;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker downloadFileBgw;
    }
}