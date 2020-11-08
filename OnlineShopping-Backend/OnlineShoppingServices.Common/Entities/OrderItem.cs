using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingServices.Common.Entities
{
   public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderItemQuantity { get; set; }
        public int OrderId { get; set; }
        public Order Orderobj { get; set; }
    }
}
