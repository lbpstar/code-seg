using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestDemo.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {
            int a = 100;
            int b = 10;
            Assert.AreEqual(Program.Add(a, b), 120);
        }
    }
}