using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Virgo;
using System.Collections.Generic;
using System.Diagnostics;

namespace VirgoUnitTest
{
    [TestClass]
    public class BCoderTest_DecodeList
    {
        [TestMethod]
        public void DecodeListValid1()
        {
            List<object> expected = new List<object>();
            expected.Add(4);
            expected.Add(5);
            List<object> actual = BCoder.DecodeList("li4ei5ee");
            CheckListsAreEqual(expected, actual);
        }

        private static void CheckListsAreEqual(List<object> expected, List<object> actual)
        {
            bool failed = false;
            foreach (object c in actual)
            {
                failed = true;
                foreach (object d in expected)
                {
                    if (c.Equals(d)) failed = false;
                }
                if (failed) Assert.Fail();
            }
            
        }
        [TestMethod]
        public void DecodeListValid2()
        {
            List<object> expected = new List<object>();
            expected.Add("abc");
            expected.Add("123");
            List<object> actual = BCoder.DecodeList("l3:abc3:123e");
            CheckListsAreEqual(expected, actual);
        }
    }
}
