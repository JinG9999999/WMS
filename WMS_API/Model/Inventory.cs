using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int? StoragerackId { get; set; }
        public int? Qty { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
