using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class EnrollCourseToStudeentController : Controller
    {
        private EnrollCourseToStudentManager enrollCourseToStudentManager;
        private DepartmentManager departmentManager;
        private StudentManager studentManager;
        private CourseManager courseManager;

        public EnrollCourseToStudeentController()
        {
            departmentManager = new DepartmentManager();
            studentManager = new StudentManager();
            enrollCourseToStudentManager = new EnrollCourseToStudentManager();
            courseManager = new CourseManager();
        }

        public ActionResult EnrollInACourse()
        {
            ViewBag.Students = studentManager.GetAllRegNoForDropdown();

            ViewBag.Courses = new List<SelectListItem>{
                new SelectListItem() {Text = "---Select---", Value = ""}
            };
            return View();
        }

        [HttpPost]
        public ActionResult EnrollInACourse(EnrollCourseToStudent aCourseToStudent)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                flag = true;
                string message = enrollCourseToStudentManager.Enroll(aCourseToStudent);
                ViewBag.Message = message;

                if (message == "Course succesfuly enrolled")
                {
                    flag = false;
                    ModelState.Clear();
                }
            }
            else ViewBag.Message = "Please enter valid information";
            

            if (flag) ViewBag.Courses = courseManager.GetAllCourseByStudentsDepartmentId(aCourseToStudent.StudentId);  
            else{
                ViewBag.Courses = new List<SelectListItem> {
                    new SelectListItem() {Text = "---Select---", Value = ""}
                };
            }

            ViewBag.Students = studentManager.GetAllRegNoForDropdown();
            
            return View();
        }

        public JsonResult GetStudentDetailsById(int studentId)
        {
            List<Student> students = new List<Student>();
            Student studentDetails = studentManager.GetStudentDetailsById(studentId);

            students.Add(studentDetails);

            return Json(students);
        }

        public JsonResult GetAllCourseByStudentsDepartmentId(int studentId)
        {
            List<SelectListItem> courses = courseManager.GetAllCourseByStudentsDepartmentId(studentId);

            return Json(courses);
        }
	}
}