using Task_3.Commands;

namespace Task_3.CommandBuilders
{
    internal class DeleteFromStorageBuilder : CommandBuilder
    {
        public override ICommand Build(string line) => new DeleteFromStorage(line.Substring(line.IndexOf(' ') + 1));
    }
}