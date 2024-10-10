
/**
1. For loop, while loop, foreach, nested loops
**/

using System;

public class Program
{
    public static void Main(string[] args)
    {
        // For Loop
        Console.WriteLine("For Loop:");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Iteration {i}");
        }

        // Foreach Loop
        string[] fruits = { "Apple", "Banana", "Cherry" };
        Console.WriteLine("\nForeach Loop:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // While Loop
        Console.WriteLine("\nWhile Loop:");
        int count = 0;
        while (count < 5)
        {
            Console.WriteLine($"Count: {count}");
            count++;
        }

        // Do-While Loop
        Console.WriteLine("\nDo-While Loop:");
        int number = 0;
        do
        {
            Console.WriteLine($"Number: {number}");
            number++;
        } while (number < 5);

        // Nested Loops
        Console.WriteLine("\nNested Loops:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Console.WriteLine($"i = {i}, j = {j}");
            }
        }
    }
}
