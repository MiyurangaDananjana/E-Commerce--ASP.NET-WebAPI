using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class ComputerProcessor
    {
        public int ProcessorId { get; set; }
        public string ProcessorName { get; set; } = null!;
        public string? Capacity { get; set; }
        public double? PriceDouble { get; set; }
    }
}
