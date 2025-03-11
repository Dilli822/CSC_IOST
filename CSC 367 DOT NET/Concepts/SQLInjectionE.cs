using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string username = "admin' OR '1'='1";
        string password = "password";
        
        SqlConnection conn = new SqlConnection("your_connection_string");
        conn.Open();

        string query = "SELECT * FROM Users WHERE Username = '" + username + "' AND Password = '" + password + "'";
        SqlCommand cmd = new SqlCommand(query, conn);
        
        SqlDataReader reader = cmd.ExecuteReader();
        
        if (reader.HasRows)
        {
            Console.WriteLine("Login successful!");
        }
        else
        {
            Console.WriteLine("Invalid credentials");
        }
        
        conn.Close();
    }
}
