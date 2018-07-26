using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;

namespace NunitDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
        }
        public static int Add(int pNum1, int pNum2)
        {
            return pNum1 + pNum2;
        }
    }
    [TestFixture()]
    public class ProgramTests
    {
        [Test()]
        public void AddTest()
        {
            int a = 100;
            int b = 10;
            Assert.AreEqual(Program.Add(a, b), 110);
        }
    }
}
