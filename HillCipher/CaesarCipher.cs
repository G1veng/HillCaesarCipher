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
      var fullAlfabet = alfabet + alfabet.ToLower();
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

    private static string InnerEncode(string plainMessage, int key)
        => CodeEncode(plainMessage, key);

    private static string InnerDecode(string encryptedMessage, int key)
        => CodeEncode(encryptedMessage, -key);

    public string Encode(string message, string key)
    {
      return InnerEncode(message, Int32.Parse(key));
    }
    public string Decode(string message, string key)
    {
      return InnerDecode(message, Int32.Parse(key));
    }
  }
}
