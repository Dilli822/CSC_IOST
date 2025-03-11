// Basic Language Constructs
// This is a basic introduction to the .NET Framework and its core concepts. 
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
    // public keyword is here access modifiers: public, protectd and private 
    // get and set are the properties of class person
    public string Name { get; set; }
    public int Age { get; set; }

    // Parameterized Constructor
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

public class Example
{
    private int[] numbers = new int[5];  // Array inside the class

    public int this[int index]          // Indexer definition
    {
        get => numbers[index];          // Get value
        set => numbers[index] = value;  // Set value
    }
}

// Usage: Inside the Main Class
Example ex = new Example();
ex[0] = 42;    // Set value at index 0
Example rc = new Example();
rc[0] = 32                         // Set value at index 0
Console.WriteLine(ex[0]);  // Get value at index 0: Output is 42
Console.WriteLine(rc[0])              



// Simple Inheritance 
public class Animal
{
    public void Eat() => Console.WriteLine("Eating...");
}

public class Dog : Animal
{
    public void Bark() => Console.WriteLine("Barking...");
}

// Usage:
Dog dog = new Dog();
dog.Eat();   // From Animal
dog.Bark();  // From Dog

// Runtime Polymorphism using method overridding
public class Animal
{
    public virtual void Speak() => Console.WriteLine("Animal sound");
}

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Bark");
}

// Usage:
Animal animal = new Dog();
animal.Speak();  // Output: "Bark"


// Structs, Enums, Abstract Classes, Sealed Classes, and Interfaces

// 1. Structs
// A struct is a value type used for small, lightweight objects.
// Cannot inherit from another class or struct but can implement interfaces.
// Example:

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, float y)
    {
        X = x;
        Y = y;
    }
}

// Usage:
Point p = new Point(5, 10.5434344);
Console.WriteLine($"X: {p.X}, Y: {p.Y}");

// 2. Enums
// An enum is a distinct type with a set of named constants.
// Ideal for representing choices or options.
// Example:
public enum Days
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

// Usage:
Days today = Days.Monday;
Console.WriteLine($"Today is: {today}");

// 3. Abstract Classes
// An abstract class is a base class that cannot be instantiated directly.
// Can have both abstract methods (no body) and regular methods.
// Example:
public abstract class Animal
{
    public abstract void Speak();  // Abstract method
    public void Eat() => Console.WriteLine("Eating...");  // Regular method
}

public class Dog : Animal
{
    public override void Speak() => Console.WriteLine("Bark!");
}

// Usage:
Animal dog = new Dog();
dog.Speak();
dog.Eat();

// 4. Sealed Classes
// A sealed class cannot be inherited.
// Useful for preventing further derivation of a class.
// Example:
public sealed class MathOperations
{
    public int Add(int a, int b) => a + b;
}

// Usage:
MathOperations math = new MathOperations();
Console.WriteLine(math.Add(3, 4));


//  Interfaces
// An interface defines a contract that classes or structs must follow.
// All methods in an interface are abstract and must be implemented by the class.
// Example:
public interface IVehicle
{
    void Drive();
}

public class Car : IVehicle
{
    public void Drive() => Console.WriteLine("Car is driving.");
}

// Usage:
IVehicle vehicle = new Car();
vehicle.Drive();

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

// File1.cs
public partial class MyClass
{
    public int MyProperty { get; set; }

    public void Method1()
    {
        // ...
    }
}

// File2.cs
public partial class MyClass
{
    public void Method2()
    {
        // ...
    }
}

// Collections
List<int> numbers = new List<int>();
Dictionary<string, int> ages = new Dictionary<string, int>();

// Lists

using System;
using System.Collections.Generic;

public class Example
{
    public static void Main(string[] args)
    {
        // Create a list of integers
        List<int> numbers = new List<int>();

        // Add elements to the list
        numbers.Add(10);
        numbers.Add(5);
        numbers.Add(15);

        // Access elements by index
        Console.WriteLine(numbers[0]); // Output: 10

        // Iterate through the list
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        // Remove an element
        numbers.Remove(5);
    }
}

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


