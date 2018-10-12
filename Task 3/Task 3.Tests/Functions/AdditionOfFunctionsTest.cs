using System;
using NUnit.Framework;
using Task_3.Functions;

namespace Task_3.Tests.Functions
{
    class AdditionOfFunctionsTest
    {
        [Test]
        public void Derivative_CosPlusSin_CorrectResultReturned()
        {
            Function a = new Cos();
            Function b = new Sin();
            var res = a + b;
            var expectedResult = new AdditionOfFunctions(new UnaryMinusOfFunction(new Sin()), new Cos());
            Assert.AreEqual(expectedResult, res.Derivative());
        }

        [Test]
        public void ValueAtPoint_LinearPlusSin_CorrectResultReturned()
        {
            Function a = new Linear(3, 5);
            Function b = new Sin();
            var c = a + b;
            const double X = 1;
            var expectedResult = a.ValueAtPoint(1) + Math.Sin(X);
            Assert.AreEqual(expectedResult, c.ValueAtPoint(X));
        }
    }
}
