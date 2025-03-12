using System;

struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Display()
    {
        Console.WriteLine($"Point: ({X}, {Y})");
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(10, 20);
        p1.Display();
    }
}


using System;

enum Days
{
    Sunday,    // 0
    Monday,    // 1
    Tuesday,   // 2
    Wednesday, // 3
    Thursday,  // 4
    Friday,    // 5
    Saturday   // 6
}

class Program
{
    static void Main()
    {
        Days today = Days.Wednesday;
        Console.WriteLine($"Today is {today}");
        Console.WriteLine($"Numerical Value: {(int)today}");
    }
}
