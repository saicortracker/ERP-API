using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int? EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string? Status { get; set; }
        public int? Gender { get; set; }
        public int? Department { get; set; }
        public int? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? ExtensionNumber { get; set; }
        public int? Location { get; set; }
        public string? Address { get; set; }
        public int? PinCode { get; set; }
    }
}
