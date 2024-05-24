using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string ContactOwner { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string LifeCycleStage { get; set; } = null!;
        public int LeadStatus { get; set; }
        public int? City { get; set; }
        public string? CompanyName { get; set; }
        public int? CountryRegion { get; set; }
        public int? Industry { get; set; }
        public int MobilePhoneNumber { get; set; }
        public int NumberOfEmployees { get; set; }
        public int PoastalCode { get; set; }
        public int? StateRegion { get; set; }
        public string? StreetAddress { get; set; }
        public int? TimeZone { get; set; }
        public int WhatAppPhoneNumber { get; set; }
    }
}
