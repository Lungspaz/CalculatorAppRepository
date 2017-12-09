using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CalculatorApp {
    [TestClass]
    public class ProgramTest {
        [TestMethod]
        public void TestExtractAndValidate() {

            double[] a = Program.ExtractAndValidate("1 2 3");
            Assert.AreEqual(3, a.Length);
            Assert.AreEqual(1, a[0]);
            Assert.AreEqual(2, a[1]);
            Assert.AreEqual(3, a[2]);
        }

        [TestMethod]
        public void TestGetValidOperations() {

            List<Operation> list = Program.GetValidOperations(3);
            Assert.AreEqual(3, list.Count);
            Assert.IsTrue(list[0] is Addition);
            Assert.IsTrue(list[1] is Subtraction);
            Assert.IsTrue(list[2] is Multiplication);
        }
    }
}
