// Delegate ExampleCH

using System;

delegate void MyDelegate(); // Declare delegate

class Program
{
    static void Show() => Console.WriteLine("Hello, Delegate!");
    
    static void Main()
    {
        MyDelegate del = Show; // Assign method
        del(); // Invoke delegate
    }
}

// Event Example
using System;

class EventDemo
{
    public event Action MyEvent; // Declare an event using Action delegate (no need for a custom delegate)
    public void Trigger() => MyEvent?.Invoke();  // Method to trigger the eventTE
}

class Program
{
    static void Main()
    {
   
        EventDemo obj = new EventDemo();
        
        // Subscribe to the event using a lambda function
        // += is used to add multiple event handlers without removing existing ones! 
        obj.MyEvent += () => Console.WriteLine("Event Triggered!");
        obj.Trigger();
     
    }
}
