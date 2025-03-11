

###### Start the project using dotnet new mvc -o projectname
##### now modify the appsettings.json as
###### {
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=DOTNET_SB;User=root;Password=;"
  }
}

###### now make sure to add the folder Data/ApplicationDbContext.cs 
###### now make sure to add the Models/Product.cs
###### This is must for version matching and alignment.
 <Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.2" />
  <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="8.0.2" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.2" />
</ItemGroup>
</Project>

###
(env) dilli@MacBookAir lab1 % dotnet restore
dotnet build

Restore complete (5.6s)

Build succeeded in 5.8s
Restore complete (0.2s)
  lab1 succeeded with 1 warning(s) (1.2s) → bin/Debug/net9.0/lab1.dll
    /Users/dilli/Desktop/CSC_IOST/CSC 367 DOT NET/lab/lab1/Models/Product.cs(5,19): warning CS8618: Non-nullable property 'Name' must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring the property as nullable.

Build succeeded with 1 warning(s) in 1.8s
(env) dilli@MacBookAir lab1 % dotnet ef database update

Build started...
Build succeeded.
An error occurred while accessing the Microsoft.Extensions.Hosting services. Continuing without the application service provider. Error: 'AddDbContext' was called with configuration, but the context type 'ApplicationDbContext' only declares a parameterless constructor. This means that the configuration passed to 'AddDbContext' will never be used. If configuration is passed to 'AddDbContext', then 'ApplicationDbContext' should declare a constructor that accepts a DbContextOptions<ApplicationDbContext> and must pass it to the base constructor for DbContext.
No migrations were applied. The database is already up to date.
Done.
(env) dilli@MacBookAir lab1 % dotnet ef migrations add InitialCreate
dotnet ef database update

Build started...
Build succeeded.
An error occurred while accessing the Microsoft.Extensions.Hosting services. Continuing without the application service provider. Error: 'AddDbContext' was called with configuration, but the context type 'ApplicationDbContext' only declares a parameterless constructor. This means that the configuration passed to 'AddDbContext' will never be used. If configuration is passed to 'AddDbContext', then 'ApplicationDbContext' should declare a constructor that accepts a DbContextOptions<ApplicationDbContext> and must pass it to the base constructor for DbContext.
Done. To undo this action, use 'ef migrations remove'
Build started...
Build succeeded.
An error occurred while accessing the Microsoft.Extensions.Hosting services. Continuing without the application service provider. Error: 'AddDbContext' was called with configuration, but the context type 'ApplicationDbContext' only declares a parameterless constructor. This means that the configuration passed to 'AddDbContext' will never be used. If configuration is passed to 'AddDbContext', then 'ApplicationDbContext' should declare a constructor that accepts a DbContextOptions<ApplicationDbContext> and must pass it to the base constructor for DbContext.
Applying migration '20250212121709_InitialCreate'.
Done.
(env) dilli@MacBookAir lab1 % 
