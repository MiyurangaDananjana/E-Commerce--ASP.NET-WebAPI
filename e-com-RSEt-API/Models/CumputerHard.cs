using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class CumputerHard
    {
        public int HardId { get; set; }
        public string HardName { get; set; } = null!;
        public string? Capacity { get; set; }
        public string? Type { get; set; }
        public double? Price { get; set; }
    }
}
