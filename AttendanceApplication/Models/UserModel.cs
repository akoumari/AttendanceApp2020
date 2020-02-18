using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApplication.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Please provide a Password")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please provide a Password")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please provide a Password")]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please provide your email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match.")]
        public string ConfirmPassword { get; set; }


    }
}
