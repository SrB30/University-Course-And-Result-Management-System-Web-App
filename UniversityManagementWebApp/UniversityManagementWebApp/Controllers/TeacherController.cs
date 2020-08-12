using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        private DesignationManager designationManager;
        private TeacherManager teacherManager;
        private DepartmentManager departmentManager;

        public TeacherController()
        {
            departmentManager = new DepartmentManager();
            teacherManager = new TeacherManager();
            designationManager = new DesignationManager();
        }
        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.Designations = designationManager.GetDesignationForDropdown();
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            return View();
        }

        [HttpPost]

        public ActionResult Save(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                string message = teacherManager.Save(teacher);
                ViewBag.Message = message;
                if (message == "Save Successful")
                {
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Message = "ModelState is invalid";
            }

            ViewBag.Designations = designationManager.GetDesignationForDropdown();
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            
            return View();
        }
	}
}