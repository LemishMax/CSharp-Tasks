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
        private readonly Dictionary<string, FunctionBuilder> _builders;

        public AddInStorageBuilder(Dictionary<string, FunctionBuilder> builders)
        {
            _builders = builders;
        }

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
                var builder = _builders.FirstOrDefault(x => Regex.IsMatch(line, x.Key)).Value;
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
