using NUnit.Framework;
using Task_3.Commands;
using Task_3.Functions;
using Task_3.FunctionStorages;

namespace Task_3.Tests.Commands
{
    internal class DeleteFromStorageTest
    {
        [Test]
        public void Execute_DeleteExistingFunction_FunctionWillBeDeleted()
        {
            var fs = new FunctionStorage();
            var command = new DeleteFromStorage("name");
            fs.Add("name", new Cos());
            var res = command.Execute(fs);
            const string expectedResult = "Функция удалена";
            Assert.AreEqual(expectedResult,res);
        }

        [Test]
        public void Execute_DeleteNonExistentFunction_ErrorReturned()
        {
            var fs = new FunctionStorage();
            var command = new DeleteFromStorage("name");
            const string expectedResult = "name не найдена";
            Assert.AreEqual(expectedResult, command.Execute(fs));
        }
    }
}
