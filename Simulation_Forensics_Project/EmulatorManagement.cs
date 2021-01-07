using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation_Forensics_Project
{
    public partial class EmulatorManagement : Form
    {
        public EmulatorManagement()
        {
            
            InitializeComponent();
            QueryEmuInfo();

        }

        public void QueryEmuInfo()
        {
            this.EmulatorInfoList.Items.Clear();

            List<string> EmuNameList = new List<string>();

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.StandardInput.WriteLine("memuc listvms");
            p.StandardInput.WriteLine("exit");
            StreamReader reader = p.StandardOutput;
            string strLine = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                strLine = strLine.Trim();
                if (strLine.Length > 0 && strLine.Contains("逍遥模拟器"))
                {
                    EmuNameList.Add(strLine);
                }
                strLine = reader.ReadLine();
            }

            for (int i = 0; i < EmuNameList.Count; i++)
            {
                this.EmulatorInfoList.Items.Add(EmuNameList[i]);
            }

        }

        private void CreateEmuBtn_Click(object sender, EventArgs e)
        {
            callCmd("memuc create 71");
            QueryEmuInfo();
        }

        private void StartEmuBtn_Click(object sender, EventArgs e)
        {
            if (this.EmulatorInfoList.SelectedItems.Count == 1)
            {
                string selectedEmu = this.EmulatorInfoList.SelectedItem.ToString();
                string[] EmuNameSplit = selectedEmu.Split( ',');
                string startCmd = "memuc start -i " + EmuNameSplit[0];
                operateEmulator(startCmd);
            }
            else
            {
                MessageBox.Show("请选择一个待启动的模拟器");
                return;
            }
        }

        private void StopEmuBtn_Click(object sender, EventArgs e)
        {
            if (this.EmulatorInfoList.SelectedItems.Count == 1)
            {
                string selectedEmu = this.EmulatorInfoList.SelectedItem.ToString();
                string[] EmuNameSplit = selectedEmu.Split(',');
                string startCmd = "memuc stop -i " + EmuNameSplit[0];
                operateEmulator(startCmd);
            }
            else
            {
                MessageBox.Show("请选择一个待停止的模拟器");
                return;
            }
        }

        private void DeleteEmuBtn_Click(object sender, EventArgs e)
        {
            if (this.EmulatorInfoList.SelectedItems.Count == 1)
            {
                string selectedEmu = this.EmulatorInfoList.SelectedItem.ToString();
                string[] EmuNameSplit = selectedEmu.Split(',');

                if ("0".Equals(EmuNameSplit[0]))
                {
                    MessageBox.Show("不能删除0号模拟器");
                    return;
                }

                string cmd = "memuc isvmrunning -i " + EmuNameSplit[0];
                bool isRunning=isEmuRunning(cmd);
                if (isRunning)
                {
                    MessageBox.Show("不能删除正在运行的模拟器");
                    return;
                }
                cmd = "memuc remove -i " + EmuNameSplit[0];
                callCmd(cmd);

                QueryEmuInfo();

            }
            else
            {
                MessageBox.Show("请选择一个待删除的模拟器");
                return;
            }
        }

        //调用命令行执行任务
        private void callCmd(Object order)
        {
            string cmdOrder = (string)order;
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.Start();
            cmdProcess.StandardInput.WriteLine(cmdOrder);
            cmdProcess.StandardInput.WriteLine("exit");
            cmdProcess.StandardInput.Flush();
            cmdProcess.WaitForExit();
        }

        private void operateEmulator(Object order)
        {
            string cmdOrder = (string)order;
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.RedirectStandardInput = true;
            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.Start();
            cmdProcess.StandardInput.WriteLine(cmdOrder);
            cmdProcess.StandardInput.WriteLine("exit");
            cmdProcess.StandardInput.Flush();
        }

        public bool isEmuRunning(string cmd)
        {
            string EmuStatus = "";

            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            p.StandardInput.WriteLine(cmd);
            p.StandardInput.WriteLine("exit");
            StreamReader reader = p.StandardOutput;
            string strLine = reader.ReadLine();

            while (!reader.EndOfStream)
            {
                strLine = strLine.Trim();
                if (strLine.Length > 0 && strLine.Contains("Running"))
                {
                    EmuStatus = strLine;
                }
                strLine = reader.ReadLine();
            }

            if ("Running".Equals(EmuStatus))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
