public class overloading {
    // Calculator class declared as static or outside to avoid inner class issues
    static class Calculator {
        // Overloaded method for addition of two integers
        int add(int a, int b) {
            return a + b;
        }

        // Overloaded method for addition of three integers
        int add(int a, int b, int c) {
            return a + b + c;
        }
    }

    public static void main(String[] args) {
        Calculator calc = new Calculator();
        System.out.println(calc.add(2, 3));       // Calls the first method
        System.out.println(calc.add(2, 3, 4));    // Calls the second method
    }
}