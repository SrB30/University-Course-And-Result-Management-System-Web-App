using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Manager;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Controllers
{
    public class UnallocateAllRoomsController : Controller
    {
        private AllocateClassRoomManager allocateClassRoomManager;

        public UnallocateAllRoomsController()
        {
            allocateClassRoomManager = new AllocateClassRoomManager();
        }
        public ActionResult UnallocateRooms()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnallocateRooms(Room room)
        {
            string message = allocateClassRoomManager.UnallocateRooms();
            ViewBag.Message = message;

            return View();
        }


	}
}