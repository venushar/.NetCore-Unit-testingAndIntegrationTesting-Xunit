using OnlineShoppingServices.Common.Entities;
using OnlineShoppingServices.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingServices.Common.Interfaces
{
   public interface IUserBusiness
    {

        Task <UserModel>Authenticate(UserModel model);
    }
}
