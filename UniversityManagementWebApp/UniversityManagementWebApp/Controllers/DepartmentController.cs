using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentManager departmentManager;

        public DepartmentController()
        {
            departmentManager = new DepartmentManager();
        }
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (ModelState.IsValid)
            {
                string message = departmentManager.Save(department);
                ViewBag.Message = message;
                if (message == "Save Successful")
                {
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Message = "ModelState is ot valid";
            }
            
            return View();
        }

        public ActionResult ShowDepartment()
        {
            List<Department> departmentList = departmentManager.GetAllDepartment();
            return View(departmentList);
        }
	}
}