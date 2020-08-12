using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway;

        public TeacherManager()
        {
            teacherGateway = new TeacherGateway();
        }

        public string Save(Teacher teacher)
        {
            int codeLen = teacher.ContactNo.Length;
            int nameLen = teacher.Name.Length;
            if (teacher.ContactNo[0] == ' ' || teacher.Name[0] == ' ')
            {
                return "Please Input without Leading Space";
            }
            else
            {
                if (teacher.ContactNo[codeLen - 1] == ' ' || teacher.Name[nameLen - 1] == ' ')
                {
                    return "Please Input without tralling Space";

                }

                else
                {
                    if (teacher.ContactNo.Contains(' '))
                    {
                        return "Please input the Contact No. without space";
                    }

                    else
                    {
                        if (teacherGateway.IsEmailExist(teacher.Email))
                        {
                            return "Email is already exists";
                        }
                        else
                        {
                            if (teacherGateway.Save(teacher) > 0)
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

        public List<SelectListItem> GetTeachersByDepartmentId(int departmentId)
        {
            List<Teacher> teachersList = teacherGateway.GetTeachersByDepartmentId(departmentId);
            List<SelectListItem> teacherSelectListItems = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Select---",
                    Value = ""
                }
            };
            teacherSelectListItems.AddRange(teachersList.Select(teacher => new SelectListItem() { Text = teacher.Name, Value = teacher.Id.ToString() }));

            return teacherSelectListItems;
        }

        public Teacher GetTeacherDetailsByTeacherId(int teacherId)
        {
            return teacherGateway.GetTeacherDetailsByTeacherId(teacherId);
        }

        public string UpdateTeacherRemainingCredit(int teacherId, decimal remainingCredit)
        {
            int rowAffect = teacherGateway.UpdateTeacherRemainingCredit(teacherId, remainingCredit);
            if (rowAffect > 0)
            {
                return "Update successful";
            }
            return "Update failed";
        }
    }
}