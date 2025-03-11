using System;

public class InsufficientFundsException : Exception { }

public class Program
{
    public static void Main()
    {
        double balance = 100;
        double withdrawalAmount = 150;

        try
        {
            if (withdrawalAmount > balance)
                throw new InsufficientFundsException();
            
            balance -= withdrawalAmount;
            Console.WriteLine("Withdrawal successful. New balance: " + balance);
        }
        catch (InsufficientFundsException)
        {
            Console.WriteLine("Error: Insufficient funds.");
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
