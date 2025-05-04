class Car {
    String color;
    int speed;

    // Constructor
    Car(String color, int speed) {
        this.color = color;
        this.speed = speed;
    }
}

public class classandobject {
    public static void main(String[] args) {
        Car carobj = new Car("red", 129);  // ✅ Pass values without naming
        System.out.println(carobj.color + " " + carobj.speed);
    }
}
