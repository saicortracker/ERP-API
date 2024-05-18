using System;
using System.Collections.Generic;

namespace CrmContacts.Models
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
        public string LeadStatus { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? CountryRegion { get; set; }
        public string? Industry { get; set; }
        public int MobilePhoneNumber { get; set; }
        public int NumberOfEmployees { get; set; }
        public int PoastalCode { get; set; }
        public string? StateRegion { get; set; }
        public string? StreetAddress { get; set; }
        public string? TimeZone { get; set; }
        public int WhatAppPhoneNumber { get; set; }
    }
}
