using System;
using System.Collections.Generic;

namespace e_com_RSEt_API.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
