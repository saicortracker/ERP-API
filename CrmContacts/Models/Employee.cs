using System;
using System.Collections.Generic;

namespace CrmContacts.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int EmployeeNo { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime JoiningDate { get; set; }
        public string? Status { get; set; }
        public string Gender { get; set; } = null!;
        public string Department { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public int ExtensionNumber { get; set; }
        public string? Location { get; set; }
        public string Address { get; set; } = null!;
        public int PinCode { get; set; }
    }
}
