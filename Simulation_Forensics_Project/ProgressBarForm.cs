using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation_Forensics_Project
{
    public partial class ProgressBarForm : Form
    {
        private int appiumPort;
       
        public ProgressBarForm(BackgroundWorker worker)
        {
            InitializeComponent();
            this.progressBarFormBgw = worker;
            this.progressBarFormBgw.ProgressChanged += new ProgressChangedEventHandler(progressBarFormBgw_Changed);
            this.progressBarFormBgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(progressBarFormBgw_Completed);
            ConfirmBtn.Hide();

        }

        public void setAppiumPort(int appiumPort)
        {
            this.appiumPort = appiumPort;
        }

        private void progressBarFormBgw_Changed(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            this.taskStatusText.Text = e.UserState.ToString();
            this.taskStatusText.Refresh();
        }



        private void progressBarFormBgw_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ControlBox = true;
            ConfirmBtn.Show();
            //this.Close();
        }

        private void ProgressBarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (appiumPort != 0)
            {
                endAppium(appiumPort);
            }
            this.Dispose();
        }

        private void ConfirmBtn_Click(object sender, EventArgs e)
        {
            if (appiumPort != 0)
            {
                endAppium(appiumPort);
            }
            this.Close();
        }

        public void endAppium(int port)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            List<int> list_pid = GetPidByPort(p, port);
            if (list_pid.Count == 0)
            {
                return;
            }

            /*            List<string> list_process = GetProcessNameByPid(p, list_pid);
                        StringBuilder sb = new StringBuilder();*/

            PidKill(p, list_pid);

        }


        private void PidKill(Process p, List<int> list_pid)
        {
            p.Start();
            foreach (var item in list_pid)
            {
                p.StandardInput.WriteLine("taskkill /pid " + item + " /f");
                p.StandardInput.WriteLine("exit");
            }
            p.Close();

            Thread.Sleep(100);
        }

        private static List<int> GetPidByPort(Process p, int port)
        {
            int result;
            bool b = true;
            p.Start();
            p.StandardInput.WriteLine(string.Format("netstat -ano|findstr \"{0}\"", port));
            p.StandardInput.WriteLine("exit");
            StreamReader reader = p.StandardOutput;
            string strLine = reader.ReadLine();
            List<int> list_pid = new List<int>();
            while (!reader.EndOfStream)
            {
                strLine = strLine.Trim();
                if (strLine.Length > 0 && ((strLine.Contains("TCP") || strLine.Contains("UDP"))))
                {
                    Regex r = new Regex(@"\s+");
                    string[] strArr = r.Split(strLine);
                    if (strArr.Length >= 4)
                    {
                        b = int.TryParse(strArr[4], out result);
                        if (b && !list_pid.Contains(result))
                            list_pid.Add(result);
                    }
                }
                strLine = reader.ReadLine();
            }
            p.WaitForExit();
            reader.Close();
            p.Close();
            return list_pid;
        }

    }
}
