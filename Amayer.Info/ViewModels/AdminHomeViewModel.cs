using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Amayer.Info.ViewModels
{
    public class AdminHomeViewModel
    {

        

        public string ServerMachineName { get; set; }
        public string ServerIp { get; set; }
        public string ServerPort { get; set; }
        public string ServerSystem { get; set; }
        public string ServerSoftware { get; set; }
        public string ServerName { get; set; }
        public string FrameworkVersion { get; set; }
        public string CpuType { get; set; }
        public string CpuCount { get; set; }

        public string ClientIp { get; set; }
        public string UserAgent { get; set; }
        public string Browser { get; set; }

        public string UserName { get; set; }
        public string RoleName { get; set; }
        public string LoginTime { get; set; }
    }
}