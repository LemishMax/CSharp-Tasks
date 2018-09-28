using Moq;
using NUnit.Framework;
using Task_3.CommandBuilders;
using Task_3.FunctionStorages;

namespace Task_3.Tests.CommandBuilders
{
    internal class RenameFunctionBuilderTest
    {
        [Test]
        public void Build_BuildRenameFunctionCommand_CommandReturned()
        {
            var mock = new Mock<IFunctionStorage>();
            var command = new RenameFunctionBuilder();
            mock.Setup(x => x.IsStored("oldName")).Returns(true);
            mock.Setup(x => x.IsStored("newName")).Returns(false);
            var res = command.Build("Rename oldName newName").Execute(mock.Object);
            const string expectedResult = "Функция перименована";
            Assert.AreEqual(expectedResult, res);
        }
    }
}
