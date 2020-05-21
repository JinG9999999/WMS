using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Inventorymove
    {
        public int InventorymoveId { get; set; }
        public int? SourceStoragerackId { get; set; }
        public int? AimStoragerackId { get; set; }
        public int? Status { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
