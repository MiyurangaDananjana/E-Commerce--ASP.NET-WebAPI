using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class Mouse
    {
        public Mouse()
        {
            Products = new HashSet<Product>();
        }

        public int MouseId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Connectivity { get; set; }
        public string? SensorType { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
