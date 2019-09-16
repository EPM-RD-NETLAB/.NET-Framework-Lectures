using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ClassForUnitTest;

namespace NUnitTest
{
    [TestFixture]
    public class ClassTest
    {
        [Test]
        public void DoCalculationsTest()
        {
            string s = "5";
            int expected = 125;
            int actual = Class1.DoCalculations(s);
            Assert.AreEqual(expected, actual);
        }
    }
}
