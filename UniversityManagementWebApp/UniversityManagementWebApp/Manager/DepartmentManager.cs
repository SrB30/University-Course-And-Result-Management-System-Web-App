using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class DepartmentManager
    {
        private DepartmentGateway departmentGateway;

        public DepartmentManager()
        {
            departmentGateway = new DepartmentGateway();
        }

        public string Save(Department department)
        {
            int codeLen = department.Code.Length;
            int nameLen = department.Name.Length;

            int valid = 0;

            for (int i = 0; i < codeLen; i++)
            {
                if ((department.Code[i] >= 65 && department.Code[i] <= 90) || (department.Code[i] >= 97 && department.Code[i] <= 122))
                {
                    valid = 1;
                    break;
                }
                else
                {
                    valid = 0;
                    break;
                }
            }

            int count = 0;

            for (int i = 0; i < codeLen; i++)
            {
                if (department.Code[i] == ' ')
                {
                    count++;
                }
            }

            int count2 = 0;
            for (int i = 0; i < nameLen; i++)
            {
                if (department.Name[i] == ' ')
                {
                    count2++;
                }
            }

            if (count == codeLen || count2 == nameLen)
            {
                return "Null Value Not Excepted";
            }
            else
            {
                if (valid == 0)
                {
                    return "Please Input Valid Character In Code";
                }

                else
                {
                    if (department.Code[0] == ' ' || department.Name[0] == ' ')
                    {
                        return "Please Input without Leading Space";
                    }
                    else
                    {
                        if (department.Code[codeLen - 1] == ' ' || department.Name[nameLen - 1] == ' ')
                        {
                            return "Please Input without tralling Space";

                        }

                        else
                        {
                            if (department.Code.Contains(' '))
                            {
                                return "Please input the Code without space";
                            }

                            else
                            {
                                int len = department.Code.Length;
                                if (len < 2 || len > 7)
                                {
                                    return "Department code must be whithin two to seven characters!";
                                }

                                else
                                {
                                    if (departmentGateway.IsCodeExist(department.Code))
                                    {
                                        return "This Department Code is Already Exist!";
                                    }

                                    else
                                    {
                                        if (departmentGateway.IsNameExist(department.Name))
                                        {
                                            return "This Department Name is Already Exist!";
                                        }

                                        else
                                        {
                                            if (departmentGateway.Save(department) > 0)
                                            {
                                                return "Save Successful";
                                            }
                                            else
                                            {
                                                return "Save Failed!";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

           
            

        }

        public List<Department> GetAllDepartment()
        {
            return departmentGateway.GetAllDepartment();
        }

        public List<SelectListItem> GetDepartmentForDropdown()
        {
            List<Department> departments = GetAllDepartment();
            List<SelectListItem> selectListItemList = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "--Select--",Value = null, Selected = true
                }
            };

            foreach (Department department in departments)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Text = department.Name;
                selectListItem.Value = department.Id.ToString();
                selectListItemList.Add(selectListItem);
            }

            return selectListItemList;
        }

        public string GetDepartmentCodeById(int departmentId)
        {
            return departmentGateway.GetDepartmentCodeById(departmentId);
        }
    }
}