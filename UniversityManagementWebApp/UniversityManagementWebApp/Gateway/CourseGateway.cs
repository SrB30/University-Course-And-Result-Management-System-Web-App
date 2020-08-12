using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{

    public class CourseGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public CourseGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(Course course)
        {
            string query =
                "INSERT INTO Course(Code,Name,Credit,Description,DepartmentId,SemesterId) Values(@code,@name,@credit,@description,@departmentId,@semesterId)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@code", course.Code);
            command.Parameters.AddWithValue("@name", course.Name);
            command.Parameters.AddWithValue("@credit", course.Credit);
            command.Parameters.AddWithValue("@description", course.Description);
            command.Parameters.AddWithValue("@departmentId", course.DepartmentId);
            command.Parameters.AddWithValue("@semesterId", course.SemesterId);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsCodeExist(string code, int departmentId)
        {
            string query = "SELECT * FROM Course Where Code=@code And DepartmentId=@departmentId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@code", code);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public bool IsNameExist(string name, int departmentId)
        {
            string query = "select * from course where name=@name And DepartmentId=@departmentId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@departmentId", departmentId);
            connection.Open();
            reader = command.ExecuteReader();
            bool isexist = reader.HasRows;
            connection.Close();

            return isexist;
        }

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            string query = "SELECT Id, Code, Name FROM Course Where DepartmentId = @departmentId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);

            connection.Open();
            reader = command.ExecuteReader();

            List<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course
                {
                    Id = (int) reader["Id"],
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString()
                };
                courses.Add(course);
            }
            connection.Close();

            return courses;

        }

        public Course GetCourseDetailsByCourseId(int courseId)
        {
            string query = "SELECT Name, Credit FROM Course Where Id = @courseId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courseId", courseId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            Course course = new Course();
            course.Name = (string) reader["Name"];
            course.Credit = (decimal) reader["Credit"];

            connection.Close();

            return course;
        }


    }
}