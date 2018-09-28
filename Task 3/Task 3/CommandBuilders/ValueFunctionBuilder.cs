using System;
using Task_3.Commands;

namespace Task_3.CommandBuilders
{
    internal class ValueFunctionBuilder : CommandBuilder
    {
        public override ICommand Build(string line)
        {
            var values = line.Split('(');
            return new ValueFunction(
                name: values[0],
                point: Convert.ToDouble(values[1].Remove(values[1].Length - 1)));
        }
    }
}
