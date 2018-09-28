using System;
using NUnit.Framework;
using Task_3.Functions;

namespace Task_3.Tests.Functions
{
    class UnaryMinusOfFunctionTest
    {
        [Test]
        public void Derivative_Sin_CorrectResultReturned()
        {
            var a = new UnaryMinusOfFunction(new Sin());
            var expectedResult = new Cos();
            Assert.AreEqual(expectedResult, a.Derivative());
        }

        [Test]
        public void ValueAtPoint_Sin_CorrectResultReturned()
        {
            var a = new UnaryMinusOfFunction(new Sin());
            const double X = 1;
            var expectedResult = Math.Sin(-X);
            Assert.AreEqual(expectedResult, a.ValueAtPoint(X));
        }
    }
}
