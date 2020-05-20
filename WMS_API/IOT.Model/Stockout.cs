using System;
using System.Collections.Generic;
using System.Text;

namespace IOT.Model
{
    public partial class Stockout
    {
        public int StockOutId { get; set; }
        public string OrderNo { get; set; }
        public string StockOutType { get; set; }
        public int? CustomerId { get; set; }
        public int? StockOutStatus { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
