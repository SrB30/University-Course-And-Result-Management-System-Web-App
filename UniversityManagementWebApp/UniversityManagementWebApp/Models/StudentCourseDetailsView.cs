using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class StudentCourseDetailsView
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }
}