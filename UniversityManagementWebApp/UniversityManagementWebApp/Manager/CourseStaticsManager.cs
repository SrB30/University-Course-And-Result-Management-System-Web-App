using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class CourseStaticsManager
    {
        private CourseStaticsGateway courseStaticsGateway;

        public CourseStaticsManager()
        {
            courseStaticsGateway = new CourseStaticsGateway();
        }

        public List<CourseStatics> GetCourseStaticsesById(int departmentId)
        {
            return courseStaticsGateway.GetCourseStaticsesById(departmentId);
        }
    }
}