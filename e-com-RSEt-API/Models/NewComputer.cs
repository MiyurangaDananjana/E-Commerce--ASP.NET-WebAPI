using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class NewComputer
    {
        public int ComId { get; set; }
        public int? ModelId { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public string? ImagePath { get; set; }
        public int? States { get; set; }
    }
}
