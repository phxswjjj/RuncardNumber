using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib.Tests
{
    [TestClass()]
    public class MyNumberTests
    {
        [TestMethod()]
        public void NextTest()
        {
            var generator = new MyNumber(1);
            Assert.AreEqual("1", generator.Next());
            Assert.AreEqual("2", generator.Next());
            Assert.AreEqual(7, generator.Nexts(7).Count);
            Assert.AreEqual("A", generator.Next());
            Assert.AreEqual("Z", generator.Nexts(25).Last());
            Assert.IsTrue(string.IsNullOrEmpty(generator.Next()));
        }
    }
}