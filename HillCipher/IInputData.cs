using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HillCipher
{
  public interface IInputData
  {
    string Input();
  }
  public class ManualInput : IInputData
  {
    public string Input()
    {
      string messageFromConsole;
      bool badData;
      do
      {
        badData = false;
        Console.WriteLine("Please enter message to encypt");
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
        messageFromConsole = tempString;
        break;
      }
      while (true);
      Console.WriteLine("Do you want to save data in file?" + Environment.NewLine + "1 - yes");
      if (SomeInput.GetInt() == 1)
      {
        File.SaveInFile(messageFromConsole);
      }
      return messageFromConsole;
    }
  }
  public class RandomInput : IInputData
  {
    const int LowerLimit = 5;
    const int UpperLimit = 12;
    static Random rnd = new Random();
    public string Input()
    {
      string randomString = "";
      int countOfNLetter = rnd.Next(LowerLimit, UpperLimit);
      for (int i = 0; i < countOfNLetter; i++)
      {
        var letter = rnd.Next(HillCipher.LENGHTOFALPHABET - 1);
        if (letter >= 0 && letter < 6)
        {
          randomString += (char)(letter + 'А');
        }
        if (letter == 6)
        {
          randomString += 'Ё';
        }
        if (letter > 6 && letter <= 32)
        {
          randomString += (char)(letter - 1 + 'А');
        }
        if (letter == 33)
        {
          randomString += '.';
        }
        if (letter == 34)
        {
          randomString += ',';
        }
        if (letter == 35)
        {
          randomString += ' ';
        }
        if (letter == 36)
        {
          randomString += '?';
        }
      }
      Console.WriteLine(randomString);
      Console.WriteLine("Do you want to save data in file?" + Environment.NewLine + "1 - yes");
      if (SomeInput.GetInt() == 1)
      {
        File.SaveInFile(randomString);
      }
      return randomString;
    }
  }

  public class FileInput : IInputData
  {
    public string Input()
    {
      string stringFromFile = "";
      string path;
      do
      {
        Console.WriteLine("Please enter path to file");
        path = Console.ReadLine();
        FileInfo tempFile = new FileInfo(path);
        if (!tempFile.Exists)
        {
          Console.WriteLine("File is not existing");
          continue;
        }
        StreamReader tempOpenedFile = new StreamReader(path);
        string tempString = "";
        while (!tempOpenedFile.EndOfStream)
        {
          tempString += tempOpenedFile.ReadLine();
        }
        tempOpenedFile.Close();
        bool badData = false;
        foreach(char letter in tempString)
        {
          if (!((letter >= 'А' && letter <= 'Я') || (letter == ',' || letter == '.' || letter == ' ' || letter == '?' || letter == 'Ё')))
          {
            Console.WriteLine("Bad data");
            badData = true;
            break;
          }
        }
        if (badData)
        {
          continue;
        }
        break;
      }
      while (true);
      StreamReader file = new StreamReader(path, false);
      while (!file.EndOfStream)
      {
        stringFromFile += file.ReadLine();
      }
      file.Close();
      Console.WriteLine(stringFromFile);
      return stringFromFile;
    }
  }
}
