using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Initial list of numbers (acts as a database)
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

        // 🔹 INSERT: Add a new number
        numbers.Add(6);
        Console.WriteLine("After Insert: " + string.Join(", ", numbers));

        // 🔹 SELECT: Get numbers greater than 2
        var selected = from n in numbers
                       where n > 2
                       select n;
        Console.WriteLine("Selected: " + string.Join(", ", selected));

        // 🔹 UPDATE: Replace number 1 with 10
        var updatedNumbers = (from n in numbers
                              select (n == 1 ? 10 : n)).ToList();
        Console.WriteLine("Updated List: " + string.Join(", ", updatedNumbers));

        // 🔹 DELETE: Remove number 2
        var deletedNumbers = (from n in updatedNumbers
                              where n != 2
                              select n).ToList();
        Console.WriteLine("After Delete: " + string.Join(", ", deletedNumbers));
    }
}

// LAMBDA EXPRESSION

using System;

class Program{
    static void Main(){
       Func<int, int, int> add = (x, y) => x + y;
       int result = add(3,4);
       Console.WriteLine(result);
        
    }
}