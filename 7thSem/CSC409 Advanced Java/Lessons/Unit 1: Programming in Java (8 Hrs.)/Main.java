// 1. Interface
// What it is:
// An interface defines a set of methods that a class must implement. It acts as a contract that classes agree to follow.

// Key points:

// Interfaces cannot have method implementations (unless they’re default).

// A class implements an interface using the implements keyword.

// Simple Example:

// java
// Copy
// Edit
// interface Animal {
//     void sound(); // Method without implementation
// }

// class Dog implements Animal {
//     public void sound() {
//         System.out.println("Bark");
//     }
// }

// public class Main {
//     public static void main(String[] args) {
//         Animal dog = new Dog();
//         dog.sound();  // Outputs: Bark
//     }
// }
// Easy Way to Remember:

// Interface = Contract.

// Classes sign the contract by implementing the interface.

// 2. Inner Class
// What it is:
// An inner class is a class defined inside another class. It's useful when the inner class should only be used by the outer class.

// Key points:

// An inner class can access the outer class’s members (even private ones).

// Can be static (accessed without an instance of the outer class) or non-static.

// Simple Example:

// java
// Copy
// Edit
// class Outer {
//     int outerValue = 10;

//     class Inner {
//         void display() {
//             System.out.println("Outer Value: " + outerValue);
//         }
//     }
// }

// public class Main {
//     public static void main(String[] args) {
//         Outer outer = new Outer();
//         Outer.Inner inner = outer.new Inner();
//         inner.display();  // Outputs: Outer Value: 10
//     }
// }
// Easy Way to Remember:

// Inner Class = Class Inside Another Class.

// The inner class is like a helper to the outer class.

// 3. Final and Static Modifiers
// Final Modifier:
// Final variable: Value cannot be changed.

// Final method: Cannot be overridden.

// Final class: Cannot be subclassed.

// Static Modifier:
// Static variable: Shared across all instances.

// Static method: Can be called without creating an object of the class.

// Simple Example:

// java
// Copy
// Edit
// class Example {
//     final int finalValue = 100;  // Can't change the value
//     static int staticValue = 50;  // Shared across all objects

//     public static void displayStatic() {
//         System.out.println("Static Value: " + staticValue);
//     }

//     public final void displayFinal() {
//         System.out.println("This is a final method.");
//     }

//     public static void main(String[] args) {
//         Example obj = new Example();
//         obj.displayFinal();  // Outputs: This is a final method.
//         Example.displayStatic();  // Outputs: Static Value: 50
//     }
// }
// Easy Way to Remember:

// Final = Cannot Change or Override.

// Static = Shared across all objects.

// 4. Packages
// What it is:
// A package is like a folder that holds classes and organizes code. It helps prevent naming conflicts and makes the code more modular.

// Key points:

// You can import classes from other packages.

// Java has built-in packages (e.g., java.util, java.io).

// Simple Example:

// java
// Copy
// Edit
// // Animal.java (Package: animals)
// package animals;

// public class Animal {
//     public void sound() {
//         System.out.println("Animal sound");
//     }
// }

// // Main.java (No package)
// import animals.Animal;

// public class Main {
//     public static void main(String[] args) {
//         Animal a = new Animal();
//         a.sound();  // Outputs: Animal sound
//     }
// }
// Easy Way to Remember:

// Package = Folder for Classes.

// Use import to bring in classes from other folders (packages).

// Summary (for Exam):
// Interface: A contract that requires implementing classes to define certain methods.

// Inner Class: A class inside another class, useful for encapsulation.

// Final Modifier: Used for variables, methods, or classes that cannot be changed or overridden.

// Static Modifier: Used for variables and methods shared across all instances of a class.

// Package: A namespace that organizes related classes to avoid conflicts.

