using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class StudentResult
    {
        [Required]
        [Display(Name = "Student Reg. No")]
        public int StudentId { get; set; }

        public string RegNo { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
    }
}