using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class LaptopDesktopView
    {
        public int CumputerId { get; set; }
        public string? Manufacture { get; set; }
        public string? Model { get; set; }
        public DateTime? Year { get; set; }
        public string? LD { get; set; }
        public double? Price { get; set; }
        public string? ImagePath { get; set; }
    }
}
