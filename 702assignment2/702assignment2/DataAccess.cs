using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace _702assignment2
{
    public class DataAccess
    {
        private readonly string _connectionString;

        // Constructor to inject IConfiguration
        public DataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ServerConnection");
        }

        public void AddCustomer(string firstName, string lastName, string email, string phoneNumber, string address, int? companyId, int? travelAgencyId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("AddCustomer", conn))
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
    }

}
