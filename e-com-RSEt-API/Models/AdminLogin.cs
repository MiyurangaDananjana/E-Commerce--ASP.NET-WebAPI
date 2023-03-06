using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class AdminLogin
    {
        public int AdminId { get; set; }
        public string? FullName { get; set; }
        public int? PhoneNumber { get; set; }
        public DateTime? Dob { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
