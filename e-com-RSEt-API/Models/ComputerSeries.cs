using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class ComputerSeries
    {
        public int SeriesId { get; set; }
        public string? SeriesName { get; set; }
        public int? CategoryId { get; set; }
    }
}
