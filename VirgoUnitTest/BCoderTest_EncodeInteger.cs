using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VirgoUnitTest
{
    /// <summary>
    /// Summary description for BCoderTest_EncodeInteger
    /// </summary>
    [TestClass]
    public class BCoderTest_EncodeInteger
    {
        public BCoderTest_EncodeInteger()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void EncodeIntegerPositiveNumberValid()
        {
            string actual = Virgo.BCoder.EncodeInteger(9);
            string expected = "i9e";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EncodeIntegerNegativeNumberValid()
        {
            string actual = Virgo.BCoder.EncodeInteger(-8);
            string expected = "i-8e";
            Assert.AreEqual(expected, actual);
        }
    }
}
