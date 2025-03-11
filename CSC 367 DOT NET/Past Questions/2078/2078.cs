Code snippet
public class InsufficientFundsException : Exception
{
    public InsufficientFundsException() : base("Insufficient funds in the account.") { }
    public InsufficientFundsException(string message) : base(message) { }
}

public class Account
{
    public decimal Balance { get; set; }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InsufficientFundsException("Withdrawal amount exceeds account balance.");
        }

        Balance -= amount;
    }
}







2. SQL Injection Example [5 marks]
C#
// Vulnerable Code
public User GetUser(string username, string password)
{
    // UNSAFE: Direct string concatenation
    string query = "SELECT * FROM Users WHERE Username='" + username + 
                  "' AND Password='" + password + "'";
    
    // Example Attack Input:
    // username: admin' --
    // password: anything
    
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        return cmd.ExecuteReader();
    }
}

// Safe Code (Parameterized Query)
public User GetUserSafe(string username, string password)
{
    string query = "SELECT * FROM Users WHERE Username=@user AND Password=@pwd";
    
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@user", username);
        cmd.Parameters.AddWithValue("@pwd", password);
        return cmd.ExecuteReader();
    }
}



using System;
using System.Data.SqlClient;

public class SqlInjectionExample
{
    public static void Main(string[] args)
    {
        string username = Console.ReadLine(); // Get username from user input

        // Vulnerable Query
        string connectionString = "your_connection_string"; 
        string query = $"SELECT * FROM Users WHERE Username = '{username}'"; 

        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Username: {reader["Username"]}"); 
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}






C#
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
}

public class EmployeeContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace with your actual connection string
        optionsBuilder.UseSqlServer("your_connection_string"); 
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new EmployeeContext())
        {
            // Create an Employee object
            Employee employee = new Employee
            {
                EmployeeId = 3,
                Name = "John",
                Salary = 12000
            };

            // Add the employee to the context
            context.Employees.Add(employee);

            // Save changes to the database
            context.SaveChanges();

            Console.WriteLine("Employee record inserted successfully.");
        }
    }
}




Example of MVC in ASP.NET Core:
Model:
csharp
Copy
Edit
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
Controller:
csharp
Copy
Edit
public class ProductController : Controller
{
    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 1200 },
            new Product { Id = 2, Name = "Phone", Price = 800 }
        };

        return View(products);
    }
}
View (Index.cshtml):
html
Copy
Edit
@model List<Product>

<h1>Product List</h1>
<table>
    <tr>
        <th>ID</th>
        <th>Name</th>
        <th>Price</th>
    </tr>
    @foreach (var product in Model)
    {
        <tr>
            <td>@product.Id</td>
            <td>@product.Name</td>
            <td>@product.Price</td>
        </tr>
    }
</table>
Benefits of the MVC Pattern:
Separation of Concerns: Improves code maintainability by separating logic, UI, and data.
Scalability: Easier to expand the application with new features.
Testability: The independent components allow for easier testing, especially the Model and Controller.






Dependency Injection and IoC Container
1. Dependency Injection (DI):
Dependency Injection is a design pattern that allows objects to receive their dependencies (objects or services) from an external source rather than creating them internally. It helps in building loosely coupled, testable, and maintainable applications.

Key Concepts of DI:
Dependency: An object that a class requires to function.
Injection: The process of providing the dependency to the dependent object.
Types of Dependency Injection:
Constructor Injection: Dependencies are passed via the constructor.
Property Injection: Dependencies are set through public properties.
Method Injection: Dependencies are provided as method parameters.
Example of Constructor Injection in .NET:
csharp
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public class ProductService
{
    private readonly ILogger _logger;

    // Dependency is injected via the constructor
    public ProductService(ILogger logger)
    {
        _logger = logger;
    }

    public void Process()
    {
        _logger.Log("Processing started.");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        ILogger logger = new ConsoleLogger(); // Dependency is created
        ProductService service = new ProductService(logger); // Injected into ProductService
        service.Process();
    }
}
2. Inversion of Control (IoC) Container:
An IoC Container is a framework or tool that automates the process of dependency injection. It manages the lifecycle and resolution of dependencies, removing the need to manually create and inject dependencies.

How IoC Works:
Define interfaces and their implementations.
Register dependencies in the IoC container.
Resolve dependencies when needed, and the IoC container automatically provides them.
Example of IoC Container in ASP.NET Core:
ASP.NET Core provides a built-in IoC container.

Register Dependencies in the Startup.cs file:
csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<ILogger, ConsoleLogger>(); // Transient: New instance per request
    services.AddScoped<ProductService>();           // Scoped: Instance per request within the scope
}
Resolve Dependencies in the Controller or Class:
csharp
public class ProductController : Controller
{
    private readonly ProductService _productService;

    // IoC container resolves and injects the dependencies
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        _productService.Process();
        return View();
    }
}
Benefits of Dependency Injection and IoC:
Loose Coupling: Classes depend on abstractions, not concrete implementations.
Improved Testability: Easier to mock dependencies during unit testing.
Centralized Configuration: Dependency management is centralized in the IoC container.
Better Code Maintainability: Reduces hard-coded dependencies, making the code more modular and adaptable.