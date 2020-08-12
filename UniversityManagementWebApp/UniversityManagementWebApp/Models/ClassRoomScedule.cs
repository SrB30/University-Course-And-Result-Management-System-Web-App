using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementWebApp.Models
{
    public class ClassRoomScedule
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Room { get; set; }
        public string Day { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string ClassScheduleInfo { get; set; }
    }
}