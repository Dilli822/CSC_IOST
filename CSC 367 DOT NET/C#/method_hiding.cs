using System;

public class BaseClass
{
    public void Display()
    {
        Console.WriteLine("Display from BaseClass");
    }
}

public class DerivedClass : BaseClass
{
    // Hiding the base class method
    public new void Display()
    {
        Console.WriteLine("Display from DerivedClass");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BaseClass baseObj = new BaseClass();
        baseObj.Display(); // Calls BaseClass method

        DerivedClass derivedObj = new DerivedClass();
        derivedObj.Display(); // Calls DerivedClass method

        BaseClass hiddenObj = new DerivedClass();
        hiddenObj.Display(); // Calls BaseClass method (hidden)
    }
}
