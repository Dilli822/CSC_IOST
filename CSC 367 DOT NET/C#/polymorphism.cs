using System;

// Base class
public class Animal
{
    // Virtual method
    public virtual void Speak()
    {
        Console.WriteLine("Animal speaks");
    }
}

// Derived class Dog
public class Dog : Animal
{
    // Override method
    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}

// Derived class Cat
public class Cat : Animal
{
    // Override method
    public override void Speak()
    {
        Console.WriteLine("Cat meows");
    }
}

// Main Program
public class Program
{
    public static void Main(string[] args)
    {
        // Creating instances of Dog and Cat
        Animal myDog = new Dog();
        Animal myCat = new Cat();

        // Calling the Speak method on both instances
        myDog.Speak(); // Output: Dog barks
        myCat.Speak(); // Output: Cat meows
    }
}
