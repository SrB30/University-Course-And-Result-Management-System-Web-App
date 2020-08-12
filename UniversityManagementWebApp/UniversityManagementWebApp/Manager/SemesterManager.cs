using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class SemesterManager
    {
        private SemesterGateway semesterGateway;

        public SemesterManager()
        {
            semesterGateway = new SemesterGateway();
        }
        public List<Semester> GetallSemester()
        {
            return semesterGateway.GetallSemester();
        }

        public List<SelectListItem> GetSemesterForDropdown()
        {
            List<Semester> semesters = GetallSemester();
            List<SelectListItem> selectListItems = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "--Select--", Value = ""}
            };
            foreach (Semester semester in semesters)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = semester.Name;
                selectListItem.Value = semester.Id.ToString();
                selectListItems.Add(selectListItem);
            }

            return selectListItems;
        }
    }
}