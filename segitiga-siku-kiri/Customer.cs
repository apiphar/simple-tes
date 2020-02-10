using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Penjualan = new HashSet<Penjualan>();
        }

        public int IntCustomerId { get; set; }
        public string TxtCustomerName { get; set; }
        public string TxtCustomerAddress { get; set; }
        public bool? BitGender { get; set; }
        public DateTime? DtmBirthDate { get; set; }
        public DateTime? Inserted { get; set; }

        public ICollection<Penjualan> Penjualan { get; set; }
    }
}
