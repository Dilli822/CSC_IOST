using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

// Model named Bag
public class Bag{
    public int ID { get; set;}
    public string Brand { get; set;}
    public decimal Price { get; set;}
}

===========================================
// DbContext class named AppDbContext 
public class AppDbContext: DbContext {
    public 
}



public class YourDbContextName : DbContext
{
    // DbSet represents the table in the database
    public DbSet<YourEntity> YourEntities { get; set; }

    // Constructor for initializing the DbContext with options
    public YourDbContextName(DbContextOptions<YourDbContextName> options) : base(options)
    {
    }
}
