using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace CRC {
  [TestFixture()]
  public class Test {

    [Test()]
    public void Autosar_ItCalculates() {
      byte[] testData = Encoding.ASCII.GetBytes("123456789");

      byte expected = 0x4B;
      byte given = CrcAutosar.Calculate(testData);


      Assert.AreEqual(expected, given);
    }

    [Test()]
    public void Autosar_ItChecks() {
      byte[] testData = Encoding.ASCII.GetBytes("123456789");
      byte[] crc = { 0x4b };
      byte[] input = new byte[testData.Length + crc.Length];

      Buffer.BlockCopy(testData, 0, input, 0, testData.Length);
      Buffer.BlockCopy(crc, 0, input, testData.Length, crc.Length);

      bool given = CrcAutosar.Check(input);
      Assert.IsTrue(given);
    }

    [Test()]
    public void Ccitt_ItCalculates() {
      byte[] testData = Encoding.ASCII.GetBytes("123456789");

      UInt16 expected = 0x29B1;
      UInt16 given = CrcCcitt.Calculate(testData);


      Assert.AreEqual(expected, given);
    }

    [Test()]
    public void Ccitt_ItChecks() {
      byte[] testData = Encoding.ASCII.GetBytes("123456789");
      byte[] crc = { 0x29, 0xB1 };
      byte[] input = new byte[testData.Length + crc.Length];

      Buffer.BlockCopy(testData, 0, input, 0, testData.Length);
      Buffer.BlockCopy(crc, 0, input, testData.Length, crc.Length);

      bool given = CrcCcitt.Check(input);
      Assert.IsTrue(given);
    }

  }
}
