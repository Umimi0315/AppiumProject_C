using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_Forensics_Project
{
    class TaskProgress
    {
        public string TASK_ID { get; set; }//任务id
        public string SUB_TASK_ID { get; set; }//子任务id
        public int PROGRESS_CUR { get; set; }//当前进度
        public int PROGRESS_TOTAL { get; set; }//总进度
        public string STATUS_CODE { get; set; }//进度状态代码 
                                                    //0：正常运行  1：出错
        public string STATUS_TEXT { get; set; }//进度状态信息
    }
}
