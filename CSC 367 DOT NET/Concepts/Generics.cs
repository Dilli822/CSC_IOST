using System;

// Define a generic class
class GenericClass<T>
{
    // Generic member variable
    private T data;

    // Generic property
    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    // Generic constructor
    public GenericClass(T value)
    {
        data = value;
    }

    // Generic method
    public void Display()
    {
        Console.WriteLine("Value: " + data);
    }
}

class Program
{
    static void Main()
    {
        // Creating an instance of the generic class with int
        GenericClass<int> intInstance = new GenericClass<int>(10);
        intInstance.Display();

        // Creating an instance of the generic class with string
        GenericClass<string> stringInstance = new GenericClass<string>("Hello");
        stringInstance.Display();
    }
}
