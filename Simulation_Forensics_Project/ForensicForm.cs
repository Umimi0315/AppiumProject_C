using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.IO;

namespace Simulation_Forensics_Project
{
    public partial class ForensicForm : Form
    {
        private string appiumProject_jarPath = Application.StartupPath + "\\jar\\AppiumProject.jar";
        private string simulation_jarPath = Application.StartupPath + "\\jar\\Simulation.jar";
        private string simulationFromFile_jarPath = Application.StartupPath + "\\jar\\SimulationFromFile.jar";
        private string methodsMapping_Path = Application.StartupPath + "\\MethodMapping\\MethodsMapping.xml";
        private string isForensicOnEmulatorMapping_Path = Application.StartupPath + "\\MethodMapping\\isForensicOnEmulatorMapping.xml";
        public List<string> attachmentList;
        private string downloadFileAppName;
        private int appiumPort;
        private int socketPort;
        //public TaskCommunicate taskCommunicate;
        public ArrayList appiumPorts=new ArrayList();

        //窗口初始化
        public ForensicForm(string[] args)
        {

            if (!available())
            {
                this.Dispose();
                return;
            }

            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            
            
            //自动装配命令行传入的参数
            if (args != null)
            {
                autowire(args);
            }


        }

        //自动装配参数
        private void autowire(string[] args)
        {
            //ADB路径
            string ADBPath = args[0];
            //仿真数据保存路径
            string simulationPath = args[1];
            //取证数据保存路径
            string forensicsPath = args[2];
            //待测APP
            string selectedAPP = args[3];
            //设备udid
            string deviceUdid = args[4];
            //设备端口
            string devicePort = args[5];


//            selectEmualtorPathText.Text = emulatorPath;
            selectADBText.Text = ADBPath;
            selectFileSavePathText.Text = simulationPath;
            filePathText.Text = forensicsPath;
            
            if ("哈啰单车".Equals(selectedAPP) || "铁路12306".Equals(selectedAPP) || "航旅纵横".Equals(selectedAPP))
            {
                optionsOnPhoneList.FindItemWithText(selectedAPP).Selected = true;
            }
            else
            {
                optionsOnEmulatorList.FindItemWithText(selectedAPP).Selected = true;
            }

            deviceNameText.Text = deviceUdid;
            devicePortText.Text = devicePort;

        }

        //取证数据保存路径按钮
        private void filePathSelectBtn_Click(object sender, EventArgs e)
        {
            this.folderBrowser.ShowDialog();
            this.folderBrowser.Dispose();
            this.filePathText.Text = this.folderBrowser.SelectedPath;
        }

        //开始取证按钮
        private void startForensicBtn_Click(object sender, EventArgs e)
        {
            string filePath = this.filePathText.Text;
            if ("".Equals(filePath))
            {
                MessageBox.Show("未选择取证数据保存路径！");
                return;
            }
            if (optionsOnEmulatorList.SelectedItems.Count > 1||(optionsOnEmulatorList.SelectedItems.Count>=1&&optionsOnPhoneList.SelectedItems.Count>=1)||optionsOnPhoneList.SelectedItems.Count>1)
            {
                MessageBox.Show("每次只能取证一个APP!");
                return;
            }
            if (optionsOnEmulatorList.SelectedItems.Count == 0&&optionsOnPhoneList.SelectedItems.Count==0)
            {
                MessageBox.Show("请选择取证APP!");
                return;
            }

            if ("".Equals(deviceNameText.Text))
            {
                MessageBox.Show("未填写目标设备udid！");
                return;
            }

            string selectedItem = null;

            if (optionsOnEmulatorList.SelectedItems.Count == 1)
            {
                selectedItem = optionsOnEmulatorList.SelectedItems[0].Text;
            }
            else
            {
                selectedItem = optionsOnPhoneList.SelectedItems[0].Text;
            }
            
            downloadFileAppName = selectedItem;
            string methodName = MethodMapping(selectedItem);
            if (methodName == null)
            {
                MessageBox.Show("未找到该APP的取证函数！");
                return;
            }

            Random rd = new Random();
            appiumPort = rd.Next(4723, 65534);
            int num = 0;
            while (PortInUse(appiumPort))
            {
                if (num == 30)
                {
                    break;
                }
                appiumPort = rd.Next(4723, 65534);
                num++;
            }
            if (num == 30)
            {
                MessageBox.Show("appium无可用端口");
                return;
            }
            appiumPorts.Add(appiumPort);

            callCmd("appium -a 127.0.0.1 -p " + appiumPort);


            BackgroundWorker bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += delegate
            {

                string deviceName = deviceNameText.Text;

                for (socketPort = 60000; socketPort < 65535; socketPort++)
                {
                    if (!PortInUse(socketPort))
                    {
                        break;
                    }
                }

                if (socketPort == 65535)
                {
                    MessageBox.Show("进度回传无可用端口！");
                    return;
                }

                TaskCommunicate taskCommunicate = new TaskCommunicate(socketPort);

                Thread extrationThread = new Thread(new ParameterizedThreadStart(callCmd));
                extrationThread.Start("java -cp" + " " + @appiumProject_jarPath + " " + methodName + " " + @filePath + " " + "127.0.0.1 " + socketPort + " " + deviceName + " " + appiumPort);

                attachmentList = new List<string>();
                taskCommunicate.communicate(bgw, socketPort);
            };

            bgw.RunWorkerAsync();
            ProgressBarForm progressBarForm = new ProgressBarForm(bgw);
            progressBarForm.setAppiumPort(appiumPort);
            progressBarForm.Show(this);

        }

        //后台执行取证任务，弃用
        private void forensicFormBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            string filePath = this.filePathText.Text;
            string selectedItems = optionsOnEmulatorList.SelectedItems[0].Text;
            string methodName = MethodMapping(selectedItems);
            string deviceName = deviceNameText.Text;
            BackgroundWorker worker = sender as BackgroundWorker;


            for (socketPort = 60000; socketPort < 65535; socketPort++)
            {
                if (!PortInUse(socketPort))
                {
                    break;
                }
            }

            if (socketPort == 65535)
            {
                MessageBox.Show("进度回传无可用端口！");
                return;
            }

            TaskCommunicate taskCommunicate = new TaskCommunicate(socketPort);


            Thread extrationThread = new Thread(new ParameterizedThreadStart(callCmd));
            extrationThread.Start("java -cp" + " " + @appiumProject_jarPath + " "+methodName+" " + @filePath + " " + "127.0.0.1 "+socketPort+" "+deviceName+" "+appiumPort);
         
            attachmentList = new List<string>();
            taskCommunicate.communicate(worker,socketPort);
   
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
        }


        //检测appium是否已启动，已废弃
        private bool isAppiumStart()
        {
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.RedirectStandardInput = true;

            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.RedirectStandardError = true;

            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.Start();
            cmdProcess.StandardInput.WriteLine("appium -a 127.0.0.1 -p 4723");
            cmdProcess.StandardInput.WriteLine("exit");
            cmdProcess.StandardInput.Flush();
            //string result = cmdProcess.StandardOutput.ReadToEnd();
            string error = cmdProcess.StandardError.ReadToEnd();
            return error.Contains("Requested port is already in use");
        }

        //检测待测APP是否可在模拟器上取证，已弃用 
        private bool isForensicOnEmulator(string itemName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(isForensicOnEmulatorMapping_Path);
            XmlNodeList xmlNodeList = document.SelectNodes("//MethodsMapping//MethodsMappingItem[ItemName='" + itemName + "']");
            if (xmlNodeList.Count == 0)
            {
                return false;
            }
            return "true".Equals(xmlNodeList[0].LastChild.InnerText);
        }

        private bool available()
        {
            string minDateString = "2020-1-1";
            string maxDateString = "2022-6-1";
            DateTime mindate = Convert.ToDateTime(minDateString);
            DateTime maxdate = Convert.ToDateTime(maxDateString);
            DateTime nowdate = DateTime.Now;
            if (DateTime.Compare(nowdate, mindate) < 0 || DateTime.Compare(nowdate, maxdate) > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //将待测APP名与取证主函数名对应
        private string MethodMapping(string itemName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(methodsMapping_Path);
            XmlNodeList xmlNodeList= document.SelectNodes("//MethodsMapping//MethodsMappingItem[ItemName='"+itemName+"']");
            if (xmlNodeList.Count == 0)
            {
                return null;
            }
            return xmlNodeList[0].LastChild.InnerText;
        }

        //检测模拟器是否启动，弃用
        private bool isEmulatorStart()
        {
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            cmdProcess.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            cmdProcess.StartInfo.UseShellExecute = false;//是否使用操作系统shell启动
            cmdProcess.StartInfo.CreateNoWindow = true;//不显示程序窗口  
            cmdProcess.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            cmdProcess.Start();

            cmdProcess.StandardInput.WriteLine("adb connect 127.0.0.1:7555");
            cmdProcess.StandardInput.WriteLine("exit");
            cmdProcess.StandardInput.Flush();

            string result = cmdProcess.StandardOutput.ReadToEnd();
            string error = cmdProcess.StandardError.ReadToEnd();

            Console.WriteLine(error);
            return result.Contains("already connected to 127.0.0.1:7555")||result.Contains("connected to 127.0.0.1:7555");

        }

        //关闭窗口
        private void ForensicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string portstr = "";
            for (int i = 0; i < appiumPorts.Count; i++)
            {
                int p = (int)appiumPorts[i];
                endAppium(p);
                portstr = portstr + p + " ";
            }

            //MessageBox.Show(portstr);

            this.Dispose();
                        
        }

        //选择ADB路径按钮
        private void selectADBFileBtn_Click(object sender, EventArgs e)
        {
            this.selectADBFolderBrowser.ShowDialog();
            this.selectFileSaveFolderBrowser.Dispose();
            this.selectADBText.Text = this.selectADBFolderBrowser.FileName;
        }

        //选择仿真数据保存路径按钮
        private void selectFileSavePathBtn_Click(object sender, EventArgs e)
        {
            this.selectFileSaveFolderBrowser.ShowDialog();
            this.selectFileSaveFolderBrowser.Dispose();
            this.selectFileSavePathText.Text = this.selectFileSaveFolderBrowser.SelectedPath;
        }

        //手机仿真按钮
        private void startSimulationBtn_Click(object sender, EventArgs e)
        {
            string selectADBText = this.selectADBText.Text;
            string selectFileSavePathText = this.selectFileSavePathText.Text;            
//            string selectEmulatorPathText = this.selectEmualtorPathText.Text;

            if (optionsOnEmulatorList.SelectedItems.Count > 1 || (optionsOnEmulatorList.SelectedItems.Count >= 1 && optionsOnPhoneList.SelectedItems.Count >= 1) || optionsOnPhoneList.SelectedItems.Count > 1)
            {
                MessageBox.Show("每次只能仿真一个APP!");
                return;
            }
            if (optionsOnEmulatorList.SelectedItems.Count == 0 && optionsOnPhoneList.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择仿真APP!");
                return;
            }

            if (optionsOnPhoneList.SelectedItems.Count==1)
            {
                MessageBox.Show("该APP无法从手机仿真到模拟器上!");
                return;
            }

            if ("".Equals(selectADBText))
            {
                MessageBox.Show("未选择ADB路径！");
                return;
            }
            if ("".Equals(selectFileSavePathText))
            {
                MessageBox.Show("未选择仿真数据保存路径！");
                return;
            }

            if ("".Equals(deviceNameText.Text))
            {
                MessageBox.Show("未填写目标设备udid！");
                return;
            }

            if ("".Equals(devicePortText.Text))
            {
                MessageBox.Show("未填写目标设备端口！");
                return;
            }

            string deviceName = deviceNameText.Text;
            string selectAPP = optionsOnEmulatorList.SelectedItems[0].Text;
            string devicePort = devicePortText.Text;

            /////////////////////////////////////////////////////
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += delegate
            {
                for (socketPort = 60000; socketPort < 65535; socketPort++)
                {
                    if (!PortInUse(socketPort))
                    {
                        break;
                    }
                }

                if (socketPort == 65535)
                {
                    MessageBox.Show("进度回传无可用端口！");
                    return;
                }

                TaskCommunicate taskCommunicate = new TaskCommunicate(socketPort);

                Thread extrationThread = new Thread(new ParameterizedThreadStart(callCmd));
                extrationThread.Start("java -jar" + " " + @simulation_jarPath + " " + selectAPP + " " + selectADBText + " " + selectFileSavePathText + " " + deviceName + " " + devicePort + " " + socketPort);

                taskCommunicate.communicate(bgw, socketPort);
            };

            bgw.RunWorkerAsync();
            ProgressBarForm progressBarForm = new ProgressBarForm(bgw);
            progressBarForm.Show(this);

        }


        //后台执行仿真任务
        private void SimulationFormBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            TaskCommunicate taskCommunicate = new TaskCommunicate(socketPort);

            taskCommunicate.communicate(worker, socketPort);
        }

        //从本地文件仿真按钮
        private void simulationFromFile_Click(object sender, EventArgs e)
        {
            string selectADBText = this.selectADBText.Text;
            string selectFileSavePathText = this.selectFileSavePathText.Text;
            string devicePort = this.devicePortText.Text;

            if (optionsOnEmulatorList.SelectedItems.Count > 1 || (optionsOnEmulatorList.SelectedItems.Count >= 1 && optionsOnPhoneList.SelectedItems.Count >= 1) || optionsOnPhoneList.SelectedItems.Count > 1)
            {
                MessageBox.Show("每次只能仿真一个APP!");
                return;
            }
            if (optionsOnEmulatorList.SelectedItems.Count == 0 && optionsOnPhoneList.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择仿真APP!");
                return;
            }

            if (optionsOnPhoneList.SelectedItems.Count == 1)
            {
                MessageBox.Show("该APP无法从手机仿真到模拟器上!");
                return;
            }

            if ("".Equals(selectADBText))
            {
                MessageBox.Show("未选择ADB路径！");
                return;
            }
            if ("".Equals(selectFileSavePathText))
            {
                MessageBox.Show("未选择仿真数据保存路径！");
                return;
            }

            string selectAPP = optionsOnEmulatorList.SelectedItems[0].Text;

            if ("".Equals(devicePort))
            {
                MessageBox.Show("未填写设备端口");
                return;
            }

/*            this.SimulationFormBgw.RunWorkerAsync();
            ProgressBarForm progressBarForm = new ProgressBarForm(this.SimulationFormBgw);
            
            progressBarForm.Show(this);*/

            //////////////////////////////////////
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += delegate
            {

                string deviceName = deviceNameText.Text;

                for (socketPort = 60000; socketPort < 65535; socketPort++)
                {
                    if (!PortInUse(socketPort))
                    {
                        break;
                    }
                }

                if (socketPort == 65535)
                {
                    MessageBox.Show("进度回传无可用端口！");
                    return;
                }

                TaskCommunicate taskCommunicate = new TaskCommunicate(socketPort);

                Thread extrationThread = new Thread(new ParameterizedThreadStart(callCmd));
                extrationThread.Start("java -jar" + " " + @simulationFromFile_jarPath + " " + selectAPP + " " + selectADBText + " " + selectFileSavePathText+" "+devicePort+" "+socketPort);

                taskCommunicate.communicate(bgw, socketPort);
            };

            bgw.RunWorkerAsync();
            ProgressBarForm progressBarForm = new ProgressBarForm(bgw);
            progressBarForm.Show(this);
        }

        private bool PortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties= IPGlobalProperties.GetIPGlobalProperties();
            //获取所有的TCP端口
            IPEndPoint[] iPEndPoints= ipProperties.GetActiveTcpListeners();

            foreach(IPEndPoint endPoint in iPEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    return inUse;
                }
            }

            iPEndPoints = ipProperties.GetActiveUdpListeners();

            foreach(IPEndPoint endPoint in iPEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    return inUse;
                }
            }

            return inUse;

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
