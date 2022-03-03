using System;
using System.Collections.Generic;
using System.Text;

namespace HillCipher
{
  public class CaesarCipher : ICipher
  {
    const string alfabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ., ?";
    private static string CodeEncode(string text, int k)
    {
      var fullAlfabet = alfabet;
      var letterQty = fullAlfabet.Length;
      var retVal = "";
      for (int i = 0; i < text.Length; i++)
      {
        var c = text[i];
        var index = fullAlfabet.IndexOf(c);
        if (index < 0)
        {
          retVal += c.ToString();
        }
        else
        {
          var codeIndex = (letterQty + index + k) % letterQty;
          retVal += fullAlfabet[codeIndex];
        }
      }

      return retVal;
    }
    private void CheckData(string message, string key)
    {
      for (int i = 0; i < message.Length; i++)
      {
        int asciCode = message[i];
        if (!(asciCode >= 'А' && asciCode <= 'Д') & !(asciCode == 'Ё') & !(asciCode > 'Д' && asciCode <= 'Я') & !(asciCode == '.')
          & !(asciCode == ',') & !(asciCode == ' ') & !(asciCode == '?'))
        {
          throw new ArgumentException();
        }
      }
      if (!int.TryParse(key, out int result))
        throw new ArgumentException();
    }

      private static string InnerEncode(string plainMessage, int key)
        => CodeEncode(plainMessage, key);

    private static string InnerDecode(string encryptedMessage, int key)
        => CodeEncode(encryptedMessage, -key);

    public string Encode(string message, string key)
    {
      CheckData(message, key);
      return InnerEncode(message, Int32.Parse(key));
    }
    public string Decode(string message, string key)
    {
      CheckData(message, key);
      return InnerDecode(message, Int32.Parse(key));
    }
  }
}
