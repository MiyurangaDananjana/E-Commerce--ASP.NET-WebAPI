using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class ProductSpacification
    {
        public int ComputerId { get; set; }
        public string? Name { get; set; }
        public int? ComouterType { get; set; }
        public int? Processor { get; set; }
        public int? Ram { get; set; }
        public int? Hard { get; set; }
        public string? Display { get; set; }
        public string? Wifi { get; set; }
        public string? Bt { get; set; }
        public int? Antivirus { get; set; }
        public int? Warranty { get; set; }
        public string? ImgePath { get; set; }
    }
}
