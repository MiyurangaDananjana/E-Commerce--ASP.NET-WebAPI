using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class CustomerAddressTb
    {
        public int AddressId { get; set; }
        public int? CustomerCode { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public int? PostalCode { get; set; }
        public int? Provition { get; set; }
        public int? City { get; set; }
    }
}
