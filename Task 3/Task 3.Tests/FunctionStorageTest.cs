using System;
using NUnit.Framework;
using Task_3.Functions;
using Task_3.FunctionStorages;

namespace Task_3.Tests
{
    public class FunctionStorageTest
    {
        [Test]
        public void Add_FunctionNameNotUsed_FunctionWillBeAdded()
        {
            var fs = new FunctionStorage();
            fs.Add("Name", new Linear(2, 1));
        }


        [Test]
        public void Add_FunctionNameUsed_ExceptionReturned()
        {
            var fs = new FunctionStorage();
            fs.Add("Name", new Linear(1, 2));
            Assert.Catch<Exception>(() => fs.Add("Name", new Linear(2, 1)));
        }

        [Test]
        public void Delete_DeleteExistingFunction_FunctionWillBeDeleted()
        {
            var fs = new FunctionStorage();
            fs.Add("Name", new Cos());
            fs.Delete("Name");
            fs.Add("Name", new Cos());
        }

        [Test]
        public void Delete_DeleteNonExistentFunction_ExceptionReturned()
        {
            var fs = new FunctionStorage();
            Assert.Catch<Exception>(() => fs.Delete("Name"));
        }

        [Test]
        public void Rename_RenameExistingFunction_FunctionWillBeRenamed()
        {
            var fs = new FunctionStorage();
            fs.Add("Name", new Cos());
            fs.Rename("Name", "Name1");
            fs.Add("Name", new Cos());
        }

        [Test]
        public void Rename_RenameNonExistentFunction_ExceptionReturned()
        {
            var fs = new FunctionStorage();
            Assert.Catch<Exception>(() => fs.Rename("Name", "Name1"));
        }

        [Test]
        public void ValueAtThePoint_ExistingFunction_ValueWillBeCalculated()
        {
            var fs = new FunctionStorage();
            fs.Add("Name", new Linear(2, 1));
            const double point = 2;
            const int expectedResult = 5;
            Assert.AreEqual(expectedResult, fs.ValueAtThePoint("Name", point));
        }

        [Test]
        public void ValueAtThePoint_ValueNonExistentFunction_ExceptionReturned()
        {
            var fs = new FunctionStorage();
            const double point = 2;
            Assert.Catch<Exception>(() => fs.ValueAtThePoint("Name", point));
        }

        [Test]
        public void Derivative_DerivativeExistingFunction_DerivativeWillBeCalculated()
        {
            var fs = new FunctionStorage();
            fs.Add("Name", new Linear(2, 1));
            var expectedResult = new Linear(0, 2);
            Assert.AreEqual(expectedResult, fs.Derivative("Name"));
        }

        [Test]
        public void Derivative_DerivativeNonExistentFunction_ExceptionReturned()
        {
            var fs = new FunctionStorage();
            Assert.Catch<Exception>(() => fs.Derivative("Name"));
        }
    }
}
