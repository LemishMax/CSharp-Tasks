
namespace Task_3.CommandBuilders
{
    using System.Collections.Generic;
    using FunctionBuilders;

    public abstract class BuildersOfCommands
    {
        protected BuildersOfCommands()
        {
        }

        protected BuildersOfCommands(Dictionary<string, FunctionBuilder> buildersOfFunctions)
        {
        }

        public abstract Dictionary<string, CommandBuilder> GetBuilders();
    }
}
