using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class ComSeries
    {
        public int SeriesId { get; set; }
        public string? SeriesName { get; set; }
        public int? MfId { get; set; }
        public int? ComputerTypeId { get; set; }
    }
}
