using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class StudentManager
    {
        private StudentGateway studentGateway;
        private DepartmentGateway departmentGateway;

        public StudentManager()
        {
            studentGateway = new StudentGateway();
            departmentGateway = new DepartmentGateway();
        }

        public string GenerateRegNo(Student student)
        {
            string studentRegNo;
            string departmentCode = departmentGateway.GetDepartmentCodeById(student.DepartmentId);
            string regNo = studentGateway.GetRegNoByDepartmentId(student.DepartmentId);

            string today = DateTime.Today.ToString("yyyy-MM-dd");
            //Debug.WriteLine(today);

            if (!student.RegDate.Equals(today))
            {
                return "";
            }


            string regNoSubStr = regNo.Substring(regNo.Length - 8, 4);
            string dateSubStr = student.RegDate.Substring(0, 4);

            if (regNo == "" || String.Compare(dateSubStr, regNoSubStr, StringComparison.OrdinalIgnoreCase) > 0)
            {
                studentRegNo = departmentCode + "-" + student.RegDate.Substring(0, 4) + "-" + "001";
                return studentRegNo;
            }


            string numSubStr = regNo.Substring(regNo.Length - 3, 3);
            int num = 0;
            for (int i = 0; i < numSubStr.Length; i++)
            {
                num += (num * 10) + (numSubStr[i] - 48);
            }
            numSubStr = (num + 1).ToString();
            numSubStr = numSubStr.PadLeft(3, '0');
            studentRegNo = departmentCode + "-" + student.RegDate.Substring(0, 4) + "-" + numSubStr;

            return studentRegNo;
        }
        public string Register(Student student)
        {
            int codeLen = student.ContactNo.Length;
            int nameLen = student.Name.Length;
            if (student.ContactNo[0] == ' ' || student.Name[0] == ' ')
            {
                return "Please Input without Leading Space";
            }
            else
            {
                if (student.ContactNo[codeLen - 1] == ' ' || student.Name[nameLen - 1] == ' ')
                {
                    return "Please Input without tralling Space";

                }

                else
                {
                    if (student.ContactNo.Contains(' '))
                    {
                        return "Please input the Contact No' without space";
                    }
                    else
                    {
                        if (!studentGateway.IsEmailExists(student.Email))
                        {
                            int rowAfect = studentGateway.Register(student);

                            if (rowAfect > 0)
                            {
                                return "Register successful";
                            }
                            return "Register failed";
                        }
                        return "This email already exists. Please enter a unique email";
                    }
                }
            }
        }

        public List<SelectListItem> GetAllRegNoForDropdown()
        {
            List<Student> studentList = studentGateway.GetAllRegNoForDropdown();
            List<SelectListItem> studentSelectList = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Select---",
                    Value = ""
                }
            };
            studentSelectList.AddRange(studentList.Select(student => new SelectListItem() { Text = student.RegNo, Value = student.Id.ToString() }));
            return studentSelectList;
        }

        public Student GetStudentDetailsById(int studentId)
        {
            Student student = studentGateway.GetStudentDetailsById(studentId);

            if (student != null)
            {
                student.DepartmentName = departmentGateway.GetDepartmentNameById(student.DepartmentId);
            }

            return student;
        }

        public List<StudentResult> GetResultsByStudentId(int studentId)
        {
            StudentResult ve = new StudentResult();
            return studentGateway.GetResultsByStudentId(studentId);
        }
    }
}