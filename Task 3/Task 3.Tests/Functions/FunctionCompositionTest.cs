using System;
using NUnit.Framework;
using Task_3.Functions;

namespace Task_3.Tests.Functions
{
    class FunctionCompositionTest
    {
        [Test]
        public void Derivative_CosSin_CorrectResultReturned()
        {
            Function a = new Cos();
            Function b = new Sin();
            var c = new FunctionComposition(a, b);
            const double X = 1;
            var expectedResult = Math.Sin(-Math.Cos(X));
            Assert.AreEqual(expectedResult, c.Derivative().ValueAtPoint(X));
        }

        [Test]
        public void ValueAtPoint_LinearSin_CorrectResultReturned()
        {
            Function a = new Sin();
            Function b = new Cos();
            var c = new FunctionComposition(a, b);
            const double X = 1;
            var expectedResult = Math.Sin(Math.Cos(X));
            Assert.AreEqual(expectedResult, c.ValueAtPoint(X));
        }
    }
}
