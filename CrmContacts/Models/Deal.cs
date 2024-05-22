using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class Deal
    {
        public int Id { get; set; }
        public string? Dealname { get; set; }
        public int? Pipeline { get; set; }
        public int? Dealstage { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? Closedate { get; set; }
        public int? Dealowner { get; set; }
        public int? Dealtype { get; set; }
        public int? Priority { get; set; }
        public int? Contact { get; set; }
        public int? Company { get; set; }
        public int? Addlineitem { get; set; }
        public int? Quantity { get; set; }
    }
}
