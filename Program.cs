using Microsoft.Data.SqlClient;
using System;

static class Program
{
    static void Main()
    {
        string password = "Admin123!";
        string id = "felixadmin";
        string connectionString = $"Server=tcp:sqldatabase-edenborgh.database.windows.net,1433;Initial Catalog=SqlDatabase_WithData;Persist Security Info=False;User ID={id};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        const string queryString =
            "SELECT AddressID, City, PostalCode from SalesLT.Address ";

        const int paramValue = 5;

        using (SqlConnection connection = new(connectionString))
        {
            SqlCommand command = new(queryString, connection);
            command.Parameters.AddWithValue("@pricePoint", paramValue);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("\t{0}\t{1}\t{2}",
                        reader[0], reader[1], reader[2]);
                }
                reader.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Exception: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
            }
            Console.ReadLine();
        }
    }
}
