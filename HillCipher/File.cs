using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HillCipher
{
  class File
  {
    static public void SaveInFile(string message)
    {
      string path = "";
      do
      {
        Console.WriteLine("Please enter path to file");
        path = Console.ReadLine();
        FileInfo tempFile = new FileInfo(path);
        if (!tempFile.Exists)
        {
          try
          {
            StreamWriter newFile = new StreamWriter(path);
            newFile.Close();
          }
          catch
          {
            Console.WriteLine("Bad name for file, please try again");
            continue;
          }
        }
        if (tempFile.Exists)
        {
          if (tempFile.IsReadOnly)
          {
            Console.WriteLine("Something wrong with file. please try again");
            continue;
          }
          else
          {
            Console.WriteLine("Do you want to rewrite file?" + Environment.NewLine + "1 - Yes");
            if (Input.GetInt() != 1)
            {
              continue;
            }
          }
        }
        tempFile.Delete();
        break;
      }
      while (true);
      StreamWriter file = new StreamWriter(path);
      file.WriteLine(message);
      file.Close();
      Console.WriteLine("File saved");
    }
    static public string GetDataFromFile()
    {
      string stringFromFile = "";
      string path = "";
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
        foreach (char letter in tempString)
        {
          if ((letter <= 'А' && letter >= 'Я') || letter != ',' || letter != '.' || letter != ' ' || letter != '?' || letter != 'Ё')
            Console.WriteLine("Bad data");
          badData = true;
          break;
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
      return stringFromFile;
    }
  }
}
