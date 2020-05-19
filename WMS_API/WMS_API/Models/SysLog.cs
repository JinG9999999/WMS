using System;
using System.Collections.Generic;

namespace WMS_API.Models
{
    public partial class SysLog
    {
        public int LogId { get; set; }
        public string LogType { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Browser { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string LogIp { get; set; }
    }
}
