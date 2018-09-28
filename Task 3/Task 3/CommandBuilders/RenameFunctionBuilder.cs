using Task_3.Commands;

namespace Task_3.CommandBuilders
{
    internal class RenameFunctionBuilder:CommandBuilder
    {
        public override ICommand Build(string line)
        {
            var names = line.Split(' ');
            return new RenameFunction(oldName: names[1], newName: names[2]);
        }
    }
}
