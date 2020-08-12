using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class SaveStudentsResultController : Controller
    {
        private StudentManager studentManager;
        private EnrollCourseToStudentManager enrollCourseToStudentManager;
        private GradeManager gradeManager;
        private SaveStudentResultManager saveStudentResultManager;

        public SaveStudentsResultController()
        {
            studentManager = new StudentManager();
            enrollCourseToStudentManager = new EnrollCourseToStudentManager();
            gradeManager = new GradeManager();
            saveStudentResultManager = new SaveStudentResultManager();
        }

        public ActionResult SaveStudentResult()
        {
            ViewBag.Students = studentManager.GetAllRegNoForDropdown();
            ViewBag.Grades = gradeManager.GetAllGrades();
            return View();
        }

        [HttpPost]
        public ActionResult SaveStudentResult(EnrollCourseToStudent courseResult)
        {
            ViewBag.Message = ModelState.IsValid ? saveStudentResultManager.Save(courseResult) : "Please enter valid information";
            
            ViewBag.Students = studentManager.GetAllRegNoForDropdown();
            ViewBag.Grades = gradeManager.GetAllGrades();
            ModelState.Clear();

            return View();
        }

        public JsonResult GetEnrolledCoursesByStudentId(int studentId)
        {
            List<SelectListItem> courses = enrollCourseToStudentManager.GetEnrolledCoursesByStudentId(studentId);

            return Json(courses);
        }
	}
}