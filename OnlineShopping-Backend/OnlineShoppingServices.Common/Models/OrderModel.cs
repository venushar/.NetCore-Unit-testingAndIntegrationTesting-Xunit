using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingServices.Common.Models
{
  public   class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemModel>OrderItems { get; set; }

    }
}
