using System;

namespace Model
{
    public class Inventoryrecord
    {
        //库存记录表
        public int InventoryrecordId { get; set; }
        public int StockInDetailId { get; set; }
        public int Qty { get; set; }
        public bool IsDel { get; set; }
        public string Remark { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
