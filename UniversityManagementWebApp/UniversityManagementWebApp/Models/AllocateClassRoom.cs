using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class AllocateClassRoom
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select department")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please select course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Please select room")]
        [Display(Name = "Room")]
        public int RoomId { get; set; }
        [Required(ErrorMessage = "Please select day")]
        [Display(Name = "Day")]
        public int DayId { get; set; }
        [Required(ErrorMessage = "Please enter time")]
        public string FromTime { get; set; }
        [Required(ErrorMessage = "Please enter time")]
        public string ToTime { get; set; }
    }
}