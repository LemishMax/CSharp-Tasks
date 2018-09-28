using System;
using NUnit.Framework;
using Task_3.Functions;

namespace Task_3.Tests.Functions
{
    public class SinTest
    {
        [Test]
        public void Derivative_Sin_CorrectResultReturned()
        {
            var sin = new Sin();
            var expectedResult =new Cos();
            Assert.AreEqual(expectedResult, sin.Derivative());
        }

        [Test]
        public void ValueAtThePoint_Sin_CorrectResultReturned()
        {
            Function a = new Sin();
            const double x = 1;
            var expectedResult = Math.Sin(x);
            Assert.AreEqual(expectedResult, a.ValueAtPoint(x));
        }
    }
}
