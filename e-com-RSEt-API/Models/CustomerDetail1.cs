﻿using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class CustomerDetail1
    {
        public int UserId { get; set; }
        public string? FristName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int? Statest { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
