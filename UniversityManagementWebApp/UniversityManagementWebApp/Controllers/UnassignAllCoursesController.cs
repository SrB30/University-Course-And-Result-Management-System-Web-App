using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class UnassignAllCoursesController : Controller
    {
        private AssignCourseToTeacherManager assignCourseToTeacherManager;
        private EnrollCourseToStudentManager enrollCourseToStudentManager;

        public UnassignAllCoursesController()
        {
            assignCourseToTeacherManager = new AssignCourseToTeacherManager();
            enrollCourseToStudentManager = new EnrollCourseToStudentManager();
        }

        [HttpGet]
        public ActionResult UnassignCourses()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnassignCourses(Course course)
        {
            string message = assignCourseToTeacherManager.UnassignCourse();
            if (message == "All Courses unassigned")
            {
                ViewBag.Message = enrollCourseToStudentManager.UnassignCourse();
            }
            else
            {
                ViewBag.Message = "Unassigned Failed";
            }
            return View();
        }
    }
}