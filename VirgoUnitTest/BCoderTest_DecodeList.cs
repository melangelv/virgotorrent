using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Virgo;
using System.Collections.Generic;

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

            foreach(object c in actual)
            {
                if (! expected.Contains(c))
                {

                }
            }
        }
    }
}
