// Why Use Collections & Generics in C#?
// 1️⃣ Collections (Efficient Data Management)
// ✅ Store multiple values dynamically (Unlike arrays, which are fixed-size)
// ✅ Pre-built operations → Add, Remove, Search, Sort, etc.
// ✅ Different types available:

// 1. List<T> → Ordered, resizable
// Dictionary<TKey, TValue> → Key-Value pairs
// Queue<T> & Stack<T> → FIFO & LIFO structures
// Example: List<T> (Better than Arrays)

List<int> numbers = new List<int> { 1, 2, 3 };
numbers.Add(4);
numbers.Remove(2);
numbers.Add(34,11,23,2);
numbers.Sort();
numbers[1] = 22333;
Console.WriteLine(numbers.Count);  // Output: 4


// 2. Create a Dictionary
Dictionary<int, string> students = new Dictionary<int, string>();

// Add key-value pairs
students.Add(101, "Alice");
students.Add(102, "Bob");
students.Add(103, "Charlie");
students.Remove(102); // Remove key 102
students[102] = "Dilli Hang Rai";

// Accessing values using keys
Console.WriteLine($"Student with ID 101: {students[101]}");
// Iterating over Dictionary
foreach (var kvp in students){
        Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
}

// Collections → Manage dynamic data easily
// Generics → Write flexible, type-safe, and optimized code

// 2️⃣ Generics (Type-Safe & Reusable Code)
// ✅ Avoids boxing/unboxing (Faster performance)
// ✅ Ensures Type Safety (Prevents runtime type errors)
// ✅ Promotes Code Reusability (Same logic for different data types)

void GenericExample<T>(T data) { Console.WriteLine(data); }
GenericExample(100);  // Works for int
GenericExample("Hello");  // Works for string



