using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApplication.Models
{
    public class RegisterModel
    {
        
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please fill in the Name section.")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please fill in the Description section.")]
        public string Description { get; set; }

        [Display(Name = "Attendance Scheme")]
        [Required(ErrorMessage = "You must select scheme.")]
        public string AttendDanceScheme { get; set; }

        public string[] SessionName { get; set; }

        [Display(Name="Class list .csv")]
        [Required(ErrorMessage = "You must upload a class list.")]
        public IFormFile ClassList { get; set; }

        public string[] SessionDescription { get; set; }

        public List<SelectListItem> Scheme
        {
            get;
            set;
        }

        [Display(Name = "Num")]
        public string Order { get; set; }

        public List<SelectListItem> NumOfOrder
        {
            get;
            set;
        }
    }
}
