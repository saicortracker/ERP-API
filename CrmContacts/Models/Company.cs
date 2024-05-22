using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class Company
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyOwner { get; set; }
        public string? Type { get; set; }
        public int? City { get; set; }
        public int? RegionState { get; set; }
        public int PostalCode { get; set; }
        public int NumberOfEmplyees { get; set; }
        public int? AnnualRevenue { get; set; }
        public int TimeZone { get; set; }
        public string? Discription { get; set; }
        public string? LinkedinCompanyPage { get; set; }
        public int? Country { get; set; }
        public int? IndustryType { get; set; }
    }
}
