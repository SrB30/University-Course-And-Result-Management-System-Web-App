using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/

        private CourseManager courseManager;
        private SemesterManager semesterManager;
        private DepartmentManager departmentManager;

        public CourseController()
        {
            courseManager = new CourseManager();
            semesterManager = new SemesterManager();
            departmentManager = new DepartmentManager();
        }

        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            ViewBag.Semesters = semesterManager.GetSemesterForDropdown();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {
            if (ModelState.IsValid)
            {
                string message = courseManager.Save(course);
                ViewBag.Message = message;
                if (message == "Save Successful")
                {
                    ModelState.Clear();
                }
            }

            else
            {
                ViewBag.Message = "ModelState Is not valid";
            }

            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            ViewBag.Semesters = semesterManager.GetSemesterForDropdown();
            
            return View();
        }
	}
}