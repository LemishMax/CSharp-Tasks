namespace Task_3.CommandBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Commands;
    using FunctionBuilders;
    using Functions;

    internal class AddInStorageBuilder : CommandBuilder
    {
        private readonly Dictionary<string, FunctionBuilder> _functionBuilders = new Dictionary<string, FunctionBuilder>
        { 
            { "^[U|u](naryMinus)?", new UnaryMinusOfFunctionBuilder() },
            { "^[F|f](unction)?[C|c](omposition)?", new FunctionCompositionBuilder() },
            { "^[A|a](dditionOf)?[F|f](unction)?", new AdditionOfFunctionsBuilder() },
            { "^[S|s](ubstringOf)?[F|f](unction)?", new SubtractionOfFunctionsBuilder() },
            { "^[F|f](unction)?", new ReferenceFunctionBuilder() },
            { "^[P|p](olynom(ial)?)?", new PolynomialBuilder() },
            { "^[L|l](inear)?", new LinearBuilder() },
            { "[S|s]in$", new SinBuilder() },
            { "[C|c]os$", new CosBuilder() }
        };

        public override ICommand Build(string line)
        {
            try
            {
                line = line.Remove(0, 4); // "Add "
                var name = line.Substring(0, line.IndexOf(' '));
                var func = BuildFunction(line.Substring(line.IndexOf(' ') + 1));
                return new AddInStorage(name, func);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Function BuildFunction(string line)
        {
            try
            {
                var builder = _functionBuilders.FirstOrDefault(x => Regex.IsMatch(line, x.Key)).Value;
                return builder.Build(line.Substring(line.IndexOf(' ') + 1));
            }
            catch (Exception)
            {
                Console.Write("Не верный формат ввода функции");
                throw;
            }
        }
    }
}
