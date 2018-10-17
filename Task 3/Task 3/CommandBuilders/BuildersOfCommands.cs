
namespace Task_3.CommandBuilders
{
    using System.Collections.Generic;

    public abstract class BuildersOfCommands
    {
        public abstract Dictionary<string, CommandBuilder> GetBuilders();
    }
}
