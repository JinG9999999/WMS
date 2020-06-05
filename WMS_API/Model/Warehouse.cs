using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Warehouse
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    //分页
    public class PageWarehouse
    {
        public List<Warehouse>  warehouses { get; set; }

        public int TotalCount { get; set; }//总记录数

        public int TotalPage { get; set; }//总页数

        public int CurrentPage { get; set; }//当前页
    }
}
