using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class Headset
    {
        public int HeadsetId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int? Connectivity { get; set; }
        public bool? Microphone { get; set; }
        public string? Compatibility { get; set; }
        public string? FrequencyResponse { get; set; }
        public string? Impedance { get; set; }
        public string? Sensitivity { get; set; }
        public string? Weight { get; set; }
        public string? Warranty { get; set; }
    }
}
