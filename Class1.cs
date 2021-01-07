using System;

public class Class1
{
	public Class1()
	{
        static void Main()
        {
            Process cmdProcess = new Process();
            cmdProcess.StartInfo.FileName = "cmd.exe";
            cmdProcess.StartInfo.RedirectStandardInput = true;

            cmdProcess.StartInfo.RedirectStandardOutput = true;
            cmdProcess.StartInfo.RedirectStandardError = true;

            cmdProcess.StartInfo.UseShellExecute = false;
            cmdProcess.StartInfo.CreateNoWindow = true;
            cmdProcess.Start();
            cmdProcess.StandardInput.WriteLine("memuc listvms");
            cmdProcess.StandardInput.WriteLine("exit");
            cmdProcess.StandardInput.Flush();
            //string result = cmdProcess.StandardOutput.ReadToEnd();
            cmdProcess.Start();

            StreamReader reader = cmdProcess.StandardOutput;
            string strLine = reader.ReadLine();
            while (!reader.EndOfStream)
            {
                strLine = strLine.Trim();
                Console.WriteLine(strLine);
                strLine = reader.ReadLine();
            }
        }
}
