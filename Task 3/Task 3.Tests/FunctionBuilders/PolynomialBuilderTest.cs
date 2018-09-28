using System.Collections.Generic;
using NUnit.Framework;
using Task_3.FunctionBuilders;
using Task_3.Functions;

namespace Task_3.Tests.FunctionBuilders
{
    internal class PolynomialBuilderTest
    {
        [Test]
        public void Build_Polynomial_CorrectResultReturned()
        {
            var polynomialBuilder = new PolynomialBuilder();
            var res = polynomialBuilder.Build("4x^3+5x^2+3x+2");
            var expected = new Polynomial(new List<double> { 2, 3, 5, 4 });
            Assert.AreEqual(expected, res);
        }

        [Test]
        public void Build_PolynomialHas1Coefficient_CorrectResultReturned()
        {
            var polynomialBuilder = new PolynomialBuilder();
            var res = polynomialBuilder.Build("x^3");
            var expectedResult = new Polynomial(new List<double> { 0, 0, 0, 1 });
            Assert.AreEqual(expectedResult, res);
        }

        [Test]
        public void Build_PolynomialHasCoefficientsLessThen0_CorrectResultReturned()
        {
            var polynomialBuilder = new PolynomialBuilder();
            var res = polynomialBuilder.Build("-x^4-x^2-x");
            var expectedResult = new Polynomial(new List<double> { 0, -1, -1, 0, -1 });
            Assert.AreEqual(expectedResult, res);
        }
    }
}
