using System;
using System.Collections.Generic;

namespace WMS_API.Models
{
    public partial class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }
        public string SupplierPerson { get; set; }
        public int? SupplierLevel { get; set; }
        public string Email { get; set; }
        public bool? IsDel { get; set; }
        public string Remark { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
