using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
