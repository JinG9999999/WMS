using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Stockin
    {
        public int StockInId { get; set; }
        public string StockInType { get; set; }
        public int? SupplierId { get; set; }
        public int? OrderNo { get; set; }
        public int? StockInStatus { get; set; }
        public string Remark { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    //分页
    public class PageStu
    {
        public List<Stockin> stockins { get; set; }

        public int TotalCount { get; set; }//总记录数

        public int TotalPage { get; set; }//总页数

        public int CurrentPage { get; set; }//当前页
    }
    public class Values
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<DateTime> times { get; set; }
    }
}
