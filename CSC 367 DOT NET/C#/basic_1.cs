
/**
1. Comments
2. Data Types
3. Control Flow - if else and switch case
4. Operators - logical, comparsion, arithmetic
5. constant keyword and for loop
6. class, class properties and constructor
**/


// SINGLE LINE COMMENTS
/**
THIS IS MULTI-LINE COMMENTS
**/

// use Console.Write() or Console.WriteLine() to print the data/output
Console.Write("This is Console.Write. Doesnot add new line");
Consoe.WriteLine("This is Console.WriteLine. Does add new line");

// How to Create C# file ? - use .cs extension

// Variables in C#
/**
 Data Types | keyword
 1. Integer - int
 2. Float - double
 3. String - string
 4. Boolean - bool

 syntax
 data type keyword variableName;
**/

int a = 12;
int b = 12;
Console.Write(a + b);

// Constant using const keyword and once created cannot be changed
const double PI = 3.14;
Console.Write(PI);

double price = 122.22;
Console.Write(price);
price = 999.89;

string username = "Dilli Hang Rai";
Console.Write(username);

/**
 Operators
 Use arithmetic (+, -, *, /, %), 
 comparison (==, !=, <, >, <=, >=), 
 and logical (&&, ||, !) operators.
**/

Console.WriteLine(10 - 5);
Console.WriteLine(5 * 4);
Console.WriteLine(15 / 5);
Console.WriteLine(16 % 5);

/*
Control Flow:
Conditional statements: 
Use if, else, and else if to make decisions.
*/

isValid = false;
if(!isValid){
    Console.Write("Form is not Valid");
}else{
    Console.WriteLine("Form is Valid!")
}

/*
Loops: Use for, while, and do-while loops to repeat code.
*/

for (int i = 0; i < 5; i++)
{
    Console.WriteLine("Iteration " + i);
}

// Array - a collections of the elements of the same data types
int [] ages = {18,19,20,21};
for(int i = 0; i < ages.Length; i++){
    Console.WriteLine(ages[i]);
}


/**
 Basic Language Constructor
 1. Variables
 2. Datatypes
 3. For Looping
 4. Operators
 5. Control Flow Statements
**/


/**
 Constructor: Constructor is a special method that is
 automatically called when an instance of class is created.
**/

public class Form{
    public string name;
    public string faculty:
    public string registrationNumbers;

    // This is constructor default Constructor invoked when
    // instance of class is created ie. object
    public Form(){

    }

};


// Constructor and Properties
using System;

public class Form
{
    // Class-level fields
    public string Username; // Capitalized for naming convention
    public string Email;

    // Constructor
    public Form(string username, string email)
    {
        // Initialize fields with the provided parameters
        Username = username; // Assign parameter to field
        Email = email;       // Assign parameter to field
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Iphone 16 Pro Max");
        
        // Create an instance of the Form class and initialize it
        Form myForm = new Form("Dilli Hang Rai", "dilli@example.com");

        // Output the initialized values
        Console.WriteLine($"Username: {myForm.Username}");
        Console.WriteLine($"Email: {myForm.Email}");

        Console.WriteLine("Enter the day number");
        int dayNumber = int.Parse(Console.ReadLine())
        // switch case
        switch(dayNumber){
            case 1:
             Console.WriteLine("Monday");
             break;
            case 2:
            Console.WriteLine("Tuesday");
            break;
            default:
            Console.WriteLine("INvalid week day number");
            break;
        }
    }
}


using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a number (1-7) for the day of the week:");
        int dayNumber = int.Parse(Console.ReadLine());

        switch (dayNumber)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Friday");
                break;
            case 6:
                Console.WriteLine("Saturday");
                break;
            case 7:
                Console.WriteLine("Sunday");
                break;
            default:
                Console.WriteLine("Invalid day number. Please enter a number between 1 and 7.");
                break;
        }
    }
}
