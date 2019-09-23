using System;

class Adventure
{
  static void Main()
  {
    Console.WriteLine("What\s your name?");
    string name = Console.ReadLine();
    Console.WriteLine("Hello " + name + "! Are you ready for an adventure? (y = yes/n = no)")
    string ready = Console.ReadLine();
    if (ready == "y") {
      Console.WriteLine("Let\'s go!");
    } else {
      Console.WriteLine("Wrong answer bro");
    }
  }
  static void StartingP()
  {
    Console.WriteLine("Welcome to CShaprivor. You have been dropped on a deserted island with 19 other castaways. You\'ll have to outwit, outplay, and outlast everyone to become the sole SHARPIVOR.");
    Console.WriteLine("You can look around using the command \'look\' or pick stuff up with the command \'pick\' or use items with the command \'use\'.")
  }
}
