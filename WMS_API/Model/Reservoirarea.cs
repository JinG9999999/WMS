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
        public string WarehouseName { get; set; }
        public string UserNickname { get; set; }
        public string UserNickname2 { get; set; }
    }
    //分页
    public class PageReservoirarea
    {
        public List<Reservoirarea>  reservoirareas { get; set; }

        public int totalCount { get; set; }//总记录数

        public int totalPage { get; set; }//总页数

        public int currentPage { get; set; }//当前页

        public int pageSize { get; set; }
    }
}
