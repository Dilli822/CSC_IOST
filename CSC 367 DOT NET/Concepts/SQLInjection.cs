using System;
using System.Data.SqlClient;

class SQLInjectionDemo
{
    static void Main()
    {
        string connStr = "Server=YOUR_SERVER;Database=YOUR_DB;User Id=YOUR_USER;Password=YOUR_PASS;";
        Console.Write("Enter Username: ");
        string username = Console.ReadLine();
        
        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            string query = $"SELECT * FROM Users WHERE Username = '{username}' AND Password = '{password}'";
            SqlCommand cmd = new SqlCommand(query, conn);

            Console.WriteLine("\n[DEBUG] Executing Query: " + query); // Shows the query executed
            
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine(reader.HasRows ? "Login Successful!" : "Invalid Credentials!");
        }
    }
}

How to Exploit?
Input these values:
1️⃣ Bypass Authentication:
Username: admin' --  
Password: anything
SQL Executed:

sql
SELECT * FROM Users WHERE Username = 'admin' --' AND Password = 'anything'
✅ Bypasses password check!

2️⃣ Universal Login Bypass:
Username: ' OR '1'='1  
Password: anything
SQL Executed:

sql
SELECT * FROM Users WHERE Username = '' OR '1'='1' AND Password = 'anything'
✅ Always returns true, giving access to any user!

Prevention?
✔ Use Parameterized Queries
✔ Sanitize Input
✔ Use ORM like Entity Framework



// SOLUTION 

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

        string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
        SqlCommand cmd = new SqlCommand(query, conn);
        
        // Use parameters to safely handle user inputs
        cmd.Parameters.AddWithValue("@Username", username);
        cmd.Parameters.AddWithValue("@Password", password);
        
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
