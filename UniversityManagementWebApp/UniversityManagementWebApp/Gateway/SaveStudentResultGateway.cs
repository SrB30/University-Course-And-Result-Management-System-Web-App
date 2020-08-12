using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class SaveStudentResultGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        //private SqlDataReader reader;

        public SaveStudentResultGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(EnrollCourseToStudent aCourseToStudent)
        {
            string query =
                "UPDATE EnrolledCourseToStudent SET GradeId=@gradeId WHERE StudentId=@studentId AND CourseId=@courseId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@gradeId", aCourseToStudent.GradeId);
            command.Parameters.AddWithValue("@studentId", aCourseToStudent.StudentId);
            command.Parameters.AddWithValue("@courseId", aCourseToStudent.CourseId);
            

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
    }
}