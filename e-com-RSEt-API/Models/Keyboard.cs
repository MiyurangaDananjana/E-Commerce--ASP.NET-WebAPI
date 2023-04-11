using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class Keyboard
    {
        public Keyboard()
        {
            Products = new HashSet<Product>();
        }

        public int KeyboardId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? Connectivity { get; set; }
        public string? Compatibility { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
