using System;
using System.Collections.Generic;
using System.Text;

namespace HillCipher
{
  interface ICipher
  {
    public enum Algorithms
    {
      HillCipher = 1,
      CaesarCipher
    }
    abstract string Encode(string message, string key);
    abstract string Decode(string message, string key);
  }
}
