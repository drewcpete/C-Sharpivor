using System.Collections.Generic;
using System.Linq;
using System;

class Adventure
{
  public static Dictionary<string, bool> alliance = new Dictionary<string,bool> () {{"&rew", false},{"jason",false},{"chris",false},{"mike",false},{"lauren",false},{"erin",false},{"nikhil",false},{"carrie",false},{"anita", false}, {"christine", false}, {"devin", false}, {"joel", false}, {"ethan", false}, {"neha", false}, {"micah", false}, {"jacqueline",false},{"sophia",false},{"molly", false},{"kira", false},{"brendan", false},{"loewy", false},{"rachel", false}, {"jennifer", false}, {"haley", false}};

  // public static Dictionary<string, string> immunity = new Dictionary<string,bool> () {{"&rew", false},{"jason",false},{"chris",false},{"mike",false},{"lauren",false},{"erin",false},{"nikhil",false},{"carrie",false},{"anita", false}, {"christine", false}, {"devin", false}, {"joel", false}, {"ethan", false}, {"neha", false}, {"micah", false}, {"jacqueline",false},{"sophia",false},{"molly", false},{"kira", false},{"brendan", false},{"loewy", false},{"rachel", false}, {"jennifer", false}};


  static void Main()
  {
    Console.WriteLine("What's your name?");
    string name = Console.ReadLine();
    Console.WriteLine("Hello " + name + "! Are you ready for an adventure? (y = yes/n = no)");
    string ready = Console.ReadLine();
    if (ready == "y") {
      Console.WriteLine("Let's go!");
      StartingP(1);
    } else {
      Console.WriteLine("Wrong answer bro");
    }
  }
  static void StartingP(int counter)
  {
    Console.WriteLine("Welcome to CShaprivor. You have been dropped on a deserted island with 19 other castaways. You'll have to outwit, outplay, and outlast everyone to become the sole SHARPIVOR.");
    // Console.WriteLine("You can look around using the command \'look\' or pick stuff up with the command \'pick\' or use items with the command \'use\'.")
    Drama(counter);
  }

  static void Drama(int counter){
    List<string> contestants = alliance.Keys.ToList();
    Random random = new Random();
    int randomNum = random.Next(0,contestants.Count-1);
    string person = contestants[randomNum];

    string[] situations = {"You catch "+person+" going through someone's stuff. Do you help (y) them or tell them to **** off (n)", person + " catches a fish. Do you build a fire (y) or do nothing(n)?", person+"shows your their 'immunity idol.' Do you trust them (y) or not (n)?", "You catch " + person + " eating communal food all by themselves. Do you join in (y) or rat them out (n)?", person+" starts talking about spirits, tarot cards, and the astrological likelihood of winning. Do you feign excietment (y) or tell them their weird (n)?", "You catch " + person + " making out with someone from the opposing alliance. Do you tell the tribe (n) or keep quiet (y)?", "You wake up to find that all the fires have been put out and the wood supply thrown into the ocean. You remember seeing " + person+ " as being the last to be awake. Do you quietly talk to them (y) or loudly accuse them (n)?"};
    if(counter % 2 ==0)
    {
      Console.WriteLine("-_-_-_-_-_-_-_-_TRIBAL COUNCIL-_-_-_-_-_-_-_-_");
      int allianceCounter = 0;
      Console.WriteLine("Players left: ");
      foreach (KeyValuePair<string, bool> entry in alliance)
      {
          Console.WriteLine("-" + entry.Key);
      }
      foreach (KeyValuePair<string, bool> entry in alliance)
      {
         if (entry.Value == true)
         {
             allianceCounter++;
         }
      }
      if(counter == 4){
        if (allianceCounter >= counter+1)
        {
          Console.WriteLine("The tribe has spoken. Jeff Probst congratulates you for being the sole Sharpivor.");
          Console.WriteLine("Would you like to play again? y/n");
          string playagain = Console.ReadLine();
          if (playagain == "y" || playagain == "Y") 
          {
            StartingP(1);
          }   
        else 
        {
          Console.WriteLine("Then go away");
        }

      }
        else
        {
        Console.WriteLine("The tribe has spoken.  Jeff Probst snuffs your torch.");
        Console.WriteLine("You have lost survivor.  Would you like to play again? y/n");
        string playagain = Console.ReadLine();
        if (playagain == "y" || playagain == "Y") 
          {
            StartingP(1);
          }
          else 
          {
            Console.WriteLine("Then go away");
          }
        }
      }
      else{
        if (allianceCounter >= counter+1)
          {
          Console.WriteLine("You sharpived, but " + person + " got their torch snuffed.");
          alliance.Remove(person);
          ImmunityChallenge(counter);
      }
      else
      {
        Console.WriteLine("The tribe has spoken.  Jeff Probst snuffs your torch.");
        Console.WriteLine("You have lost survivor.  Would you like to play again? y/n");
        string playagain = Console.ReadLine();
        if (playagain == "y" || playagain == "Y") 
        {
          StartingP(1);
        }
        else 
        {
          Console.WriteLine("Then go away");
        }
      }
      
      }
    }
    else{

      string situation = situations[random.Next(0,situations.Length-1)];
      Console.WriteLine("You're back at camp. " + situation);
      string response = Console.ReadLine();
      if(response == "y"){
        alliance[person] = true;
        Console.WriteLine("You are now friends with " + person + ". Time to get ready for the immunity challenge.");
        ImmunityChallenge(counter);
      }
      else{
        Console.WriteLine("You have made an enemy out of " + person + ". Time to get ready for the immunity challenge.");
        ImmunityChallenge(counter);
      }
    }
  }

  static void ImmunityChallenge(int counter){
    Console.WriteLine("*******IMMUNITY CHALLENGE*******");
    if(counter == 1){
      List<string> contestants = alliance.Keys.ToList();
      List<string> teamMates = new List<string>();

      Console.WriteLine("Today's immunity challenge... Your teammates are:");
      for(int i = 0;i<contestants.Count/2;i++){
        string person = contestants[i];
        teamMates.Add(person);
        Console.WriteLine("-" +person);
      }
      Random random = new Random();
      int randomNum1 = random.Next(0,contestants.Count/2);
      int randomNum2 = random.Next(0,contestants.Count/2);
      int randomNum3 = random.Next(0,contestants.Count/2);

      string teamMate1 = teamMates[randomNum1];
      string teamMate2 = teamMates[randomNum2];
      string teamMate3 = teamMates[randomNum3];
      string otherTeamMate = contestants[random.Next(contestants.Count/2,contestants.Count)];

      
      Console.WriteLine("Your teammate " + teamMate1 +" is about to drown. Will you help them? y/n");
      string answer = Console.ReadLine();
      if(answer == "y" || answer == "Y")
      {
        Console.WriteLine("You attempted to save " + teamMate1 + " but were unsuccessful.  Production had to rescue both of you and your team forfeit the challenge.");
        Console.WriteLine("Did you learn that helping others is worth it?");
        string answer2 = Console.ReadLine();
          if(answer2 == "y" || answer2 == "Y")
          {
            Console.WriteLine("That is not the message you should've learned");
            Console.WriteLine("You're tribe now believe you to be a liability and a sucker.  You lose your alliance.");
            
            foreach (var item in teamMates)
            {
                alliance[item] = false;
            }

            Drama(counter+1);
          }
          else if (answer2 == "n" || answer2 == "N")
          {
            Console.WriteLine("Good. But remember to always look out for yourself!");
            Console.WriteLine("Youre tribemates now respect you more!  They all make alliances with you");
            foreach (var item in teamMates)
            {
              alliance[item] = true;
            }
            Drama(counter+1);
          } 
          else
          {
            Console.WriteLine("That wasn't a valid choice. Start Over.");
            ImmunityChallenge(counter);
          }
      }
      else if (answer == "n" || answer == "N")
      {
        Console.WriteLine(otherTeamMate +" from the other tribe tries to save them.  They were unsuccessful both drown!");
        alliance.Remove(otherTeamMate);
        alliance.Remove(teamMate1);
        teamMates.Remove(teamMate1);
        contestants.Remove(teamMate1);
        contestants.Remove(otherTeamMate);
        Console.WriteLine("Everyone celebrates the increase in their chance of becoming the sole Sharpivor!  Do you join in with the celebrations?");
        string answer3 = Console.ReadLine();
          if(answer3 == "y" || answer3 == "Y")
        {
          Console.WriteLine("Everyone Celebrates! You make alliances with everyone!");
          foreach (var item in contestants)
          {
            alliance[item] = true;
          }
          Drama(counter+1);
        }
        else if (answer3 == "n" || answer3 == "N")
        {
          Console.WriteLine("Everyone thinks you're a fucking freak and stop talking to you. Lose all alliances.");
          foreach (var item in contestants)
          {
              alliance[item] = false;
          }
          Drama(counter+1);
        }
        else
        {
          Console.WriteLine("That wasn't a valid choice. Start Over.");
          ImmunityChallenge(counter);
        }

      }
      else
      {
        Console.WriteLine("That wasn't a valid choice. Start Over.");
        ImmunityChallenge(counter);
      }
    }      
    else if (counter == 2){
      List<string> contestants = alliance.Keys.ToList();
      List<string> teamMates = new List<string>();

      Console.WriteLine("Today's immunity challenge... Your teammates are:");
      for(int i = 0;i<contestants.Count/2;i++){
        string person = contestants[i];
        teamMates.Add(person);
        Console.WriteLine("-" +person);
      }
      Random random = new Random();
      int randomNum1 = random.Next(0,contestants.Count/2);
      int randomNum2 = random.Next(0,contestants.Count/2);
      int randomNum3 = random.Next(0,contestants.Count/2);

      string teamMate1 = teamMates[randomNum1];
      string teamMate2 = teamMates[randomNum2];
      string teamMate3 = teamMates[randomNum3];
      string otherTeamMate = contestants[random.Next(contestants.Count/2,contestants.Count)];

      
      Console.WriteLine("Your teammate " + teamMate1 +" is super slow. Do you yell at them for being slow? y/n");
      string answer = Console.ReadLine();
      if(answer == "y" || answer == "Y")
      {
        Console.WriteLine("Your teammate " + teamMate1 + " gets angry.  In a fit of rage they end up speeding up. Do you continue to egg them on? y/n");
        Console.WriteLine("Did you learn that helping others is worth it?");
        string answer2 = Console.ReadLine();
          if(answer2 == "y" || answer2 == "Y")
          {
            Console.WriteLine( teamMate1 + " ends up pulling through and winning the challenge for your team. The team and" + teamMate1 + " realize you work really well at motivating them. You gain alliances with everyone in your tribe." );
            foreach (var item in teamMates)
            {
                alliance[item] = true;
            }

            Drama(counter+1);
          }
          else if (answer2 == "n" || answer2 == "N")
          {
            Console.WriteLine("Good. But remember to always look out for yourself!");
            Console.WriteLine("Youre tribemates now respect you more!  They all make alliances with you");
            foreach (var item in teamMates)
            {
              alliance[item] = true;
            }
            Drama(counter+1);
          } 
          else
          {
            Console.WriteLine("That wasn't a valid choice. Start Over.");
            ImmunityChallenge(counter);
          }
      }
      else if (answer == "n" || answer == "N")
      {
        Console.WriteLine(otherTeamMate +" starts tuanting" + teamMate1+". "+teamMate1+" starts to break down. Do you console them? y/n");
        Console.WriteLine("Do you console them? y/n");
        string answer3 = Console.ReadLine();
          if(answer3 == "y" || answer3 == "Y")
        {
          Console.WriteLine("Your tribe is pissed of you're wasting time. You end up losing the Immunity Challenge and lose all your alliances.");
          foreach (var item in contestants)
          {
            alliance[item] = false;
          }
          Drama(counter+1);
        }
        else if (answer3 == "n" || answer3 == "N")
        {
          Console.WriteLine("Your tribe pulls through while ignoring" + teamMate1 + ". " + "You all gain each other's respect and form an alliance, excluding " + teamMate1 + ".");
          foreach (var item in contestants)
          {
              if(item != teamMate1)
              {
                alliance[item] = true;
              } 
          }
          Drama(counter+1);
        }
        else
        {
          Console.WriteLine("That wasn't a valid choice. Start Over.");
          ImmunityChallenge(counter);
        }

      }
      else
      {
        Console.WriteLine("That wasn't a valid choice. Start Over.");
        ImmunityChallenge(counter);
      }
    }
    else if (counter == 3)
    {
      List<string> contestants = alliance.Keys.ToList();
      List<string> teamMates = new List<string>();

      Console.WriteLine("Today's immunity challenge... Your teammates are:");
      for(int i = 0;i<contestants.Count/2;i++){
        string person = contestants[i];
        teamMates.Add(person);
        Console.WriteLine("-" +person);
      }
      Random random = new Random();
      int randomNum1 = random.Next(0,contestants.Count/2);
      int randomNum2 = random.Next(0,contestants.Count/2);
      int randomNum3 = random.Next(0,contestants.Count/2);

      string teamMate1 = teamMates[randomNum1];
      string teamMate2 = teamMates[randomNum2];
      string teamMate3 = teamMates[randomNum3];
      string otherTeamMate = contestants[random.Next(contestants.Count/2,contestants.Count)];

      
      Console.WriteLine(teamMate1 + "keeps missing their throws! Do you request to replace them because you can do better? y/n");
      string answer = Console.ReadLine();
      if(answer == "y" || answer == "Y")
      {
        Console.WriteLine("You replace " + teamMate1 + " but you suck just as much as they do.  Do you request someone else to sub in for you? y/n");
          string answer2 = Console.ReadLine();
          if(answer2 == "y" || answer2 == "Y")
          {
            Console.WriteLine(teamMate2 + "subs in.  They're the worst of all of you guys and you lose the challenge.");
            Console.WriteLine("You're tribe now believe you to be stupid and bossy.  You lose your alliance from this team.");
            
            foreach (var item in teamMates)
            {
                alliance[item] = false;
            }

            Drama(counter+1);
          }
          else if (answer2 == "n" || answer2 == "N")
          {
            Console.WriteLine("You find your stride and throw those balls perfectly.  Much better than " + otherTeamMate);
            Console.WriteLine("You're tribemates now respect you more!  They all make alliances with you! Except for " + teamMate1 + " who thinks you stole their glory.");
            foreach (var item in teamMates)
            {
              if (teamMate1 != item)
              {
              alliance[item] = true;
              }
            }
            Drama(counter+1);
          } 
          else
          {
            Console.WriteLine("That wasn't a valid choice. Start Over.");
            ImmunityChallenge(counter);
          }
      }
      else if (answer == "n" || answer == "N")
      {
        Console.WriteLine(otherTeamMate + " makes a while throw and accidentally hits " + teamMate3 + " . Medical says they have a concussion and they've been removed from the game!!");
        alliance.Remove(otherTeamMate);
        alliance.Remove(teamMate3);
        teamMates.Remove(teamMate3);
        contestants.Remove(teamMate3);
        Console.WriteLine("The other tribe celebrates the increase in their chance of becoming the sole Sharpivor! Do you want to join? y/n");
        string answer3 = Console.ReadLine();
          if(answer3 == "y" || answer3 == "Y")
        {
          Console.WriteLine("The other team doesn't appreciate you joining in their festivities and neither does your tribe. You lose all alliances!");
          foreach (var item in contestants)
          {
            alliance[item] = false;
          }
          Drama(counter+1);
        }
        else if (answer3 == "n" || answer3 == "N")
        {
          Console.WriteLine("Your team ends up sulking and fighting within the tribe. " + teamMate2 + ", " + teamMate1 + " and " + teamMate3 + "get into a physical altercation with " + otherTeamMate + ". All players involved were removed from the game.");
          alliance.Remove(teamMate1);
          alliance.Remove(teamMate2);
          alliance.Remove(teamMate3);
          alliance.Remove(otherTeamMate);
          contestants.Remove(teamMate1);
          contestants.Remove(teamMate2);
          contestants.Remove(teamMate3);
          contestants.Remove(otherTeamMate);
          Drama(counter+1);
        }
        else
        {
          Console.WriteLine("That wasn't a valid choice. Start Over.");
          ImmunityChallenge(counter);
        }

      }
      else
      {
        Console.WriteLine("That wasn't a valid choice. Start Over.");
        ImmunityChallenge(counter);
      }
    }
    else{
      Console.WriteLine("How did you even get here?");
      Console.WriteLine("Would you like to play again? y/n");
        string playagain = Console.ReadLine();
        if (playagain == "y" || playagain == "Y") 
        {
          StartingP(1);
        }
        else 
        {
          Console.WriteLine("Then go away");
        }
    }
  }
}

 