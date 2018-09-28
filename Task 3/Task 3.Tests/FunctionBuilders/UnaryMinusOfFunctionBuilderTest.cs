using System.Collections.Generic;
using NUnit.Framework;
using Task_3.CommandBuilders;
using Task_3.Functions;

namespace Task_3.Tests.FunctionBuilders
{
    internal class UnaryMinusOfFunctionBuilderTest
    {
        [Test]
        public void BuiltFunction_FunctionContainsAdditionOfFunctions_CorrectResultReturned()
        {
            const string function = "u -(af l x+3 + p x^3-5)";
            var res = new AddInStorageBuilder().BuildFunction(function);
            var expectedResult = new UnaryMinusOfFunction(
                new AdditionOfFunctions(
                    new Linear(1, 3),
                    new Polynomial(new List<double> { -5, 0, 0, 1 })));
            Assert.AreEqual(expectedResult, res);
        }

        [Test]
        public void BuiltFunction_FunctionContainsTwoAdditionOfFunctions_CorrectResultReturned()
        {
            const string function = "u -(af l x+3 + af p x^3-5 + cos)";
            var res = new AddInStorageBuilder().BuildFunction(function);
            var expectedResult = new UnaryMinusOfFunction(
                new AdditionOfFunctions(new Linear(1, 3),
                    new AdditionOfFunctions(new Polynomial(new List<double> { -5, 0, 0, 1 }),
                        new Cos())));
            Assert.AreEqual(expectedResult, res);
        }

        [Test]
        public void BuiltFunction_FunctionContainsAdditionOfFunctionsAndSubtractionOfFunctions_CorrectResultReturned()
        {
            const string function = "u -(af l x+3 + sf p x^3-5 - l x)";
            var res = new AddInStorageBuilder().BuildFunction(function);
            var expectedResult = new UnaryMinusOfFunction
            (new AdditionOfFunctions(
                new Linear(1, 3),
                new SubtractionOfFunctions(
                    new Polynomial(new List<double> { -5, 0, 0, 1 }),
                    new Linear(1, 0))));
            Assert.AreEqual(expectedResult, res);
        }
    }
}
