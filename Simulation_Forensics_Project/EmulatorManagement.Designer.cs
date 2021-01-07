namespace Simulation_Forensics_Project
{
    partial class EmulatorManagement
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
            this.EmulatorInfoList = new System.Windows.Forms.ListBox();
            this.CreateEmuBtn = new System.Windows.Forms.Button();
            this.StartEmuBtn = new System.Windows.Forms.Button();
            this.StopEmuBtn = new System.Windows.Forms.Button();
            this.DeleteEmuBtn = new System.Windows.Forms.Button();
            this.EmuManageInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EmulatorInfoList
            // 
            this.EmulatorInfoList.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmulatorInfoList.FormattingEnabled = true;
            this.EmulatorInfoList.ItemHeight = 16;
            this.EmulatorInfoList.Location = new System.Drawing.Point(2, 29);
            this.EmulatorInfoList.Name = "EmulatorInfoList";
            this.EmulatorInfoList.Size = new System.Drawing.Size(432, 356);
            this.EmulatorInfoList.TabIndex = 0;
            // 
            // CreateEmuBtn
            // 
            this.CreateEmuBtn.Location = new System.Drawing.Point(11, 409);
            this.CreateEmuBtn.Name = "CreateEmuBtn";
            this.CreateEmuBtn.Size = new System.Drawing.Size(80, 21);
            this.CreateEmuBtn.TabIndex = 1;
            this.CreateEmuBtn.Text = "创建";
            this.CreateEmuBtn.UseVisualStyleBackColor = true;
            this.CreateEmuBtn.Click += new System.EventHandler(this.CreateEmuBtn_Click);
            // 
            // StartEmuBtn
            // 
            this.StartEmuBtn.Location = new System.Drawing.Point(122, 409);
            this.StartEmuBtn.Name = "StartEmuBtn";
            this.StartEmuBtn.Size = new System.Drawing.Size(81, 21);
            this.StartEmuBtn.TabIndex = 2;
            this.StartEmuBtn.Text = "启动";
            this.StartEmuBtn.UseVisualStyleBackColor = true;
            this.StartEmuBtn.Click += new System.EventHandler(this.StartEmuBtn_Click);
            // 
            // StopEmuBtn
            // 
            this.StopEmuBtn.Location = new System.Drawing.Point(230, 409);
            this.StopEmuBtn.Name = "StopEmuBtn";
            this.StopEmuBtn.Size = new System.Drawing.Size(82, 21);
            this.StopEmuBtn.TabIndex = 3;
            this.StopEmuBtn.Text = "停止";
            this.StopEmuBtn.UseVisualStyleBackColor = true;
            this.StopEmuBtn.Click += new System.EventHandler(this.StopEmuBtn_Click);
            // 
            // DeleteEmuBtn
            // 
            this.DeleteEmuBtn.Location = new System.Drawing.Point(340, 409);
            this.DeleteEmuBtn.Name = "DeleteEmuBtn";
            this.DeleteEmuBtn.Size = new System.Drawing.Size(83, 21);
            this.DeleteEmuBtn.TabIndex = 4;
            this.DeleteEmuBtn.Text = "删除";
            this.DeleteEmuBtn.UseVisualStyleBackColor = true;
            this.DeleteEmuBtn.Click += new System.EventHandler(this.DeleteEmuBtn_Click);
            // 
            // EmuManageInfo
            // 
            this.EmuManageInfo.AutoSize = true;
            this.EmuManageInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmuManageInfo.Location = new System.Drawing.Point(171, 10);
            this.EmuManageInfo.Name = "EmuManageInfo";
            this.EmuManageInfo.Size = new System.Drawing.Size(88, 16);
            this.EmuManageInfo.TabIndex = 5;
            this.EmuManageInfo.Text = "模拟器列表";
            // 
            // EmulatorManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 442);
            this.Controls.Add(this.EmuManageInfo);
            this.Controls.Add(this.DeleteEmuBtn);
            this.Controls.Add(this.StopEmuBtn);
            this.Controls.Add(this.StartEmuBtn);
            this.Controls.Add(this.CreateEmuBtn);
            this.Controls.Add(this.EmulatorInfoList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EmulatorManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EmulatorManagement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox EmulatorInfoList;
        private System.Windows.Forms.Button CreateEmuBtn;
        private System.Windows.Forms.Button StartEmuBtn;
        private System.Windows.Forms.Button StopEmuBtn;
        private System.Windows.Forms.Button DeleteEmuBtn;
        private System.Windows.Forms.Label EmuManageInfo;
    }
}