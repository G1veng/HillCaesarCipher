using System;
using System.Collections.Generic;
using System.Text;

namespace HillCipher
{
  class SomeInput
  {
    static public int GetInt()
    {
      int number = 0;
      while (true)
      {
        Console.Write("Please enter integer: ");
        string text = Console.ReadLine();
        if (int.TryParse(text, out number))
        {
          break;
        }
        Console.WriteLine("This is not a integer, try again");
      }
      return number;
    }
    static public string GetIntKey()
    {
      string text = "";
      while (true)
      {
        Console.Write("Please enter integer: ");
        text = Console.ReadLine();
        if (int.TryParse(text, out int number))
        {
          break;
        }
        Console.WriteLine("This is not a integer, try again");
      }
      return text;
    }
    static public string GetStringKey()
    {
      string key;
      bool badData;
      do
      {
        badData = false;
        Console.WriteLine("Please enter key");
        string tempString = Console.ReadLine();
        foreach (char letter in tempString)
        {
          if (!((letter >= 'А' && letter <= 'Я') || (letter == ',' || letter == '.' || letter == ' ' || letter == '?' || letter == 'Ё')))
          {
            Console.WriteLine("Bad data");
            badData = true;
            break;
          }
        }
        if (badData)
          continue;
        key = tempString;
        break;
      }
      while (true);
      return key;
    }
  }
}
