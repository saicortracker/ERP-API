﻿using System;
using System.Collections.Generic;

namespace ERP.Models
{
    public partial class Source
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
