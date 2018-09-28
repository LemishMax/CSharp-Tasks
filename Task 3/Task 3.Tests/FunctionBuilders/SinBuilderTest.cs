using NUnit.Framework;
using Task_3.FunctionBuilders;
using Task_3.Functions;

namespace Task_3.Tests.FunctionBuilders
{
    internal class SinBuilderTest
    {
        [Test]
        public void Build_Sin_CorrectResultReturned()
        {
            var sinBuilder = new SinBuilder();
            var res = sinBuilder.Build("Sin");
            var expectedResult = new Sin();
            Assert.AreEqual(expectedResult, res);
        }
    }
}
