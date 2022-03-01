using System;
using System.Collections.Generic;
using System.Text;

namespace HillCipher
{
  static class GetInput
  {
    public enum UserChoice
    {
      ConsoleInput = 1,
      FileInput,
      RandomInput,
      End
    }
    static public IInputData GetSomeInput(int choice)
    {
      IInputData someInput = null;
      if((UserChoice)choice == UserChoice.ConsoleInput)
      {
        someInput = new ManualInput();
      }
      if ((UserChoice)choice == UserChoice.RandomInput)
      {
        someInput = new RandomInput();
      }
      if ((UserChoice)choice == UserChoice.FileInput)
      {
        someInput = new FileInput();
      }
      return someInput;
    }
    static public ICipher GetAlgorithm(int choice)
    {
      if((ICipher.Algorithms)choice == ICipher.Algorithms.CaesarCipher)
      {
        return new CaesarCipher();
      }
      if ((ICipher.Algorithms)choice == ICipher.Algorithms.HillCipher)
      {
        return new HillCipher();
      }
      return null;
    }
  }
}
