using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class GradeManager
    {
        private GradeGateway gradeGateway;

        public GradeManager()
        {
            gradeGateway = new GradeGateway();
        }

        public List<SelectListItem> GetAllGrades()
        {
            List<Grade> gradeList = gradeGateway.GetAllGrades();
            List<SelectListItem> gradeSelectList = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Select---",
                    Value = ""
                }
            };
            gradeSelectList.AddRange(gradeList.Select(course => new SelectListItem() { Text = course.Name, Value = course.Id.ToString() }));

            return gradeSelectList;
        }
    }
}