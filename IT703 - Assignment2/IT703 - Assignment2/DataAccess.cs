using System;
using System.Data;
using System.Data.SqlClient;
using IT703___Assignment2.Models;
using Microsoft.Extensions.Configuration;

namespace IT703___Assignment2
{
    public class DataAccess
    {
        public readonly string _connectionString;

        // Constructor to inject IConfiguration
        public DataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ServerConnection");
        }

        public void AddCustomer(string firstName, string lastName, string email, string phoneNumber, string address, int? companyId, int? travelAgencyId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_AddCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@CustFirstName", firstName);
                    cmd.Parameters.AddWithValue("@CustLastName", lastName);
                    cmd.Parameters.AddWithValue("@CustEmail", email);
                    cmd.Parameters.AddWithValue("@CustPhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@CustAddress", address);
                    cmd.Parameters.AddWithValue("@CompanyID", (object)companyId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TravelAgencyID", travelAgencyId);

                    // Open connection and execute the command
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Customermodel> GetAllCustomers()
        {
            List<Customermodel> customers = new List<Customermodel> ();
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT CustomerID, CustFirstName, CustLastName, CustEmail, CustPhoneNumber, CustAddress FROM CUSTOMER";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customermodel
                    {
                        CustmerID = (int)reader["CustomerID"],
                        FirstName = reader["CustFirstName"].ToString(),
                        LastName = reader["CustLastName"].ToString(),
                        Email = reader["CustEmail"].ToString(),
                        PhoneNumber = reader["CustPhoneNumber"].ToString(),
                        Address = reader["CustAddress"].ToString()
                    });

                }

            }

            return customers;
        }
    }

}
