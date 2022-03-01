using Microsoft.VisualStudio.TestTools.UnitTesting;
using HillCipher;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillCipher.Tests
{
  [TestClass()]
  public class CaesarCipherTests
  {
    [TestMethod()]
    public void EncodeTest()
    {
      string expectedEncodeAnswer = "ЭНЩХ";
      string message = "ШИФР";
      string key = "5";
      CaesarCipher algorithm = new CaesarCipher();
      Assert.AreEqual(expectedEncodeAnswer, algorithm.Encode(message, key));
    }

    [TestMethod()]
    public void DecodeTest()
    {
      string expectedDecodeAnswer = "ШИФР";
      string message = "ЭНЩХ";
      string key = "5";
      CaesarCipher algorithm = new CaesarCipher();
      Assert.AreEqual(expectedDecodeAnswer, algorithm.Decode(message, key));
    }
  }
}