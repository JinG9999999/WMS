using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Storagerack
    {
        public int StorageRackId { get; set; }
        public string StorageRackName { get; set; }
        public int? ReservoirAreaId { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string WarehouseId { get; set; }
    }
}
