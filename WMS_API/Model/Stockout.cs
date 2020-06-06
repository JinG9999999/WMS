using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Stockout
    {
        public int StockOutId { get; set; }
        public int OrderNo { get; set; }
        public string StockOutType { get; set; }
        public int CustomerId { get; set; }
        public int? StockOutStatus { get; set; }
        public string Remark { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class PageStus
    {
        public List<Stockout> stockouts { get; set; }

        public int TotalCount { get; set; }//总记录数

        public int TotalPage { get; set; }//总页数

        public int CurrentPage { get; set; }//当前页
    }
}
