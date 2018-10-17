namespace Task_3.CommandBuilders
{
    using System.Collections.Generic;
    using FunctionBuilders;

    public class BuildersOfCommandsForFunctionStorage : BuildersOfCommands
    {
        private readonly Dictionary<string, FunctionBuilder> _buildersOfFunctions;

        public BuildersOfCommandsForFunctionStorage(Dictionary<string, FunctionBuilder> buildersOfFunctions)
        {
            _buildersOfFunctions = buildersOfFunctions;
        }

        public override Dictionary<string, CommandBuilder> GetBuilders() => new Dictionary<string, CommandBuilder>
            {
            {
                "^[A|a]dd \\w+", new AddInStorageBuilder(_buildersOfFunctions)
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
    }
}
