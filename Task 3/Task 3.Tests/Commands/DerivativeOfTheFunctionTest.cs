using NUnit.Framework;
using Task_3.Commands;
using Task_3.Functions;
using Task_3.FunctionStorages;

namespace Task_3.Tests.Commands
{
    internal class DerivativeOfTheFunctionTest
    {
        [Test]
        public void Execute_DerivativeExistingFunction_DerivativeWillBeCalculated()
        {
            var fs = new FunctionStorage();
            fs.Add("Name", new Linear(2, 1));
            var command = new DerivativeOfTheFunction("Name");
            var res = command.Execute(fs);
            const string expectedResult = "Функция добавлена в хранилище.\nПроизводная Name = 2";
            Assert.AreEqual(expectedResult, res);
        }

        [Test]
        public void Execute_DerivativeNonExistentFunction_ErrorReturned()
        {
            var fs = new FunctionStorage();
            var command = new DerivativeOfTheFunction("Name");
            const string expectedResult = "Name не найдена";
            Assert.AreEqual(expectedResult, command.Execute(fs));
        }
    }
}
