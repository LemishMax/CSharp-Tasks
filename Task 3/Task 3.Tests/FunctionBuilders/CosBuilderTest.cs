using NUnit.Framework;
using Task_3.FunctionBuilders;
using Task_3.Functions;

namespace Task_3.Tests.FunctionBuilders
{
    internal class CosBuilderTest
    {
        [Test]
        public void Build_Cos_CorrectResultReturned()
        {
            var cosBuilder = new CosBuilder();
            var res = cosBuilder.Build("Cos");
            var expectedResult = new Cos();
            Assert.AreEqual(expectedResult, res);
        }
    }
}
