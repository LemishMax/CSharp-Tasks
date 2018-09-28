using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Task_3.Commands;
using Task_3.FunctionBuilders;
using Task_3.Functions;

namespace Task_3.CommandBuilders
{
    internal class AddInStorageBuilder : CommandBuilder
    {
        private readonly Dictionary<string, FunctionBuilder> _functions = new Dictionary<string, FunctionBuilder>
        {
            {"^[U|u](naryMinus)?", new UnaryMinusOfFunctionBuilder()},
            {"^[F|f](unction)?[C|c](omposition)?", new FunctionCompositionBuilder()},
            {"^[A|a](dditionOf)?[F|f](unction)?", new AdditionOfFunctionsBuilder()},
            {"^[S|s](ubstringOf)?[F|f](unction)?", new SubtractionOfFunctionsBuilder()},
            {"^[P|p](olynom(ial)?)?", new PolynomialBuilder()},
            {"^[L|l](inear)?", new LinearBuilder()},
            {"[S|s]in$", new SinBuilder()},
            {"[C|c]os$", new CosBuilder()}
        };

        public override ICommand Build(string line)
        {
            line = line.Remove(0, 4);//"Add "
            var name = line.Substring(0, line.IndexOf(' '));
            try
            {
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
                var builder = _functions.FirstOrDefault(x => Regex.IsMatch(line, x.Key)).Value;
                Console.WriteLine(builder);
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
