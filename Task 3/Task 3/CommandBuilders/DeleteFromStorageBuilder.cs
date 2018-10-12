namespace Task_3.CommandBuilders
{
    using Commands;

    internal class DeleteFromStorageBuilder : CommandBuilder
    {
        public override ICommand Build(string line) => new DeleteFromStorage(line.Substring(line.IndexOf(' ') + 1));
    }
}