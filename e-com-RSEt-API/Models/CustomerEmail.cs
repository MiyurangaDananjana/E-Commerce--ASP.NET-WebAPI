using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class CustomerEmail
    {
        public int EmailId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public int? Statest { get; set; }
    }
}
