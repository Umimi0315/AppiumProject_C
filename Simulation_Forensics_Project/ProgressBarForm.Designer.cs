namespace Simulation_Forensics_Project
{
    partial class ProgressBarForm
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.taskStatusText = new System.Windows.Forms.Label();
            this.progressBarFormBgw = new System.ComponentModel.BackgroundWorker();
            this.ConfirmBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 80);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(332, 23);
            this.progressBar.TabIndex = 0;
            // 
            // taskStatusText
            // 
            this.taskStatusText.AutoSize = true;
            this.taskStatusText.Location = new System.Drawing.Point(131, 54);
            this.taskStatusText.Name = "taskStatusText";
            this.taskStatusText.Size = new System.Drawing.Size(83, 12);
            this.taskStatusText.TabIndex = 1;
            this.taskStatusText.Text = "正在初始化...";
            // 
            // progressBarFormBgw
            // 
            this.progressBarFormBgw.WorkerReportsProgress = true;
            // 
            // ConfirmBtn
            // 
            this.ConfirmBtn.Location = new System.Drawing.Point(133, 129);
            this.ConfirmBtn.Name = "ConfirmBtn";
            this.ConfirmBtn.Size = new System.Drawing.Size(75, 23);
            this.ConfirmBtn.TabIndex = 2;
            this.ConfirmBtn.Text = "确定";
            this.ConfirmBtn.UseVisualStyleBackColor = true;
            this.ConfirmBtn.Click += new System.EventHandler(this.ConfirmBtn_Click);
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 175);
            this.ControlBox = false;
            this.Controls.Add(this.ConfirmBtn);
            this.Controls.Add(this.taskStatusText);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ProgressBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "任务进度";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProgressBarForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label taskStatusText;
        private System.ComponentModel.BackgroundWorker progressBarFormBgw;
        private System.Windows.Forms.Button ConfirmBtn;
    }
}