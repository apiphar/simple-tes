using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Penjualan
    {
        public int IntSalesOrderId { get; set; }
        public int? IntCustomerId { get; set; }
        public int? IntProductId { get; set; }
        public DateTime? DtSalesOrder { get; set; }
        public double? IntQty { get; set; }

        public Customer IntCustomer { get; set; }
        public Product IntProduct { get; set; }
    }
}
