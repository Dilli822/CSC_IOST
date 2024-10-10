using System;

// Define a custom exception class
public class MySimpleException : Exception
{
    public MySimpleException(string message) : base(message) { }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Throw the custom exception
            throw new MySimpleException("This is a simple custom exception.");
        }
        catch (MySimpleException ex)
        {
            Console.WriteLine(ex.Message); // Print the exception message
        }
    }
}
