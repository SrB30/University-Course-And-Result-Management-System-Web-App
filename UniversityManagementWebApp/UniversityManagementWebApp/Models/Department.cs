using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Department
    {
        [Required]
        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter department code")]
        [StringLength(maximumLength: 7, MinimumLength = 2, ErrorMessage = "code must be two (2) to seven (7) characters long")]
        public string Code { get; set; }


        [Required(ErrorMessage = "Please enter department name")]
        [Display(Name = "Department")]
        public string Name { get; set; }
    }
}