using System;

public class Animal
{
    // Base class properties
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor for the base class
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Method in the base class
    public void Speak()
    {
        Console.WriteLine($"{Name} makes a sound.");
    }
}

public class Dog : Animal
{
    // Additional property for the derived class
    public string Breed { get; set; }

    // Constructor for the derived class
    public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed; // Initialize the derived class property
    }

    // Overriding the Speak method
    public void Speak()
    {
        // Call the base class Speak method
        base.Speak(); // Calling the base class method
        Console.WriteLine($"{Name} barks."); // Additional behavior
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of the Dog class
        Dog myDog = new Dog("Buddy", 3, "Golden Retriever");
        
        // Use the Speak method
        myDog.Speak();
    }
}
