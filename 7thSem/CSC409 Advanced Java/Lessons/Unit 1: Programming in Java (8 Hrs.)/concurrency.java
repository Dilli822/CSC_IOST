public class concurrency{
// ✅ Concurrency in Java (Short Notes)
// 1. Introduction
// Concurrency means multiple tasks running at the same time.

// In Java, this is achieved using Threads.

// Useful for games, servers, downloading/uploading, etc.

// 2. Thread States
// Threads have 5 main states:

// New – Thread created but not started.

// Runnable – Ready to run, waiting for CPU.

// Running – Currently executing.

// Blocked/Waiting – Waiting for resource or signal.

// Terminated – Execution complete.

// 3. Writing Multithreaded Programs
// Two ways to create a thread:

// java
// Copy
// Edit
// // Method 1: Extend Thread class
// class MyThread extends Thread {
//     public void run() {
//         System.out.println("Running thread");
//     }
// }

// // Method 2: Implement Runnable interface
// class MyRunnable implements Runnable {
//     public void run() {
//         System.out.println("Running runnable");
//     }
// }
// 4. Thread Properties
// start() – starts thread

// run() – defines thread task

// sleep(ms) – pause thread

// join() – waits for thread to finish

// isAlive() – checks if thread is running

// 5. Thread Synchronization
// Used to prevent conflicts when multiple threads access the same resource.

// Use synchronized keyword.

// java
// synchronized void print() {
//     // only one thread at a time
// }
// 6. Thread Priorities
// Threads have priority values from 1 (MIN_PRIORITY) to 10 (MAX_PRIORITY).

// Default is 5 (NORM_PRIORITY).

// Set using t.setPriority(7);

// 🧠 Easy Summary:
// Concept	Keyword/Example
// Create Thread	extends Thread or implements Runnable
// Run thread	start()
// Sync thread	synchronized block
// Sleep thread	sleep(1000)
// Join thread	join()
// Check alive	isAlive()
// Set priority	setPriority(1–10)


// ✅ Short Multithreading Java Program
// java
// Copy
// Edit
// class MyThread extends Thread {
//     public void run() {
//         synchronized(System.out) {
//             for (int i = 1; i <= 3; i++)
//                 System.out.println(getName() + " - " + i);
//         }
//     }
// }

// public class TestThreads {
//     public static void main(String[] args) {
//         MyThread t1 = new MyThread();
//         MyThread t2 = new MyThread();
        
//         t1.setName("Low");
//         t2.setName("High");
        
//         t1.setPriority(3);  // Lower priority
//         t2.setPriority(8);  // Higher priority

//         t1.start();
//         t2.start();
//     }
// }
// 🔍 What it shows:
// MyThread extends Thread → creates thread

// synchronized(System.out) → simple synchronization

// setPriority() → shows thread priorities

// start() → runs both threads

// 🧠 Memory Tips:
// Class extends Thread

// Override run() method

// Use start() to begin

// Wrap output in synchronized to avoid mix-up

// Set names & priorities for clarity


}