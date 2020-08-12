using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class AssignCourseToTeacherController : Controller
    {
        private AssignCourseToTeacherManager assignCourseToTeacherManager;
        private DepartmentManager departmentManager;
        private TeacherManager teacherManager;
        private CourseManager courseManager;

        public AssignCourseToTeacherController()
        {
            assignCourseToTeacherManager = new AssignCourseToTeacherManager();
            departmentManager = new DepartmentManager();
            teacherManager = new TeacherManager();
            courseManager = new CourseManager();
        }
        
        [HttpGet]
        public ActionResult Assign()
        {
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            ViewBag.teacher = new List<SelectListItem>(){
                new SelectListItem(){
                    Text = "--Select--",Value = "", Selected = true
                }
            };
            return View();
        }

        [HttpPost]
        public ActionResult Assign(AssignCourseToTeacher aCourseToTeacher)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = assignCourseToTeacherManager.Assign(aCourseToTeacher);
                if (ViewBag.Message == "The selected course is already assigned") ModelState.Clear();
                else if (ViewBag.Message != null)
                {
                    string message =
                    teacherManager.UpdateTeacherRemainingCredit(aCourseToTeacher.TeacherId, aCourseToTeacher.RemainingCredit -
                                                                aCourseToTeacher.CourseCredit);
                    if (message == "Update successful")
                    {
                        ModelState.Clear();
                    }
                }
            }
            else
            {
                ViewBag.Message = "Please enter valid information";
            }
            
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            ViewBag.teacher = new List<SelectListItem>(){
                new SelectListItem(){
                    Text = "--Select--",Value = "", Selected = true
                }
            };
            
            return View();
        }

        public JsonResult GetTeachersByDepartmentId(int departmentId)
        {
            List<SelectListItem> teachers = teacherManager.GetTeachersByDepartmentId(departmentId);

            return Json(teachers);
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            List<SelectListItem> courses = courseManager.GetCoursesByDepartmentId(departmentId);

            return Json(courses);
        }

        public JsonResult GetTeacherDetailsByTeacherId(int teacherId)
        {
            Teacher teacher =  teacherManager.GetTeacherDetailsByTeacherId(teacherId);
            List<Teacher> teachers = new List<Teacher>();
            teachers.Add(teacher);
            return Json(teachers);
        }

        public JsonResult GetCourseDetailsByCourseId(int courseId)
        {
            Course course = courseManager.GetCourseDetailsByCourseId(courseId);
            List<Course> courses = new List<Course>();
            courses.Add(course);
            return Json(courses);
        }
	}
}