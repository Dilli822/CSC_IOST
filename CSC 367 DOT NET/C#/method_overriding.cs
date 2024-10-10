using System;

public class BaseClass
{
    // Declaring the method as virtual
    public virtual void Display()
    {
        Console.WriteLine("Display from BaseClass");
    }
}

public class DerivedClass : BaseClass
{
    // Overriding the base class method
    public override void Display()
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

        BaseClass overrideObj = new DerivedClass();
        overrideObj.Display(); // Calls DerivedClass method (overridden)
    }
}
