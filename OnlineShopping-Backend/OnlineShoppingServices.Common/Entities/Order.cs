using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingServices.Common.Entities
{
  public   class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public IEnumerable<OrderItem>OrderItems { get; set; }

    }
}
