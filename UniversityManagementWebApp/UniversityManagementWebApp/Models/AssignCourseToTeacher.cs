using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class AssignCourseToTeacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select a teacher")]
        [Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        [Display(Name = "Credit To Be Taken")]
        public decimal CreditToBeTaken { get; set; }

        [Display(Name = "Remaining Credit")]
        public decimal RemainingCredit { get; set; }

        [Required(ErrorMessage = "Please select a course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Display(Name = "Name")]
        public string CourseName { get; set; }

        [Display(Name = "Credit")]
        public decimal CourseCredit { get; set; }
    }
}