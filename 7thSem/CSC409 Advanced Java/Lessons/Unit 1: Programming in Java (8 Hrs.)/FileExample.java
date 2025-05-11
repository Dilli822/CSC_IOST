import java.io.*;

class SimpleFile {
    public static void main(String[] args) throws Exception {

        // Byte Stream
        FileOutputStream fos = new FileOutputStream("byte.txt");
        fos.write("Byte".getBytes());
        fos.close();

        // Character Stream
        FileWriter fw = new FileWriter("char.txt");
        fw.write("Char");
        fw.close();

        // Random Access File
        RandomAccessFile raf = new RandomAccessFile("rand.txt", "rw");
        raf.writeUTF("Random");
        raf.seek(0);
        System.out.println(raf.readUTF());
        raf.close();

        // Object Stream         // Object Stream (Write)
        ObjectOutputStream oos = new ObjectOutputStream(new FileOutputStream("obj.txt"));
        oos.writeObject("Object");
        oos.close();

        // Object Stream (Read)
        ObjectInputStream ois = new ObjectInputStream(new FileInputStream("obj.txt"));
        System.out.println((String) ois.readObject());
        ois.close();

    }
}


// Exactly! That’s a shortcut way to memorize the file handling classes and what they do:

// ✅ Memory Aid:
// Variable	Stream Type	Handles	Hint
// fos	FileOutputStream	Byte data	Think: "fos → Output Byte"
// fw	FileWriter	Char data	Think: "FileWriter → Writing Characters"
// raf	RandomAccessFile	Random Access read/write	Think: "RAF → Random Access File"
// oos	ObjectOutputStream	Write Object	Think: "Object Output"
// ois	ObjectInputStream	Read Object	Think: "Object Input"

// 🧠 Mnemonic:
// FOS → Byte, FW → Char, RAF → Random, OOS/OIS → Object

// Very helpful for exams and viva!