﻿using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
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

        public List<RoomModel> GetAllRooms()
        {
            List<RoomModel> rooms = new List<RoomModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT RoomID, RoomType, RoomStatus FROM ROOM";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rooms.Add(new RoomModel
                    {
                        RoomID = (int)reader["RoomID"],
                        RoomType = reader["RoomType"].ToString(),
                        RoomStatus = reader["RoomStatus"].ToString()

                    });

                }

            }

            return rooms;
        }
        public List<BookingModel> GetAllBookings()
        {
            List<BookingModel> bookings = new List<BookingModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT BookingID, DateBooked, LeavingDate, RoomID, CustomerID, CarParkID, BookingStatus FROM BOOKINGS";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bookings.Add(new BookingModel
                    {
                        BookingID = (int)reader["BookingID"],
                        DateBooked = (DateTime)reader["DateBooked"],
                        LeavingDate = (DateTime)reader["LeavingDate"],
                        RoomID = (int)reader["RoomID"],
                        CustomerID = (int)reader["CustomerID"],
                        CarParkID = (int)reader["CarParkID"],
                        BookingStatus = reader["BookingStatus"].ToString()

                    });

                }

            }

            return bookings;
        }
        public List<CarParkModel> GetAllCarParks()
        {
            List<CarParkModel> carParks = new List<CarParkModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT CarParkID, CarParkStatus FROM CARPARK";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    carParks.Add(new CarParkModel
                    {
                        CarParkID = (int)reader["CarParkID"],
                        CarParkStatus = reader["CarParkStatus"].ToString()
                    });
                }
            }

            return carParks;
        }

        public Customermodel GetCustomerById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var sqlQuery = "SELECT * FROM Customers WHERE CustomerID = @CustomerID";
                return conn.QueryFirstOrDefault<Customermodel>(sqlQuery, new { CustomerID = id });
            }
        }
        public void UpdateCustomer(int id, string firstName, string lastName, string email, string phoneNumber, string address, int? companyId, int? travelAgencyId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_UpdateCustomer", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@CustomerID", id);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@CompanyID", (object)companyId ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TravelAgencyID", (object)travelAgencyId ?? DBNull.Value);

                    // Open connection and execute the command
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<RoomModel> GetAvailableRooms()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var sqlQuery = "SELECT RoomID FROM ROOM WHERE RoomStatus = 'VacantClean';";
                return conn.Query<RoomModel>(sqlQuery).ToList();
            }
        }

        public List<CarParkModel> GetAvailableCarParks()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var sqlQuery = "SELECT CarParkID FROM CARPARK WHERE CarParkStatus = 'Available';";
                return conn.Query<CarParkModel>(sqlQuery).ToList();
            }
        }
        public List<Customermodel> GetCustomers()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var sqlQuery = "SELECT CustomerID, CustomerName FROM Customers"; // Adjust table and column names as needed
                return conn.Query<Customermodel>(sqlQuery).ToList();
            }
        }
        public void AddBooking(int customerID, int roomID, int? carParkID, DateTime dateBooked, DateTime leavingDate, string bookingStatus)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                var sqlQuery = "SP_Booking";  // Your stored procedure name
                conn.Execute(sqlQuery, new
                {
                    @customerID = customerID,
                    @roomID = roomID,
                    @carParkID = carParkID,
                    @dateBooked = dateBooked,
                    @leavingDate = leavingDate,
                    @bookingStatus = bookingStatus
                }, commandType: CommandType.StoredProcedure);
            }
        }


    }

}
