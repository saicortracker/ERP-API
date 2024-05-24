using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class Leaf
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? LeaveType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int? BalanceLeaves { get; set; }
        public string? GuidFilename { get; set; }
        public string? FileName { get; set; }
        public int? Status { get; set; }
        public string? Remarks { get; set; }
        public int? ReportingManager { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
