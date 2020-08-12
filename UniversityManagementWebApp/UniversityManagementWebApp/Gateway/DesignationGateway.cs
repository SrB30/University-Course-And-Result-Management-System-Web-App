using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementWebApp.Models;

namespace UniversityManagementWebApp.Gateway
{
    public class DesignationGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public DesignationGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["universityManagementConString"]
                .ConnectionString;
            connection = new SqlConnection(connectionString);
        }

       public List<Designation> GetAllDesignation()
        {
            string query = "SELECT * FROM Designation";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Designation> designationList = new List<Designation>();
            while (reader.Read())
            {
                Designation designation = new Designation();
                designation.Id = Convert.ToInt32(reader["Id"]);
                designation.Name = reader["Name"].ToString();

                designationList.Add(designation);
            }
            reader.Close();
            connection.Close();

            return designationList;
        }
    }
}