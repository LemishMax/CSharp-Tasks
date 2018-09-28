using NUnit.Framework;
using Task_3.FunctionBuilders;
using Task_3.Functions;

namespace Task_3.Tests.FunctionBuilders
{
    internal class LinearFunctionBuilderTest
    {
        [Test]
        public void Build_TestOfParseMinusCoefficients_CorrectResultReturned()
        {
            var linearBuilder = new LinearBuilder();
            var res = linearBuilder.Build("-2.5x-11");
            var expectedResult = new Linear(-2.5, -11);
            Assert.AreEqual(expectedResult, res);
        }

        [Test]
        public void Build_KEqualsZero_CorrectResultReturned()
        {
            var linearBuilder = new LinearBuilder();
            var res = linearBuilder.Build("x+1");
            var expected = new Linear(1, 1);
            Assert.AreEqual(expected, res);
        }

        [Test]
        public void Build_KEqualsMinus_CorrectResultReturned()
        {
            var linearBuilder = new LinearBuilder();
            var res = linearBuilder.Build("-x");
            var expected = new Linear(-1, 0);
            Assert.AreEqual(expected, res);
        }
    }
}
