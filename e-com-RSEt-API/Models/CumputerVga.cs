using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class CumputerVga
    {
        public int VgaId { get; set; }
        public string VgaName { get; set; } = null!;
        public string? Capacity { get; set; }
        public double? Price { get; set; }
    }
}
