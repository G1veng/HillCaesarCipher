using System;
using System.Text;

namespace HillCipher
{
  class Program
  {
    static void Main(string[] args)
    {
      string key, message;
      int count, choice;
      IInputData someInput;
      ICipher algorithm;
      Console.WriteLine("Created by: Shishko Daniil Yrevich" + Environment.NewLine +
        "Option: 9" + Environment.NewLine + "Aim: Create an ICipher interface that defines methods to support string encryption. " +
        "The interface declares two methods Encode() and Decode(), which are used to encrypt and decrypt strings" + 
        ", respectively. Implement 2 classes implementing this interface." + Environment.NewLine +
        "Welcome.");
      do
      {
        count = 1;
        Console.WriteLine(Environment.NewLine + Environment.NewLine + "1 - Console input" + Environment.NewLine
          + "2 - File input" + Environment.NewLine + "3 - Random input" + Environment.NewLine + "4 - End program");
        choice = Input.GetInt();
        if ((GetInput.UserChoice)choice < GetInput.UserChoice.ConsoleInput || (GetInput.UserChoice)choice > GetInput.UserChoice.End)
        {
          Console.WriteLine("We don't have these choice, please try again");
          continue;
        }
        someInput = GetInput.GetSomeInput(choice);
        message = someInput.input();
        do
        {
          Console.WriteLine();
          Console.WriteLine("Please choose the algorithm");
          foreach (string name in Enum.GetNames(typeof(ICipher.Algorithms)))
          {
            Console.WriteLine(count.ToString() + " - " + name);
            count++;
          }
          choice = Input.GetInt();
          if ((ICipher.Algorithms)choice < ICipher.Algorithms.HillCipher || (ICipher.Algorithms)choice > ICipher.Algorithms.CaesarCipher)
          {
            Console.WriteLine("We don't have these choice, please try again");
            continue;
          }
          algorithm = GetInput.GetAlgorithm(choice);
          Console.WriteLine();
          if ((ICipher.Algorithms)choice == ICipher.Algorithms.HillCipher)
          {
            key = Input.GetStringKey();
            break;
          }
          if ((ICipher.Algorithms)choice == ICipher.Algorithms.CaesarCipher)
          {
            key = Input.GetIntKey();
            break;
          }
        } while (true);
        do
        {
          Console.WriteLine(Environment.NewLine + "1 - To Encode" + Environment.NewLine + "2 - To Decode");
          choice = Input.GetInt();
          if(choice == 1)
          {
            message = algorithm.Encode(message, key);
            Console.WriteLine("Encoded string: " + message);
            Console.WriteLine("Do you want to save data in file?" + Environment.NewLine + "1 - yes");
            if(Input.GetInt() == 1)
            {
              File.SaveInFile(message);
            }
          }
          if (choice == 2)
          {
            message = algorithm.Decode(message, key);
            Console.WriteLine("Decoded string: " + message);
            Console.WriteLine("Do you want to save data in file?" + Environment.NewLine + "1 - yes");
            if (Input.GetInt() == 1)
            {
              File.SaveInFile(message);
            }
          }
          else
          {
            Console.WriteLine("We don't have these choice, please try again");
            continue;
          }
          Console.WriteLine(Environment.NewLine + "Enter 0 to return");
          if (Input.GetInt() == 0)
            break;
        } while (true);
      }
      while (true);
    }
  }
}
