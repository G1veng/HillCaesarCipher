using System;
using System.Collections.Generic;
using System.Text;

namespace HillCipher
{
  interface ICipher
  {
    //Even numbers - cipher with int key
    //Odd numbers - cipher with string key
    public enum Algorithms
    {
      HillCipher = 1,
      CaesarCipher = 2,
    }
    string Encode(string message, string key);
    string Decode(string message, string key);
  }
}
