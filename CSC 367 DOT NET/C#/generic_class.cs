using System;

public class GenericClass<T>
{
    // Generic member variable
    private T data;

    // Generic constructor
    public GenericClass(T value)
    {
        data = value;
    }

    // Generic property
    public T DataProperty
    {
        get { return data; }
        set { data = value; }
    }

    // Generic method
    public void DisplayData()
    {
        Console.WriteLine(data);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Creating an instance of GenericClass with an int
        GenericClass<int> intInstance = new GenericClass<int>(10);
        intInstance.DisplayData(); // Output: 10

        // Creating an instance of GenericClass with a string
        GenericClass<string> stringInstance = new GenericClass<string>("Hello");
        stringInstance.DisplayData(); // Output: Hello
    }
}
