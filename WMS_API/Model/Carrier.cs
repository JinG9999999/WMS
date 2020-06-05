using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Carrier
    {
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string CarrierPerson { get; set; }
        public int? CarrierLevel { get; set; }
        public string Email { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class PageCarrier
    {
        public List<Carrier> Carriers { get; set; }

        public int TotalCount { get; set; }//总记录数

        public int TotalPage { get; set; }//总页数

        public int CurrentPage { get; set; }//当前页
    }
}
