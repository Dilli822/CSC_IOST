Here’s a clean implementation of an ASP.NET Core MVC CRUD application where a single view is used for adding, updating, and deleting employees.

1. Create the Employee Model (Employee.cs)
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int Salary { get; set; }
}

2. Configure the Database Context (AppDbContext.cs)

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=YOUR_SERVER;Database=YOUR_DB;User Id=YOUR_USER;Password=YOUR_PASS;");
    }
}


3. Create the Employee Controller (EmployeeController.cs)

using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class EmployeeController : Controller
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }L 

    // Display Employee List & Form
    public IActionResult Index(int? id)
    {
        var employees = _context.Employees.ToList();
        var employee = id == null ? new Employee() : _context.Employees.Find(id);
        return View((employees, employee));
    }

    // Create or Update Employee
    [HttpPost]
        public IActionResult Save(Employee employee)
    {
        if (employee.EmployeeId == 0)
            _context.Employees.Add(employee);
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
4. Create the View (Index.cshtml)

@model (List<Employee> Employees, Employee Employee)

<h2>Employee Management</h2>

<!-- Employee Form -->
<form method="post" asp-action="Save">
    <input type="hidden" asp-for="Employee.EmployeeId" />

    <label>Name:</label>
    <input type="text" asp-for="Employee.Name" required />

    <label>Salary:</label>
    <input type="number" asp-for="Employee.Salary" required />

    <button type="submit">@(Model.Employee.EmployeeId == 0 ? "Create" : "Update")</button>
</form><

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
