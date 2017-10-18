using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SudokuSolver;

namespace Tests
{
    [TestClass]
    public class ArrayExtensionTests
    {
        [TestMethod]
        public void Remove_Test()
        {
            int[] a = new int[] { 0, 1, 2, 3, 4, 5 };
            int[] result = a.Remove(2);
            Assert.IsTrue(result.SequenceEqual(new int[] { 0, 1, 3, 4, 5 }));
        }

        [TestMethod]
        public void Contains_Test()
        {
            int[] a = new int[] { 0, 1, 2, 3, 4, 5 };
            Assert.IsTrue(a.Contains(4));
            Assert.IsFalse(a.Contains(9));
        }

    }
}
