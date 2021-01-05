using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation_Forensics_Project
{
    public partial class DownloadFileForm : Form
    {

        public List<String> attachmentsList;
        public TaskCommunicate taskCommunicate;

        public DownloadFileForm(List<String> attachmentsList,TaskCommunicate taskCommunicate)
        {
            this.attachmentsList = attachmentsList;
            this.taskCommunicate = taskCommunicate;
            InitializeComponent();
            for(int i=0;i<this.attachmentsList.Count;i++)
            this.attachmentListBox.Items.Add(this.attachmentsList[i]);
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            if (this.attachmentListBox.SelectedItem == null)
            {
                MessageBox.Show("请选择文件名后再下载");
                return;
            }
            
            
            this.downloadFileBgw.RunWorkerAsync();

            ProgressBarForm progressBarForm = new ProgressBarForm(this.downloadFileBgw);
            progressBarForm.Show(this);

        }

        private void DownloadFileBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            string downloadFileName = this.attachmentListBox.SelectedItem.ToString();
            this.taskCommunicate.downloadFile(worker,downloadFileName);
        }

        private void DownloadFileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.taskCommunicate.close();
            this.Dispose();
        }
    }
}
