using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Interfaces;

namespace OnlineShoppingServices.Data
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ShoppingDBContext _shoppingDBContext;
        public OrderRepository(ShoppingDBContext context) : base(context) {
            _shoppingDBContext = context;
        }

           public IEnumerable <OrderItem> GetOrderItems(int OrderId)
        {
            return ((IEnumerable<OrderItem>)(from m in this._shoppingDBContext.Orders 
                    where m.OrderId.Equals(OrderId) select m.OrderItems)).ToList();
            
        }

       
    }
}
