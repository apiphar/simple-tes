using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Product
    {
        public Product()
        {
            Penjualan = new HashSet<Penjualan>();
        }

        public int IntProductId { get; set; }
        public string TxtProductCode { get; set; }
        public string TxtProductName { get; set; }
        public int? IntQty { get; set; }
        public decimal? DecPrice { get; set; }
        public DateTime? DtInserted { get; set; }

        public ICollection<Penjualan> Penjualan { get; set; }
    }
}
