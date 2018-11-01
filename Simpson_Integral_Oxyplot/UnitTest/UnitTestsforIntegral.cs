using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simpson_Integral_Oxyplot;

namespace UnitTest {
    [TestClass]
    public class UnitTestsforIntegral {
        [TestMethod]
        public void Testing_Single_Integral_xx() {
            double a = 0;
            double b = 100;
            int n = 10000000;
            double ext = 333333.333;
            simpson integral = new simpson();
            double result = integral.calcPosl(n, a, b, x => x * x);

            Assert.AreEqual(ext, result, 0.1);
            
        }

        [TestMethod]
        public void Testing_Parallel_Integral_xx() {
            double a = 0;
            double b = 100;
            int n = 10000000;
            double ext = 333333.333;
            simpson integral = new simpson();
            double result = integral.calcParallel(n, a, b, x => x * x);

            Assert.AreEqual(ext, result, 0.1);

        }
       
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Testing_Posl_Integral_not_N() {
            double a = 0;
            double b = 100;
            int n = -10000000;
            double ext = 333333.333;
            simpson integral = new simpson();
            double result = integral.calcPosl(n, a, b, x => x * x);

            Assert.Fail();

        }

        [TestMethod]
        public void Testing_Parallel_Integral_Not_Equal() {
            double a = 0;
            double b = 100;
            int n = 10000000;
            double ext = 433333.333;
            simpson integral = new simpson();
            double result = integral.calcParallel(n, a, b, x => x * x);

            Assert.AreNotEqual(ext, result, 0.1);

        }
    }
}
