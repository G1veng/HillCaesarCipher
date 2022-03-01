using Microsoft.VisualStudio.TestTools.UnitTesting;
using HillCipher;
using System;
using System.Collections.Generic;
using System.Text;

namespace HillCipher.Tests
{
  [TestClass()]
  public class HillCipherTests
  {
    [TestMethod()]
    public void EncodeTest()
    {
      string expectedEncodeAnswer = "АЮНЧХЯ";
      string message = "ШИФР";
      string key = "АЛЬПИНИЗМ";
      HillCipher algorithm = new HillCipher();
      Assert.AreEqual(expectedEncodeAnswer, algorithm.Encode(message, key));
    }

    [TestMethod()]
    public void DecodeTest()
    {
      string message = "АЮНЧХЯ";
      string expectedDecodeAnswer = "ШИФР";
      string key = "АЛЬПИНИЗМ";
      HillCipher algorithm = new HillCipher();
      Assert.AreEqual(expectedDecodeAnswer, algorithm.Decode(message, key));
    }
  }
}