using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class EnrollCourseToStudentGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public EnrollCourseToStudentGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Enroll(EnrollCourseToStudent acCourseToStudent)
        {
            string query =
                "INSERT INTO EnrolledCourseToStudent(StudentId, CourseId, EnrolledDate) Values(@studentId, @courseId, @enrollDate)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", acCourseToStudent.StudentId);
            command.Parameters.AddWithValue("@courseId", acCourseToStudent.CourseId);
            command.Parameters.AddWithValue("@enrollDate", acCourseToStudent.EnrollDate);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsCourseEnrolled(int studentId, int courseId)
        {
            string query = "SELECT * FROM EnrolledCourseToStudent Where (StudentId=@studentId AND CourseId=@courseId) AND Assigned=1";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            command.Parameters.AddWithValue("@courseId", courseId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            bool isEnrolled = reader.HasRows;
            connection.Close();

            return isEnrolled;

        }

        public int UnassignCourse()
        {
            string query =
                "UPDATE EnrolledCourseToStudent SET Assigned= 0";
            command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public List<StudentCourseDetailsView> GetEnrolledCoursesByStudentId(int studentId)
        {
            string query = "SELECT CourseId, CourseName FROM StudentCourseDetailsView Where CourseId IS NOT NULL AND (StudentId = @studentId AND Assigned=1)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);

            connection.Open();
            reader = command.ExecuteReader();

            List<StudentCourseDetailsView> courses = new List<StudentCourseDetailsView>();
            while (reader.Read())
            {
                StudentCourseDetailsView course = new StudentCourseDetailsView
                {
                    CourseId = (int)reader["CourseId"],
                    CourseName = reader["CourseName"].ToString()
                };
                courses.Add(course);
            }
            connection.Close();

            return courses;
        }
    }
}