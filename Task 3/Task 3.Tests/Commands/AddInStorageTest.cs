using NUnit.Framework;
using Task_3.Commands;
using Task_3.Functions;
using Task_3.FunctionStorages;

namespace Task_3.Tests.Commands
{
    internal class AddInStorageTest
    {
        [Test]
        public void Execute_AddFunction_FunctionWillBeAdded()
        {
            var fs = new FunctionStorage();
            var command = new AddInStorage("name",new Cos());
            var res = command.Execute(fs);
            const string expectedResult = "Функция добавлена";
            Assert.AreEqual(expectedResult, res);
        }

        [Test]
        public void Execute_AddExistingFunctionFunction_ErrorReturned()
        {
            var fs = new FunctionStorage();
            var command = new AddInStorage("name", new Cos());
            fs.Add("name",new Sin());
            var res = command.Execute(fs);
            const string expectedResult = "name уже используется";
            Assert.AreEqual(expectedResult, res);
        }
    }
}
