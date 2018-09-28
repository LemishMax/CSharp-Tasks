using System;
using NUnit.Framework;
using Task_3.Functions;

namespace Task_3.Tests.Functions
{
    public class CosTest
    {
        [Test]
        public void Derivative_Cos_CorrectResultReturned()
        {
            var cos = new Cos();
            var expectedResult = new UnaryMinusOfFunction(new Sin());
            Assert.AreEqual(expectedResult, cos.Derivative());
        }

        [Test]
        public void ValueAtThePoint_Cos_CorrectResultReturned()
        {
            Function a = new Cos();
            const double x = 1;
            var expectedResult = Math.Cos(x);
            Assert.AreEqual(expectedResult, a.ValueAtPoint(x));
        }
    }
}
