using System;
using System.Data.SqlClient;

namespace VulnerableApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            // VULNERABILITY #1: Hardcoded database credentials
            string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=admin;Password=admin123;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // VULNERABILITY #2: SQL Injection risk
                string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("Login failed.");
                }
            }
        }
    }
}
