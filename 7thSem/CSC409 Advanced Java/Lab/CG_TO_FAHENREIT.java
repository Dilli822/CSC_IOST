import java.util.Scanner;

public class CG_TO_FAHENREIT{
    public static void main(String[] args){
        System.out.println("hello world");
        Scanner scan = new Scanner(System.in);
        System.out.println("Enter temperature in celsius ");
        float celsiusTemp = scan.nextFloat();
        System.out.println("Temp in Celsius: "+ celsiusTemp + "C'");
        
        float fahrenheit = (celsiusTemp * 9/5) + 32;
        System.out.println("Temperature in Fahrenheit: " + fahrenheit);
        
        if(fahrenheit > 90){
            System.out.println("Temperature is hot!!");
        }else{
            System.out.println("Temperature is not so hot!!");
        }
    }
}
