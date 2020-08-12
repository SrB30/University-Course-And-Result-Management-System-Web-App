using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class EnrollCourseToStudentManager
    {
        private EnrollCourseToStudentGateway enrollCourseToStudentGateway;

        public EnrollCourseToStudentManager()
        {
            enrollCourseToStudentGateway = new EnrollCourseToStudentGateway();
        }
        public string UnassignCourse()
        {
            int rowAffect = enrollCourseToStudentGateway.UnassignCourse();
            if (rowAffect > 0)
            {
                return "All courses successfully unassigned";
            }
            return "";
        }

        public string Enroll(EnrollCourseToStudent aCourseToStudent)
        {
            bool isCourseEnrolled = enrollCourseToStudentGateway.IsCourseEnrolled(aCourseToStudent.StudentId,
                aCourseToStudent.CourseId);
            if (!isCourseEnrolled)
            {
                int rowAffect = enrollCourseToStudentGateway.Enroll(aCourseToStudent);
                if (rowAffect>0)
                {
                    return "Course succesfuly enrolled";
                }
                return "Course enroll failed";
            }
            return "This course is already enrolled to the entered student";
        }

        public List<SelectListItem> GetEnrolledCoursesByStudentId(int studentId)
        {
            List<StudentCourseDetailsView> courseList = enrollCourseToStudentGateway.GetEnrolledCoursesByStudentId(studentId);
            List<SelectListItem> courseSelectList = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Select---",
                    Value = ""
                }
            };
            courseSelectList.AddRange(courseList.Select(course => new SelectListItem() { Text = course.CourseName, Value = course.CourseId.ToString() }));

            return courseSelectList;
        }
    }
}