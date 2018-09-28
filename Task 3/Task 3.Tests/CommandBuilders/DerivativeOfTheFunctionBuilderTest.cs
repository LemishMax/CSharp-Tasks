using Moq;
using NUnit.Framework;
using Task_3.CommandBuilders;
using Task_3.FunctionStorages;

namespace Task_3.Tests.CommandBuilders
{
    internal class DerivativeOfTheFunctionBuilderTest
    {
        [Test]
        public void Build_BuildDerivativeOfTheFunctionCommand_CommandReturned()
        {
            var mock = new Mock<IFunctionStorage>();
            var command = new DerivativeOfTheFunctionBuilder();
            mock.Setup(x => x.IsStored("name")).Returns(true);
            var res = command.Build("Derivative name").Execute(mock.Object);
            const string expectedResult = "Функция добавлена в хранилище.\nПроизводная name = ";
            mock.Verify(x => x.Derivative("name"));
            Assert.AreEqual(expectedResult, res);

        }
    }
}
