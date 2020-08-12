using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class GradeGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public GradeGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public List<Grade> GetAllGrades()
        {
            string query = "SELECT Id, Name FROM Grade";
            command = new SqlCommand(query, connection);

            connection.Open();
            reader = command.ExecuteReader();

            List<Grade> grades = new List<Grade>();
            while (reader.Read())
            {
                Grade grade = new Grade
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };
                grades.Add(grade);
            }
            connection.Close();

            return grades;
        }
    }
}