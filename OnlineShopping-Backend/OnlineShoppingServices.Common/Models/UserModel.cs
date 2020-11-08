using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingServices.Common.Models
{
   public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string JwtToken { get; set; }
        public int Mobile { get; set; }

    }
}
