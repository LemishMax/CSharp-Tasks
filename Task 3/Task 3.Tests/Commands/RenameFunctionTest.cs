using NUnit.Framework;
using Task_3.Commands;
using Task_3.Functions;
using Task_3.FunctionStorages;

namespace Task_3.Tests.Commands
{
    internal class RenameFunctionTest
    {
        [Test]
        public void Execute_RenameExistingFunction_FunctionWillBeRenamed()
        {
            var fs = new FunctionStorage();
            fs.Add("oldName", new Cos());
            var command = new RenameFunction("oldName", "newName");
            var res = command.Execute(fs);
            const string expectedResult = "Функция перименована";
            Assert.AreEqual(expectedResult, res);
        }

        [Test]
        public void Execute_RenameNonExistentFunction_ErrorReturned()
        {
            var fs = new FunctionStorage();
            var command = new RenameFunction("name", "newName");
            const string expectedResult = "name не найдена";
            Assert.AreEqual(expectedResult, command.Execute(fs));
        }
    }
}
