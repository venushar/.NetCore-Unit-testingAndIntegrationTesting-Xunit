using DataAnnotationsExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace OnlineShoppingServices.Common.Entities
{
    public class User
    {
       // [Key]
        public int UserId { get; set; }
       
      //  [Required]
        public string UserName { get; set; }
        //[Required(ErrorMessage = "Password is required")]
        //[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required(ErrorMessage = "Confirm Password is required")]
        //[StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        //[DataType(DataType.Password)]
        //[System.ComponentModel.DataAnnotations.Compare("Password")]
      //  public string ConfirmPassword { get; set; }
        
        //[Required(ErrorMessage = "You must provide a phone number")]
        //[Display(Name = "Home Phone")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public int Mobile { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[Remote(action: "VerifyEmail", controller: "Users")]
        [Email(ErrorMessage = "Bad email")]
        public string Email { get; set; }
             

    }
}
