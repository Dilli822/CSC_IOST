using System;

public class Home{

    public string username;
    public string email;

    public Home(){
        Console.WriteLine("Constructor called");
    }

    public static void Main(string[] args){

        Console.WriteLine("string");

        Home home1 = new Home();
        home1.username = "Dilli";
        home1.email = "dillihangrae";

        Console.WriteLine($"{home1.username}");

    }


    try{
        Console.WriteLine(10/0);
    }
    catch(DivideByZeroException e){
        Console.Write(e.Message);
    }


};






using System;

public class Form{
  // 
  public string username {get; set;}
  public int age {get; set;}
  
  public Form(string username, int age){
      this.username = username;
      this.age = age;
      Console.WriteLine($"Username: {this.username}, Age: {this.age} ");
  }
  public static void Main(){
      Form form1 = new Form("Dilli Hang Rai", 25);
      
  }  
    
};E