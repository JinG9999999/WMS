using System;
using System.Collections.Generic;

namespace WMS_API.Models
{
    public partial class Inventory
    {
        public int InventoryId { get; set; }
        public int? StoragerackId { get; set; }
        public int? Qty { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
