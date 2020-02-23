using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApplication.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please provide a first name")]
        [MinLength(1, ErrorMessage = "Firstame is too short"), MaxLength(25, ErrorMessage = "Name is too long max char. is 25"), RegularExpression(@"^[A-Za-z\-\s]+$", ErrorMessage = "Name can only contain a-z, dashes, and spaces.")]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please provide a last name")]
        [MinLength(1, ErrorMessage = "Lastame is too short"), MaxLength(25, ErrorMessage = "Lastame is too long max char. is 25"), RegularExpression(@"^[A-Za-z\-\s]+$", ErrorMessage = "Name can only contain a-z, dashes, and spaces.")]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please provide your email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide a Password")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password is too short"), MaxLength(12, ErrorMessage = "Password is too long max char. is 12"), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[@$!%*#?&\-\+])(.{6,}$)", ErrorMessage = "Passwords must be 6 - 12 characters in length, contain at least 1 uppercase letter, contain at least 1 special character")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Your password and confirm password do not match.")]
        
        public string ConfirmPassword { get; set; }
        
        [Required(ErrorMessage = "Please provide an address")]
        [MinLength(10, ErrorMessage = "Address is too short"), MaxLength(120, ErrorMessage = "Address is too long max char. is 12"), RegularExpression(@"^[\w\.\,\-\s]+$", ErrorMessage = "Address can only contain a-z, 0-9, punctuation/dashes/underscores, and spaces.")]
        public string Address { get; set; }


        


    }
}
