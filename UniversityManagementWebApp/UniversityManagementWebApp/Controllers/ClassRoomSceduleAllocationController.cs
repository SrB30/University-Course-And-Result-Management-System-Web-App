using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class ClassRoomSceduleAllocationController : Controller
    {
        //
        // GET: /ClassRoomSceduleAllocation/
        private DepartmentManager departmentManager;
        private AllocateClassRoomManager allocateClassRoomManager;

        public ClassRoomSceduleAllocationController()
        {
            departmentManager = new DepartmentManager();
            allocateClassRoomManager = new AllocateClassRoomManager();
        }

        [HttpGet]
        public ActionResult ClassRoomScedule()
        {
            ViewBag.Departments = departmentManager.GetDepartmentForDropdown();
            return View();
        }
        public JsonResult GetClassRoomSceduleByDepartmentId(int deptId)
        {
            List<ClassRoomScedule> classRoomScedules = allocateClassRoomManager.GetClassRoomSceduleByDepartmentId(deptId);
            return Json(classRoomScedules);
        }
	}
}