using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class EnrollCourseToStudent
    {
        [Required(ErrorMessage = "Please select a student")]
        [Display(Name = "Student Id")]
        public int StudentId { get; set; }
        [Display(Name="Name")]
        public string Name{ get; set; }
        public string Email { get; set; }
        [Display(Name = "Department")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Please select a course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Display(Name = "Date")]
        public string EnrollDate { get; set; }

        [Required(ErrorMessage = "Please select a grade")]
        [Display(Name = "Grade")]
        public int GradeId { get; set; }
    }
}