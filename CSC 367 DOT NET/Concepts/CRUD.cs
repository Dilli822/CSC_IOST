using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// Model 
public class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=YOUR_DB;User Id=YOUR_USER;Password=YOUR_PASS;");
    }
}

class EmployeeCRUD
{
    public static void InsertEmployee(int id, string name, int salary)
    {
        using (var context = new AppDbContext())
        {
            var employee = new Employee { EmployeeId = id, Name = name, Salary = salary };
            context.Employees.Add(employee);
            context.SaveChanges();
            Console.WriteLine("Inserted Successfully!");
        }
    }

    public static void ReadEmployees()
    {
        using (var context = new AppDbContext())
        {
            var employees = context.Employees.ToList();
            foreach (var emp in employees)
                Console.WriteLine($"ID: {emp.EmployeeId}, Name: {emp.Name}, Salary: {emp.Salary}");
        }
    }

    public static void UpdateEmployee(int id, string name, int salary)
    {
        using (var context = new AppDbContext())
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                employee.Name = name;
                employee.Salary = salary;
                context.SaveChanges();
                Console.WriteLine("Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Employee Not Found!");
            }
        }
    }

    public static void DeleteEmployee(int id)
    {
        using (var context = new AppDbContext())
        {
            var employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                Console.WriteLine("Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Employee Not Found!");
            }
        }
    }

    static void Main()
    {
        InsertEmployee(3, "John", 12000);
        ReadEmployees();
        UpdateEmployee(3, "John Doe", 15000);
        ReadEmployees();
        DeleteEmployee(3);
        ReadEmployees();
    }
}



// Controller
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class EmployeeController : Controller
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    // Display Employees and Form in a Single View
    public IActionResult Index(int? id)
    {
        var employees = _context.Employees.ToList();
        var employee = id == null ? new Employee() : _context.Employees.Find(id);

        return View((employees, employee)); // Pass list and single employee
    }

    // Create or Update Employee
    [HttpPost]
    public IActionResult Save(Employee employee)
    {
        if (employee.EmployeeId == 0)
            _context.Employees.Add(employee);  // Insert new employee
        else
        {
            var existingEmployee = _context.Employees.Find(employee.EmployeeId);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Salary = employee.Salary;
            }
        }
        
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    // Delete Employee
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee != null)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
}

// Views
@model (List<Employee> Employees, Employee Employee)

<h2>Employee Management</h2>

<!-- Form for Create / Update -->
<form method="post" asp-action="Save">
    <input type="hidden" asp-for="Employee.EmployeeId" />
    
    <label>Name:</label>
    <input type="text" asp-for="Employee.Name" required />
    
    <label>Salary:</label>
    <input type="number" asp-for="Employee.Salary" required />
    
    <button type="submit">@(Model.Employee.EmployeeId == 0 ? "Create" : "Update")</button>
</form>

<hr>

<!-- Employee Table -->
<table border="1">
    <tr>
        <th>ID</th>
        <th>Name</th>
        <th>Salary</th>
        <th>Actions</th>
    </tr>
    @foreach (var emp in Model.Employees)
    {
        <tr>
            <td>@emp.EmployeeId</td>
            <td>@emp.Name</td>
            <td>@emp.Salary</td>
            <td>
                <a asp-action="Index" asp-route-id="@emp.EmployeeId">Edit</a>
                <form method="post" asp-action="Delete" style="display:inline;">
                    <input type="hidden" name="id" value="@emp.EmployeeId" />
                    <button type="submit">Delete</button>
                </form>
            </td>
        </tr>
    }
</table>


// CRUD (Create, Read, Update, Delete) system using ASP.NET Core MVC with Entity Framework Core.

// 📌 Breakdown of Your MVC Implementation
// Component	Description	Present in Code?
// Model	Represents Employee class with properties	✅ Yes
// View	Razor view (Index.cshtml) to display form & table	✅ Yes
// Controller	EmployeeController.cs handles user actions	✅ Yes
// Database Context	AppDbContext connects to SQL Server	✅ Yes