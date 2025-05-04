// public ✅ 9. Packages in Java
// Definition: A package is a collection of classes, interfaces, and sub-packages.

// Syntax:
// java

package myPackage;

public class MyClass {
    public void display() {
        System.out.println("Hello from MyClass!");
    }
}
// To use this class in another file:

// java

import myPackage.MyClass;

public class Main {
    public static void main(String[] args) {
        MyClass obj = new MyClass();
        obj.display();
    }
}
 {
    
}
