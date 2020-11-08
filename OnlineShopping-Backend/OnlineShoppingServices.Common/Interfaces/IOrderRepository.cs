using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingServices.Common.Interfaces
{
 public  interface IOrderRepository 
    {
        IEnumerable<OrderItem> GetOrderItems(int OrderId);
    }
}
