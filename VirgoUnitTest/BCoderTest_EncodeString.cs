using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VirgoUnitTest
{
    [TestClass]
    public class BCoderTest_EncodeString
    {
        [TestMethod]
        public void EncodeStringValid()
        {
            string actual = Virgo.BCoder.EncodeString("virgo");
            string expected = "5:virgo";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EncodeStringNullInvalid()
        {
            try
            {
                Virgo.BCoder.EncodeString(null);
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void EncodeStringEmptyInvalid()
        {
            try
            {
                Virgo.BCoder.EncodeString("");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
        [TestMethod]
        public void EncodeStringSpacedInvalid()
        {
            try
            {
                Virgo.BCoder.EncodeString("   ");
                Assert.Fail();
            }
            catch (ArgumentException) { }
        }
    }
}
