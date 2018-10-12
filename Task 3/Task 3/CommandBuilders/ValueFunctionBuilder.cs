namespace Task_3.CommandBuilders
{
    using System;
    using Commands;

    internal class ValueFunctionBuilder : CommandBuilder
    {
        public override ICommand Build(string line)
        {
            var values = line.Split('(');
            return new ValueFunction(
                values[0],
                Convert.ToDouble(values[1].Remove(values[1].Length - 1)));
        }
    }
}
