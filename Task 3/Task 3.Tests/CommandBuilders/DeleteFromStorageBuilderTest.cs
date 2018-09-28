using Moq;
using NUnit.Framework;
using Task_3.CommandBuilders;
using Task_3.FunctionStorages;

namespace Task_3.Tests.CommandBuilders
{
    internal class DeleteFromStorageBuilderTest
    {
        [Test]
        public void Build_BuildDeleteFromStorageCommand_CommandReturned()
        {
            var mock = new Mock<IFunctionStorage>();
            var command = new DeleteFromStorageBuilder();
            mock.Setup(x => x.IsStored("name")).Returns(true);
            var res = command.Build("Delete name").Execute(mock.Object);
            const string expectedResult = "Функция удалена";
            Assert.AreEqual(expectedResult, res);
        }
    }
}
