using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
// # Model Defintion
public class Bag
{
    public int ID { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
}
======================================================================================================
//  Define the DbContext in Entity Framework Core
// DbContext is the primary class in Entity Framework Core that acts as a bridge between  C# application and the database.
// It allows you to perform CRUD (Create, Read, Update, Delete) operations on your database using C# code.
// ================================ Key Responsibilities of DbContext ===================================================
// Manages Database Connection
// Establishes a link between your application and the database.
// Tracks Changes in Entities
// Detects modifications made to data and applies them to the database.
// Handles Queries and Commands
// Converts LINQ queries into SQL and executes them.
// Manages Transactions
// Ensures data integrity by grouping multiple operations into a single transaction.

public class AppDbContext : DbContext
{
    // represents BAGS table in the database and bag objects corresponds to rows in the table
    public DbSet<Bag> Bags { get; set; }

    // This constructor initializes the AppDbContext with options, like the database connection string.
    // DbContextOptions<AppDbContext> provides configuration settings (e.g., which database provider to use, connection string, etc.).
    // base(options) passes these options to the DbContext base class.

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

// Perform the Operations
using (var context = new AppDbContext(options))
{
    // Update Price to 2000 for Books published in 2022
    context.Bags.Where(b => b.Date == 2022).ToList().ForEach(b => b.Price = 2000);
    
    // Delete Books published in 1981
    context.Bags.RemoveRange(context.Bags.Where(b => b.Date == 1981));

    // Retrieve Brands of Books with Price > 500
    var brands = context.Bags.Where(b => b.Price > 500).Select(b => b.Brand).ToList();

    context.SaveChanges();
}




// Model
public class Bag{
    public int ID { get; set; }
    public string Brand { get; set: }
}

// DBContext 
public class AppDbContext: DbContext{
  public DbSet <Bag> Bags { get; set;}
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
     
}

// In the code provided, we have two main components: the model and the DbContext.

// 1. Model: Bag class
// public class Bag{
//     public int ID { get; set; }
//     public string Brand { get; set; }
// }
// Bag class: This is the model that represents a table in the database. In this case, the Bag class will map to a table called "Bags" (by convention) in the database.
// ID: This property represents the primary key of the Bag table, which uniquely identifies each row in the table.
// Brand: This property represents a column in the Bag table to store the brand name of a bag.

// 2. DbContext: AppDbContext class
// public class AppDbContext : DbContext{
//     public DbSet<Bag> Bags { get; set; }
    
//     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
// }

// AppDbContext class: This class inherits from DbContext and serves as the bridge between the application and the database. It provides an interface for querying and saving data to the database.
// DbSet<Bag> Bags { get; set; }: This defines a collection of Bag entities that Entity Framework Core will use to interact with the Bags table in the database. DbSet<Bag> allows us to perform CRUD (Create, Read, Update, Delete) operations on the Bag table.
// Constructor (AppDbContext(DbContextOptions<AppDbContext> options)):
// DbContextOptions<AppDbContext> options: This parameter contains the database connection and configuration options, such as the database provider (e.g., SQL Server) and connection string. These options are used to configure the context so that Entity Framework Core knows how to connect to the database.
// : base(options): This calls the base class constructor (DbContext) and passes the options parameter to it, which initializes the connection to the database.
// What is happening here?
// The Bag class defines the data structure for the Bags table.
// The AppDbContext class represents the database context and is used to interact with the database.
// When AppDbContext is initialized, it uses the provided DbContextOptions to set up the connection to the database.
// The DbSet<Bag> property allows access to the Bags table in the database, allowing you to query and manipulate records related to the Bag model.
// This setup is the foundation for working with a database using Entity Framework Core.

====================================================================
// Q. How do you create a controller? Mention some requirements for rendering HTML.
// Controller Named HomeController
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View(); // Renders Index.cshtml view
    }

    public IActionResult About()
    {
        return Content("About Page"); // Returns plain text
    }
}

// Example: Views/Home/Index.cshtml
// Basic Razor syntax example:
// html
// <h1>Welcome to My Page</h1>
// <p>This is an MVC view.</p>

// Configure MVC in Program.cs

// var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddControllersWithViews(); // Enable MVC views
// var app = builder.Build();
// app.UseRouting();
// app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
// app.Run();