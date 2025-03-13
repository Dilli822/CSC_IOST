using System;

// Step 1: Create a custom exception class
class MyCustomException : Exception {
    public MyCustomException(string message) : base(message){ }
}

class Program {
    static void Main(){
        int a = 10, b = 0;

        try{
            if (b == 0){
                throw new MyCustomException("Division by zero is not allowed.");
            }

            int divide = a / b; // This will not execute if b == 0
            Console.WriteLine("Result: " + divide);
        }
        catch (MyCustomException ex){
            // Step 3: Handle the exception
            Console.WriteLine("Caught Exception: " + ex.Message);
        }
    }
}



using System;

public class InsufficientFundsException : Exception { }

public class Program
{
    public static void Main()
    {
        try
        {
            throw new InsufficientFundsException();
        }
        catch (InsufficientFundsException)
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}



using System;

public class Program
{
    public static void Main()
    {
        try
        {
            int[] numbers = { 1, 2, 3 };
            Console.WriteLine(numbers[5]);  // This will throw an IndexOutOfRangeException
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("A general error occurred: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("This block is always executed.");
        }
    }
}
