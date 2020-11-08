using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApi.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using OnlineShoppingServices.Data;
using OnlineShoppingServices.Common.Models;
using OnlineShoppingServices.Common.Interfaces;
using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using OnlineShoppingServices.Common.Entities;

namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserBusiness _userService;

        public UserController(IUserBusiness userService)
        {
            _userService = userService;
        }

          [AllowAnonymous]
      [HttpPost("authenticate")]
 public async Task<IActionResult> Authenticate([FromBody]UserModel userModel)
      {
           
            if (string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Password))
          {
             // ModelState.AddModelError()
              return BadRequest();
          }
       
          try
          {
              var response = await _userService.Authenticate(userModel);

              if (response == null)
                  return BadRequest(new { message = "Username or password is incorrect" });              

              return Ok(response);
          }
          catch(Exception ex)
          {
              return  StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

          }
      }

/*
      [AcceptVerbs("GET", "POST")]
      public IActionResult VerifyEmail(string email)
      {
          if (!_userService.VerifyEmail(email))
          {
              return Json($"Email {email} is already in use.");
          }

          return Json(true);
      }
*/
    }
}
