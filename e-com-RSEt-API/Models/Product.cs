using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Keyboards = new HashSet<Keyboard>();
            Mice = new HashSet<Mouse>();
        }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public byte[]? ProductImage { get; set; }
        public decimal? Price { get; set; }
        public int? StockQuantity { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ICollection<Keyboard> Keyboards { get; set; }
        public virtual ICollection<Mouse> Mice { get; set; }
    }
}
