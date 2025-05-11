import java.util.Scanner;

public class scannr {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);  // Create Scanner object

        System.out.print("Enter your name: ");
        String name = scanner.nextLine();          // Read a string

        System.out.print("Enter your age: ");
        int age = scanner.nextInt();               // Read an integer

        System.out.println("Hello, " + name + "! You are " + age + " years old.");
    }
}
