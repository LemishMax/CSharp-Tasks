namespace Task_3.Commands
{
    using System.Collections.Generic;
    using CommandBuilders;

    public class BuildersOfCommandsForFunctionStorage
    {
        private readonly Dictionary<string, CommandBuilder> _builders = new Dictionary<string, CommandBuilder>
        {
            {
                "^[A|a]dd \\w+", new AddInStorageBuilder()
            },
            {
                "^[D|d]elete \\w+", new DeleteFromStorageBuilder()
            },
            {
                "^[R|r]ename \\w+ \\w+", new RenameFunctionBuilder()
            },
            {
                "^\\w+\\(-?[0-9]+(,[0-9]+)?\\)", new ValueFunctionBuilder()
            },
            {
                "^[D|d]erivative \\w+", new DerivativeOfTheFunctionBuilder()
            }
        };

        public Dictionary<string, CommandBuilder> GetBuilders() => _builders;
    }
}
