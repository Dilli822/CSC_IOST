public class Arrays {
    public static void main(String[] args) {
        int[] numbers = {1, 2, 3, 4, 5};      // Declare and initialize an array
        numbers[numbers.length - 1] = 100;    // Update the last element
        for (int num : numbers) {
            System.out.println(num);         // Output each element
        }
    }
}

// In Java, arrays are objects that store multiple values of the same type. 
// There are mainly three types of arrays in Java:

// 1. One-Dimensional Array
// It’s like a simple list of elements.

// java
// int[] numbers = {1, 2, 3, 4, 5};
// ✅ Access using index: numbers[0] gives 1.

// 2. Two-Dimensional Array
// It’s like a table (matrix) with rows and columns.

// java
// int[][] matrix = {
//     {1, 2, 3},
//     {4, 5, 6}
// };
// ✅ Access like: matrix[1][2] gives 6.

// 3. Multidimensional Array (3D or more)
// Arrays inside arrays of arrays… mostly used in complex problems.

// java
// int[][][] cube = new int[2][3][4];  // 3D array
// ✅ Access: cube[1][2][3]


// In Java, the f in 1.23f explicitly tells the compiler that the number is a float literal, 
// not a double (which is the default type for decimal numbers in Java).

// Example:
// Java

// float a = 1.23f;  // Correct
// float b = 1.23;   // Compilation error: possible lossy conversion from double to float
// Why it's needed:
// 1.23 by itself is a double (64-bit).

// float is a 32-bit type, so assigning a double to a float without casting or f suffix causes an error.

// Summary:
// f = float literal (32-bit)

// d = double literal (optional, 64-bit; default)

// Data types in Java
// Java has two categories of data types:

// 1. Primitive Data Types (built-in, 8 types):
// Data Type	Size	Description	Example
// byte	1 byte	Whole numbers from -128 to 127	byte b = 100;
// short	2 bytes	Whole numbers from -32,768 to 32,767	short s = 5000;
// int	4 bytes	Whole numbers (default integer type)	int i = 100000;
// long	8 bytes	Large whole numbers	long l = 100000L;
// float	4 bytes	Decimal numbers with 6–7 digits	float f = 5.75f;
// double	8 bytes	Decimal numbers with 15 digits (default float type)	double d = 19.99;
// char	2 bytes	Single character (Unicode)	char c = 'A';
// boolean	1 bit	True or False	boolean flag = true;

// 2. Non-Primitive Data Types (reference types):
// These are created by the programmer or provided by Java.

// Strings → String name = "Alice";

// Arrays → int[] nums = {1, 2, 3};

// Classes → Custom objects like Student, Book

// Interfaces, Enums, etc.

