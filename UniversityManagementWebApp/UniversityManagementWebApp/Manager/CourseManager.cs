using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementWebApp.Gateway;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Manager
{
    public class CourseManager
    {
        private CourseGateway courseGateway;
        private StudentGateway studentGateway;

        public CourseManager()
        {
            courseGateway = new CourseGateway();
            studentGateway = new StudentGateway();
        }
        public string Save(Course course)
        {
            int codeLen = course.Code.Length;
            int nameLen = course.Name.Length;
            if (course.Code[0] == ' ' || course.Name[0] == ' ')
            {
                return "Please Input without Leading Space";
            }
            else
            {
                if (course.Code[codeLen - 1] == ' ' || course.Name[nameLen - 1] == ' ')
                {
                    return "Please Input without tralling Space";

                }

                else
                {
                    if (course.Code.Contains(' '))
                    {
                        return "Please input the Code without space";
                    }
                    else
                    {
                        int len = course.Code.Length;
                        if (len < 5)
                        {
                            return "Course code must be five character long";
                        }

                        else
                        {
                            if (courseGateway.IsCodeExist(course.Code, course.DepartmentId))
                            {
                                return "This course Code is Already Exist!";
                            }

                            else
                            {
                                if (courseGateway.IsNameExist(course.Name, course.DepartmentId))
                                {
                                    return "This course Name is Already Exist!";
                                }

                                else
                                {
                                    if (courseGateway.Save(course) > 0)
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

        public List<SelectListItem> GetCoursesByDepartmentId(int departmentId)
        {
            List<Course> courseList = courseGateway.GetCoursesByDepartmentId(departmentId);
            List<SelectListItem> courseSelectList = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Select---",
                    Value = ""
                }
            };
            courseSelectList.AddRange(courseList.Select(course => new SelectListItem() { Text = course.Code, Value = course.Id.ToString() }));

            return courseSelectList;
        }

        public List<SelectListItem> GetAllCourseByStudentsDepartmentId(int studentId)
        {
            int departmentId = studentGateway.GetDepartmentIdByStudentId(studentId);
            List<Course> courseList = courseGateway.GetCoursesByDepartmentId(departmentId);
            List<SelectListItem> courseSelectList = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "---Select---",
                    Value = ""
                }
            };
            courseSelectList.AddRange(courseList.Select(course => new SelectListItem() { Text = course.Name, Value = course.Id.ToString() }));

            return courseSelectList;
        }

        public Course GetCourseDetailsByCourseId(int courseId)
        {
            return courseGateway.GetCourseDetailsByCourseId(courseId);
        }
    }
}