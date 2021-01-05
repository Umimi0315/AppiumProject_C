using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_Forensics_Project
{
    public class TaskCommunicate
    {
		Socket serverSocket;
		Socket socket;

		public TaskCommunicate(int socketPort)
        {
			serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

			IPAddress ip = IPAddress.Parse("127.0.0.1");//本机IP
			IPEndPoint ipend = new IPEndPoint(ip, socketPort);//网络终结点表示为IP地址和端口号
			serverSocket.Bind(ipend);
			//Socket socket = serverSocket.accept();
			serverSocket.Listen(10);
			
		}

		public bool byteArrayEquals(byte[] b1, byte[] b2)
		{
			if (b1 == null || b2 == null) return false;
			if (b1.Length != b2.Length) return false;
			for (int i = 0; i < b1.Length; i++)
			{
				if (b1[i] != b2[i])
				{
					return false;
				}
			}
			return true;
		}
		public int byteToInt(byte[] bytes)
		{
			return (int)((((bytes[3] & 0xff) << 24) | ((bytes[2] & 0xff) << 16) | ((bytes[1] & 0xff << 8) | ((bytes[0] & 0xff) << 0))));
		}
		public byte[] arrayJoin(byte[] a, byte[] b)
		{
			byte[] arr = new byte[a.Length + b.Length];
			for (int i = 0; i < a.Length; i++)
			{
				arr[i] = a[i];
			}
			for (int j = 0; j < b.Length; j++)
			{
				arr[a.Length + j] = b[j];
			}

			return arr;

		}

		public byte[] intToBytes(int value)
		{
			byte[] bytes = new byte[4];
			bytes[3] = (byte)(value >> 24);
			bytes[2] = (byte)(value >> 16);
			bytes[1] = (byte)(value >> 8);
			bytes[0] = (byte)(value >> 0);
			return bytes;
		}

		public void communicate(BackgroundWorker worker,int port)
		{
            try
            {
				socket = serverSocket.Accept();//等待用户连接

				List<String> attachmentsList = new List<string>();

				//byte[] b = new byte[1024];

				//OutputStream outputStream = socket.getOutputStream();
				byte[] frameHeader = new byte[] { (byte)0x00 };
				byte[] frameLength = intToBytes(4);
				byte[] frameCmd = new byte[] { (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x00 };
				byte[] frameEnd = new byte[] { (byte)0xff };

				byte[] frame1 = arrayJoin(frameHeader, frameLength);
				byte[] frame2 = arrayJoin(frame1, frameCmd);
				byte[] frame = arrayJoin(frame2, frameEnd);
				socket.Send(frame);

				while (true)
				{
					byte[] receiveFrameHeader = new byte[1];
					socket.Receive(receiveFrameHeader);
					byte[] receiveFrameLength = new byte[4];
					socket.Receive(receiveFrameLength);
					int length = byteToInt(receiveFrameLength);//命令+内容长度
					length -= 4;//内容长度
					byte[] receiveCommand = new byte[4];
					socket.Receive(receiveCommand);
					byte[] attachmentCommand = new byte[] {0x00,0x00,0x00,0x02};//附件名报文命令
					byte[] progressCommand = new byte[] { 0x00, 0x00, 0x00, 0x01 };//进度报文命令
					byte[] attachmentEndCommand = new byte[] { 0x00, 0x00, 0x00, 0x03 };//附件名传送结束命令
					if (byteArrayEquals(receiveCommand, attachmentCommand))
					{
						if (length > 0)//有附件内容
						{
							byte[] attachmentContent = new byte[length];
							socket.Receive(attachmentContent);
							string content = Encoding.UTF8.GetString(attachmentContent, 0, length);
							attachmentsList.Add(content);
						}
					}
					if (byteArrayEquals(receiveCommand, progressCommand))
					{
						if (length > 0)//有内容
						{
							byte[] receiveContent = new byte[length];
							socket.Receive(receiveContent);
							//string content = receiveContent.ToString();
							string content = Encoding.UTF8.GetString(receiveContent, 0, length);
							TaskProgress taskProgress = new TaskProgress();
							JObject contentJObject = JObject.Parse(content);
							taskProgress.TASK_ID = (string)contentJObject["TASK_ID"];
							taskProgress.SUB_TASK_ID = (string)contentJObject["SUB_TASK_ID"];
							taskProgress.PROGRESS_CUR = (int)contentJObject["PROGRESS_CUR"];
							taskProgress.PROGRESS_TOTAL = (int)contentJObject["PROGRESS_TOTAL"];
							taskProgress.STATUS_CODE = (string)contentJObject["STATUS_CODE"];
							taskProgress.STATUS_TEXT = (string)contentJObject["STATUS_TEXT"];

							worker.ReportProgress(taskProgress.PROGRESS_CUR, taskProgress.STATUS_TEXT);

						}
					}
					byte[] receiveFrameEnd = new byte[1];
					socket.Receive(receiveFrameEnd);
					byte[] endCommand = new byte[] { 0x00, 0x00, 0xff, 0xff };
					if (byteArrayEquals(endCommand, receiveCommand))
					{
						socket.Close();
						serverSocket.Close();
						break;
					}
					if (byteArrayEquals(attachmentEndCommand, receiveCommand))
					{
						break;
					}
				}
				if (attachmentsList.Count > 0)
				{
					DownloadFileForm downloadFileForm = new DownloadFileForm(attachmentsList,this);
					downloadFileForm.ShowDialog();
				}
            }
            finally
            {
                if (socket != null)
                {
					socket.Close();
                }
                if (serverSocket != null)
                {
					serverSocket.Close();
                }
            }

		}

		public void downloadFile(BackgroundWorker worker, String FileName)
        {
			byte[] frameHeader = new byte[] { (byte)0x00 };

			byte[] downloadFileBytes = System.Text.Encoding.UTF8.GetBytes(FileName);

			byte[] frameLength = intToBytes(downloadFileBytes.Length+4);
			byte[] frameCmd = new byte[] { (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x02 };//通知客户端下载文件
			byte[] frameEnd = new byte[] { (byte)0xff };

			byte[] frame1 = arrayJoin(frameHeader, frameLength);
			byte[] frame2 = arrayJoin(frame1, frameCmd);
			byte[] frame3 = arrayJoin(frame2, downloadFileBytes);
			byte[] frame = arrayJoin(frame3, frameEnd);
			socket.Send(frame);

			while (true)
			{
				byte[] receiveFrameHeader = new byte[1];
				socket.Receive(receiveFrameHeader);
				byte[] receiveFrameLength = new byte[4];
				socket.Receive(receiveFrameLength);
				int length = byteToInt(receiveFrameLength);//命令+内容长度
				length -= 4;//内容长度
				byte[] receiveCommand = new byte[4];
				socket.Receive(receiveCommand);
				byte[] progressCommand = new byte[] { 0x00, 0x00, 0x00, 0x01 };//进度报文命令
				byte[] attachmentEndCommand = new byte[] { 0x00, 0x00, 0x00, 0x03 };//附件名传送结束命令
				byte[] fileDownloadEndCommand = new byte[] { 0x00, 0x00, 0x00, 0x04 };//文件已进行下载命令
				
				if (length > 0)//有内容
				{
					byte[] receiveContent = new byte[length];
					socket.Receive(receiveContent);
					//string content = receiveContent.ToString();
					string content = Encoding.UTF8.GetString(receiveContent, 0, length);
					TaskProgress taskProgress = new TaskProgress();
					JObject contentJObject = JObject.Parse(content);
					taskProgress.TASK_ID = (string)contentJObject["TASK_ID"];
					taskProgress.SUB_TASK_ID = (string)contentJObject["SUB_TASK_ID"];
					taskProgress.PROGRESS_CUR = (int)contentJObject["PROGRESS_CUR"];
					taskProgress.PROGRESS_TOTAL = (int)contentJObject["PROGRESS_TOTAL"];
					taskProgress.STATUS_CODE = (string)contentJObject["STATUS_CODE"];
					taskProgress.STATUS_TEXT = (string)contentJObject["STATUS_TEXT"];

					worker.ReportProgress(taskProgress.PROGRESS_CUR, taskProgress.STATUS_TEXT);

				}
				
				byte[] receiveFrameEnd = new byte[1];
				socket.Receive(receiveFrameEnd);
				/*				byte[] endCommand = new byte[] { 0x00, 0x00, 0xff, 0xff };
                                if (byteArrayEquals(endCommand, receiveCommand))
                                {
                                    socket.Close();
                                    serverSocket.Close();
                                    break;
                                }*/
				if (byteArrayEquals(fileDownloadEndCommand, receiveCommand))
				{
					break;
				}
			}
		}

		public void close()
        {

			byte[] frameHeader = new byte[] { (byte)0x00 };
			byte[] frameLength = intToBytes(4);
			byte[] frameCmd = new byte[] { (byte)0x00, (byte)0x00, (byte)0x00, (byte)0x03 };
			byte[] frameEnd = new byte[] { (byte)0xff };

			byte[] frame1 = arrayJoin(frameHeader, frameLength);
			byte[] frame2 = arrayJoin(frame1, frameCmd);
			byte[] frame = arrayJoin(frame2, frameEnd);
			socket.Send(frame);

			while (true)
			{
				byte[] receiveFrameHeader = new byte[1];
				socket.Receive(receiveFrameHeader);
				byte[] receiveFrameLength = new byte[4];
				socket.Receive(receiveFrameLength);
				int length = byteToInt(receiveFrameLength);//命令+内容长度
				length -= 4;//内容长度
				byte[] receiveCommand = new byte[4];
				socket.Receive(receiveCommand);

				if (length > 0)//有内容
				{
					byte[] receiveContent = new byte[length];
					socket.Receive(receiveContent);
					//string content = receiveContent.ToString();
					string content = Encoding.UTF8.GetString(receiveContent, 0, length);
					TaskProgress taskProgress = new TaskProgress();
					JObject contentJObject = JObject.Parse(content);
					taskProgress.TASK_ID = (string)contentJObject["TASK_ID"];
					taskProgress.SUB_TASK_ID = (string)contentJObject["SUB_TASK_ID"];
					taskProgress.PROGRESS_CUR = (int)contentJObject["PROGRESS_CUR"];
					taskProgress.PROGRESS_TOTAL = (int)contentJObject["PROGRESS_TOTAL"];
					taskProgress.STATUS_CODE = (string)contentJObject["STATUS_CODE"];
					taskProgress.STATUS_TEXT = (string)contentJObject["STATUS_TEXT"];
				}
				byte[] receiveFrameEnd = new byte[1];
				socket.Receive(receiveFrameEnd);
				byte[] endCommand = new byte[] { 0x00, 0x00, 0xff, 0xff };
				if (byteArrayEquals(endCommand, receiveCommand))
				{
					break;
				}
			}

			if (socket != null)
            {
				socket.Close();
            }
            if (serverSocket != null)
            {
				serverSocket.Close();
            }
        }


	}
}
