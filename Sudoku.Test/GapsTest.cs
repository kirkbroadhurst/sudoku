using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Sudoku;

namespace UnitTestProject1
{
    [TestClass]
    public class GapsTest
    {
        [TestMethod]
        public void TestTwoValues()
        {
            var values = new List<int> { 1, 2, 3, 4, 5, 6, 7 };
            var result = Game.Gaps(values);
            Assert.IsTrue(result.Count == 2);
            Assert.IsTrue(result.Contains(8));
            Assert.IsTrue(result.Contains(9));
        }
    }
}
