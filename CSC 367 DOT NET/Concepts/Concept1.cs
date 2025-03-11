
Example showing where the DbContext is located in a typical ASP.NET Core MVC project structure:
Note: /Data is added customarily to separate data access concerns from other parts of the application.
/ProjectRoot
├── /Data (or /Persistence)
│   └── AppDbContext.cs
├── /Models
│   └── Book.cs
├── /Controllers
│   └── BookController.cs
├── /Views
│   └── ...
└── Program.cs

// Concept of AppDbContext.cs remeber the name can be changed.
using Microsoft.EntityFrameworkCore;
namespace MyApp.Data{
public class YourDbContextName : DbContext
{
    // DbSet represents the table in the database
    public DbSet<YourEntity> YourEntities { get; set; }

    // Constructor for initializing the DbContext with options
    public YourDbContextName(DbContextOptions<YourDbContextName> options) : base(options)
    {
    }
}
}


// Concept of Model 
public class ClassName
{
    // Property with get and set accessors
    public DataType PropertyName { get; set; }
}

// Concept of DbContext to include DbSet 
public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}

// Concept of DbContext to include DbSet
// 1. first let's create a model class
// 2. then create a DbContext class that inherits from DbContext

// Model class
using System.Linq;
public class Product {
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal rating {get; set; }

    public bool Banned {get; set;}
}


// DbContext
using Microsoft.EntityFrameworkCore;
public class ProductDBContext: DbContext{
    public DbSet<Product> Products { get; set;}
    public DbSet<Product> hello { get; set; }

    // lets make connection to the database??
}