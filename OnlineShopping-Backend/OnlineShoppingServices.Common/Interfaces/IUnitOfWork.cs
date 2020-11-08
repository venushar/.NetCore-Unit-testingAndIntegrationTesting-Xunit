using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServices.Common.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        Task commit();

     
       // IAsyncRepository<User> GenericRepository { get; }
        IAsyncRepository<User> UserRepository { get; }
        IAsyncRepository<Product> ProductRepository { get; }
        IOrderRepository OrderRepository { get; }


    }
}
