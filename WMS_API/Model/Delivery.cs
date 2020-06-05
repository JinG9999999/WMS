using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Delivery
    {
        public int DeliveryId { get; set; }
        public int StockOutId { get; set; }
        public int CarrierId { get; set; }
        public bool IsDel { get; set; }
        public string Remark { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string TrackingNo { get; set; }
    }
    public class PageDelivery
    {
        public List<Delivery> Deliverys { get; set; }

        public int TotalCount { get; set; }//总记录数

        public int TotalPage { get; set; }//总页数

        public int CurrentPage { get; set; }//当前页
    }
}
