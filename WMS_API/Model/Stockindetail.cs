using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Stockindetail
    {
        public int StockInDetailId { get; set; }
        public int? StockInId { get; set; }
        public int? Status { get; set; }
        public int? PlanInQty { get; set; }
        public int? ActInQty { get; set; }
        public int? StoragerackId { get; set; }
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
