interface Animal {
    void sound();  // Abstract method
}

class Dog implements Animal {
    public void sound() {
        System.out.println("Woof!");
    }
}

public class InterfaceExample {  // Make sure this matches the filename!
    public static void main(String[] args) {
        Dog dog = new Dog();
        dog.sound();  // Output: Woof!
    }
}
