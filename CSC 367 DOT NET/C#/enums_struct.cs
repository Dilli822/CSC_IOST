using System;

public class DotNet
{
    // Struct is a template that holds collections of fields which can hold different data types
    struct Student
    {
        public string username;
        public int age;
        public double weight;

        // Constructor to initialize the struct
        public Student(string username, int age, double weight)
        {
            this.username = username;
            this.age = age;
            this.weight = weight;
        }
    }

    // Enum allows creating a custom data type; enums are typically integers
    enum WeekDays
    {
        monday = 1,    // Use commas, not semicolons
        tuesday = 2,
        wednesday = 3
    }

    public static void Main(string[] args)
    {
        // Creating an instance of struct Student
        Student dilli = new Student("Dilli Hang Rai", 25, 66.78);

        Console.WriteLine("Hello From Inside");
        Console.WriteLine($"Student Name: {dilli.username}, Age: {dilli.age}, Weight: {dilli.weight}");
        
        // Example of using the enum
        WeekDays today = WeekDays.wednesday;
        Console.WriteLine($"Today is {today} (Value: {(int)today})");
    }
}
