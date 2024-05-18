using System;
using System.Collections.Generic;

namespace CrmContacts.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string ShippingNo { get; set; } = null!;
        public int? SerialNo { get; set; }
        public string BatchNo { get; set; } = null!;
        public decimal Mrp { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
