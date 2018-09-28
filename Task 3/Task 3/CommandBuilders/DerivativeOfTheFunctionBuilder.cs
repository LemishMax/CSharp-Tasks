using Task_3.Commands;

namespace Task_3.CommandBuilders
{
    internal class DerivativeOfTheFunctionBuilder : CommandBuilder
    {
        public override ICommand Build(string line) => new DerivativeOfTheFunction(line.Substring(line.IndexOf(' ') + 1));
    }
}