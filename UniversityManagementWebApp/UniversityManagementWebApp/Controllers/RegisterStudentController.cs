using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class RegisterStudentController : Controller
    {
        private DepartmentManager departmentManager;
        private StudentManager studentManager;

        public RegisterStudentController()
        {
            departmentManager = new DepartmentManager();
            studentManager = new StudentManager();
        }
        [HttpGet]
        public ActionResult Register()
        {
            Student student = null;
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            return View(student);
        }

        [HttpPost]
        public ActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                student.RegNo = studentManager.GenerateRegNo(student);
                if (student.RegNo == "")
                {
                    ViewBag.Message = "Your entered date doesn't match today's date. You can only register today";
                }
                else
                {
                    ViewBag.Message = studentManager.Register(student);
                    ViewBag.Student = student;
                }
            }
            else
            {
                ViewBag.Message = "Please enter valid information";
            }
            
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            return View(student);
        }
	}
}