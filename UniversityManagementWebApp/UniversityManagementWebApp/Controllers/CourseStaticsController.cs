using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class CourseStaticsController : Controller
    {
        //
        // GET: /CourseStatics/
        private DepartmentManager departmentManager;
        private CourseStaticsManager courseStaticsManager;

        public CourseStaticsController()
        {
            departmentManager = new DepartmentManager();
            courseStaticsManager = new CourseStaticsManager();
        }

        [HttpGet]
        public ActionResult Statics()
        {
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            return View();
        }
        public JsonResult GetCourseStaticById(int deptId)
        {
            List<CourseStatics> courseStaticses = courseStaticsManager.GetCourseStaticsesById(deptId);
            return Json(courseStaticses);
        }
    }
}