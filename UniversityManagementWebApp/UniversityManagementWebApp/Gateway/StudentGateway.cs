using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class StudentGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public StudentGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public bool IsEmailExists(string email)
        {
            string query = "SELECT * FROM Student Where Email=@email";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", email);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public int Register(Student student)
        {
            string query =
                "INSERT INTO Student(Name,Email,ContactNo, RegDate, Address,DepartmentId,RegNo) Values(@name,@email,@contactNo,@regDate, @address, @departmentId,@regNo)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@email", student.Email);
            command.Parameters.AddWithValue("@contactNo", student.ContactNo);
            command.Parameters.AddWithValue("@regDate", student.RegDate);
            command.Parameters.AddWithValue("@address", student.Address);
            command.Parameters.AddWithValue("@departmentId", student.DepartmentId);
            command.Parameters.AddWithValue("@regNo", student.RegNo);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }


        public string GetRegNoByDepartmentId(int departmentId)
        {
            string query = "SELECT RegNo FROM Student WHERE DepartmentId= @departmentId ORDER BY RegNo DESC";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            string regNo = reader["RegNo"].ToString();
            reader.Close();
            connection.Close();

            return regNo;
        }

        public List<Student> GetAllRegNoForDropdown()
        {
            string query = "SELECT Id, RegNo FROM Student ORDER BY RegNo ASC";
            command = new SqlCommand(query, connection);

            connection.Open();
            reader = command.ExecuteReader();
            

            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(reader["Id"]);
                student.RegNo = reader["RegNo"].ToString();
                students.Add(student);
            }
            
            reader.Close();
            connection.Close();

            return students;
        }

        public Student GetStudentDetailsById(int studentId)
        {
            string query = "SELECT Name, Email, DepartmentId FROM Student WHERE Id= @studentId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();

            Student student = new Student
            {
                Name = reader["Name"].ToString(),
                Email = reader["Email"].ToString(),
                DepartmentId = (int) reader["DepartmentId"]
            };

            reader.Close();
            connection.Close();

            return student;
        }

        public int GetDepartmentIdByStudentId(int studentId)
        {
            string query = "SELECT DepartmentId FROM Student Where Id = @studentId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();


            int departmentId = (int) reader["DepartmentId"];
            

            reader.Close();
            connection.Close();

            return departmentId;
        }

        public List<StudentResult> GetResultsByStudentId(int studentId)
        {
            string query =
                "SELECT * FROM StudentCourseDetailsView WHERE StudentId=@studentId AND Assigned=1";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            connection.Open();
            reader = command.ExecuteReader();
            List<StudentResult> viewResultList = new List<StudentResult>();
            while (reader.Read())
            {
                StudentResult viewResult = new StudentResult();
                viewResult.CourseCode = reader["Code"].ToString();
                viewResult.Name = reader["CourseName"].ToString();
                string grade = reader["Grade"].ToString();
                if (grade == "")
                {
                    viewResult.Grade = "Not Graded Yet";
                }
                else
                {
                    viewResult.Grade = reader["Grade"].ToString();
                }

                viewResultList.Add(viewResult);
            }
            reader.Close();
            connection.Close();

            return viewResultList;
        }
    }
}