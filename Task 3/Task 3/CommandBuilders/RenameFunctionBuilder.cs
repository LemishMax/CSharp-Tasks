namespace Task_3.CommandBuilders
{
    using Commands;

    internal class RenameFunctionBuilder : CommandBuilder
    {
        public override ICommand Build(string line)
        {
            var names = line.Split(' ');
            return new RenameFunction(names[1], names[2]);
        }
    }
}
