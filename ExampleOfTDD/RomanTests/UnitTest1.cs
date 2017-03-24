using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanNumeralsClass;

namespace RomanTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SanityCheck()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Given_1_return_I()
        {
            RomanConverter rc = new RomanConverter();
            Assert.AreEqual("I", rc.GetRoman(1));
        }

        [TestMethod]
        public void Given_2_return_II()
        {
            RomanConverter rc = new RomanConverter();
            Assert.AreEqual("II", rc.GetRoman(2));
        }

        [TestMethod]
        public void Given_4_return_IV()
        {
            RomanConverter rc = new RomanConverter();
            Assert.AreEqual("IV", rc.GetRoman(4));
        }
    }
}
