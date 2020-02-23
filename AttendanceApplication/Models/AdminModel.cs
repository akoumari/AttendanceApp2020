using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApplication.Models
{
    public class AdminModel
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

        public bool test()
        {
            if (this.Lastname == "noob")
            {
                return true;
            }
            return false;
        }
    }
}
