using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class DepartmentGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public DepartmentGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int Save(Department department)
        {
            string query = "INSERT INTO Department(Code,Name) Values(@code,@name)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@code", department.Code);
            command.Parameters.AddWithValue("@name", department.Name);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsCodeExist(string code)
        {
            string query = "SELECT * FROM Department Where Code=@code";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@code", code);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public bool IsNameExist(string name)
        {
            string query = "SELECT * FROM Department Where Name=@name";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public List<Department> GetAllDepartment()
        {
            string query = "SELECT * FROM Department";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Department> departmentList = new List<Department>();
            while (reader.Read())
            {
                Department aDepartment = new Department();
                aDepartment.Id = Convert.ToInt32(reader["Id"]);
                aDepartment.Code = reader["Code"].ToString();
                aDepartment.Name = reader["Name"].ToString();

                departmentList.Add(aDepartment);
            }
            reader.Close();
            connection.Close();

            return departmentList;
        }

        public string GetDepartmentCodeById(int departmentId)
        {
            string query = "SELECT Code FROM Department WHERE Id= @departmentId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            string departmentCode = reader["Code"].ToString();
            reader.Close();
            connection.Close();

            return departmentCode;
        }

        public string GetDepartmentNameById(int departmentId)
        {
            string query = "SELECT Name FROM Department WHERE Id= @departmentId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@departmentId", departmentId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            string departmentName = reader["Name"].ToString();
            reader.Close();
            connection.Close();

            return departmentName;
        }
    }
}