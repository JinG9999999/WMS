using System;
using System.Collections.Generic;

namespace WMS_API.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserNickname { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public bool? Sex { get; set; }
        public int? DeptId { get; set; }
        public string LoginIp { get; set; }
        public DateTime? LoginDate { get; set; }
        public bool? IsEabled { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? RoleId { get; set; }
        public string HeadImg { get; set; }
    }
}
