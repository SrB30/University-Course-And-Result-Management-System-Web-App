using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class AssignCourseToTeacherManager
    {
        private AssignCourseToTeacherGateway assignCourseToTeacherGateway;
        private TeacherGateway teacherGateway;

        public AssignCourseToTeacherManager()
        {
            assignCourseToTeacherGateway = new AssignCourseToTeacherGateway();
            teacherGateway = new TeacherGateway();
        }

        public string Assign(AssignCourseToTeacher aCourseToTeacher)
        {
            bool isCourseAssigned = assignCourseToTeacherGateway.IsCourseAssigned(aCourseToTeacher.CourseId);
            if (!isCourseAssigned)
            {
                int rowAffect = assignCourseToTeacherGateway.Assign(aCourseToTeacher);

                if (rowAffect > 0)
                {
                    return "Course successfully assigned";
                }
                return "Course assignment failed";

            }
            return "The selected course is already assigned";
        }

        public string UnassignCourse()
        {
            int rowAffect = assignCourseToTeacherGateway.UnassignCourse();
            if (rowAffect > 0)
            {
                rowAffect = teacherGateway.UpdateAllTeacherRemainingCredit();
                return "All Courses unassigned";
            }
            return "Course unassignment failed";
        }
    }
}