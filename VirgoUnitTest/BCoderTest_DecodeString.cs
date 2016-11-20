using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VirgoUnitTest
{
    [TestClass]
    public class BCoderTest_DecodeString
    {
        [TestMethod]
        public void DecodeStringLengthPrefixedStringValid()
        {
            string actual = Virgo.BCoder.DecodeString("5:virgo");
            string expected = "virgo";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecodeStringLengthPrefixedStringComplexValid()
        {
            string actual = Virgo.BCoder.DecodeString("13:virgo:awesome");
            string expected = "virgo:awesome";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecodeStringNotLengthPrefixedInvalid()
        {
            try
            {
                string actual = Virgo.BCoder.DecodeString("virgo");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                
            }
        }
        [TestMethod]
        public void DecodeStringFakeLengthPrefixedInvalid()
        {
            try
            {
                string actual = Virgo.BCoder.DecodeString(":virgo");
                Assert.Fail();
            }
            catch (ArgumentException)
            {

            }
        }
        [TestMethod]
        public void DecodeStringOvershootInvalid()
        {
            try
            {
                string actual = Virgo.BCoder.DecodeString("100:virgo");
                Assert.Fail();
            }
            catch (ArgumentException)
            {

            }
        }
        [TestMethod]
        public void DecodeStringEmptyStringInvalid()
        {
            try
            {
                string actual = Virgo.BCoder.DecodeString("");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                
            }
        }
        [TestMethod]
        public void DecodeStringNullStringInvalid()
        {
            try
            {
                string actual = Virgo.BCoder.DecodeString(null);
                Assert.Fail();
            }
            catch (ArgumentException)
            {

            }
        }
        [TestMethod]
        public void DecodeStringGarbageStringInvalid()
        {
            try
            {
                string actual = Virgo.BCoder.DecodeString("lsjhaqıuaıojuhwoe");
                Assert.Fail();
            }
            catch (ArgumentException)
            {

            }
        }
    }
}
