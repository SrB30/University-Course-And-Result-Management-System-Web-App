using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class CourseStaticsGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public CourseStaticsGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public List<CourseStatics> GetCourseStaticsesById(int departmentId)
        {
            string query = "SELECT * FROM CourseStatisticsView where DepartmentId=@departmentId";
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();
            List<CourseStatics> courseStaticsList = new List<CourseStatics>();
            while (reader.Read())
            {
                CourseStatics courseStatics = new CourseStatics();
                courseStatics.Code = reader["Code"].ToString();
                courseStatics.Name = reader["Name"].ToString();
                courseStatics.Semester = reader["Semester"].ToString();
                string assignTo = reader["AssignedTo"].ToString();
                string msg = "Not Assigned Yet";
                string check = reader["Assigned"].ToString();

                if (check=="1")
                {
                    if (assignTo != "")
                    {
                        courseStatics.AssignTo = reader["AssignedTo"].ToString();
                    }
                    else
                    {
                        courseStatics.AssignTo = msg;
                    }
                }
                else
                {
                    courseStatics.AssignTo = msg;
                }

                courseStaticsList.Add(courseStatics);
            }
            reader.Close();
            connection.Close();

            return courseStaticsList;
        }
    }
}