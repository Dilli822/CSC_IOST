using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "Server=localhost;Database=DOTNET_DB;User=root;Password=;",
            new MySqlServerVersion(new Version(8, 0, 27))
        );
    }
}
