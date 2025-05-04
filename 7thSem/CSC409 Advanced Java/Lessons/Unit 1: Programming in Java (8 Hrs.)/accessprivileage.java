
public class accessprivileage {
    public static void main(String[] args) {
        AccessPrivileges obj = new AccessPrivileges(10, 20);
        obj.display();

        System.out.println("Accessing publicVar: " + obj.publicKey);
        System.out.println("Accessing privateVar: " + obj.privateVar); // ❌ Will cause an error
    }
}

class AccessPrivileges {
    public int publicKey;
    private int privateKey;

    AccessPrivileges(int pub, int priv) {
        publicKey = pub;
        
        privateKey = priv;
    }

    public void display() {
        System.out.println("Public: " + publicKey);
        System.out.println("Private: " + privateKey);
    }
}