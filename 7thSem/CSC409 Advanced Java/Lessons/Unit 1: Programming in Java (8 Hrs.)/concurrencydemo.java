

public class concurrencydemo{
    public static void main(String[] args) throws InterruptedException {

        // Thread states: NEW -> RUNNABLE -> RUNNING -> BLOCKED -> TERMINATED
        
        // Thread 1 (Low Priority)
        MyThread t1 = new MyThread();
        t1.setName("Thread-1");
        t1.setPriority(Thread.MIN_PRIORITY);  // Low priority

        // Thread 2 (High Priority)
        MyThread t2 = new MyThread();
        t2.setName("Thread-2");
        t2.setPriority(Thread.MAX_PRIORITY);  // High priority

        // Thread 3 (Normal Priority)
        MyThread t3 = new MyThread();
        t3.setName("Thread-3");
        t3.setPriority(Thread.NORM_PRIORITY); // Normal priority

        // Start threads
        t1.start();  // Starts Thread-1
        t2.start();  // Starts Thread-2
        t3.start();  // Starts Thread-3

        // Wait for threads to finish (join)
        t1.join();
        t2.join();
        t3.join();

        // Display a message after all threads are done
        System.out.println("All threads have completed.");
    }
}


class MyThread extends Thread {
    public void run() {
        // Synchronize block to demonstrate synchronization
        synchronized (System.out) {
            for (int i = 1; i <= 3; i++) {
                System.out.println(Thread.currentThread().getName() + " - " + i);
                try {
                    Thread.sleep(500); // Simulate work
                } catch (InterruptedException e) {
                    System.out.println(e);
                }
            }
        }
    }
}

// 🧠 Concepts Covered:
// Thread States:

// NEW: Threads are created (MyThread t1 = new MyThread();).

// RUNNABLE: After calling start(), threads become runnable.

// RUNNING: Threads execute their run() method.

// BLOCKED: The thread waits for a synchronized block (in synchronized(System.out)).

// TERMINATED: Once run() completes, the thread terminates.

// Multithreaded Program:

// Threads are created using MyThread t1 = new MyThread(); and run using start() method.

// Three threads are demonstrated, each printing a message with a delay (Thread.sleep(500)).

// Thread Properties:

// Thread Name: t1.setName("Thread-1") sets the thread name.

// Thread Priority: t1.setPriority(Thread.MIN_PRIORITY) sets the priority of threads. 
// Threads with higher priority (e.g., Thread.MAX_PRIORITY) are scheduled more frequently.

// Thread Synchronization:

// Synchronized Block: synchronized(System.out) ensures that only one thread writes to System.out at a time, 
// avoiding mixed outputs.

// This is a simple example of thread synchronization.

// Thread Priorities:

// Threads have priority values between Thread.MIN_PRIORITY (1) and Thread.MAX_PRIORITY (10). 
// Here, Thread-2 has the highest priority (Thread.MAX_PRIORITY), Thread-1 has the lowest (Thread.MIN_PRIORITY), 
// and Thread-3 has a normal priority (Thread.NORM_PRIORITY).

// 🧠 Key Points to Remember:
// Thread states change from NEW → RUNNABLE → RUNNING → BLOCKED → TERMINATED.

// Thread priority affects how the thread is scheduled but does not guarantee order.

// Synchronization prevents race conditions and ensures that only one thread at a time can access a resource.

// Use start() to begin a thread and join() to ensure one thread waits for others to finish before proceeding.