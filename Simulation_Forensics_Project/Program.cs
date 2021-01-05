using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation_Forensics_Project
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length < 5)
            {
                Application.Run(new ForensicForm(null));
            }
            else
            {
                Application.Run(new ForensicForm(args));
            }
            
        }
    }
}
