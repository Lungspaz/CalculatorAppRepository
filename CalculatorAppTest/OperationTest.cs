using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CalculatorApp {
    [TestClass]
    public class OperationTest {

        [TestMethod]
        public void DivisionTest() {

            List<double> inputs = new List<double>() { 3, 0 };
            Division division = new Division();
            double result = division.Calculate(inputs);
        }
    }
}
