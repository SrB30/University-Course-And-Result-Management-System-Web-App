using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class TeacherGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public TeacherGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(Teacher teacher)
        {
            string query =
                "INSERT INTO Teacher(Name,Address,Email,ContactNo,DesignationId,DepartmentId,CreditToBeTaken, RemainingCredit) Values(@name,@address,@email,@contactNo,@designationId,@departmentId,@creditToBeTaken, @remainingCredit)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", teacher.Name);
            command.Parameters.AddWithValue("@address", teacher.Address);
            command.Parameters.AddWithValue("@email", teacher.Email);
            command.Parameters.AddWithValue("@contactNo", teacher.ContactNo);
            command.Parameters.AddWithValue("@designationId", teacher.DesignationId);
            command.Parameters.AddWithValue("@departmentId", teacher.DepartmentId);
            command.Parameters.AddWithValue("@creditToBeTaken", teacher.CreditToBeTaken);
            command.Parameters.AddWithValue("@remainingCredit", teacher.CreditToBeTaken);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
        public bool IsEmailExist(string email)
        {
            string query = "SELECT * FROM Teacher Where Email=@email";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@email", email);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public List<Teacher> GetTeachersByDepartmentId(int departmentId)
        {
            string query = "SELECT Id, Name FROM Teacher Where DepartmentId = @departmentId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);

            connection.Open();
            reader = command.ExecuteReader();

            List<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = (int)reader["Id"];
                teacher.Name = reader["Name"].ToString();
                teachers.Add(teacher);
            }
            connection.Close();

            return teachers;
        }

        public Teacher GetTeacherDetailsByTeacherId(int teacherId)
        {
            string query = "SELECT CreditToBeTaken, RemainingCredit FROM Teacher Where Id = @teacherId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@teacherId", teacherId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            Teacher teacher = new Teacher();
            teacher.CreditToBeTaken = (decimal) reader["CreditToBeTaken"];
            teacher.RemainingCredit = (decimal) reader["RemainingCredit"];

            connection.Close();

            return teacher;
        }

        public int UpdateTeacherRemainingCredit(int teacherId, decimal remainingCredit)
        {
            string query =
                "UPDATE Teacher SET RemainingCredit= @remainingCredit WHERE Id= @teacherId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@remainingCredit", remainingCredit);
            command.Parameters.AddWithValue("@teacherId", teacherId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        
        public int UpdateAllTeacherRemainingCredit()
        {
            string query =
                "UPDATE Teacher SET RemainingCredit= CreditToBeTaken";
            command = new SqlCommand(query, connection);
            
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }
    }
}