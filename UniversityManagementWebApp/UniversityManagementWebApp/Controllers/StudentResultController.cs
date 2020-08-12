using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class StudentResultController : Controller
    {
        //
        // GET: /StudentResult/
        private StudentManager studentManager;

        public StudentResultController()
        {
            studentManager = new StudentManager();
        }
        [HttpGet]
        public ActionResult Result()
        {
            ViewBag.RegestrationNo = studentManager.GetAllRegNoForDropdown();
            return View();
        }

        public JsonResult GetStudentDetailsById(int studentId)
        {
            List<Student> students = new List<Student>();
            Student studentDetails = studentManager.GetStudentDetailsById(studentId);

            students.Add(studentDetails);

            return Json(students);
        }

        public JsonResult GetStudentResultById(int studentId)
        {
            List<StudentResult> studentResultList = studentManager.GetResultsByStudentId(studentId);

            return Json(studentResultList);
        }
	}
}