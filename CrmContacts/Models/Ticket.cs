using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public string? Ticketname { get; set; }
        public int? Pipeline { get; set; }
        public int? Ticketstatus { get; set; }
        public string? Ticketdescription { get; set; }
        public int? Source { get; set; }
        public int? Ticketowner { get; set; }
        public int? Priority { get; set; }
        public DateTime? Createdate { get; set; }
        public int? Contact { get; set; }
        public int? Company { get; set; }
    }
}
