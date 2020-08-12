using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class SemesterGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SemesterGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public List<Semester> GetallSemester()
        {
            string query = "SELECT * FROM Semester";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Semester> semesterList = new List<Semester>();
            while (reader.Read())
            {
                Semester aSemester = new Semester();
                aSemester.Id = Convert.ToInt32(reader["Id"]);
                aSemester.Name = reader["Name"].ToString();

                semesterList.Add(aSemester);
            }
            reader.Close();
            connection.Close();

            return semesterList;
        }
    }
}