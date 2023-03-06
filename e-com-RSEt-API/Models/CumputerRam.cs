using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class CumputerRam
    {
        public int RamId { get; set; }
        public string RamName { get; set; } = null!;
        public string? Capacity { get; set; }
        public double? Price { get; set; }
    }
}
