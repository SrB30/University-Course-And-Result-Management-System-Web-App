using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class AllocateClassRoomController : Controller
    {
        //
        // GET: /AllocateClassRoom/
        private AllocateClassRoomManager allocateClassRoomManager;
        private DepartmentManager departmentManager;
        private CourseManager courseManager;

        public AllocateClassRoomController()
        {
            allocateClassRoomManager = new AllocateClassRoomManager();
            departmentManager = new DepartmentManager();
            courseManager = new CourseManager();
        }

        [HttpGet]
        public ActionResult ClassRoom()
        
        {
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            ViewBag.Rooms = allocateClassRoomManager.GetAllRoomForDropdown();
            ViewBag.Days = allocateClassRoomManager.GetAllDayForDropdown();
            ViewBag.Courses = new List<SelectListItem>(){
                new SelectListItem {Text = "---Select---", Value = ""}
            };
            return View();
        }

        [HttpPost]
        public ActionResult ClassRoom(AllocateClassRoom classRoom)
        {
            bool flag = false;
            if (ModelState.IsValid)
            {
                flag = true;
                string message = allocateClassRoomManager.Save(classRoom);
                ViewBag.Message = message;
                if (message == "Save Successful")
                {
                    flag = false;
                    ModelState.Clear();
                }
            }
            else
            {
                ViewBag.Message = "ModelState is Invalid";
            }
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            ViewBag.Rooms = allocateClassRoomManager.GetAllRoomForDropdown();
            ViewBag.Days = allocateClassRoomManager.GetAllDayForDropdown();
            if (flag) ViewBag.Courses = courseManager.GetCoursesByDepartmentId(classRoom.DepartmentId);
            else{
                ViewBag.Courses = new List<SelectListItem>(){
                    new SelectListItem {Text = "---Select---", Value = ""}
                };
            }

            return View();
        }

        public JsonResult GetAllCourseByDepartmentId(int deptId)
        {
            List<SelectListItem> courses = courseManager.GetCoursesByDepartmentId(deptId);
            return Json(courses);
        }
	}
}