using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XUnitDemo;
using Xunit;

namespace XUnitDemoTest
{

    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()
        {
            int a = 100;
            int b = 10;
            Xunit.Assert.Equal(120,Program.Add(a, b));
        }
    }
}
