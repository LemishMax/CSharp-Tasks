using NUnit.Framework;
using Task_3.Commands;
using Task_3.Functions;
using Task_3.FunctionStorages;

namespace Task_3.Tests.Commands
{
    internal class ValueFunctionTest
    {
        [Test]
        public void Execute_ExistingFunction_ValueWillBeCalculated()
        {
            var fs = new FunctionStorage();
            fs.Add("Name", new Linear(2, 1));
            const double point = 2;
            var command = new ValueFunction("Name", point);
            var res = command.Execute(fs);
            const string expectedResult = "Значение Name в точке 2 = 5";
            Assert.AreEqual(expectedResult, res);
        }


        [Test]
        public void Execute_ValueNonExistentFunction_ErrorReturned()
        {
            var fs = new FunctionStorage();
            var command = new ValueFunction("Name", 2);
            const string expectedResult = "Name не найдена";
            Assert.AreEqual(expectedResult, command.Execute(fs));
        }

    }
}
