namespace Task_3.CommandBuilders
{
    using Commands;

    internal class DerivativeOfTheFunctionBuilder : CommandBuilder
    {
        public override ICommand Build(string line) => new DerivativeOfTheFunction(line.Substring(line.IndexOf(' ') + 1));
    }
}