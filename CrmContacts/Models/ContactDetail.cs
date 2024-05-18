using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrmContacts.Models
{
    public partial class ContactDetail
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ContactOwner { get; set; }
        public string? JobTitle { get; set; }
        public int? PhoneNumber { get; set; }
        public string? LifeCycleStage { get; set; }
        public string? LeadStatus { get; set; }
        public string? City { get; set; }
        public string? CompanyName { get; set; }
        public string? CountryRegion { get; set; }
        public string? Industry { get; set; }
        public int? MobilePhoneNumber { get; set; }
        public int? NumberOfEmployees { get; set; }
        public int? PoastalCode { get; set; }
        public string? StateRegion { get; set; }
        public string? StreetAddress { get; set; }
        public string? TimeZone { get; set; }
        public int? WhatAppPhoneNumber { get; set; }
    }
}
