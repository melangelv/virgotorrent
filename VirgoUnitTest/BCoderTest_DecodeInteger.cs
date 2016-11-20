using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Virgo;

namespace VirgoUnitTest
{
    [TestClass]
    public class BCoderTest_DecodeInteger
    {
        [TestMethod]
        public void DecodeIntegerValidNumber()
        {
            int actual = BCoder.DecodeInteger("i95e");
            int expected = 95;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecodeIntegerZeroValid()
        {
            int actual = BCoder.DecodeInteger("i0e");
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecodeIntegerNegativeNumberValid()
        {
            int actual = BCoder.DecodeInteger("i-9e");
            int expected = -9;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DecodeIntegerNegativeZeroInvalid()
        {
            try
            {
                int actual = BCoder.DecodeInteger("i-0e");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                
            }
        }
        [TestMethod]
        public void DecodeIntegerStartWithZeroInvalid()
        {
            try
            {
                int actual = BCoder.DecodeInteger("i09e");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                
            }
        }
        [TestMethod]
        public void DecodeIntegerJustMinusInvalid()
        {
            try
            {
                int actual = BCoder.DecodeInteger("i-e");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                
            }
        }
        [TestMethod]
        public void DecodeIntegerEmptyContentInvalid()
        {
            try
            {
                int actual = BCoder.DecodeInteger("ie");
                Assert.Fail();
            }
            catch (ArgumentException)
            {

            }
        }
        [TestMethod]
        public void DecodeIntegerEmptyInputInvalid()
        {
            try
            {
                int actual = BCoder.DecodeInteger("");
                Assert.Fail();
            }
            catch (ArgumentException)
            {

            }
        }
        [TestMethod]
        public void DecodeIntegerNullInputInvalid()
        {
            try
            {
                int actual = BCoder.DecodeInteger(null);
                Assert.Fail();
            }
            catch (ArgumentException)
            {

            }
        }
        [TestMethod]
        public void DecodeIntegerGarbageStringInvalid()
        {
            try
            {
                int actual = BCoder.DecodeInteger("sj1s910j9101uj3901");
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                
            }
        }
        [TestMethod]
        public void DecodeIntegerFakeStringInvalid()
        {
            try
            {
                int actual = BCoder.DecodeInteger("i293920oejdjd203e");
                Assert.Fail();
            }
            catch (ArgumentException)
            {

            }
        }
    }
}
