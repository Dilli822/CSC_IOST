using System;

public class SimpleCollection
{
    private int[] numbers = new int[5]; // Array to hold integers

    // Indexer to access integers by index
    public int this[int index]
    {
        get
        {
            return numbers[index]; // Return the number at the specified index
        }
        set
        {
            numbers[index] = value; // Set the number at the specified index
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SimpleCollection myNumbers = new SimpleCollection();

        // Adding numbers using the indexer
        myNumbers[0] = 10;
        myNumbers[1] = 20;
        myNumbers[2] = 30;

        // Accessing numbers using the indexer
        Console.WriteLine("Numbers in the collection:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(myNumbers[i]); // Print each number
        }
    }
}
