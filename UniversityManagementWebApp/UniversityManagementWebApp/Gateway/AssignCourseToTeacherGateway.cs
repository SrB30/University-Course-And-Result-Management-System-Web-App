using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class AssignCourseToTeacherGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public AssignCourseToTeacherGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Assign(AssignCourseToTeacher aCourseToTeacher)
        {
            string query =
                "INSERT INTO AssignedCourseToTeacher(CourseId, TeacherId) Values(@courseId, @teacherId)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courseId", aCourseToTeacher.CourseId);
            command.Parameters.AddWithValue("@teacherId", aCourseToTeacher.TeacherId);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsCourseAssigned(int courseId)
        {
            string query = "SELECT * FROM AssignedCourseToTeacher Where CourseId=@courseId AND Assigned=1";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@courseId", courseId);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            bool isAssigned = reader.HasRows;
            connection.Close();

            return isAssigned;
        
        }

        public int UnassignCourse()
        {
            string query =
                "UPDATE AssignedCourseToTeacher SET Assigned= 0";
            command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
    }
}