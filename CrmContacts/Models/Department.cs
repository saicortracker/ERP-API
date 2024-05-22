﻿using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class Department
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}
