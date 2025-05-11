
public class find_factorial {
    public static void main(String[] args) {
      int number = 5;
      int factorial = 1;
      int i = 1;
      while(i <= number){
        factorial = factorial * i; // factorial = 1 * 1, factorial = 1 // factorial = 1 * 2
        i = i + 1;   // i = 1+1 , i=2 // i = 2+1 i = 3
       
      }
      System.out.println("factorial is" + factorial);
    }
}
