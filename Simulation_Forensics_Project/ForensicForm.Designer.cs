namespace Simulation_Forensics_Project
{
    partial class ForensicForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("T3出行", "T3出行.jpg");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("曹操出行", "曹操出行.jpg");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("神州专车", "神州专车.jpg");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("首汽约车", "首汽约车.jpg");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("美团", "美团.jpg");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("滴滴出行", "滴滴出行.jpg");
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem("115网盘", "115网盘.png");
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("腾讯微云", "腾讯微云.jpg");
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("百度网盘", "百度网盘.jpg");
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("QQ邮箱", "QQ邮箱.png");
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem("网易邮箱", "网易邮箱.jpg");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForensicForm));
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem("哈啰单车", "哈啰单车.jpg");
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem("铁路12306", "铁路12306.jpg");
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem("航旅纵横", "航旅纵横.jpg");
            this.optionsOnEmulatorList = new System.Windows.Forms.ListView();
            this.largeIconList = new System.Windows.Forms.ImageList(this.components);
            this.forensicOnEmualtorTitle = new System.Windows.Forms.Label();
            this.startForensicBtn = new System.Windows.Forms.Button();
            this.folderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.saveFileLabel = new System.Windows.Forms.Label();
            this.filePathText = new System.Windows.Forms.TextBox();
            this.filePathSelectBtn = new System.Windows.Forms.Button();
            this.forensicFormBgw = new System.ComponentModel.BackgroundWorker();
            this.selectADBText = new System.Windows.Forms.TextBox();
            this.selectADBFileBtn = new System.Windows.Forms.Button();
            this.selectFileSavePathText = new System.Windows.Forms.TextBox();
            this.selectFileSavePathBtn = new System.Windows.Forms.Button();
            this.selectADBFileLabel = new System.Windows.Forms.Label();
            this.selectFileSavePathLabel = new System.Windows.Forms.Label();
            this.startSimulationBtn = new System.Windows.Forms.Button();
            this.selectEmulatorPathBrowser = new System.Windows.Forms.OpenFileDialog();
            this.selectFileSaveFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.selectADBFolderBrowser = new System.Windows.Forms.OpenFileDialog();
            this.SimulationFormBgw = new System.ComponentModel.BackgroundWorker();
            this.deviceNameText = new System.Windows.Forms.TextBox();
            this.deviceNameLabel = new System.Windows.Forms.Label();
            this.simulationFromFile = new System.Windows.Forms.Button();
            this.forensicOnPhoneTitle = new System.Windows.Forms.Label();
            this.optionsOnPhoneList = new System.Windows.Forms.ListView();
            this.DevicePort = new System.Windows.Forms.Label();
            this.devicePortText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // optionsOnEmulatorList
            // 
            this.optionsOnEmulatorList.HideSelection = false;
            this.optionsOnEmulatorList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11});
            this.optionsOnEmulatorList.LargeImageList = this.largeIconList;
            this.optionsOnEmulatorList.Location = new System.Drawing.Point(12, 28);
            this.optionsOnEmulatorList.Name = "optionsOnEmulatorList";
            this.optionsOnEmulatorList.Size = new System.Drawing.Size(743, 188);
            this.optionsOnEmulatorList.TabIndex = 0;
            this.optionsOnEmulatorList.UseCompatibleStateImageBehavior = false;
            // 
            // largeIconList
            // 
            this.largeIconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("largeIconList.ImageStream")));
            this.largeIconList.TransparentColor = System.Drawing.Color.Transparent;
            this.largeIconList.Images.SetKeyName(0, "T3出行.jpg");
            this.largeIconList.Images.SetKeyName(1, "曹操出行.jpg");
            this.largeIconList.Images.SetKeyName(2, "神州专车.jpg");
            this.largeIconList.Images.SetKeyName(3, "首汽约车.jpg");
            this.largeIconList.Images.SetKeyName(4, "美团.jpg");
            this.largeIconList.Images.SetKeyName(5, "滴滴出行.jpg");
            this.largeIconList.Images.SetKeyName(6, "百度网盘.jpg");
            this.largeIconList.Images.SetKeyName(7, "115网盘.png");
            this.largeIconList.Images.SetKeyName(8, "腾讯微云.jpg");
            this.largeIconList.Images.SetKeyName(9, "QQ邮箱.png");
            this.largeIconList.Images.SetKeyName(10, "网易邮箱.jpg");
            this.largeIconList.Images.SetKeyName(11, "哈啰单车.jpg");
            this.largeIconList.Images.SetKeyName(12, "青桔单车.jpg");
            this.largeIconList.Images.SetKeyName(13, "美团单车.png");
            this.largeIconList.Images.SetKeyName(14, "铁路12306.jpg");
            this.largeIconList.Images.SetKeyName(15, "航旅纵横.jpg");
            // 
            // forensicOnEmualtorTitle
            // 
            this.forensicOnEmualtorTitle.AutoSize = true;
            this.forensicOnEmualtorTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.forensicOnEmualtorTitle.Location = new System.Drawing.Point(315, 9);
            this.forensicOnEmualtorTitle.Name = "forensicOnEmualtorTitle";
            this.forensicOnEmualtorTitle.Size = new System.Drawing.Size(120, 16);
            this.forensicOnEmualtorTitle.TabIndex = 1;
            this.forensicOnEmualtorTitle.Text = "模拟器取证列表";
            // 
            // startForensicBtn
            // 
            this.startForensicBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startForensicBtn.Location = new System.Drawing.Point(194, 565);
            this.startForensicBtn.Name = "startForensicBtn";
            this.startForensicBtn.Size = new System.Drawing.Size(90, 23);
            this.startForensicBtn.TabIndex = 2;
            this.startForensicBtn.Text = "开始取证";
            this.startForensicBtn.UseVisualStyleBackColor = true;
            this.startForensicBtn.Click += new System.EventHandler(this.startForensicBtn_Click);
            // 
            // saveFileLabel
            // 
            this.saveFileLabel.AutoSize = true;
            this.saveFileLabel.Location = new System.Drawing.Point(17, 498);
            this.saveFileLabel.Name = "saveFileLabel";
            this.saveFileLabel.Size = new System.Drawing.Size(101, 12);
            this.saveFileLabel.TabIndex = 3;
            this.saveFileLabel.Text = "取证数据保存路径";
            // 
            // filePathText
            // 
            this.filePathText.Location = new System.Drawing.Point(139, 495);
            this.filePathText.Name = "filePathText";
            this.filePathText.Size = new System.Drawing.Size(500, 21);
            this.filePathText.TabIndex = 4;
            // 
            // filePathSelectBtn
            // 
            this.filePathSelectBtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.filePathSelectBtn.Location = new System.Drawing.Point(645, 497);
            this.filePathSelectBtn.Name = "filePathSelectBtn";
            this.filePathSelectBtn.Size = new System.Drawing.Size(102, 23);
            this.filePathSelectBtn.TabIndex = 5;
            this.filePathSelectBtn.Text = "选择";
            this.filePathSelectBtn.UseVisualStyleBackColor = true;
            this.filePathSelectBtn.Click += new System.EventHandler(this.filePathSelectBtn_Click);
            // 
            // forensicFormBgw
            // 
            this.forensicFormBgw.WorkerReportsProgress = true;
            this.forensicFormBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.forensicFormBgw_DoWork);
            // 
            // selectADBText
            // 
            this.selectADBText.Location = new System.Drawing.Point(139, 441);
            this.selectADBText.Name = "selectADBText";
            this.selectADBText.Size = new System.Drawing.Size(500, 21);
            this.selectADBText.TabIndex = 14;
            // 
            // selectADBFileBtn
            // 
            this.selectADBFileBtn.Location = new System.Drawing.Point(645, 439);
            this.selectADBFileBtn.Name = "selectADBFileBtn";
            this.selectADBFileBtn.Size = new System.Drawing.Size(102, 23);
            this.selectADBFileBtn.TabIndex = 13;
            this.selectADBFileBtn.Text = "选择";
            this.selectADBFileBtn.UseVisualStyleBackColor = true;
            this.selectADBFileBtn.Click += new System.EventHandler(this.selectADBFileBtn_Click);
            // 
            // selectFileSavePathText
            // 
            this.selectFileSavePathText.Location = new System.Drawing.Point(139, 468);
            this.selectFileSavePathText.Name = "selectFileSavePathText";
            this.selectFileSavePathText.Size = new System.Drawing.Size(500, 21);
            this.selectFileSavePathText.TabIndex = 16;
            // 
            // selectFileSavePathBtn
            // 
            this.selectFileSavePathBtn.Location = new System.Drawing.Point(645, 468);
            this.selectFileSavePathBtn.Name = "selectFileSavePathBtn";
            this.selectFileSavePathBtn.Size = new System.Drawing.Size(102, 23);
            this.selectFileSavePathBtn.TabIndex = 15;
            this.selectFileSavePathBtn.Text = "选择";
            this.selectFileSavePathBtn.UseVisualStyleBackColor = true;
            this.selectFileSavePathBtn.Click += new System.EventHandler(this.selectFileSavePathBtn_Click);
            // 
            // selectADBFileLabel
            // 
            this.selectADBFileLabel.AutoSize = true;
            this.selectADBFileLabel.Location = new System.Drawing.Point(19, 444);
            this.selectADBFileLabel.Name = "selectADBFileLabel";
            this.selectADBFileLabel.Size = new System.Drawing.Size(47, 12);
            this.selectADBFileLabel.TabIndex = 17;
            this.selectADBFileLabel.Text = "ADB路径";
            // 
            // selectFileSavePathLabel
            // 
            this.selectFileSavePathLabel.AutoSize = true;
            this.selectFileSavePathLabel.Location = new System.Drawing.Point(17, 471);
            this.selectFileSavePathLabel.Name = "selectFileSavePathLabel";
            this.selectFileSavePathLabel.Size = new System.Drawing.Size(101, 12);
            this.selectFileSavePathLabel.TabIndex = 18;
            this.selectFileSavePathLabel.Text = "仿真数据保存路径";
            // 
            // startSimulationBtn
            // 
            this.startSimulationBtn.Location = new System.Drawing.Point(344, 565);
            this.startSimulationBtn.Name = "startSimulationBtn";
            this.startSimulationBtn.Size = new System.Drawing.Size(89, 23);
            this.startSimulationBtn.TabIndex = 19;
            this.startSimulationBtn.Text = "手机仿真";
            this.startSimulationBtn.UseVisualStyleBackColor = true;
            this.startSimulationBtn.Click += new System.EventHandler(this.startSimulationBtn_Click);
            // 
            // SimulationFormBgw
            // 
            this.SimulationFormBgw.WorkerReportsProgress = true;
            this.SimulationFormBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SimulationFormBgw_DoWork);
            // 
            // deviceNameText
            // 
            this.deviceNameText.Location = new System.Drawing.Point(139, 525);
            this.deviceNameText.Name = "deviceNameText";
            this.deviceNameText.Size = new System.Drawing.Size(197, 21);
            this.deviceNameText.TabIndex = 20;
            // 
            // deviceNameLabel
            // 
            this.deviceNameLabel.AutoSize = true;
            this.deviceNameLabel.Location = new System.Drawing.Point(19, 525);
            this.deviceNameLabel.Name = "deviceNameLabel";
            this.deviceNameLabel.Size = new System.Drawing.Size(53, 12);
            this.deviceNameLabel.TabIndex = 21;
            this.deviceNameLabel.Text = "设备udid";
            // 
            // simulationFromFile
            // 
            this.simulationFromFile.Location = new System.Drawing.Point(487, 565);
            this.simulationFromFile.Name = "simulationFromFile";
            this.simulationFromFile.Size = new System.Drawing.Size(86, 23);
            this.simulationFromFile.TabIndex = 22;
            this.simulationFromFile.Text = "本地仿真";
            this.simulationFromFile.UseVisualStyleBackColor = true;
            this.simulationFromFile.Click += new System.EventHandler(this.simulationFromFile_Click);
            // 
            // forensicOnPhoneTitle
            // 
            this.forensicOnPhoneTitle.AutoSize = true;
            this.forensicOnPhoneTitle.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.forensicOnPhoneTitle.Location = new System.Drawing.Point(315, 219);
            this.forensicOnPhoneTitle.Name = "forensicOnPhoneTitle";
            this.forensicOnPhoneTitle.Size = new System.Drawing.Size(104, 16);
            this.forensicOnPhoneTitle.TabIndex = 23;
            this.forensicOnPhoneTitle.Text = "手机取证列表";
            // 
            // optionsOnPhoneList
            // 
            this.optionsOnPhoneList.HideSelection = false;
            this.optionsOnPhoneList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem12,
            listViewItem13,
            listViewItem14});
            this.optionsOnPhoneList.LargeImageList = this.largeIconList;
            this.optionsOnPhoneList.Location = new System.Drawing.Point(12, 238);
            this.optionsOnPhoneList.Name = "optionsOnPhoneList";
            this.optionsOnPhoneList.Size = new System.Drawing.Size(743, 184);
            this.optionsOnPhoneList.TabIndex = 24;
            this.optionsOnPhoneList.UseCompatibleStateImageBehavior = false;
            // 
            // DevicePort
            // 
            this.DevicePort.AutoSize = true;
            this.DevicePort.Location = new System.Drawing.Point(342, 529);
            this.DevicePort.Name = "DevicePort";
            this.DevicePort.Size = new System.Drawing.Size(77, 12);
            this.DevicePort.TabIndex = 25;
            this.DevicePort.Text = "目标设备端口";
            // 
            // devicePortText
            // 
            this.devicePortText.Location = new System.Drawing.Point(425, 526);
            this.devicePortText.Name = "devicePortText";
            this.devicePortText.Size = new System.Drawing.Size(214, 21);
            this.devicePortText.TabIndex = 26;
            // 
            // ForensicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(767, 604);
            this.Controls.Add(this.devicePortText);
            this.Controls.Add(this.DevicePort);
            this.Controls.Add(this.optionsOnPhoneList);
            this.Controls.Add(this.forensicOnPhoneTitle);
            this.Controls.Add(this.simulationFromFile);
            this.Controls.Add(this.deviceNameLabel);
            this.Controls.Add(this.deviceNameText);
            this.Controls.Add(this.startSimulationBtn);
            this.Controls.Add(this.selectFileSavePathLabel);
            this.Controls.Add(this.selectADBFileLabel);
            this.Controls.Add(this.selectFileSavePathText);
            this.Controls.Add(this.selectFileSavePathBtn);
            this.Controls.Add(this.selectADBText);
            this.Controls.Add(this.selectADBFileBtn);
            this.Controls.Add(this.filePathSelectBtn);
            this.Controls.Add(this.filePathText);
            this.Controls.Add(this.saveFileLabel);
            this.Controls.Add(this.startForensicBtn);
            this.Controls.Add(this.forensicOnEmualtorTitle);
            this.Controls.Add(this.optionsOnEmulatorList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ForensicForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取证界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ForensicForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView optionsOnEmulatorList;
        private System.Windows.Forms.Label forensicOnEmualtorTitle;
        private System.Windows.Forms.Button startForensicBtn;
        private System.Windows.Forms.ImageList largeIconList;
        private System.Windows.Forms.FolderBrowserDialog folderBrowser;
        private System.Windows.Forms.Label saveFileLabel;
        private System.Windows.Forms.TextBox filePathText;
        private System.Windows.Forms.Button filePathSelectBtn;
        private System.ComponentModel.BackgroundWorker forensicFormBgw;
        private System.Windows.Forms.TextBox selectADBText;
        private System.Windows.Forms.Button selectADBFileBtn;
        private System.Windows.Forms.TextBox selectFileSavePathText;
        private System.Windows.Forms.Button selectFileSavePathBtn;
        private System.Windows.Forms.Label selectADBFileLabel;
        private System.Windows.Forms.Label selectFileSavePathLabel;
        private System.Windows.Forms.Button startSimulationBtn;
        private System.Windows.Forms.OpenFileDialog selectEmulatorPathBrowser;
        private System.Windows.Forms.FolderBrowserDialog selectFileSaveFolderBrowser;
        private System.Windows.Forms.OpenFileDialog selectADBFolderBrowser;
        private System.ComponentModel.BackgroundWorker SimulationFormBgw;
        private System.Windows.Forms.TextBox deviceNameText;
        private System.Windows.Forms.Label deviceNameLabel;
        private System.Windows.Forms.Button simulationFromFile;
        private System.Windows.Forms.Label forensicOnPhoneTitle;
        private System.Windows.Forms.ListView optionsOnPhoneList;
        private System.Windows.Forms.Label DevicePort;
        private System.Windows.Forms.TextBox devicePortText;
    }

}

