using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApplication.Models
{
    public class AttendanceSchemeModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please fill in the Name section.")]
        [MinLength(3, ErrorMessage = "Name is too short"), MaxLength(20, ErrorMessage = "Name is too long max char. is 20"), RegularExpression(@"^[\w\-\s]+$", ErrorMessage = "Name can only contain a-z, 0-9, dashes/underscores, and spaces.")]
        public string Name { get; set; }


        [Display(Name = "Symbol")]
        public string[] Symbol { get; set; }


        public string[] StatusName { get; set; }
        [Display(Name = "Assigned %")]
        public string[] AssignedPercentage { get; set; }



        [Display(Name = "Num")]
        public string Order { get; set; }

        public List<SelectListItem> NumOfOrder
        {
            get;
            set;
        }
    }
}
