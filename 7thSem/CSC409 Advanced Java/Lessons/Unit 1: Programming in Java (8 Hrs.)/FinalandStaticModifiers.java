public class FinalandStaticModifiers {
    class MyClass {
        static int count = 0;   // Static variable
        final int MAX = 100;    // Final variable
    
        static void increment() {
            count++;
        }
    }
    
    public class Main {
        public static void main(String[] args) {
            MyClass.increment();  // Access static method
            System.out.println(MyClass.count);  // Output: 1
        }
    }
    
}
