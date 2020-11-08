/* using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnlineShoppingServices.Data;
using WebApi.Entities;

using WebApi.Models;
using User2 = WebApi.Entities.User2;

namespace WebApi.Services
{
public interface IUserService
 {
     AuthenticateResponse Authenticate(AuthenticateRequest model);
      Task<List<User>> GetAll();
 }*/

//public class UserService
        /*: IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User2> _users = new List<User2>
        { 
            new User2 { UserId = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" } 
        };

        private readonly OnlineShoppingServices.Data.UnitOfWork _UoW;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, OnlineShoppingServices.Data.IUnitOfWork UoW)
        {
            _appSettings = appSettings.Value;
            this._UoW = UoW as UnitOfWork;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public async Task<List<User>> GetAll()
        {
            var persons = await _UoW.genericRepository.FindAsync<User>
                           (x => x.UserId.Equals(2));
            return persons.Select(person => new User()).ToList();
        }

        // helper methods

        private string generateJwtToken(User2 user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

  
        //public IEnumerable<User> GetAll()
        //{
        //    throw new NotImplementedException();
        //}
    }
}*/