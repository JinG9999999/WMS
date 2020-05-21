using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Reservoirarea
    {
        public int ReservoirAreaId { get; set; }
        public string ReservoirAreaName { get; set; }
        public int? WarehouseId { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
