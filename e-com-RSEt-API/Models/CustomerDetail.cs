﻿using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class CustomerDetail
    {
        public int CustomerId { get; set; }
        public string? FristName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public int? EmailValidate { get; set; }
        public int? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Password { get; set; }
        public int? CustomerStatus { get; set; }
    }
}
