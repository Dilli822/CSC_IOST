

public class foreachloop {
    public static void main(String[] args) {
        int[] numbers = {1, 2, 3, 4, 5};
        for (int num : numbers) {
            System.out.println(num);  // Output each element
        }
    }
}


// for (type variable : array) {
//     // Body of the loop
// }



// In Java, there are four main types of loops, each used to repeat a block of code multiple times:

// 1. for loop
// Best when number of iterations is known.

// java
// for (int i = 0; i < 5; i++) {
//     System.out.println(i);
// }
// 2. while loop
// Used when you don’t know how many times you'll loop, but you have a condition.

// java

// int i = 0;
// while (i < 5) {
//     System.out.println(i);
//     i++;
// }
// 3. do-while loop
// Like while, but guarantees at least one execution.

// java

// int i = 0;
// do {
//     System.out.println(i);
//     i++;
// } while (i < 5);
// 4. for-each loop (enhanced for loop)
// Used to loop through arrays or collections.

// java

// int[] numbers = {1, 2, 3, 4, 5};
// for (int num : numbers) {
//     System.out.println(num);
// }
