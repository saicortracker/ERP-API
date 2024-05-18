using System;
using System.Collections.Generic;

namespace CrmContacts.Models
{
    public partial class Company
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyOwner { get; set; }
        public string? Type { get; set; }
        public string? City { get; set; }
        public string? RegionState { get; set; }
        public int PostalCode { get; set; }
        public int NumberOfEmplyees { get; set; }
        public int? AnnualRevenue { get; set; }
        public string TimeZone { get; set; } = null!;
        public string? Discription { get; set; }
        public string? LinkedinCompanyPage { get; set; }
    }
}
