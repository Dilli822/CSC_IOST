class Outer {
    private int outerVar = 10;

    class Inner {
        void display() {
            System.out.println("Outer variable: " + outerVar);
        }
    }

    public static void main(String[] args) {
        Outer outer = new Outer();
        Outer.Inner inner = outer.new Inner();
        inner.display();  // Output: Outer variable: 10
    }
}
