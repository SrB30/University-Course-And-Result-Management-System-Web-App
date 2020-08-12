using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class DesignationManager
    {
        private DesignationGateway designationGateway;

        public DesignationManager()
        {
            designationGateway = new DesignationGateway();
        }

        public List<Designation> GetAllDesignation()
        {
            return designationGateway.GetAllDesignation();
        }

        public List<SelectListItem> GetDesignationForDropdown()
        {
            List<Designation> designations = GetAllDesignation();
            List<SelectListItem> selectListItemlList = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "--Select--", Value = ""}
            };
            foreach (Designation designation in designations)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = designation.Name;
                selectListItem.Value = designation.Id.ToString();
                selectListItemlList.Add(selectListItem);
            }

            return selectListItemlList;
        }
    }
    
}