using Moq;
using NUnit.Framework;
using Task_3.CommandBuilders;
using Task_3.FunctionStorages;

namespace Task_3.Tests.CommandBuilders
{
    internal class AddInStorageBuilderTest
    {
        [Test]
        public void Build_BuildAddInStorageCommand_CommandReturned()
        {
            var mock = new Mock<IFunctionStorage>();
            var command = new AddInStorageBuilder();
            mock.Setup(x => x.IsStored("name")).Returns(false);
            var res = command.Build("Add name linear x").Execute(mock.Object);
            const string expectedResult = "Функция добавлена";
            Assert.AreEqual(expectedResult, res);
        }
    }
}
