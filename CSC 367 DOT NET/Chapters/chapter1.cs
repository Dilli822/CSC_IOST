// Basic Language Constructs

// C#
// Variables and Data Types
int age = 30;
double pi = 3.14159;
string name = "Alice";
bool isStudent = true;

// Operators
int sum = 10 + 20;
int difference = 15 - 5;
int product = 3 * 4;
int quotient = 10 / 2;

// Control Flow Statements
if (age >= 18)
{
    Console.WriteLine("You are an adult.");
}
else
{
    Console.WriteLine("You are a minor.");
}


// Constructor, Properties, Arrays, and Strings

// C#
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;   

    }
}

// Array
int[] numbers = { 1, 2, 3, 4, 5 };

// String
string greeting = "Hello, World!";


// Indexers, Inheritance, and Polymorphism

// C#
public class Animal
{
    public virtual void MakeSound()
    {
        Console.WriteLine("Generic animal sound");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Woof!");   

    }
}


// Structs, Enums, Abstract Classes, Sealed Classes, and Interfaces

// C#
public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

public enum Color { Red, Green, Blue }

public abstract class Shape
{
    public abstract double Area();
}

public sealed class Circle : Shape
{
    public double Radius { get; set; }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}

public interface IShape
{
    double Area();
}


// Delegates and Events

// C#
public delegate void MyDelegate();

public class EventPublisher
{
    public event MyDelegate MyEvent;

    public void TriggerEvent()
    {
        if (MyEvent != null)
        {
            MyEvent();
        }
    }
}


// Partial Classes and Collections

// C#
// Partial Class
public partial class MyClass
{
    // ...
}

public partial class MyClass
{
    // ...
}

// Collections
List<int> numbers = new List<int>();
Dictionary<string, int> ages = new Dictionary<string, int>();


// Generics

// C#
public class GenericList<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }
}


// File I/O

// C#
using System.IO;

string filePath = "data.txt";

// Write to a file
File.WriteAllText(filePath, "Hello, World!");

// Read from a file
string content = File.ReadAllText(filePath);


// LINQ Fundamentals

// C#
int[] numbers = { 1, 2, 3, 4, 5 };

// Query Syntax
var evenNumbers = from num in numbers
                  where num % 2 == 0
                  select num;

// Method Syntax
var evenNumbers = numbers.Where(num => num % 2 == 0);


// Try Statements and Exceptions

// C#
try
{
    int result = 10 / 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Error: Division by zero.");
}


// Attributes

// C#
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class MyAttribute : Attribute
{
    public string Description { get; set; }
}

[MyAttribute(Description = "This is a test class")]
public class MyClass
{
    // ...
}


// Asynchronous Programming

// C#
async Task MyAsyncMethod()
{
    await Task.Delay(1000);
    Console.WriteLine("Task completed.");
}


// This is a basic introduction to the .NET Framework and its core concepts. 