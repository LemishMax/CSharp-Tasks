using System;
using System.Collections.Generic;
using Task_3.CommandBuilders;
using Task_3.FunctionStorages;

namespace Task_3
{
    /// <summary>
    /// Основной класс.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            var commands = new Dictionary<string, CommandBuilder>
            {
                {"^[A|a]dd \\w+", new AddInStorageBuilder()},
                {"^[D|d]elete \\w+", new DeleteFromStorageBuilder()},
                {"^[R|r]ename \\w+ \\w+", new RenameFunctionBuilder()},
                {"^\\w+\\(-?[0-9]+(,[0-9]+)?\\)", new ValueFunctionBuilder()},
                {"^[D|d]erivative \\w+", new DerivativeOfTheFunctionBuilder()}
            };

            var fs = new FunctionStorage();
            var interpreter = new Interpreter(fs, commands);
            var command = "";
            while (command != "exit")
            {
                command = Console.ReadLine();
                Console.WriteLine(interpreter.Parse(command));
            }
        }
    }
}
