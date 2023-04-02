using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class ComputerOder
    {
        public int OrderId { get; set; }
        public int? CusId { get; set; }
        public int? ProcessorId { get; set; }
        public int? RamId { get; set; }
        public int? VgaId { get; set; }
        public int? OsId { get; set; }
        public int? AntivirusGrdId { get; set; }
        public int? ShipingAddressId { get; set; }
        public int? BullingAddressId { get; set; }
        public int? ShipingMethod { get; set; }
        public DateTime? OderDate { get; set; }
        public int? ApprovedBy { get; set; }
        public int? OderStatus { get; set; }
    }
}
