using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Invmovedetail
    {
        public int MoveDetailId { get; set; }
        public int? InventorymoveId { get; set; }
        public int? Status { get; set; }
        public int? PlanQty { get; set; }
        public int? ActQty { get; set; }
        public int? AuditinId { get; set; }
        public DateTime? AuditinTime { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
