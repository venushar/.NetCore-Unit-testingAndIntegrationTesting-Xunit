using Microsoft.Extensions.Configuration;
using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Interfaces;
using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServices.Data
{
   public  class UnitOfWork : IUnitOfWork
    {

        private readonly ShoppingDBContext _shoppingDBContext;
        private IOrderRepository _orderRepository;      
        private IAsyncRepository<User> _blogRepository;
        private IAsyncRepository<Product> _produtRepository;

        public UnitOfWork(ShoppingDBContext shoppingDBContext) {
            this._shoppingDBContext = shoppingDBContext;
       
    
        }
        public IAsyncRepository<User> UserRepository
        {
            get
            {
                return _blogRepository = _blogRepository ?? new GenericRepository<User>(_shoppingDBContext);
            }
        }

        public IAsyncRepository<Product> ProductRepository
        {
            get
            {
                return _produtRepository = _produtRepository ?? new GenericRepository<Product>(_shoppingDBContext);
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return _orderRepository = _orderRepository ?? new OrderRepository(_shoppingDBContext);
            }
        }
       
        public async Task commit()
        {
           await  this._shoppingDBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _shoppingDBContext.Dispose();
            }
        }

    }
}
