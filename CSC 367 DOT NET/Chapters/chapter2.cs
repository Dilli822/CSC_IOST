// 1. .NET Core: Hello World

using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, .NET Core!");
        }
    }
}
// 2. ASP.NET Core: Minimal Web API

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Welcome to ASP.NET Core!");
app.Run();

// 3. CLI Operations

# Create a new console application
dotnet new console -o HelloWorldApp

# Build the project
dotnet build

# Run the application
dotnet run

# Create a new Web API project
dotnet new webapi -o WebApiApp

# Test the project
dotnet test
// 4. ASP.NET MVC Controller Example

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return Content("About this Application");
    }
}
// 5. ASP.NET Web API Example

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new[] { "Sunny", "Cloudy", "Rainy" };
    }
}
// 6. Dependency Injection in .NET Core

public interface IMessageService
{
    string GetMessage();
}

public class MessageService : IMessageService
{
    public string GetMessage() => "Hello, Dependency Injection!";
}

// Program.cs
builder.Services.AddSingleton<IMessageService, MessageService>();

app.MapGet("/", (IMessageService messageService) => messageService.GetMessage());
// 7. LINQ Query Example

using System.Linq;

int[] numbers = { 1, 2, 3, 4, 5, 6 };

var evenNumbers = numbers.Where(n => n % 2 == 0);

foreach (var num in evenNumbers)
{
    Console.WriteLine(num);
}
// 8. MSIL Generation

# Compile the program to generate IL code
csc HelloWorld.cs
ildasm HelloWorld.exe
