using Moq;
using NUnit.Framework;
using Task_3.CommandBuilders;
using Task_3.FunctionStorages;

namespace Task_3.Tests.CommandBuilders
{
    internal class ValueFunctionBuilderTest
    {
        [Test]
        public void Build_BuildValueFunctionCommand_CommandReturned()
        {
            var mock = new Mock<IFunctionStorage>();
            var command = new ValueFunctionBuilder();
            mock.Setup(x => x.IsStored("name")).Returns(true);
            var res = command.Build("name(1)").Execute(mock.Object);
            mock.Verify(x => x.ValueAtThePoint("name", 1));
            const string expectedResult = "Значение name в точке 1 = 0";
            Assert.AreEqual(expectedResult, res);
        }
    }
}
