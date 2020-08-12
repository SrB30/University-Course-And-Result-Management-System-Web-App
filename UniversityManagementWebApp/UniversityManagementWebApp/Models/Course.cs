using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter course code")]
        [StringLength(15,MinimumLength = 5)]
        public string Code { get; set; }
        [Required(ErrorMessage = "Please enter course name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter course credit")]
        [Range(0.5,5.00)]
        public decimal Credit { get; set; }
        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please select department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please select semester")]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
    }
}